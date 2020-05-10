using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Controllers
{
    public class OrdersController : Controller
    {
        private StoreContext _db;
        
        public OrdersController(StoreContext db)
        {
            _db = db;
        }

        // GET
        public IActionResult Index()
        {
            List<Order> orders = 
                _db.Orders.Include(c => c.Phone)
                    .ToList();
            return View(orders);
        }
        
        
        public IActionResult Create(int phoneId)
        {
         
            Phone phone = _db.Phones.FirstOrDefault(c => c.Id == phoneId);
            return View(new Order{Phone = phone});
        }
        
        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (order != null)
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "Orders");
        }
    }
}