using System;
using System.Collections;

namespace ToolsForHire.Data
{
    public class Product
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
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
