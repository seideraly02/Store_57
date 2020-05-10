
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Store.Models;

namespace Store.Controllers
{
    public class BrandsController : Controller
    {
        StoreContext _db { get; set; }

        public BrandsController(StoreContext db)
        {
            _db = db;
        }
        
        // GET
        
        public IActionResult Create()
        {
            ViewBag.brands = _db.Brands.ToList();
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _db.Brands.Add(brand);
                _db.SaveChanges();
            }

            ViewBag.brands = _db.Brands.ToList();
            return View();
        }

        

        public IActionResult Remove(int id)
        {
            Brand brand = _db.Brands.FirstOrDefault(b => b.Id == id);
            if(brand != null)
            {
                _db.Brands.Remove(brand);
                _db.SaveChanges();
            }
            return RedirectToAction("Create");
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Brand brand = _db.Brands.FirstOrDefault(b => b.Id == id);
                if (brand != null)
                {
                    return View(brand);
                }
            }
            return NotFound();
        }
        
        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _db.Brands.Update(brand);
                _db.SaveChanges();
                return RedirectToAction("Create");
            }
            return RedirectToAction("Edit");
        }
    }
}