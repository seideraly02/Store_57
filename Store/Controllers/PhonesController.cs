using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Models;
using Store.ModelsView;

namespace Store.Controllers
{
    public class PhonesController : Controller
    {
        private StoreContext _db { get; set; }
            
        
        public PhonesController(StoreContext db)
        {
            _db = db;
        } 

        // GET
        public IActionResult Index()
        {
            List<Phone> phones = _db.Phones.Include(b => b.Brand).ToList();
            return View(phones);
        }

        public IActionResult Create()
        {
            PhoneCrateViewModels crateViewModels = new PhoneCrateViewModels()
            {
                Phone = new Phone(),
                Brands = _db.Brands.ToList()
            };
            ViewBag.phone = _db.Phones.ToList();
            return View(crateViewModels);
        }
        
        [HttpPost]
        public IActionResult Create(PhoneCrateViewModels model)
        {
            if (ModelState.IsValid)
            {
                _db.Phones.Add(model.Phone);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }
        public IActionResult Edit(int phoneId)
        {
            PhoneCrateViewModels crateViewModels = new PhoneCrateViewModels()
            {
                Phone = _db.Phones.FirstOrDefault(p => p.Id == phoneId),
                Brands = _db.Brands.ToList()
            };
            if (crateViewModels.Phone != null)
            {
                return View(crateViewModels);
            }
            return NotFound();
        }
        [ActionName("Edit")]
        [HttpPost]
        public IActionResult EditSave(PhoneCrateViewModels model)
        {
            if (ModelState.IsValid)
            {
                _db.Phones.Update(model.Phone);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Phone phone = _db.Phones.FirstOrDefault(p => p.Id == id);
                if (phone != null)
                {
                    return View(phone);
                }
            }
            return NotFound();
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfigDelete(int? id)
        {
            if (id != null)
            {
                Phone phone = _db.Phones.FirstOrDefault(p => p.Id == id);
                if (phone != null)
                {
                    _db.Phones.Remove(phone);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                
                Phone phone = _db.Phones.Include(b => b.Brand).FirstOrDefault(p => p.Id == id);
                if (phone != null)
                {
                    ViewBag.reviewsCount = 0;
                    ViewBag.averageMark = 0;
                    if (_db.Users.Count() != 0)
                    {
                        List<ReviewsUser> reviewsUser = RevocationList(phone.Id);
                        if (reviewsUser != null)
                        {
                            ViewBag.reviewsUser = reviewsUser;
                            ViewBag.reviewsCount = reviewsUser.Count;
                            double sum = 0;
                            foreach (var user in reviewsUser)
                                sum += user.Estimation;
                            ViewBag.averageMark = Math.Round(sum / reviewsUser.Count,2);
                        }
                    }
                    ViewBag.currency = Program._сurrencies;
                    ViewData["price12"] = Math.Round(phone.Price / 12, 2);
                    return View(phone);
                }
            }
            
            return NotFound();
        }

        public List<ReviewsUser> RevocationList(int phoneId)
        {
            List<ReviewsUser> users = new List<ReviewsUser>();
            List<ReviewsUser> buffer = _db.Users.ToList();
            
            foreach (var user in buffer)
                if (user.PhoneId == phoneId)
                    users.Add(user);
            
            if (users.Count != 0)
            {
                return users;
            }
            return null;
        }

        public IActionResult Reviews(int phoneId)
        {
            ViewBag.phoneId = phoneId;
            ViewBag.phoneName = _db.Phones.FirstOrDefault(b => b.Id == phoneId)?.Name;
            return View();
        }
        
        [HttpPost]
        public IActionResult Reviews(ReviewsUser review)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(review);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}












