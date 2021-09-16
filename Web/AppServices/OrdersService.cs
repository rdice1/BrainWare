using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;
using Web.DataAccessLayer;

namespace Web.AppServices
{
    public class OrdersService
    {
        private DataAccess dataAccess;

        public OrdersService()
        {
            dataAccess = new DataAccess();
        }

        public IList<Order> GetOrders()
        {
            try
            {
                var orders = dataAccess.GetOrders();

                return orders;
            }
            catch (Exception e)
            {
                // TO DO: use some exception shielding here
                throw;
            }
        }
    }
}