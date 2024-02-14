using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Features.Products.Command.CreateProduct;
using OnionArch.Application.Features.Products.Command.DeleteProduct;
using OnionArch.Application.Features.Products.Command.UpdateProduct;
using OnionArch.Application.Features.Products.Queries.GetAllProducts;

namespace OnionArch.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        } 
        
        [HttpPost]
        public async Task<IActionResult> UpdateProduct (UpdateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }  

        [HttpPost]
        public async Task<IActionResult> DeleteProduct (DeleteProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }


    }
}
