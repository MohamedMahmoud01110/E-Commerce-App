using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DataTransferObjects.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.API.Controllers
{
    public class ProductsController(IProductService service) : APIBaseController
    {
        // Get all (filteration , search , order , pagination)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProducts(CancellationToken cancellationToken = default)
        {
            var response = await service.GetProductsAsync(cancellationToken);
            return Ok(response);
        }
        // Get By Id (int id)
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> Get(int id, CancellationToken cancellationToken = default)
        {
            var response = await service.GetByIdAsync(id, cancellationToken);
            return Ok(response);
        }
        // Get Brand
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandResponse>>> GetBrands(CancellationToken cancellationToken = default)
        {
            var response = await service.GetBrandsAsync(cancellationToken);
            return Ok(response);
        }
        // Get Types
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeResponse>>> GetTypes(CancellationToken cancellationToken = default)
        {
            var response = await service.GetTypesAsync(cancellationToken);
            return Ok(response);
        }

    }
}
