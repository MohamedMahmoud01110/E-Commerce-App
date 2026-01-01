using E_Commerce.Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ServiceAbstraction
{
    public interface IBasketService
    {
        Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO basketDTO);
        Task<CustomerBasketDTO> GetByIdAsync(string id);
        Task DeleteAsync(string id);
    }
}
