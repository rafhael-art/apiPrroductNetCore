using System;

namespace ApiProduct.DTOs
{
	public class ProductDto
	{
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}

