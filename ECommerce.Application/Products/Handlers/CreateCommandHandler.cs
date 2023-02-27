using ECommerce.Application.Products.Commands;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Products.Handlers
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public CreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.ProductName, request.Description, request.Image,
                request.Stock, request.Price, request.Favorite);
            if (product == null)
            {
                throw new ApplicationException($"Entity could not be found");
            }else
            {
                product.CategoryId = request.CategoryId;
                return await _productRepository.CreateAsync(product);
            }
        }
    }
}
