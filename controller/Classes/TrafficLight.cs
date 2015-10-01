using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controller.Classes
{
    public enum lightColor { green, yellow, red };
    class TrafficLight
    {
        public lightColor currentState { get; set; }
        private int timeSpentGreen;
        private int timeSpentRed;

        public TrafficLight() {
            currentState = lightColor.red;
        }

        /// <summary>
        /// this changes the State of the trafficlight to the next state.
        /// </summary>
        public void changeTrafficLight() {
            if (currentState == lightColor.red)
                currentState = lightColor.green;
            if (currentState == lightColor.green)
                currentState = lightColor.red;//this needs to be yellow
            if (currentState == lightColor.yellow)
                currentState = lightColor.red;
        }

        public void increaseGreenLight() {
            timeSpentGreen++;
        }

        public int getTimeSpentGreen() {
            return timeSpentGreen;
        }

    }
}
