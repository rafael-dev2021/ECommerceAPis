using ECommerce.Application.Products.Commands;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Products.Handlers
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public UpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                //retornar para altera ArgumentNullException;
                throw new ApplicationException($"Entity could not be found");
            }
            else
            {
                product.Update(request.ProductName, request.Description, request.Image, request.Stock,
                    request.Price, request.Favorite, request.CategoryId);
                return await _productRepository.UpdateAsync(product);
            }
        }
    }
}
