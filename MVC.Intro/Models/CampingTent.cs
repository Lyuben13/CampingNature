using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Intro.Models
{
    public class CampingTent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string ImagePath { get; set; } = string.Empty;

        public int Capacity { get; set; }

        public bool IsWaterproof { get; set; }

        public bool HasVentilation { get; set; }

        public string? Features { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
