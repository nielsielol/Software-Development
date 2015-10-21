using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controller.Classes
{
    class MainCore
    {
        public static List<Lane> lanes = new List<Lane>();

        public static void initializeLanes()
        {
            lanes.Add(new Lane(0, new List<int> { 4, 8, 13 }, "Normallane (sidelane)"));
            lanes.Add(new Lane(1, new List<int> { 5, 6, 9, 10, 11, 12, 13, 16 }, "Normallane direction = left", 5));
            lanes.Add(new Lane(2, new List<int> { 5, 6, 7, 8, 12, 13 }, "doublelane direction = straigt"));
            lanes.Add(new Lane(3, new List<int> { 5, 6, 7, 7, 12, 13 }, "doublelane direction = straigt"));
            lanes.Add(new Lane(4, new List<int> { 0, 8, 13, 15 }, "Normalelane direction = right"));
            lanes.Add(new Lane(5, new List<int> { 1, 2, 3, 8, 9, 10, 13, 14, 16 }, "Normalelane direction = left"));
            lanes.Add(new Lane(6, new List<int> { 1, 2, 3, 15, 8, 9, 10, 16, 12 }, "Normalelane direction = straight"));
            lanes.Add(new Lane(7, new List<int> { 2, 3, 12, 15 }, "Normalelane direction = right"));
            lanes.Add(new Lane(8, new List<int> { 2, 3, 4, 15, 5, 6, 12, 13 }, "Normalelane direction = left"));
            lanes.Add(new Lane(9, new List<int> { 1, 5, 6, 16, 12, 13, 14 }, "doublelane direction = straight"));
            lanes.Add(new Lane(10, new List<int> { 1, 5, 6, 16, 12, 13, 14 }, "doublelane direction = straight"));
            lanes.Add(new Lane(11, new List<int> { 1, 6, 16 }, "normallane direction = right", 8));
            lanes.Add(new Lane(12, new List<int> { 1, 2, 3, 6, 7, 8, 9, 10, 15 }, "normallane direction = left"));
            lanes.Add(new Lane(13, new List<int> { 0, 1, 2, 3, 4, 5, 8, 9, 10, 15, 16 }, "normallane direction = straight"));
            lanes.Add(new Lane(14, new List<int> { 5, 9, 10, 16 }, "normallane direction = right"));
            lanes.Add(new Lane(15, new List<int> { 4, 5, 6, 7, 8, 12, 13 }, "buslane next to crystelik"));
            lanes.Add(new Lane(16, new List<int> { 1, 5, 6, 9, 10, 11, 12, 13, 14 }, "buslane across crystelik"));
            //Lane lane17 = new Lane(17, new List<int> { 1,6,11}, "buslane 16 but direction = right");

            lanes[1].setVehicleWaiting(true);
            lanes[11].setVehicleWaiting(true);
            lanes[7].setVehicleWaiting(true);
            Console.WriteLine(lanes[2].laneNumber + ":" + lanes[2].trafficLight.getCurrentState());
        }

        /// <summary>
        /// just run this with the up to date list of lanes and it will return the lane with the hightest priority
        /// this should be called after the first cars arrived
        /// </summary>
        /// <param name="lanes">list of the up to date lanes</param>
        /// <returns>the lane with the highest priority</returns>
        private static Lane getHighestPriority(List<Lane> lanes)
        {
            int higestPriority = 11;
            Lane currentLane = new Lane(0, null, "");

            foreach (Lane lane in lanes)
            {
                if (lane.getPriority() < higestPriority && lane.getPriority() != 0)
                {
                    higestPriority = lane.getPriority();
                    currentLane = lane;
                }
            }


            if (higestPriority == 11) // 11 refers to this highest priority :)
            {
                Console.WriteLine("[program.cs - getHighestPriority] - Error no highest priority found");
                //throw new Exception("error no highest priority found");
                return default(Lane);
            }

            return currentLane;
        }

        /// <summary>
        /// call this to get a new state..
        /// </summary>
        /// <param name="lanes">all the lanes</param>
        /// <returns>the new state</returns>
        public static List<Lane> getNewState(List<Lane> lanes)
        {
            List<Lane> newState = new List<Lane>();
            List<int> crossLanes = new List<int>();


            /* add a piece that will find out when lanes need to stay green 
            


            */
            while (lanes.Count > 0)
            {
                Lane highestPriority = getHighestPriority(lanes);
                if (highestPriority == null)
                    break;//get out of the while loop becouse we don't have a lane to check anymore

                highestPriority.trafficLight.setTrafficLight(lightColor.green);
                lanes.Remove(highestPriority);

                //crossLanes = highestPriority.crossingLanes;
                foreach (int i in highestPriority.crossingLanes)
                {
                    crossLanes.Add(i);
                }

                List<Lane> tempLanes = new List<Lane>();

                foreach (Lane lane in lanes)
                {

                    foreach (int crosslane in crossLanes)
                    {
                        if (crosslane == lane.getLaneNumber())
                        {
                            lane.trafficLight.setTrafficLight(lightColor.red);
                            tempLanes.Add(lane);
                            newState.Add(lane);
                            break;
                        }
                    }
                }
                foreach (Lane lane in tempLanes)
                {
                    lanes.Remove(lane);
                }

                newState.Add(highestPriority);

            }

            return newState;
        }

        /// <summary>
        /// this will be called every second!
        /// </summary>
        public void mainTicker() {
            foreach (Lane lane in lanes) {
                if (lane.laneTicker()) {
                    //probably the yellow light to red!
                }
            }
        }
    }
}
