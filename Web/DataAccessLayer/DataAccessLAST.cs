using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Web.Models;

namespace Web.DataAccessLayer
{
    public class DataAccess
    {
        private string connectionString;

        private enum QueryIndices 
        {
            OrderId,
            Description,
            CompanyId,
            ProductId,
            ProductName,
            Price,
            CompanyName
        }

        public DataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BrainWareConnectionString"].ToString();

            ExecuteReader();
        }

        public IEnumerable<Web.Models.Order> ExecuteReader()
        {
            try
            {
                var items = new List<Web.Models.Order>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetOrders";

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Each item read represents an Order

                            var id = reader.GetInt32((int)QueryIndices.OrderId);
                            var CompanyId = reader.GetInt32((int)QueryIndices.CompanyId);
                            var CompanyName = reader.GetInt32((int)QueryIndices.CompanyName);

                            var p = items.Find(i => i.Id == id);

                            if (p == null)
                            {
                                p = new Product
                                {
                                    Id = reader.GetInt32((int)QueryIndices.ProductId),
                                    Name = reader.GetString((int)QueryIndices.ProductName),
                                    Price = reader.GetDecimal((int)QueryIndices.Price),
                                };
                            }
                            else
                            { 
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {
                // TO DO: do something...
                throw;
            }









            throw new NotImplementedException();

            //var sqlQuery = new SqlCommand(query, connectionString);

            //return sqlQuery.ExecuteReader();
        }

        //public int ExecuteNonQuery(string query)
        //{
        //    var sqlQuery = new SqlCommand(query, connectionString);

        //    return sqlQuery.ExecuteNonQuery();
        //}

    }
}