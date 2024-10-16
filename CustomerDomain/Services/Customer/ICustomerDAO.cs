using CarApi.Models;

namespace CarApi.Domain.Services.Customer
{
    public interface ICustomerDAO
    {
        public int Create(CustomerModel customer);
        public CustomerModel? GetById(int id);
        public List<CustomerModel> GetAll();
        public void Update(CustomerModel customer);
        public void Delete(int id);
    }
}
