using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controller.Classes
{
    class MainCore
    {
        public List<Lane> lanesState = new List<Lane>();

        public void initializeLanes()
        {
            /*lanesState.Add(new Lane(0, new List<int> { 4, 8, 13 }, "Normallane (sidelane)"));
            lanesState.Add(new Lane(1, new List<int> { 5, 6, 9, 10, 11, 12, 13, 16 }, "Normallane direction = left", 5));
            lanesState.Add(new Lane(2, new List<int> { 5, 6, 7, 8, 12, 13 }, "doublelane direction = straigt"));
            lanesState.Add(new Lane(3, new List<int> { 5, 6, 7, 7, 12, 13 }, "doublelane direction = straigt"));
            lanesState.Add(new Lane(4, new List<int> { 0, 8, 13, 15 }, "Normalelane direction = right"));
            lanesState.Add(new Lane(5, new List<int> { 1, 2, 3, 8, 9, 10, 13, 14, 16 }, "Normalelane direction = left"));
            lanesState.Add(new Lane(6, new List<int> { 1, 2, 3, 15, 8, 9, 10, 16, 12 }, "Normalelane direction = straight"));
            lanesState.Add(new Lane(7, new List<int> { 2, 3, 12, 15 }, "Normalelane direction = right"));
            lanesState.Add(new Lane(8, new List<int> { 2, 3, 4, 15, 5, 6, 12, 13 }, "Normalelane direction = left"));
            lanesState.Add(new Lane(9, new List<int> { 1, 5, 6, 16, 12, 13, 14 }, "doublelane direction = straight"));
            lanesState.Add(new Lane(10, new List<int> { 1, 5, 6, 16, 12, 13, 14 }, "doublelane direction = straight"));
            lanesState.Add(new Lane(11, new List<int> { 1, 6, 16 }, "normallane direction = right", 8));
            lanesState.Add(new Lane(12, new List<int> { 1, 2, 3, 6, 7, 8, 9, 10, 15 }, "normallane direction = left"));
            lanesState.Add(new Lane(13, new List<int> { 0, 1, 2, 3, 4, 5, 8, 9, 10, 15, 16 }, "normallane direction = straight"));
            lanesState.Add(new Lane(14, new List<int> { 5, 9, 10, 16 }, "normallane direction = right"));
            lanesState.Add(new Lane(15, new List<int> { 4, 5, 6, 7, 8, 12, 13 }, "buslane next to crystelik"));
            lanesState.Add(new Lane(16, new List<int> { 1, 5, 6, 9, 10, 11, 12, 13, 14 }, "buslane across crystelik"));
            *///Lane lane17 = new Lane(17, new List<int> { 1,6,11}, "buslane 16 but direction = right");

            lanesState.Add(new Lane(0, new List<int> { 4, 8, 13 }, "Normallane (sidelane)"));
            lanesState.Add(new Lane(1, new List<int> { 5, 6, 9, 10, 11, 12, 13, 16,17,25,26 }, "Normallane direction = left"));
            lanesState.Add(new Lane(2, new List<int> { 5, 6, 7, 8, 12, 13,17,25,26,21,22,31,32 }, "doublelane direction = straigt"));
            lanesState.Add(new Lane(3, new List<int> { 5, 6, 7, 7, 12, 13, 17, 25, 26, 21, 22, 31, 32 }, "doublelane direction = straigt"));
            lanesState.Add(new Lane(4, new List<int> { 0, 8, 13, 15,17,25,26,27,28,19,20 }, "Normalelane direction = right"));
            lanesState.Add(new Lane(5, new List<int> { 1, 2, 3, 8, 9, 10, 13, 14, 16 ,19,20,17,29,30,23,24}, "Normalelane direction = left"));
            lanesState.Add(new Lane(6, new List<int> { 1, 2, 3, 15, 8, 9, 10, 16, 12,19,20,29,30 }, "Normalelane direction = straight"));
            lanesState.Add(new Lane(7, new List<int> { 2, 3, 12, 15,19,20,21,22,29,30,31,32 }, "Normalelane direction = right"));
            lanesState.Add(new Lane(8, new List<int> { 2, 3, 4, 15, 5, 6, 12, 13,21,22,19,20,33,34,27,28 }, "Normalelane direction = left"));
            lanesState.Add(new Lane(9, new List<int> { 1, 5, 6, 16, 12, 13, 14,21,22,17,33,34,23,24 }, "doublelane direction = straight"));
            lanesState.Add(new Lane(10, new List<int> { 1, 5, 6, 16, 12, 13, 14,21,22,17,33,34,23,24 }, "doublelane direction = straight"));
            lanesState.Add(new Lane(11, new List<int> { 1, 6, 16,21,22,33,34 }, "normallane direction = right"));
            lanesState.Add(new Lane(12, new List<int> { 1, 2, 3, 6, 7, 8, 9, 10, 15,21,22,31,32 }, "normallane direction = left"));
            lanesState.Add(new Lane(13, new List<int> { 0, 1, 2, 3, 4, 5, 8, 9, 10, 15, 16 ,19,20,27,28}, "normallane direction = straight"));
            lanesState.Add(new Lane(14, new List<int> { 5, 9, 10, 16,17,23,24 }, "normallane direction = right"));
            lanesState.Add(new Lane(15, new List<int> { 4, 5, 6, 7, 8, 12, 13,19,20,21,22,27,28,31,32 }, "buslane next to crystelik",4));
            lanesState.Add(new Lane(16, new List<int> { 1, 5, 6, 9, 10, 11, 12, 13, 14,21,22,17,33,34 }, "buslane across crystelik",4));

            lanesState.Add(new Lane(17, new List<int> {1,2,3,4,14,9,10,5 }, "fietsers"));
            lanesState.Add(new Lane(19, new List<int> {5,6,7,4,8,13,15 }, "fietsers"));
            lanesState.Add(new Lane(20, new List<int> { 5, 6, 7, 4, 8, 13, 15 }, "fietsers"));
            lanesState.Add(new Lane(21, new List<int> { 8, 9, 10, 11, 7, 2, 3, 12 }, "fietsers"));
            lanesState.Add(new Lane(22, new List<int> { 8, 9, 10, 11, 7, 2, 3, 12 }, "fietsers"));

            lanesState.Add(new Lane(23, new List<int> {14,9,10,5,16 }, "voetgangers"));
            lanesState.Add(new Lane(24, new List<int> { 14, 9, 10, 5, 16 }, "voetgangers"));
            lanesState.Add(new Lane(25, new List<int> {1,2,3,4,15 }, "voetgangers"));
            lanesState.Add(new Lane(26, new List<int> { 1, 2, 3, 4, 15 }, "voetgangers"));
            lanesState.Add(new Lane(27, new List<int> {4,15,8,13 }, "voetgangers"));
            lanesState.Add(new Lane(28, new List<int> { 4, 15, 8, 13 }, "voetgangers"));
            lanesState.Add(new Lane(29, new List<int> {5,6,7 }, "voetgangers"));
            lanesState.Add(new Lane(30, new List<int> { 5, 6, 7 }, "voetgangers"));
            lanesState.Add(new Lane(31, new List<int> {7,2,3,15,12 }, "voetgangers"));
            lanesState.Add(new Lane(32, new List<int> { 7, 2, 3, 15, 12 }, "voetgangers"));
            lanesState.Add(new Lane(33, new List<int> {8,9,10,11,16 }, "voetgangers"));
            lanesState.Add(new Lane(34, new List<int> { 8, 9, 10, 11, 16 }, "voetgangers"));
            //this is a test ^^
            Console.WriteLine("We are setting some vehicels");
            lanesState[1].setVehicleWaiting(true);
            lanesState[11].setVehicleWaiting(true);
            lanesState[7].setVehicleWaiting(true);
            //Console.WriteLine(lanesState[2].laneNumber + ":" + lanesState[2].trafficLight.getCurrentState());
        }

        /// <summary>
        /// just run this with the up to date list of lanes and it will return the lane with the hightest priority
        /// this should be called after the first cars arrived
        /// </summary>
        /// <param name="lanes">list of the up to date lanes</param>
        /// <returns>the lane with the highest priority</returns>
        private Lane getHighestPriority(List<Lane> lanes)
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
                return default(Lane);
            }

            return currentLane;
        }

        /// <summary>
        /// call this to get a new state..
        /// </summary>
        /// <param name="lanes">all the lanes</param>
        /// <returns>the new state</returns>
        public List<Lane> getNewState(List<Lane> lanes)
        {
            List<int> indexNummerGewijzigd = new List<int>();
            
            List<Lane> newState = new List<Lane>();
            List<int> crossLanes = new List<int>();
            if (getHighestPriority(lanes) == null) {
                return default(List<Lane>);
            }

            foreach (Lane lane in lanes) {
                if (!lane.trafficLight.maybeEddited)
                {//als de lane niet gewijzigd mag worden dan worden de crossinglanes toegevoegd!
                    Console.WriteLine("de lane mag niet gewijzigd worden! kan dus groen zijn of oranje" +
                        ". met de bijbehorende state: " + lane.trafficLight.getCurrentState());
                    foreach (int i in lane.crossingLanes) {
                        crossLanes.Add(i);
                    }
                    newState.Add(lane);
                }

                if (lane.trafficLight.getCurrentState() == lightColor.yellow && lane.trafficLight.maybeEddited) {//deze zetten we op rood
                    lane.changeTrafficLight(lightColor.red);
                }
            }

            if (getHighestPriority(lanes).getPriority() >= 2)//als er een priority is van 2 of lager dan gaan we geen nieuwe state geven.
            {

                while (lanes.Count > 0)
                {
                    Lane highestPriority = getHighestPriority(lanes);
                    if (highestPriority == null)
                        break;//get out of the while loop becouse we don't have a lane to check anymore

                    highestPriority.trafficLight.setTrafficLight(lightColor.green);
                    Console.WriteLine(highestPriority.trafficLight.getCurrentState());
                    lanes.Remove(highestPriority);
                    Console.WriteLine(highestPriority.trafficLight.getCurrentState());
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
                    Console.WriteLine("adding a lane" + highestPriority.getLaneNumber() + "state:" + highestPriority.trafficLight.getCurrentState());
                    newState.Add(highestPriority);

                }
            }

            foreach (Lane lane in lanes) {
                Console.WriteLine("lanes: " + lane.getLaneNumber() + " " + lane.trafficLight.getCurrentState());
            }
            foreach (Lane lane in newState)
            {
                Console.WriteLine("newState: " + lane.getLaneNumber() + " " + lane.trafficLight.getCurrentState());
            }

            return newState;
        }

        /// <summary>
        /// this will be called every second! before you try to get a new state!
        /// </summary>
        public void mainTicker() {
            foreach (Lane lane in lanesState) {
                lane.laneTicker();
            }
        }
    }
}
