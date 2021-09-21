using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyDemo.Models
{
    public class Knot
    {
        public double PositionX { get; set; }
        public double OldPositionX { get; set; } // For verlet integration
        public double PositionY { get; set; }
        public double OldPositionY { get; set; } // For verlet integration
        public bool IsKinematic { get; }
        private double VelocityX { get; set; } = 0;
        private double VelocityY { get; set; } = 0;
        private double DeltaTimeFactor;

        public Guid ID { get; }

        public Knot(double x, double y)
        {
            ID = new Guid();
            PositionX = x;
            OldPositionX = x;
            PositionY = y;
            OldPositionY = y;
            IsKinematic = true;
        }
        public Knot(double x, double y, bool kinematic)
        {
            ID = new Guid();
            PositionX = x;
            OldPositionX = x;
            PositionY = y;
            OldPositionY = y;
            IsKinematic = kinematic;
        }

        public Knot(double x, double y, double VX, double VY)
        {
            ID = new Guid();
            PositionX = x;
            OldPositionX = x;
            PositionY = y;
            OldPositionY = y;
            VelocityX = VX;
            VelocityY = VY;
            IsKinematic = true;
        }

        // Apply gravity as a constant velocity
        // TODO: Apply as a force
        private void AddGravity()
        {
            // Update new current Y velocity
            VelocityY = VelocityY + (Globals.Gravity * DeltaTimeFactor);
        }

        // Bounce back when you hit a border
        private void BounceBack()
        {
            if(PositionX >= 990 & VelocityX > 0) // 1000 is sim-plane width
            {
                VelocityX = -VelocityX * 0.85;
            }
            else if(PositionX <= 10 & VelocityX < 0)
            {
                VelocityX = -VelocityX * 0.85;
            }
            if(PositionY >= 590 & VelocityY > 0) // 600 is sim-plane height
            {
                VelocityY = -VelocityY * 0.85;
            }
        }

        private void ApplyVelocity()
        {
            // Calculate new position from current velocity
            OldPositionX = PositionX;
            OldPositionY = PositionY;
            PositionX = PositionX + (VelocityX * DeltaTimeFactor);
            PositionY = PositionY + (VelocityY * DeltaTimeFactor);
        }

        // Run this every Frame
        public void Update()
        {
            DeltaTimeFactor = (Globals.DeltaTime.Milliseconds / 1000d);
            if(IsKinematic)
            {
                AddGravity();
                BounceBack();
                ApplyVelocity();
            }
            else
            {
                PositionX = OldPositionX;
                PositionY = OldPositionY;
            }
        }

        // Return current position as a CSS string
        public string GetPositionCSS()
        {
            return "Left: " + PositionX + "px; Top: " + PositionY + "px;";
        }
    }
}
