using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		IProductService _productService;
		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _productService.GetAll();
			return Ok(result);
			
		}


		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _productService.GetById(id);
			return Ok(result);
			
		}

		[HttpPost("deletebyid")]
		public IActionResult DeleteById(int id)
		{
			_productService.Delete(id);
			return Ok();
		}
	}
}
