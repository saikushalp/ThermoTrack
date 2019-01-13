using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;

namespace TemperatureTrackingSystem.Server
{
    /// <summary>
    /// Sensor Hub
    /// </summary>
    public class SensorHub : Hub
    {
        /// <summary>
        /// Method which responds when a client is connected.
        /// </summary>
        /// <returns>void</returns>
        public override Task OnConnected()
        {
            Console.WriteLine("Hub OnConnected {0}\n", Context.ConnectionId);
            return (base.OnConnected());
        }

        /// <summary>
        /// Method which responds when a client is disconnected.
        /// </summary>
        /// <returns>void</returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine("Hub OnDisconnected {0}\n", Context.ConnectionId);
            return (base.OnDisconnected(stopCalled));
        }
    }
}
