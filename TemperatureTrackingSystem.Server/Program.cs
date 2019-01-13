using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TemperatureTrackingSystem.Server
{
    class Program
    {
        private static Timer _timer;

        static void Main(string[] args)
        {
            Console.WriteLine("Temperature Sensor Service Started");

            Console.WriteLine("Press any Key to exit Temperature Sensor Service");

            Console.WriteLine("_____________________________________________\n");

            string url = "http://localhost:8026";
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

        private static void OnElapsedTime(object sender, ElapsedEventArgs e)
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<SensorHub>();
            hubContext.Clients.All.addMessage(new Random().Next(10, 50), DateTime.Now.ToString());
        }
    }
}
