﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using controller.Classes;
using System.Threading;

namespace controller
{
    class Program
    {
        static void Main(string[] args)
        {
            normal();
        }

        public static void testJSON() {
            /*Console.WriteLine("We are running a test (JSON)");
            JSONConverter json = new JSONConverter(server);

            Server server = new Server(json);
            Thread newThread = new Thread(new ThreadStart(server.createListener));
            newThread.Start(); //here we start the server
            

            json.getMessage("{busbanen:[{\"id\":1,\"eerstvolgendelijn\":70,\"bezet\":true},{\"id\":2,\"eerstvolgendelijn\":170,\"bezet\":false}]}");
            */
        }

        public static void test() {
           /* Console.WriteLine("We are running a test (Connection test)");

            Server server = new Server();
            Thread newThread = new Thread(new ThreadStart(server.createListener));
            newThread.Start(); //here we start the server
            JSONConverter json = new JSONConverter(server);
            Console.WriteLine("the server is created! press enter to send a message (already the json)");
            while (true)
            {
                Console.ReadLine();
                List<Lane> lanes = new List<Lane>();
                lanes.Add(new Lane(0, new List<int> { 4, 8, 13 }, "Normallane (sidelane)"));
                lanes.Add(new Lane(1, new List<int> { 5, 6, 9, 10, 11, 12, 13, 16 }, "Normallane direction = left", 5));
                lanes.Add(new Lane(2, new List<int> { 5, 6, 7, 8, 12, 13 }, "doublelane direction = straigt"));
                lanes.Add(new Lane(3, new List<int> { 5, 6, 7, 7, 12, 13 }, "doublelane direction = straigt"));
                lanes.Add(new Lane(4, new List<int> { 0, 8, 13, 15 }, "Normalelane direction = right"));
                lanes.Add(new Lane(5, new List<int> { 1, 2, 3, 8, 9, 10, 13, 14, 16 }, "Normalelane direction = left"));
                lanes.Add(new Lane(6, new List<int> { 1, 2, 3, 15, 8, 9, 10, 16, 12 }, "Normalelane direction = straight"));
                lanes.Add(new Lane(7, new List<int> { 2, 3, 12, 15 }, "Normalelane direction = right"));

                
                Console.WriteLine("we are sending a message from program.cs!");
                json.sendMessage(lanes);
            }*/

        }

        public static void normal() {
            Console.WriteLine("we are running the normal program");
            JSONConverter json = new JSONConverter();


            Server server = new Server(json);

            Thread newThread = new Thread(new ThreadStart(server.createListener));
            Console.WriteLine("we are creating the server(communication)");
            newThread.Start();
            
            

            Tickerthread ticker = new Tickerthread(json, server);
            json.setServerTicker(server, ticker);
            Thread secondThread = new Thread(ticker.Run);
            Console.WriteLine("we are starting the second thread! so the program is running now (cpu )");
            secondThread.Start();


            Console.ReadLine();
        }

        /*public static void initializeLanes() {
            
            lanes.Add(new Lane(0, new List<int> { 4, 8, 13 }, "Normallane (sidelane)"));
            lanes.Add(new Lane(1, new List<int> { 5, 6, 9, 10, 11, 12, 13, 16 }, "Normallane direction = left",5));
            lanes.Add(new Lane(2, new List<int> { 5, 6, 7, 8, 12, 13}, "doublelane direction = straigt"));
            lanes.Add(new Lane(3, new List<int> { 5, 6, 7, 7, 12, 13}, "doublelane direction = straigt"));
            lanes.Add(new Lane(4, new List<int> { 0, 8, 13, 15}, "Normalelane direction = right"));
            lanes.Add(new Lane(5, new List<int> { 1, 2, 3, 8, 9, 10, 13, 14, 16 }, "Normalelane direction = left"));
            lanes.Add(new Lane(6, new List<int> { 1, 2, 3, 15, 8, 9, 10, 16, 12 }, "Normalelane direction = straight"));
            lanes.Add(new Lane(7, new List<int> { 2, 3, 12, 15 }, "Normalelane direction = right"));
            lanes.Add(new Lane(8, new List<int> { 2,3,4,15,5,6,12,13 }, "Normalelane direction = left"));
            lanes.Add(new Lane(9, new List<int> { 1, 5, 6, 16, 12, 13, 14 }, "doublelane direction = straight"));
            lanes.Add(new Lane(10, new List<int> { 1, 5, 6, 16, 12, 13, 14 }, "doublelane direction = straight"));
            lanes.Add(new Lane(11, new List<int> { 1,6,16 }, "normallane direction = right",8));
            lanes.Add(new Lane(12, new List<int> { 1,2,3,6,7,8,9,10,15 }, "normallane direction = left"));
            lanes.Add(new Lane(13, new List<int> { 0,1,2,3,4,5,8,9,10,15,16 }, "normallane direction = straight"));
            lanes.Add(new Lane(14, new List<int> { 5,9,10,16 }, "normallane direction = right"));
            lanes.Add(new Lane(15, new List<int> { 4,5,6,7,8,12,13 }, "buslane next to crystelik"));
            lanes.Add(new Lane(16, new List<int> { 1,5,6,9,10,11,12,13,14 }, "buslane across crystelik"));
            //Lane lane17 = new Lane(17, new List<int> { 1,6,11}, "buslane 16 but direction = right");

            lanes[1].setVehicleWaiting(true);
            lanes[11].setVehicleWaiting(true);
            lanes[7].setVehicleWaiting(true);
            Console.WriteLine(lanes[2].laneNumber + ":" + lanes[2].trafficLight.currentState);
        }*/

        

        
    }
}
