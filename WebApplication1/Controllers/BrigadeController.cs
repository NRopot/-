using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class BrigadeController : Controller
    {
        Construction_companyContext context = new Construction_companyContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(context.Brigade.ToList());
        }
        public IActionResult Details(int? id)
        {
            var brigade = context.Brigade.Where(m => m.BrigadeId == id).First();
            return View(brigade);
        }
        public IActionResult Edit(int? id)
        {
            var brigade = context.Brigade.Where(m => m.BrigadeId == id).First();
            return View(brigade);
        }
    }
}
