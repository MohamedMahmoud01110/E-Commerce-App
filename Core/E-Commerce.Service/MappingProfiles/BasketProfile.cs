using E_Commerce.Domain.Entities.Basket;
using E_Commerce.Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.MappingProfiles
{
    internal class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketItem, BasketItemDTO>().ReverseMap();
            CreateMap<CustomerBasket, CustomerBasketDTO>().ReverseMap();
        }

    }
}
