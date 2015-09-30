using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using controller.Classes;

namespace controller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("we are working :D");
            initializeLanes();
            
            Console.ReadLine();
        }

        public static void initializeLanes() {
            Lane lane0 = new Lane(0, new List<int> { 4, 8, 13 }, "Normallane (sidelane)");
            Lane lane1 = new Lane(1, new List<int> { 5, 6, 9, 10, 11, 12, 13, 16 }, "Normallane direction = left");
            Lane lane2 = new Lane(2, new List<int> { 5, 6, 7, 8, 12, 13}, "doublelane direction = straigt");
            Lane lane3 = new Lane(3, new List<int> { 5, 6, 7, 7, 12, 13}, "doublelane direction = straigt");
            Lane lane4 = new Lane(4, new List<int> { 0, 8, 13, 15}, "Normalelane direction = right");
            Lane lane5 = new Lane(5, new List<int> { 1, 2, 3, 8, 9, 10, 13, 14, 16 }, "Normalelane direction = left");
            Lane lane6 = new Lane(6, new List<int> { 1, 2, 3, 15, 8, 9, 10, 16, 12 }, "Normalelane direction = straight");
            Lane lane7 = new Lane(7, new List<int> { 2, 3, 12, 15 }, "Normalelane direction = right");
            Lane lane8 = new Lane(8, new List<int> { 2,3,4,15,5,6,12,13 }, "Normalelane direction = left");
            Lane lane9 = new Lane(9, new List<int> { 1, 5, 6, 16, 12, 13, 14 }, "doublelane direction = straight");
            Lane lane10 = new Lane(10, new List<int> { 1, 5, 6, 16, 12, 13, 14 }, "doublelane direction = straight");
            Lane lane11 = new Lane(11, new List<int> { 1,6,16 }, "normallane direction = right");
            Lane lane12 = new Lane(12, new List<int> { 1,2,3,6,7,8,9,10,15 }, "normallane direction = left");
            Lane lane13 = new Lane(13, new List<int> { 0,1,2,3,4,5,8,9,10,15,16 }, "normallane direction = straight");
            Lane lane14 = new Lane(14, new List<int> { 5,9,10,16 }, "normallane direction = right");
            Lane lane15 = new Lane(15, new List<int> { 4,5,6,7,8,12,13 }, "buslane next to crystelik");
            Lane lane16 = new Lane(16, new List<int> { 1,5,6,9,10,11,12,13,14 }, "buslane across crystelik");
            //Lane lane17 = new Lane(17, new List<int> { 1,6,11}, "buslane 16 but direction = right");

            Console.WriteLine(lane3.laneNumber + ":" + lane3.trafficLight.currentState);


        }
    }
}
