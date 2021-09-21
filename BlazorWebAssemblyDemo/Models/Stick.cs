using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyDemo.Models
{
    public class Stick
    {
        public Knot KnotAlpha;
        public Knot KnotBeta;
        public double Length;


        public Stick(Knot A, Knot B)
        {
            KnotAlpha = A;
            KnotBeta = B;
            Length = GetDistance();
        }

        private double GetDistance()
        {
            var distance = Math.Pow((KnotBeta.PositionX - KnotAlpha.PositionX), 2) + Math.Pow((KnotBeta.PositionY - KnotAlpha.PositionY), 2);
            return Math.Sqrt(distance);
        }
        // Called every frame
        public void Update()
        {
            var currentDistance = GetDistance();
            var distanceOffset = Length - currentDistance;
            var offsetPercent = distanceOffset / currentDistance / 2;
            var offsetX = (KnotBeta.PositionX - KnotAlpha.PositionX) * offsetPercent;
            var offsetY = (KnotBeta.PositionY - KnotAlpha.PositionY) * offsetPercent;
            KnotAlpha.PositionX -= offsetX;
            KnotAlpha.PositionY -= offsetY;
            KnotBeta.PositionX += offsetX;
            KnotBeta.PositionY += offsetY;
        }
    }
}
