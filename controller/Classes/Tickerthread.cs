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
        Server socket;

        public Tickerthread(JSONConverter server, Server socket) {
            mainCore = new MainCore();
            this.server = server;
            this.socket = socket;
            mainCore.initializeLanes();
        }

        public void Run() {
            while (true) {// we are going to look every second if we need to change the 
                Thread.Sleep(1000 /*1000ms*/);
               // Console.WriteLine("[tickerthread.cs] - reached!");
                if (socket.Connection)
                {
                    //ticker all the lanes so if they need to be tickered they will if not they won't.
                    mainCore.mainTicker();
                    //Console.WriteLine("[tickerthread.cs] - inside socket connection! runned the tickers!");
                    //get a new state!
                    List<Lane> stateToBeSended = mainCore.getNewState();
                    //Console.WriteLine("[tickerthread.cs] - after getting a new state! before the ifs");
                    if (stateToBeSended != null)
                    {
                        if (stateToBeSended.Count > 0)
                        {
                            //Console.WriteLine("[Tickerthread.cs] - run: Nu zenden we alleen de dingen die veranderd zijn!");
                            foreach (Lane lane in stateToBeSended)
                            {
                                Console.WriteLine("deze lane wordt zometeen verstuurd: " + lane.getLaneNumber() + " state: " + lane.trafficLight.getCurrentState());
                            }
                            server.sendMessage(stateToBeSended);
                        }
                    }
                }
            }
        }
    }
}
