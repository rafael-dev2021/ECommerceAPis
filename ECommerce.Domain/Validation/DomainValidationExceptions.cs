namespace ECommerce.Domain.Validation
{
    public class DomainValidationExceptions : Exception
    {
        public DomainValidationExceptions(string error) : base(error)
        {
            
        }

        public static void When(bool hasError, string error)
        {
            if (hasError)
            {//voltar para alterar DomainValidationExceptions;
                throw new ApplicationException(error);
            }
        }
    }
}
