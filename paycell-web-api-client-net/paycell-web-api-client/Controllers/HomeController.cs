
using System.Web.Mvc;
using paycell_web_api_client.Session;

namespace paycell_web_api_client.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.requestType = MySession.Current.requestFilter;

            return View();
        }

        public ActionResult CheckRequestType(FormCollection collection)
        {
            MySession.Current.requestFilter = collection["RequestType"].ToString();

            return RedirectToAction("Index");
            
        }

    }

}
