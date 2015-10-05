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
        public void setTrafficLight(lightColor color) {
            
            if (color == lightColor.yellow) {

            }
        }

        public void increaseGreenLight() {
            timeSpentGreen++;
        }

        public int getTimeSpentGreen() {
            return timeSpentGreen;
        }

        public void increaseRedLight() {
            timeSpentRed++;
        }

        public int getTimeSpentRed() {
            return timeSpentRed;
        }

    }
}
