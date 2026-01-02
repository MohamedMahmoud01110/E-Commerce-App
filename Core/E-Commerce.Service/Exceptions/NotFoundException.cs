using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Exceptions
{
    public abstract class NotFoundException(string msg) : Exception(msg);
    public sealed class ProductNotFoundException(int id) : NotFoundException($"Product With Id {id} Was Not Found");
    public sealed class BasketNotFoundException(string id) : NotFoundException($"Basket With Id {id} Was Not Found");
}
