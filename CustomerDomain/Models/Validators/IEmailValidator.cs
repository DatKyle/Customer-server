namespace CarApi.Domain.Models.Validators
{
    public interface IEmailValidator
    {
        public bool Validate(string email);
    }
}
