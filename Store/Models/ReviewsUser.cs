using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class ReviewsUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string UserName { get; set; }
        public float Estimation { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [MinLength(5, ErrorMessage = "Минимальная дилна 5")]
        [MaxLength(125, ErrorMessage = "Максимальная дилна 125")]
        public string Reviews { get; set; }
        public int PhoneId { get; set; }
    }
}