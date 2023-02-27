using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Products.Queries
{
    public class GetListFavoritesQueries : IRequest<IEnumerable<Product>>
    {
    }
}
