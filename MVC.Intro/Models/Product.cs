using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Intro.Models
{
    public class Product
    {
        [DisplayName("Идентификатор")]
        public Guid Id { get; set; }

        [DisplayName("Наименование")]
        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Дължината на името трябва да е между 3 и 50 символа")]
        [RegularExpression(@"^(PRD_)?[A-Za-zА-Яа-яЁё\s\-]+$", ErrorMessage = "Името може да съдържа само букви, интервали и тирета")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Цена")]
        [Required(ErrorMessage = "Задължително е продуктът да има цена")]
        [Range(24.99, 9999.99, ErrorMessage = "Цената трябва да е между 24.99 и 9999.99")]
        public decimal Price { get; set; }

        [DisplayName("Снимка")]
        [StringLength(255)]
        public string? ImagePath { get; set; }
    }
}
