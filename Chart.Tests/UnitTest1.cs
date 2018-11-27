using System;
using System.Linq;
using ChartExercise;
using Xunit;

namespace Chart.Tests
{
    /// <summary>
    /// not unit testing but testing dapper
    /// </summary>
    public class UnitTest1
    {
        [Fact]
        public void ReadDataUsingDapper()
        {
            var sut = new Repository();
            var result = sut.GetSales(10);
            
            var categories = sut.GetCategories();

            var products = sut.GetProducts(categories.First());

            // no assert yet.
        }
    }
}
