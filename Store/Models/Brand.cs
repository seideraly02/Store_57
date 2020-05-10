using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace Store.Models
{
    public class Brand
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Remote("CheckName", "ValidationBrand",ErrorMessage = "Такой бренд уже существует!")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Remote("CheckDate", "ValidationBrand",ErrorMessage = "Нельзя добавить дату из будущего или ранее чем 100 лет")]
        public DateTime DateFoundation { get; set; }
    }
}