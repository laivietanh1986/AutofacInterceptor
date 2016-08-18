using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacContrib.DynamicProxy;

namespace AutofacInterceptor
{
    
    public class ProductRepository:IProductRepository
    {
        public IEnumerable<string> GetProducts()
        {
           return new List<String>() {"Television","Laptop","Book"};
        }
    }
    [Intercept("log-calls")]
    public interface IProductRepository
    {
        IEnumerable<string> GetProducts();
    }
}
