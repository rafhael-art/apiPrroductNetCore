using System;
using ApiProduct.DTOs;
using ApiProduct.Models;
using AutoMapper;

namespace ApiProduct
{
	public class MapppingConfig
	{
		public static MapperConfiguration RegisterMaps() {
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<ProductDto, Product>().ReverseMap();
			});
			return mappingConfig;

        }
	}
}

