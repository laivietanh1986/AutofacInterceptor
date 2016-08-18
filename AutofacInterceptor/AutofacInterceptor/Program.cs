using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AutofacContrib.DynamicProxy;
using Castle.DynamicProxy;

namespace AutofacInterceptor
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder =  new ContainerBuilder();
            builder.Register(c => new LogInterceptor(Console.Out))
                .Named<IInterceptor>("log-calls");
            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .EnableInterfaceInterceptors();
            using (var container = builder.Build())
            {
                ShowProducts(container);
            }

        }

        private static void ShowProducts(IContainer container)
        {
            var ProductsRepository = container.Resolve<IProductRepository>();
            foreach (var product in ProductsRepository.GetProducts())
            {
                Console.WriteLine(product);
            }
        }
    }
}
