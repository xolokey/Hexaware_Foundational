using BikeStoresWebAPIDemo.Models;
namespace BikeStoresWebAPIDemo.Repository
{
    public interface ICustomerService
    {
        public List<Customer> AllCustomer();
        public Customer GetCustomerById(int id);
        public Customer AddCustomer(Customer customer);
        public string UpdateCustomer(int  id, Customer customer);
        public string DeleteCustomer(int id);

    }
}
