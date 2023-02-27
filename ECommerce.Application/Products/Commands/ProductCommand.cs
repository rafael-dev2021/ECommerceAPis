using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Products.Commands
{
    public abstract class ProductCommand : IRequest<Product>
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public bool Favorite { get; set; }
        public int CategoryId { get; set; }
    }
}
