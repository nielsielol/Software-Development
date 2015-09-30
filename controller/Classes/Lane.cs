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

        private readonly int defaultPriority = 7;
        private int priority;
        private bool vehicleWaiting = false;

        public List<int> crossingLanes = new List<int>();

        /// <summary>
        /// initialises the Lane class
        /// </summary>
        /// <param name="laneNumber">the number of the lane</param>
        /// <param name="crossingLanes">this needs to be a list of integers with the numbers of other lanes crossing when it's on green</param>
        /// <param name="comment">place a comment like: "this is a bikelane, buslane or normallane"</param>
        public Lane(int laneNumber, List<int> crossingLanes, string comment = "No comment added") {
            this.laneNumber = laneNumber;
            this.comment = comment;
            this.crossingLanes = crossingLanes;
            trafficLight = new TrafficLight();
        }

        public void changeTrafficLight()
        {
            trafficLight.changeTrafficLight();
        }

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

        public int getPriority()
        {
            return priority;
        }

        /// <summary>
        /// increasePriority when we are waiting
        /// </summary>
        public void increasePriority()
        {
            if (priority > 0)
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
