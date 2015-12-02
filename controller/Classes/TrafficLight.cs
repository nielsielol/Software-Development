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
        public bool maybeEddited { get; set; }



        /// <summary>
        /// constructor needs a minumum time spent green (default = 10 sec)
        /// </summary>
        /// <param name="minTimeSpentGreen">int in seconds</param>
        public TrafficLight(int minTimeSpentGreen = 10, int maxTimeSpentGreen = 120) {
            currentState = lightColor.red;
            this.maxTimeSpentGreen = maxTimeSpentGreen;
            this.minTimeSpentGreen = minTimeSpentGreen;
            maybeEddited = true;

        }


        /// <summary>
        /// this changes the State of the trafficlight to the given lightcolor (only call when it's changed!)
        /// </summary>
        public void setTrafficLight(lightColor color) {
            if (color == lightColor.red) {//the color is changed to red so we need to set that timer to 0
                timeSpentRed = 0;
                maybeEddited = true;
            }
            if (color == lightColor.yellow)
            {//the color is changed to yellow so we need to set that timer to 0
                timeSpentYellow = 0;
                maybeEddited = false;
            }
            if (color == lightColor.green || color == lightColor.right || color == lightColor.straightforward
                || color == lightColor.straightforwardRight)
            {//the color is changed to green or something equal so we need to set that timer to 0
                timeSpentGreen = 0;
                maybeEddited = false;
            }
            this.currentState = color;

        }
        /// <summary>
        /// the methods will increase the lights and are controlling the maybeEddited!
        /// </summary>
        #region increase and get the timeSpent
        public void increaseGreenLight() {
            maybeEddited = false;
            timeSpentGreen++;
            Console.WriteLine("okay"+"time spent green: " + timeSpentGreen);
            if (timeSpentGreen > minTimeSpentGreen) {
                
                maybeEddited = true;
            }
        }

        public int getTimeSpentGreen() {
            return timeSpentGreen;
        }

        public void increaseRedLight() {
            timeSpentRed++;
            maybeEddited = true;
        }

        public int getTimeSpentRed() {
            return timeSpentRed;
        }
        
        public void increaseYellowLight() {
            timeSpentYellow++;
            maybeEddited = false;
            if (timeSpentYellow > maxTimeYellow) {
                maybeEddited = true;
            } 
            
        }

        public int getTimeSpentYellow() {
            return timeSpentYellow;
        }
        #endregion

        public lightColor getCurrentState()
        {
            return currentState;
        }

    }
}
