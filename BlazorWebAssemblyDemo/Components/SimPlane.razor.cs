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
        private Knot KnotB;
        private Knot KnotC;
        private Knot KnotD;

        private Stick StickAB;
        private Stick StickBC;
        private Stick StickCD;
        private Stick StickDA;
        private Stick StickAC;
        private Stick StickBD;
        // Constructor
        protected override void OnInitialized()
        {
            KnotA = new Knot(70, 20);
            KnotB = new Knot(90, 100, 150, 20);
            KnotC = new Knot(150, 120, -80, 0);
            KnotD = new Knot(210, 40);

            /*
            StickAB = new Stick(KnotA, KnotB);
            StickBC = new Stick(KnotB, KnotC);
            StickCD = new Stick(KnotC, KnotD);
            StickDA = new Stick(KnotD, KnotA);
            StickAC = new Stick(KnotA, KnotC);
            StickBD = new Stick(KnotB, KnotD);
            */

            Globals.TargetFPS = 100;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Start main Simulation
        public async void Run()
        {
            if(!Globals.simRunning)
            {
                Globals.simRunning = true;
                Globals.DeltaTimerStart = DateTime.Now;
                while (Globals.simRunning)
                {
                    // Update DeltaTime Var with the interval from the last frame
                    Globals.UpdateDeltaTime();
                   
                    KnotA.Update();
                    KnotB.Update();
                    KnotC.Update();
                    KnotD.Update();

                    /*
                    StickAB.Update();
                    StickBC.Update();
                    StickCD.Update();
                    StickDA.Update();
                    StickAC.Update();
                    StickBD.Update();
                    */

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
