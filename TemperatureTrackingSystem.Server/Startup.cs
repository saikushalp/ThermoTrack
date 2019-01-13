using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(TemperatureTrackingSystem.Server.Startup))]
namespace TemperatureTrackingSystem.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                // Setup the CORS middleware to run before SignalR and by default this will allow all origins                
                map.UseCors(CorsOptions.AllowAll);

                var hubConfiguration = new HubConfiguration();
                
                // Run the SignalR pipeline. We're not using MapSignalR
                // since this branch already runs under the "/signalr"
                // path.

                hubConfiguration.EnableDetailedErrors = true;
                map.RunSignalR(hubConfiguration);
            });
        }
    }
}
