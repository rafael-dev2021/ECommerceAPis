using ECommerce.Domain.Validation;

namespace ECommerce.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; private set; }
        public ICollection<Product> ProductsCollection { get; set; }

        public Category(string categoryName)
        {
            Valid(categoryName);
        }

        public Category(int id, string categoryName)
        {
            Id = id;
            Valid(categoryName);
        }

        private void Valid(string categoryName)
        {
            DomainValidationExceptions.When(string.IsNullOrEmpty(categoryName), "Category name cannot be empty");
            DomainValidationExceptions.When(categoryName?.Length < 5, "Minimum 5 characters");
            CategoryName = categoryName;
        }
    }
}
