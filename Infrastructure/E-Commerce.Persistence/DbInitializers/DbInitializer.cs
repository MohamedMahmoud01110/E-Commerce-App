using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.DbInitializers
{
    internal class DbInitializer(ApplicationDbContext dbContext) : IDbInitializer
    {
        public async Task InitializeAsync()
        {
            //dbContext

            if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
                await dbContext.Database.MigrateAsync();

            if (!dbContext.ProductBrands.Any())
            {
                // Read as json
                var BrandsData = await File.ReadAllTextAsync(@"..\Infrastructure\E-Commerce.Persistence\Context\DataSeed\brands.json");
                // Deserialize
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData, options);
                if (brands != null && brands.Any())
                {
                    dbContext.ProductBrands.AddRange(brands);

                }

                // Save to DB
                await dbContext.SaveChangesAsync();
            }
            if (!dbContext.ProductTypeds.Any())
            {
                // Read as json
                var TypesData = await File.ReadAllTextAsync(@"..\Infrastructure\E-Commerce.Persistence\Context\DataSeed\types.json");
                // Deserialize
                var types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
                if (types != null && types.Any())
                {
                    dbContext.ProductTypeds.AddRange(types);

                }

                // Save to DB
                await dbContext.SaveChangesAsync();
            }
            if (!dbContext.Products.Any())
            {
                // Read as json
                var ProductData = await File.ReadAllTextAsync(@"..\Infrastructure\E-Commerce.Persistence\Context\DataSeed\products.json");
                // Deserialize
                var products = JsonSerializer.Deserialize<List<Product>>(ProductData);
                if (products != null && products.Any())
                {
                    dbContext.Products.AddRange(products);

                }

                // Save to DB
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
