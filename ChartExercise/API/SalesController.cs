using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChartExercise.API
{    
    public class SalesController : Controller
    {
        private readonly Repository _repository = new Repository();
        // I'd change these methods to return a httpresponse

        [HttpGet]
        [Route("api/sales/{categoryName}/products")]
        public IEnumerable<Product> Get(string categoryName)
        {
            return _repository.GetProducts(categoryName);
        }

        [HttpGet]
        [Route("api/sales/categories")]
        public IEnumerable<string> GetCategories()
        {
            return _repository.GetCategories();
        }

        [HttpGet]
        [Route("api/sales/{productId:int}")]
        public IEnumerable<SalesModel> Get(int productId)
        {
            return _repository.GetSales(productId);
        }
    }
}
