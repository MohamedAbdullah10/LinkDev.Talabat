using LinkDev.Talabat.Core.Domain.Contract;
using LinkDev.Talabat.Core.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Persistence.Data
{
    internal class StoreContextIntializer(StoreDbContext dbContext) :
        IStoreContextIntializer
    {
        public async Task InitializeAsync()
        {
            var pendingMigration = dbContext.Database.GetPendingMigrations();
            if (pendingMigration.Any())
                await dbContext.Database.MigrateAsync();
         
        }

       

        public async Task SeedAsync()
        {
            if (!dbContext.Brands.Any())
            {

                var brandseed = await File.ReadAllTextAsync("../LinkDev.Talabat.Infrastructure.Persistence/Data/Seeds/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandseed);

                if (brands?.Count > 0)
                {

                    await dbContext.Brands.AddRangeAsync(brands);
                    await dbContext.SaveChangesAsync();


                }



            }

            if (!dbContext.Categories.Any())
            {
                var categoriesseed = await File.ReadAllTextAsync("../LinkDev.Talabat.Infrastructure.Persistence/Data/Seeds/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesseed);
                if (categories?.Count > 0)
                {
                    await dbContext.Categories.AddRangeAsync(categories);
                    await dbContext.SaveChangesAsync();

                }




            }
            if (!dbContext.Products.Any())
            {
                var productsseed = await File.ReadAllTextAsync("../LinkDev.Talabat.Infrastructure.Persistence/Data/Seeds/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsseed);
                if (products?.Count > 0)
                {
                    await dbContext.Products.AddRangeAsync(products);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
