using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyDemo.Models
{
    public class Knot
    {
        private double PositionX { get; set; }
        private double PositionY { get; set; }

        private double VelocityX { get; set; } = 0;
        private double VelocityY { get; set; } = 0;

        public Guid ID { get; }

        public Knot(double x, double y)
        {
            ID = new Guid();
            PositionX = x;
            PositionY = y;
        }

        // Apply gravity as a constant velocity
        // TODO: Apply as a force
        private void ApplyGravity()
        {
            var DeltaTimeFactor = (Globals.DeltaTime.Milliseconds / 1000d);
            // Update new current Y velocity
            VelocityY = VelocityY + (Globals.Gravity * DeltaTimeFactor);
            // Calculate new Y position from current velocity + gravity
            PositionY = PositionY + (VelocityY * DeltaTimeFactor);
            Console.WriteLine(VelocityY);
        }


        // Run this every Frame
        public void Update()
        {
            ApplyGravity();
        }
        // Return current position as a CSS string
        public string GetPositionCSS()
        {
            return "Left: " + PositionX + "px; Top: " + PositionY + "px;";
        }
    }
}
