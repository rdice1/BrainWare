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
        }

        public IList<Order> GetOrders()
        {
            return FetchOrders();
        }

        private IList<Order> FetchOrders()
        {
            try
            {
                var items = new List<Order>();

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

                            var o = items.Find(i => i.Id == id);

                            if (o == null)
                            {
                                // order doesn't exists, create order and also add the first product

                                o = new Order
                                {
                                    Id = reader.GetInt32((int)QueryIndices.OrderId),
                                    Description = reader.GetString((int)QueryIndices.Description),
                                    OrderCompany = new List<Company>
                                    {
                                        new Company
                                        {
                                            Id = reader.GetInt32((int)QueryIndices.CompanyId),
                                            Name = reader.GetString((int)QueryIndices.CompanyName)
                                        }
                                    },
                                    OrderProducts = new List<Product>
                                    {
                                        new Product
                                        {
                                            Id = reader.GetInt32((int)QueryIndices.ProductId),
                                            Name = reader.GetString((int)QueryIndices.ProductName),
                                            Price = reader.GetDecimal((int)QueryIndices.Price)
                                        }
                                    }
                                };

                                items.Add(o);
                            }
                            else
                            {
                                // order exists, add the products

                                ((List<Product>)o.OrderProducts).Add(
                                            new Product
                                            {
                                                Id = reader.GetInt32((int)QueryIndices.ProductId),
                                                Name = reader.GetString((int)QueryIndices.ProductName),
                                                Price = reader.GetDecimal((int)QueryIndices.Price)
                                            });
                            }
                        }

                    }
                }

                return items;
            }
            catch (Exception e)
            {
                // TO DO: do something... use exception shielding
                throw;
            }
        }

        //public int ExecuteNonQuery(string query)
        //{
        //    var sqlQuery = new SqlCommand(query, connectionString);

        //    return sqlQuery.ExecuteNonQuery();
        //}

    }
}