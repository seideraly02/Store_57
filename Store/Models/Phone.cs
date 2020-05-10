using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Phone
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Range(10,10000,ErrorMessage = "Максимальная число 10 000, минимальня 10")]
        public double Price { get; set; }
        [Url(ErrorMessage = "укажите Url адрес")]
        public string UrlPhoto { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [MinLength(5, ErrorMessage = "Минимальная дилна 5")]
        [MaxLength(125, ErrorMessage = "Максимальная дилна 125")]
        public string Descriptions { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
       
    }
}