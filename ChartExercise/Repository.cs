using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ChartExercise
{
    // using a simple repository class to keep the code simple
    // lots of repeated code. only focusing on the functionality
    public class Repository
    {
        const string _connectionString = "Server=summitdevtest.database.windows.net;Database=devtest;User Id=summitdev;Password='hjuOc57kO8;';";
        const string _salesSummaryStoredProcedure = "ssp_GetSummaryByProduct";
        public IEnumerable<SalesModel> GetSales(int productId)
        {
            IEnumerable<SalesModel> result;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                result = connection.Query<SalesModel>(_salesSummaryStoredProcedure,
                                new { ProductId = productId },
                                commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public IEnumerable<Product> GetProducts(string categoryName)
        {
            IEnumerable<Product> result;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                result = connection.Query<Product>("SELECT ProductId, ProductDescription FROM PRODUCT WHERE CategoryDescription = @CategoryName"
                    , new { CategoryName = categoryName });
            }
            return result;
        }

        public IEnumerable<string> GetCategories()
        {
            IEnumerable<string> result;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                result = connection.Query<string>("SELECT DISTINCT CategoryDescription FROM PRODUCT");
            }
            return result;
        }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductDescription { get; set; }
    }

    public class SalesModel
    {
        public int ProductId { get; set; }
        public int TotalTransactions { get; set; }
        public decimal TotalSalesValue { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime SalesDate { get; set; }
        public string DateDisplay {
            get
            {
                return SalesDate.ToString("dd/MM/yyyy");
            }
        }
    }
}
