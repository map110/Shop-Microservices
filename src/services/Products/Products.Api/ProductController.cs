using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Products.Commands.Create;
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
    //     return _mapper.Map<List<ProductDtos.ProductResDto>>(await _readUnitOfWork.ProductReadRepository.GetAllAsync()) ;
    // }

    [HttpPost("AddProduct")]
    public async Task<ProductDtos.ProductResDto> AddProductAsync(AddProductCommand request)
    {
        return await _mediator.Send(request);
    }
}