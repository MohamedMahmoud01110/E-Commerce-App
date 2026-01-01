using E_Commerce.Domain.Entities.Basket;
using E_Commerce.Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Services
{
    public class BasketService(IBasketRepository basketRepository, IMapper mapper) : IBasketService
    {
        public async Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO basketDTO)
        {
            var customerBasket = mapper.Map<CustomerBasket>(basketDTO);
            await basketRepository.CreateOrUpdateAsync(customerBasket);
            return mapper.Map<CustomerBasketDTO>(customerBasket);
        }

        public async Task DeleteAsync(string id)
        {
            await basketRepository.DeleteAsync(id);
        }

        public async Task<CustomerBasketDTO> GetByIdAsync(string id)
        {
            var customerBasket = await basketRepository.GetAsync(id);
            return mapper.Map<CustomerBasketDTO>(customerBasket);
        }
    }
}
