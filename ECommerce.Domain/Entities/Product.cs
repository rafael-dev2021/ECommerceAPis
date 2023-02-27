using ECommerce.Domain.Validation;

namespace ECommerce.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set; }
        public bool Favorite { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string productName, string description, string image, int stock, decimal price, bool favorite)
        {
            Valid(productName, description, image, stock, price);
            Favorite = favorite;
        }

        public Product(int id, string productName, string description, string image, int stock, decimal price, bool favorite)
        {
            DomainValidationExceptions.When(id < 1, "Invalid id value");
            Id = id;
            Valid(productName, description, image, stock, price);
            Favorite = favorite;
        }

        public void Update(string productName, string description, string image, int stock, decimal price, bool favorite, int categoryId)
        {
            Valid(productName, description, image, stock, price);
            Favorite = favorite;
            CategoryId = categoryId;

        }

        private void Valid(string productName, string description, string image, int stock, decimal price)
        {
            DomainValidationExceptions.When(string.IsNullOrEmpty(productName), "Category name cannot be empty");
            DomainValidationExceptions.When(productName?.Length < 5, "Minimum 5 characters");
            DomainValidationExceptions.When(string.IsNullOrEmpty(description), "Description  cannot be empty");
            DomainValidationExceptions.When(description?.Length < 15, "Minimum 15 characters");
            DomainValidationExceptions.When(image?.Length > 600, "Maximum 600 characters");
            DomainValidationExceptions.When(price <= 0, "Invalid price value");
            DomainValidationExceptions.When(stock < 0, "Invalid stock value");

            ProductName = productName;
            Description = description;
            Image = image;
            Stock = stock;
            Price = price;
        }

    }
}
