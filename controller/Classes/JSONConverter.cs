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
        public List<BusBanen> busbanen { get; set; }
    }

    class BusBanen {
        public BusBanen(int id, int eerstvolgendelijn, bool bezet)
        {
            this.id = id;
            this.eerstvolgendelijn = eerstvolgendelijn;
            this.bezet = bezet;
        }

        public int id { get; set; }
        public int eerstvolgendelijn { get; set; }
        public bool bezet { get; set; }
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
        Tickerthread ticker;
        public JSONConverter()
        {
        }

        public void setServerTicker(Server server,Tickerthread ticker) {
            this.server = server;
            this.ticker = ticker;
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
            GotData received = JsonConvert.DeserializeObject<GotData>(Jsonstring);
            
            Console.WriteLine("[JSONConverter.cs] - we are in the getMessage(), we are presenting the id's and the occupied booleans");

            if (received.banen != null)
            {
                foreach (Banen baan in received.banen)
                {
                    Console.WriteLine("baanId: " + baan.id + " baanBezet: " + baan.bezet);
                    ticker.mainCore.lanesState[baan.id].setVehicleWaiting(baan.bezet);
                }
            }
            else if (received.busbanen != null) {
                foreach (BusBanen busbaan in received.busbanen)
                {
                    Console.WriteLine("busBaanId: " + busbaan.id + " baanEerstvolgendelijn: " +busbaan.eerstvolgendelijn +" baanBezet: " + busbaan.bezet);
                    if (busbaan.eerstvolgendelijn == 170)
                    {
                        if (busbaan.id == 15) {
                            Console.WriteLine("WARNING THIS MAY NOT HAPPEN IN ANY CASE! NOT MY FAULT BUT THE CLIENT HIS FAULT:"+
                                 " we got a bus with lijn 170 on the busbaan this may not happen!");
                        }
                        ticker.mainCore.lanesState[busbaan.id].setVehicleWaiting(busbaan.bezet);
                    }
                    else {
                        ticker.mainCore.lanesState[busbaan.id].setVehicleWaiting(busbaan.bezet, busbaan.eerstvolgendelijn);
                    }

                }
            }

        }
    }
}
