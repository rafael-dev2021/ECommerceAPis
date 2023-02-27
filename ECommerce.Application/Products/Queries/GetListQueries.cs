using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Products.Queries
{
    public class GetListQueries : IRequest<IEnumerable<Product>>
    {
    }
}
