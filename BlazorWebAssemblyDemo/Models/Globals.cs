using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyDemo.Models
{
    public static class Globals
    {
        // Simulation running toggler
        public static bool simRunning = false;
        // World Pixel Gravity (Annahme: 300px => 1m) -> (9.81m/ss => 2943px/ss)
        public static double Gravity = 2943;
        // Target FPS for the simulation
        public static int TargetFPS;
        // The interval from the last frame to the current one
        public static TimeSpan DeltaTime;
        // Internal Value for the DeltaTime Calculation
        public static DateTime DeltaTimerStart = new DateTime(0);

        public static void UpdateDeltaTime()
        {
            DeltaTime = DateTime.Now - DeltaTimerStart;
            DeltaTimerStart = DateTime.Now;
        }
    }
}
