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
                currentState = lightColor.yellow;
            if (currentState == lightColor.yellow)
                currentState = lightColor.red;
        }

    }
}
