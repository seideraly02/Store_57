using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using Store.Models;

namespace Store.Controllers
{
    public class ValidationBrandController : Controller
    {
        private StoreContext _db;

        public ValidationBrandController(StoreContext db)
        {
            _db = db;
        }

        // GET
        public bool CheckName(string name)
        {
            return !_db.Brands.Any(b => b.Name.ToUpper() == name.ToUpper());
        }
        
        public bool CheckDate(DateTime dateFoundation)
        {
            bool result = false;
            if (dateFoundation <= DateTime.Now)
            {
                DateTime maxDate = DateTime.Now;
                DateTime minDate = new DateTime(maxDate.Year - 100, maxDate.Month, maxDate.Day);
                if (dateFoundation >= minDate)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}