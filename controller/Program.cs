using System;
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
            Console.WriteLine("we are working :D");
            /*initializeLanes();
            lanes = getNewState(lanes);
            foreach (Lane lane in lanes) {
                Console.WriteLine("state:" + lane.trafficLight.currentState.ToString() +" lane: " + lane.getLaneNumber());
            }*/
            

            Server server = new Server();

            Thread newThread = new Thread(new ThreadStart(server.createListener));
            //we are gonna listen for a 
            newThread.Start();
            

            Console.WriteLine("the server is created! press enter to send a message (already the json)");
            Console.ReadLine();
            JSONConverter json = new JSONConverter(server);
            json.sendMessage(lanes);
            

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
