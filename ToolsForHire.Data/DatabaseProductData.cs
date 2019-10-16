using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ToolsForHire.Data
{
    public class DatabaseProductData : IProductData
    {
        private readonly ProductContext context;

        public DatabaseProductData(ProductContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return from p in context.Products
                   select p;
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            return context.Products.Where(p => p.ProductName.Contains(name));
        }

        public IEnumerable<Product> GetProductsByProductCode(string productCode)
        {
            return context.Products.Where(p => p.ProductCode.Contains(productCode));
        }
    }
}
