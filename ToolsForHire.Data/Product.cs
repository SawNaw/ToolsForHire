using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ToolsForHire.Data
{
    public class Product
    {
        [Key]
        [Required]
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Daily Hire Cost")]
        public decimal DailyHireCost { get; set; }
        

        public Product(string productCode, string productName, decimal dailyHireCost)
        {
            ProductCode = productCode;
            ProductName = productName;
            DailyHireCost = dailyHireCost;
        }

        public Product()
        {

        }
    }
}
