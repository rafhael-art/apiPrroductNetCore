using System;
namespace ApiProduct.DTOs
{
	public class ResponseDto
	{
		public bool IsSucced { get; set; }
		public object? Result { get; set; }
		public string DisplayMenssage { get; set; } = null!;
	}
}

