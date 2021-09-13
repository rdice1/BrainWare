using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainWare.Controllers
{
    public class OrdersController : Controller
    {
        Data.BrainWareContext _dbContext;

        public OrdersController()
        {
            _dbContext = new Data.BrainWareContext();
        }

        // GET: OrdersController
        public ActionResult Index()
        {
            //var query = _dbContext.Orderproducts
            //    .Include(x => x.Order)
            //    //.ThenInclude(x => x.Orderproducts)
            //    .AsNoTracking()
            //    .AsEnumerable();

            var query = _dbContext.Orders
                .Include(x => x.Orderproducts)
                .ThenInclude(x => x.Product)
                .AsNoTracking()
                .AsEnumerable();

            return View(query);
        }
    }
}
