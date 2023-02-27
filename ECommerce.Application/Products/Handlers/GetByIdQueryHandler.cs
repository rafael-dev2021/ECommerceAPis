using ECommerce.Application.Products.Queries;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Products.Handlers
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIdAsync(request.Id);
        }
    }
}
