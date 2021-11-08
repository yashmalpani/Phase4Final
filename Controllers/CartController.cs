using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Phase4Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Phase4Final.Helpers;

namespace Phase4Final.Controllers
{
    public class CartController : Controller
    {
        ApplicationDBContext context;
        public CartController()
        {
            context = new ApplicationDBContext();
        }
        public IActionResult Index()
        {

            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                return RedirectToAction("Index","Pizza");
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Pizza.Price * item.Quantity);
                return View();
            }

        }

        public IActionResult Clear()
        {
            SessionHelper.setObjectAsJson(HttpContext.Session, "cart", null);
            return RedirectToAction("Index", "Pizza");
        }

        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Pizza = context.Pizza.Find(id), Quantity = 1 });
                SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExists(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Pizza = context.Pizza.Find(id), Quantity = 1 });
                }
                SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Checkout");
        }

        public int isExists(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Pizza.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult Checkout()
        { 
            return View();
        }
    }
}
