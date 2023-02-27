using ECommerce.Application.Products.Queries;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Products.Commands
{
    public class GetListQueriesHandler : IRequestHandler<GetListQueries, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetListQueriesHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetListQueries request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsAsync();
        }
    }
}
