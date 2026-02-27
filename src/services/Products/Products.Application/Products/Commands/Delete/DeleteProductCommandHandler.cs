using AutoMapper;
using MediatR;
using Products.Domain;
using Products.Domain.Products;

namespace Products.Application.Products.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;

    public DeleteProductCommandHandler(IMapper mapper, IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork)
    {
        _mapper = mapper;
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var findProduct = await _readUnitOfWork.ProductReadRepository.GetAsync(request.Id);
        if (findProduct == null)
        {
            throw new KeyNotFoundException($"product with {request.Id} not found.");
        }

        await _writeUnitOfWork.ProductWriteRepository.DeleteAsync(findProduct);
        return true;
    }
}