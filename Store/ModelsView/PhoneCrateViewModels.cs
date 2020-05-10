using System.Collections.Generic;
using Store.Models;

namespace Store.ModelsView
{
    public class PhoneCrateViewModels
    {
        public Phone Phone { get; set; } = new Phone();
        public List<Brand> Brands { get; set; }
    }
}