using Microsoft.AspNetCore.Mvc;
using MVCProducts.Models;

// namespace MVCProducts.Controllers;
namespace MvcProductDemo.Controllers
{
    public class ProductsController : Controller
    {
        List<Products> products = new List<Products>
            {
                new Products {Id = 1, Name = "Phone", Price = 20000},
                new Products {Id = 2, Name = "TV", Price = 25000},
                new Products {Id = 3, Name = "Laptop", Price = 50000}
            };

        public IActionResult Index()
        {

            return View(products);
        }

        public IActionResult GetDetails(int Id)
        {
            var item = products.FirstOrDefault(x => x.Id == Id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
    }


}
