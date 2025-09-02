using System;
using System.ComponentModel.DataAnnotations;

namespace MaterialApi.Models
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "Material name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; } = string.Empty;

        public string? Brand { get; set; }

        [Required(ErrorMessage = "Unit price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than 0.")]
        public decimal UnitPrice { get; set; }

        public string UnitOfMeasure { get; set; } = string.Empty;

        public int InStockQty { get; set; }

        public int ReorderLevel { get; set; }

        [Range(0, 28, ErrorMessage = "GST must be between 0 and 28.")]
        public decimal GstPercent { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime AddedOn { get; set; } = DateTime.Now;
    }
}

