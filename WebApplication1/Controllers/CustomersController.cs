using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {      

        Construction_companyContext context = new Construction_companyContext();
        // GET: Customers
        public IActionResult Index()
        {
            return View(context.Customers.ToList());
        }
        
        public IActionResult Details(int? id)
        {
            var customer = context.Customers.Where(m => m.CustomerId == id).First();
            return View(customer);
        }
        public IActionResult Edit(int? id)
        {
            var customer = context.Customers.Where(m => m.CustomerId == id).First();
            return View(customer);
        }
    }
}
