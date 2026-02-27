using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Domain;
using Products.Domain.Products;

namespace Products.Application.Products.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly ILogger<UpdateProductCommandHandler> _logger;
    private readonly IReadUnitOfWork _readUnitOfWork; // بررسی وجود شی پروداکت جهت ویرایش

    public UpdateProductCommandHandler(IMapper mapper, IWriteUnitOfWork writeUnitOfWork, ILogger<UpdateProductCommandHandler> logger, IReadUnitOfWork readUnitOfWork)
    {
        _mapper = mapper;
        _writeUnitOfWork = writeUnitOfWork;
        _logger = logger;
        _readUnitOfWork = readUnitOfWork;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var updateProduct = _mapper.Map<Product>(request);
        var updatedProduct = await _writeUnitOfWork.ProductWriteRepository.UpdateAsync(updateProduct);
        _logger.LogInformation($"product {updatedProduct.Id} is successfully updated.");
        return true;
    }
}