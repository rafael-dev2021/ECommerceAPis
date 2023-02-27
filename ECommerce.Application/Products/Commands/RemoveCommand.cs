using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Products.Commands
{
    public class RemoveCommand : IRequest<Product>
    {
        public int Id { get; set; }

        public RemoveCommand(int id)
        {
            Id = id;
        }
    }
}
