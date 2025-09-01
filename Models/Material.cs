using System;
using System.ComponentModel.DataAnnotations;

namespace MaterialApi.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }   // Primary Key

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }   // 1. Material Name

        [MaxLength(250)]
        public string Description { get; set; }   // 2. Description

        [Required]
        public string Category { get; set; }   // 3. Category

        public string Supplier { get; set; }   // 4. Supplier

        public int Quantity { get; set; }   // 5. Quantity

        public decimal UnitPrice { get; set; }   // 6. Price per unit

        public DateTime PurchaseDate { get; set; }   // 7. Purchase date

        public bool IsAvailable { get; set; }   // 8. Availability

        public string Location { get; set; }   // 9. Storage location

        public string Notes { get; set; }   // 10. Extra notes
    }
}
