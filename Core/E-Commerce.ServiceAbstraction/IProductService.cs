using E_Commerce.Shared.DataTransferObjects;
using E_Commerce.Shared.DataTransferObjects.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ServiceAbstraction
{
    public interface IProductService
    {
        Task<ProductResponse?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<PaginatedResult<ProductResponse>> GetProductsAsync(ProductQueryParameters parameters, CancellationToken cancellationToken = default);
        Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TypeResponse>> GetTypesAsync(CancellationToken cancellationToken = default);

    }
}
