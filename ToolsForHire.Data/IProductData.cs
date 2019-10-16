using System.Collections.Generic;
using System.Text;

namespace ToolsForHire.Data
{
    public interface IProductData
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByName(string name);
        IEnumerable<Product> GetProductsByProductCode(string productCode);
    }
}
