using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Products.Queries
{
    public class GetByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }

        public GetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
