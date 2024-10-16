using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
using System.Xml.Linq;
using CarApi.Domain.Errors.DAO;
using CarApi.Domain.Services.Customer;
using CarApi.Models;

namespace CarApi.DAO.InMemory.Customer
{
    public class CustomerDAO: ICustomerDAO
    {

        private readonly Dictionary<int, CustomerModel> customers;
        private int index = 0;

        public CustomerDAO() {
            customers = new Dictionary<int, CustomerModel>();
            Create(new CustomerModel()
            {
                Name = "Kyle",
                Address = "name st",
                PostalCode = "CV5",
                Country = "UK",
                Phone = "07772225555"
            });
        }

        public int Create(CustomerModel customer)
        {
            customer.Id = index++;
            customers.Add(customer.Id.Value, customer);
            return customer.Id.Value;
        }

        public CustomerModel? GetById(int id) => customers.FirstOrDefault(kv => kv.Key == id).Value;
        
        public List<CustomerModel> GetAll() => customers.Values.ToList();

        public void Update(CustomerModel customer)
        {
            if (!customer.Id.HasValue) throw new ArgumentException($"Id is required");
            if (!customers.ContainsKey(customer.Id.Value)) throw new RecordDoesNotExists($"customer {customer.Id} does not exist");
            
            customers[customer.Id.Value] = customer;
        }

        public void Delete(int id)
        {
            // Note: Ignoring the failure to delete if id doesn't exist
            customers.Remove(id);
        }
    }
}
