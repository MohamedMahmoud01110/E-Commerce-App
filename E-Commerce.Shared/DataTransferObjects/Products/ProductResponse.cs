using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DataTransferObjects.Products
{
    public record ProductResponse(int Id, string Name, string Description, string PictureUrl, decimal Price, string Brand, string Type);


    //C# 9.0
    //override toString

}
