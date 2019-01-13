using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using System;
using System.Timers;

namespace TemperatureTrackingSystem.Server
{
    class Program
    {
        #region Private Fields
        private static Timer _timer;
        #endregion

        #region Main Method
        static void Main(string[] args)
        {
            Console.WriteLine("Temperature Tracking System Sensor Started");

            Console.WriteLine("Press any Key to exit Temperature Tracking System");

            Console.WriteLine("_____________________________________________\n");

            string url = "http://localhost:8026"; //SignalR self hosting URL
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                _timer = new Timer();

                _timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
                _timer.Interval = 2000; //number in milisecinds  
                _timer.Enabled = true;
                _timer.Start();

                Console.ReadLine();
            }
        }
        #endregion

        #region Event Listeners
        /// <summary>
        /// Method used which responds based on the elapsed time
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event Arguments</param>
        private static void OnElapsedTime(object sender, ElapsedEventArgs e)
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<SensorHub>();
            hubContext.Clients.All.addMessage(new Random().Next(10, 50), DateTime.Now.ToString());
        }
        #endregion
    }
}
