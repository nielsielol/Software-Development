using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace controller.Classes
{
    class Server
    {
        static string output;
        private readonly int port = 11000;
        private Socket socket;

        /// <summary>
        ///  constructor not nessecary
        /// </summary>
        public Server()
        {
        }

        public void createListener()
        {
            TcpListener tcpListener = null;

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress localAdress = host.AddressList[0];// = Dns.GetHostEntry("localhost").AddressList[0];
            foreach (IPAddress ip in host.AddressList)
            {
                Console.WriteLine(ip.ToString());
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine(ip.ToString());
                    localAdress = ip;

                    break;
                }
            }

            try
            {
                tcpListener = new TcpListener(localAdress, port);
                tcpListener.Start();
                output = "Waiting for a connection... on: " + localAdress.ToString() + ":" + port.ToString();
            }
            catch (Exception e)
            {
                output = "Error: " + e.ToString();
                Console.WriteLine(output);
            }

            try
            {
                Thread.Sleep(10);
                Console.WriteLine(output);
                socket = tcpListener.AcceptSocket();
                Console.WriteLine("send that we got a connection and we can start everything");
                NetworkStream stream = new NetworkStream(socket);
                string received = "";
                int sameReceived = 0;
                while (true)
                {
                    Thread.Sleep(10);
                    Console.WriteLine("we are in the while loop");
                    try
                    {
                        byte[] bytes = new byte[1024];// this is the buffer
                        stream.Read(bytes, 0, bytes.Length);
                        if (received.Equals(Encoding.ASCII.GetString(bytes, 0, bytes.Length)))
                        {// this means a normal shutdown so we should exit the program
                            sameReceived++;
                            if (sameReceived > 5)// als we 5 maal achterelkaar hetzelfde bericht krijgen moeten we afsluiten (een lekker grote check);
                                return;
                        }
                        else
                        {// reset when we don't have the same outcome
                            sameReceived = 0;
                        }
                        received = Encoding.ASCII.GetString(bytes, 0, bytes.Length);

                        //Console.WriteLine("we received the follwing: " + received);
                        messageReceived(received);

                    }
                    catch (Exception e)
                    {// when we got an error (not a normal shutdown) we restart the listening and we wait for the connection to be reastablished
                        Console.WriteLine("We got an error!" + e.ToString());
                        Console.WriteLine(output);
                        socket = tcpListener.AcceptSocket();
                        stream = new NetworkStream(socket);
                        received = "";
                        sameReceived = 0;
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
                Console.Read();
            }

        }

        /// <summary>
        /// this will be called from this class, the string will be passed to the jsonconverter
        /// </summary>
        /// <param name="message">this will be a JSON string</param>
        private void messageReceived(string message) {//this will be called when we received a message
            char[] test = {' '};
            Console.WriteLine(message.TrimEnd(test));

            //
        
            //Console.WriteLine(message.Length);
            //Console.WriteLine(message);
        }

        /// <summary>
        /// this needs to be called when you want to send a message to the other side (the java client)
        /// </summary>
        /// <param name="message">JSON string</param>
        public void sendMessage(string message) {
            byte[] byteData = Encoding.ASCII.GetBytes(message);
            Console.WriteLine("sending message: " + message);
            /*
            if (socket != null) {
                try {
                    socket.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), socket);
                } catch (Exception e){
                    Console.WriteLine(e.ToString()); 
                }
            }*/

            NetworkStream ns = new NetworkStream(socket);
            StreamWriter sw = new StreamWriter(ns);
            sw.WriteLine(message);
            sw.Flush();
            Console.WriteLine("we sended?");
            sw.Close();
            ns.Close();
        }

        /// <summary>
        /// this may only be called from this class
        /// </summary>
        /// <param name="ar"></param>
        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;
                //Console.WriteLine(client);

                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.
                //sendDone.Set();
                //client.EndSend(ar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        
    }
}
