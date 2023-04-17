using System;
using ApiProduct.DTOs;
using ApiProduct.Models;
using ApiProduct.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiProduct.DbContexts
{
    [ApiController]
    [Route("api/Products")]
    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository;
        private ResponseDto responseDto;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            this.responseDto = new ResponseDto();
        }

        [HttpGet]
        public async Task<Object> Get()
        {

            try
            {
                IEnumerable<ProductDto> products = await productRepository.GetProducts();
                responseDto.Result = products;
                responseDto.IsSucced = true;
            }
            catch (Exception ex)
            {
                responseDto.IsSucced = false;
                responseDto.DisplayMenssage = ex.Message;
            }
            return responseDto;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<Object> Get(int id)
        {
            try
            {
                ProductDto product = await productRepository.GetProductById(id);
                responseDto.Result = product;
                responseDto.IsSucced = true;
            }
            catch (Exception ex)
            {
                responseDto.IsSucced = false;
                responseDto.DisplayMenssage = ex.Message;
            }
            return responseDto;
        }

        [HttpPost]
        public async Task<object> Post(ProductDto productDto)
        {
            try
            {
                ProductDto result = await productRepository.CreateProduct(productDto);
                responseDto.Result = result;
                responseDto.IsSucced = true;
            }
            catch (Exception ex)
            {
                responseDto.IsSucced = false;
                responseDto.DisplayMenssage = ex.Message;
            }
            return responseDto;
        }


        [HttpPut]
        public async Task<object> Put(ProductDto productDto)
        {
            try
            {
                ProductDto result = await productRepository.UpdateProduct(productDto);
                responseDto.Result = result;
                responseDto.IsSucced = true;
            }
            catch (Exception ex)
            {
                responseDto.IsSucced = false;
                responseDto.DisplayMenssage = ex.Message;
            }
            return responseDto;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool result = await productRepository.DeleteProduct(id);
                responseDto.Result = result;
                responseDto.IsSucced = true;
            }
            catch (Exception ex)
            {
                responseDto.IsSucced = false;
                responseDto.DisplayMenssage = ex.Message;
            }
            return responseDto;
        }

    }
}

