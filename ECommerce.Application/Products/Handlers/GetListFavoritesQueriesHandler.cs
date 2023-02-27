using ECommerce.Application.Products.Queries;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Products.Handlers
{
    public class GetListFavoritesQueriesHandler : IRequestHandler<GetListFavoritesQueries, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetListFavoritesQueriesHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetListFavoritesQueries request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetFavoritesAsync();
        }
    }
}
