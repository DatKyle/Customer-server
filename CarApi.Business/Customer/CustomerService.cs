using CarApi.Domain.Models.Validators;
using CarApi.Domain.Services.Customer;
using CarApi.Models;

namespace CarApi.Business.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDAO _customerDAO;
        private readonly ICustomerValidator _customerValidator;

        public CustomerService(ICustomerDAO customerDAO, ICustomerValidator customerValidator)
        {
            _customerDAO = customerDAO;
            _customerValidator = customerValidator;
        }
        public int Create(CustomerModel customer)
        {
            if (customer == null) throw new ArgumentNullException(typeof(CustomerModel).FullName);

            _customerValidator.Validate(customer);

            return _customerDAO.Create(customer);
        }

        public List<CustomerModel> GetAll()
        {
            return _customerDAO.GetAll();
        }

        public CustomerModel? GetById(int id)
        {
            return _customerDAO.GetById(id);
        }

        public void Update(CustomerModel customer)
        {
            _customerValidator.Validate(customer);
            _customerDAO.Update(customer);
        }

        public void Delte(int id)
        {
            _customerDAO.Delete(id);
        }

    }
}
