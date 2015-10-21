using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controller.Classes
{
    class Lane
    {
        public readonly int laneNumber;
        public readonly string comment;

        public TrafficLight trafficLight;

        private readonly int defaultPriority;
        private int priority = 0;
        private bool vehicleWaiting = false;

        private bool greenTicker, redTicker, yellowTicker; // redTicker is also the priorityTicker
        private int prioritySeconds;

        public List<int> crossingLanes = new List<int>();

        /// <summary>
        /// initialises the Lane class
        /// </summary>
        /// <param name="laneNumber">the number of the lane</param>
        /// <param name="crossingLanes">this needs to be a list of integers with the numbers of other lanes crossing when it's on green</param>
        /// <param name="comment">place a comment like: "this is a bikelane, buslane or normallane"</param>
        public Lane(int laneNumber, List<int> crossingLanes, string comment = "No comment added", int defaultPriority = 7) {
            this.laneNumber = laneNumber;
            this.comment = comment;
            this.crossingLanes = crossingLanes;
            trafficLight = new TrafficLight();
            this.defaultPriority = defaultPriority;
        }

        public void changeTrafficLight(Classes.lightColor newColor)
        {
            switch (newColor) {
                case Classes.lightColor.red:
                    priority = 0;
                    if (vehicleWaiting) {
                        setPriority();
                        redTicker = true;
                    }
                    break;
                case Classes.lightColor.yellow:
                    yellowTicker = true;
                    break;
                case Classes.lightColor.green:
                    greenTicker = true;
                    break;
                case Classes.lightColor.straightforwardRight:
                    greenTicker = true;
                    break;
                case Classes.lightColor.straightforward:
                    greenTicker = true;
                    break;
                case Classes.lightColor.right:
                    greenTicker = true;
                    break;
            }
        }


        /// <summary>
        /// call this from the tickerthread if this returns true then the light needs to be changed to yellow (this is already done) but it has to be send to the client
        /// </summary>
        /// <returns>true means add this change to the client message</returns>
        public bool laneTicker() {
            if (redTicker) {
                trafficLight.increaseRedLight();
                if (prioritySeconds % 10 == 0) {
                    increasePriority();
                }
                prioritySeconds++;
            }
            if (yellowTicker) {
                return trafficLight.checkAndChangeLight();
            } if (greenTicker) {
                trafficLight.increaseGreenLight();
            }

            return false;
        }



        /// <summary>
        /// this will return the lane number use this for checking crosslanes
        /// </summary>
        /// <returns>the lane number</returns>
        public int getLaneNumber() {
            return laneNumber;
        }

        /// <summary>
        /// whenever a vehicle change presists call this function
        /// </summary>
        /// <param name="waiting">true for vehicle waiting, false when there isn't</param>
        public void setVehicleWaiting(bool waiting) {
            vehicleWaiting = waiting;
            if (vehicleWaiting)//if it's true we will set the priority
                setPriority();
            else
                priority = 0;
        }

        /// <summary>
        /// set the priority so this lane will start to wait for his turn.
        /// </summary>
        private void setPriority()
        {
            priority = defaultPriority;
        }

        /// <summary>
        /// returns the value of the current priority
        /// </summary>
        /// <returns> priority </returns>
        public int getPriority()
        {
            return priority;
        }

        /// <summary>
        /// increasePriority when we are waiting
        /// </summary>
        public void increasePriority()
        {
            if (priority > 1)
            {
                priority -= 1;
            }
            else
            {
                Console.WriteLine("[TrafficLight.cs - increasePriority] - priority is out of bounds");
                priority = 1;
            }

        }


    }
}
