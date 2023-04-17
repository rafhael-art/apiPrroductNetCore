using System;
using ApiProduct.DbContexts;
using ApiProduct.DTOs;
using ApiProduct.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiProduct.Repository
{
	public class ProductSQLRepository : IProductRepository
	{
        private AppDbContext appDbContext;
        private IMapper mapper;

        public ProductSQLRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }


        public async Task<ProductDto> CreateProduct(ProductDto productDto)
        {
            var product = mapper.Map<Product>(productDto);
            await this.appDbContext.Products.AddAsync(product);
            await this.appDbContext.SaveChangesAsync();
            return mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int ProductId)
        {
            try
            {
                Product? product = await appDbContext.Products.FirstOrDefaultAsync(x => x.ProductId == ProductId);
                if (product is null)
                {
                    return false;
                }
                this.appDbContext.Products.Remove(product);
                await this.appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product? product = await this.appDbContext.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

            return mapper.Map<ProductDto>(product);

        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> products = await appDbContext.Products.ToListAsync();
            return mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> UpdateProduct(ProductDto productDto)
        {
            var product =  mapper.Map<Product>(productDto);
            this.appDbContext.Products.Update(product);
            await this.appDbContext.SaveChangesAsync();
            return mapper.Map<ProductDto>(product);
        }
    }
}

