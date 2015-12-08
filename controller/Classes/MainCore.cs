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
                //Console.WriteLine("[MainCore.cs - getHighestPriority] - Error no highest priority found");
                return default(Lane);
            }

            
            return currentLane;
        }

        /// <summary>
        /// call this to get a new state..
        /// </summary>
        /// <param name="lanes">all the lanes</param>
        /// <returns>the new state</returns>
        public List<Lane> getNewState()
        {
            //deze word gelijk aan de lanesState en hier worden eerst bewerkingen op uitgevoerd!
            List<Lane> temporaryLanes = new List<Lane>();            
            foreach (Lane lane in lanesState) {
                temporaryLanes.Add(lane);
            }

            // hier lanes aan toevoegen als deze gewijzigd worden
            // dit word dus ook de nieuwe state
            List<Lane> newState = new List<Lane>();
            // hier worden steeds alle crossinglanes aan toegevoegd!
            List<int> crossLanes = new List<int>();

            // deze gaan we gebruiken om te checken met de priority
            bool waitForThisOne = false;
            // hier checken we eerst op een highest priority
            // (als er geen voorkomt komt er ook geen nieuwe state)
            if (getHighestPriority(temporaryLanes) == null) {
                return default(List<Lane>);
            }
           // Console.WriteLine("0");
            List<Lane> temporaryLanesForAdding = new List<Lane>();
            // we gaan door elke lane! en checken of we deze lane mogen veranderen of
            // dat hij van oranje naar groen moet!
            foreach (Lane lane in temporaryLanes) {
                
                if (!lane.trafficLight.maybeEddited)
                {
                    //Console.WriteLine("dit moet groen zijn! of oranje! " + lane.trafficLight.getCurrentState());
                    // als de lane niet gewijzigd mag worden dan worden de crossinglanes toegevoegd!
                    foreach (int i in lane.crossingLanes) {
                        crossLanes.Add(i);
                    }
                    // deze lane mag niet meegenomen worden aangezien hij niet aangepast mag worden
                    // (heeft onvoldoende tijd gehad om op een bepaalte kleur te staan)
                    temporaryLanesForAdding.Add(lane);
                    // als hij niet gewijzigd mag worden en hij een priority van 2 of lager heeft
                    // dan gaan we wachten tot hij wel gewijzigd mag worden!
                    if (lane.getPriority() <= 2)
                        waitForThisOne = true;
                }

                // deze zetten we van oranje op rood
                if (lane.trafficLight.getCurrentState() == lightColor.yellow && lane.trafficLight.maybeEddited) {
                    lane.changeTrafficLight(lightColor.red);
                    newState.Add(lane);
                    //double check
                    temporaryLanesForAdding.Add(lane);
                }
            }
            //Console.WriteLine("1");

            foreach (Lane lane in temporaryLanesForAdding)
            {
                    temporaryLanes.Remove(lane);
            }

            

            //if (!waitForThisOne)//als er een priority is van 2 of lager dan gaan we geen nieuwe state geven.
            
               // Console.WriteLine("2");
                // zolang nog niet alle lanes nog niet gecheckt zijn moeten we doorgaan!
                while (temporaryLanes.Count > 0)
                {
                    bool startOver = false;
                    // verkrijg de hoogste priority
                    Lane highestPriority = getHighestPriority(temporaryLanes);

                    // als er geen highest priority meer is dan hoeven we niet meer te checken
                    // aangezien er dan geen meer stoplichten op groen moeten
                    // deze kunnen rood blijven omdat er verder nog geen autos daar zijn
                    if (highestPriority == null)
                        break;

                    foreach (int i in crossLanes) {
                        if (i == highestPriority.getLaneNumber()) {
                            // then we may not continue with this highestpriority
                            startOver = true;
                        }
                    }
                //Console.WriteLine("3");
                if (!startOver)
                {
                    bool weAddedAPriority = false;
                    //Console.WriteLine("4");
                    if (!waitForThisOne) {
                        // zet daarna de kleur van dit licht op groen!
                        if (highestPriority.trafficLight.getCurrentState() != lightColor.green &&
                            highestPriority.trafficLight.getCurrentState() != lightColor.right &&
                            highestPriority.trafficLight.getCurrentState() != lightColor.straightforwardRight &&
                            highestPriority.trafficLight.getCurrentState() != lightColor.straightforward)
                        {
                            //Console.WriteLine("we zetten dit licht op groen! " + highestPriority.getLaneNumber());
                            //highestPriority.trafficLight.setTrafficLight(lightColor.green);
                            highestPriority.changeTrafficLight(lightColor.green);
                            newState.Add(highestPriority);
                            weAddedAPriority = true;
                        }
                    }

                    Console.WriteLine("1: " + temporaryLanes.Count);
                    // haal daarna de highest priority uit de checklijst
                    temporaryLanes.Remove(highestPriority);
                    // en voeg deze toe aan de nieuwe state!
                    Console.WriteLine("2: " + temporaryLanes.Count);

                    if (weAddedAPriority) { 
                    // update de crossinglanes ( zodat er niet meer gecrossed kan worden )
                        foreach (int i in highestPriority.crossingLanes)
                        {
                                crossLanes.Add(i);

                        }
                    }


                        // temporary list aangezien ik deze moet gebruiken om door te loopen
                        List<Lane> tempLanes = new List<Lane>();

                        foreach (Lane lane in temporaryLanes)
                        {
                            foreach (int crosslane in crossLanes)
                            {
                                if (crosslane == lane.getLaneNumber())
                                {
                                    // nu moet een stoplicht op rood worden gezet ( we kijken hier nog even)
                                    // als ie niet al op rood staat :D 
                                    if (lane.trafficLight.getCurrentState() != lightColor.yellow &&
                                        lane.trafficLight.getCurrentState() != lightColor.red)
                                    {
                                        //lane.trafficLight.setTrafficLight(lightColor.red);
                                        lane.changeTrafficLight(lightColor.yellow);
                                        tempLanes.Add(lane);
                                        newState.Add(lane);
                                    }

                                    break;
                                }
                            }
                        }
                        foreach (Lane lane in tempLanes)
                        {
                            temporaryLanes.Remove(lane);
                        }
                    }
                    else {
                        // i hope this breaks out of the if loop :)
                        break;
                    }

                }
            
            
            // nu hebben we de nieuwe state en gaan we de toekomstige nieuwe lijst updaten
            // zodat deze de nieuwe data bevat!
            for (int i = 0; i < lanesState.Count; i++) {
                foreach (Lane laneGewijzigd in newState) {
                    if (lanesState[i].getLaneNumber() == laneGewijzigd.getLaneNumber()) {
                        lanesState[i] = laneGewijzigd;
                    }
                }
            }

            // en nu versturen wij de nieuwe state!
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
