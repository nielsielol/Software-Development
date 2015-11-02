using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controller.Classes
{
    public enum lightColor { green, yellow, red, straightforwardRight, straightforward, right };
    class TrafficLight
    {
        private lightColor currentState;
        private int timeSpentGreen;
        private int timeSpentRed;
        private int timeSpentYellow;
        private readonly int maxTimeYellow = 3;
        private int minTimeSpentGreen, maxTimeSpentGreen;
        
        
        /// <summary>
        /// constructor needs a minumum time spent green (default = 10 sec)
        /// </summary>
        /// <param name="minTimeSpentGreen">int in seconds</param>
        public TrafficLight(int minTimeSpentGreen = 10, int maxTimeSpentGreen = 120) {
            currentState = lightColor.red;
            this.maxTimeSpentGreen = maxTimeSpentGreen;
            this.minTimeSpentGreen = minTimeSpentGreen;
        }


        /// <summary>
        /// this changes the State of the trafficlight to the next state.
        /// </summary>
        public void setTrafficLight(lightColor color) {
            
            if (color == lightColor.yellow) {
                timeSpentYellow = 0;
            }
            if (color == lightColor.green)
            {
                timeSpentYellow = 0;
            }
            currentState = color;
        }

        /// <summary>
        /// call this to add the time spend green
        /// </summary>
        public void increaseGreenLight() {
            timeSpentGreen++;
        }

        public int getTimeSpentGreen() {
            return timeSpentGreen;
        }

        /// <summary>
        /// call this to add the time spend red!
        /// </summary>
        public void increaseRedLight() {
            timeSpentRed++;
        }

        public int getTimeSpentRed() {
            return timeSpentRed;
        }


        /// <summary>
        /// call for check and add yellowtime 
        /// when this retruns true we got a change in lights
        /// </summary>
        /// <returns>true: lightchange, false: not a change in lightcolor</returns>
        public bool checkAndChangeLight() {
            if (currentState == lightColor.yellow)
            {
                if (maxTimeYellow > timeSpentYellow)
                {
                    timeSpentYellow++;
                    return false;
                }
                else
                {
                    timeSpentYellow = 0;
                    setTrafficLight(lightColor.red);
                    return true;
                }
            }
            else {
                timeSpentYellow = 0;
                return false;
            }
        }

        public lightColor getCurrentState()
        {
            return currentState;
        }

    }
}
