using System.Web.Mvc;
using Web.AppServices;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var ordersService = new OrdersService();
            var orders = ordersService.GetOrders();
            return View(orders);
        }
    }
}
