using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ToolsForHire.Data;

namespace ToolsForHire.Pages
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IProductData productData;

        public IEnumerable<Product> Products { get; set; }

        public ListModel(IConfiguration config, IProductData productData)
        {
            this.config = config;
            this.productData = productData;
        }

        public void OnGet()
        {
            // Give this List page model access to all products, so that it can list them.
            Products = productData.GetAllProducts();
        }
    }
}