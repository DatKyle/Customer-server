using CarApi.Models;

namespace CarApi.Domain.Services.Customer
{
    public interface ICustomerService
    {
        public int Create(CustomerModel customer);
        public CustomerModel? GetById(int id);
        public List<CustomerModel> GetAll();
        public void Update(CustomerModel customer);
        public void Delte(int id);
    }
}
