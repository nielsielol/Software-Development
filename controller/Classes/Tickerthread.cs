using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace controller.Classes
{
    class Tickerthread
    {
        public MainCore mainCore;
        JSONConverter server;

        public Tickerthread(JSONConverter server) {
            mainCore = new MainCore();
            this.server = server;
            mainCore.initializeLanes();
        }

        public void Run() {
            while (true) {// we are going to look every second if we need to change the 
                Thread.Sleep(1000 /*1000ms*/);
                mainCore.mainTicker();
                /* List<Lane> newMainCoreState = new List<Lane>();
                 foreach (Lane lane in mainCore.lanesState) {
                     newMainCoreState.Add(lane);
                 }*/


                 List<Lane> stateToBeSended = mainCore.getNewState(mainCore.lanesState);
                /*

                 foreach (Lane lane in mainCore.lanesState) {
                     newMainCoreState.Add(lane);
                 }
                 */

                Console.WriteLine("we are here!");
                if (stateToBeSended != null)
                {
                    Console.WriteLine("satetobesended is niet null" + stateToBeSended.Count);
                    if (stateToBeSended.Count > 0)
                    {
                        Console.WriteLine("Nu zenden we alleen de dingen die veranderd zijn!");
                        foreach (Lane lane in stateToBeSended) {
                            Console.WriteLine("id gewijzigd: " + lane.getLaneNumber());
                        }
                        server.sendMessage(stateToBeSended);
                    }
                }
                else {
                    Console.WriteLine("we havent got a state yet!");
                }

            }
        }
    }
}
