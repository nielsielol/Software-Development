using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace controller.Classes
{
    class Data {
        public List<Stoplicht> stoplichten { get; set; }
    }

    class GotData {
        public List<Banen> banen { get; set; }
    }

    class Banen {
        public Banen(int id, bool bezet)
        {
            this.id = id;
            this.bezet = bezet;
        }

        public int id { get; set; }
        public bool bezet { get; set; }
    }

    class Stoplicht{
        public Stoplicht(int id, int status) {
            this.id = id;
            this.status = status;
        }

        public int id { get; set; }
        public int status { get; set; }
    }

    class JSONConverter
    {
        Server server;
        public JSONConverter(Server server)
        {
            this.server = server;
        }


        public void sendMessage(List<Lane> lanes) {
            Data data = new Data();
            List<Stoplicht> sended = new List<Stoplicht>();
            foreach ( Lane lane in lanes)
            {
                int status = 0;
                switch (lane.trafficLight.getCurrentState())
                {
                    case Classes.lightColor.yellow:
                        status = 1;
                        break;
                    case Classes.lightColor.green:
                        status = 2;
                        break;
                    case Classes.lightColor.straightforwardRight:
                        status = 3;
                        break;
                    case Classes.lightColor.straightforward:
                        status = 4;
                        break;
                    case Classes.lightColor.right:
                        status = 5;
                        break;
                    default: // this would mean it's red
                        status = 0;
                        break;
                }
                sended.Add(new Stoplicht(lane.laneNumber, status));
            }
            data.stoplichten = sended;
            string output = JsonConvert.SerializeObject(data);
            Console.WriteLine("we are sending this: " + output);
            server.sendMessage(output);
        }

        public void getMessage(string Jsonstring) {
            GotData hallo = (GotData) JsonConvert.DeserializeObject(Jsonstring);

            foreach (Banen baan in hallo.banen) {
            }

        }
    }
}
