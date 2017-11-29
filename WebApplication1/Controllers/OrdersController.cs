using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class OrdersController : Controller
    {
        Construction_companyContext context = new Construction_companyContext();
        public IActionResult Index()
        {
            return View(context.Orders.ToList());
        }

        public IActionResult Details(int? id)
        {
            var orders = context.Orders.Where(m => m.OrderId == id).First();
            return View(orders);
        }
        public IActionResult Edit(int? id)
        {
            var orders = context.Orders.Where(m => m.OrderId == id).First();
            return View(orders);
        }
    }
}