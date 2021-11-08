using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Phase4Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Phase4Final.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ApplicationDBContext _context;

        public PizzaController()
        {
            _context = new ApplicationDBContext();
        }

        public IActionResult Index()
        {
            var products = _context.Pizza.ToList();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = _context.Pizza.Find(id);
            return View(product);
        }
    }
}
