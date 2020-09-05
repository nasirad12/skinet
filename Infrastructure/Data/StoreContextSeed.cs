using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogInformation("StoreContextSeed Before Brands");

                if (!context.ProductBrands.Any())
                {
                    logger.LogInformation("StoreContextSeed In Brands");

                    var brandsData = 
                    File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach ( var item in brands)
                    {
                        context.ProductBrands.Add(item);
                        logger.LogInformation("StoreContextSeed In Brand Loop");
                    }

                    await context.SaveChangesAsync();
                }

                logger.LogInformation("StoreContextSeed Before Types");

                if (!context.ProductTypes.Any())
                {
                    logger.LogInformation("StoreContextSeed In Types");

                    var typesData = 
                    File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach ( var item in types)
                    {
                        logger.LogInformation("StoreContextSeed In Loop Types");
                        context.ProductTypes.Add(item);
                    }
                    
                    await context.SaveChangesAsync();
                }

                logger.LogInformation("StoreContextSeed Post Types");

                if (!context.Products.Any())
                {
                    logger.LogInformation("StoreContextSeed In Product");
                    var productsData = 
                    File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach ( var item in products)
                    {
                        logger.LogInformation("StoreContextSeed In Loop Products");
                        context.Products.Add(item);
                    }
                    
                    await context.SaveChangesAsync();
                }

                if (!context.DeliveryMethods.Any())
                {
                    logger.LogInformation("StoreContextSeed In DeliveryMethods");
                    var dmData = 
                    File.ReadAllText("../Infrastructure/Data/SeedData/delivery.json");
                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

                    foreach ( var item in methods)
                    {
                        logger.LogInformation("StoreContextSeed In Loop Products");
                        context.DeliveryMethods.Add(item);
                    }
                    
                    await context.SaveChangesAsync();
                }

                logger.LogInformation("StoreContextSeed Post all Loops");

            }
            catch ( Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}