using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ServiceAbstraction.Common
{
    public partial class Error
    {
        public static class Product
        {
            public static Error NotFound => NotFound("Product Not Found", "Product with specified id was not found ");
        }

    }
}
