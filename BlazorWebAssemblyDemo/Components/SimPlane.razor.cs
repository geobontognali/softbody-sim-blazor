using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BlazorWebAssemblyDemo.Models;

namespace BlazorWebAssemblyDemo.Components
{
    public partial class SimPlane
    {
        private Knot KnotA;

        // Constructor
        protected override void OnInitialized()
        {
            KnotA = new Knot(20, 20);
            Globals.TargetFPS = 60;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Start main Sim
        public async void Run()
        {
            if(!Globals.simRunning)
            {
                Globals.simRunning = true;
                Globals.DeltaTimerStart = new DateTime(0);
                while (Globals.simRunning)
                {
                    // Update DeltaTime Var with the interval from the last frame
                    Globals.UpdateDeltaTime();
                    Console.WriteLine("Last Frame dured: " + Globals.DeltaTime.Milliseconds);

                    KnotA.Update();

                    await InvokeAsync(StateHasChanged); // Update DOM
                    await Task.Delay(1000 / Globals.TargetFPS); // Wait to match target FPS
                }
            }       
        }

        // Stop main Sim
        public void Stop()
        {
            Globals.simRunning = false;
        }
    }
}
