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
            PositionY = PositionY + (Globals.Gravity * (Globals.DeltaTime.Milliseconds / 1000d));
        }

        private void CheckRelevance()
        {
            // Todo: If object its out of range, should be deleted from the simulation
        }


        // Run this every Frame
        public void Update()
        {
            ApplyGravity();
            CheckRelevance();
        }
        // Return current position as a CSS string
        public string GetPositionCSS()
        {
            return "Left: " + PositionX + "px; Top: " + PositionY + "px;";
        }
    }
}
