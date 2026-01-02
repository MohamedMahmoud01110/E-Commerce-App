using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DataTransferObjects
{
    public class CustomerBasketDTO
    {
        public string Id { get; set; } // Client generated (GUID)
        public ICollection<BasketItemDTO> Items { get; set; } = [];

    }
}
