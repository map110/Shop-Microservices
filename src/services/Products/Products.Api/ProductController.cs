using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Products.Commands.Create;
using Products.Application.Products.Commands.Delete;
using Products.Application.Products.Commands.Update;
using Products.Domain;
using Products.Domain.Products;

namespace Products.Api;

[ApiController]
[Route("api/[Controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // [HttpGet("GetAll")]
    // public async Task<List<ProductDtos.ProductResDto>> GetAllAsync()
    // {
    //     _mediator.Send(new );
    // }

    [HttpPost("AddProduct")]
    public async Task<ProductDtos.ProductResDto> AddProductAsync(AddProductCommand request)
    {
        return await _mediator.Send(request);
    }

    [HttpPut("UpdateProduct/{id}")]
    public async Task<ActionResult<bool>> UpdateProductAsync(int id,UpdateProductCommand request)
    {
        if (id != request.Id)
        {
            return BadRequest("Id in body and query must be equal");
        }
        var res = await _mediator.Send(request);
        return res;
    }
    [HttpDelete("DeleteProduct")]
    public async Task<bool> DeleteProductAsync(DeleteProductCommand request)
    {
        return await _mediator.Send(request);
    }
}