using System.Web.Mvc;

namespace TemperatureTrackingSystem.Client.Web.Controllers
{
    /// <summary>
    /// Default Controller
    /// </summary>
    public class HomeController : Controller
    {
        #region Action Methods
        /// <summary>
        /// Default Action Method
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action Method used to dispaly Contact page
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Contact()
        {
            return View();
        }
        #endregion
    }
}