using BikeStoresWebAPIDemo.Models;
using Microsoft.Identity.Client;

namespace BikeStoresWebAPIDemo.Repository
{
    public class CustomerService: ICustomerService
    {
        private readonly AppDBContext _context;
        public CustomerService (AppDBContext context)
        {
            _context = context;
        }

        public List<Customer> AllCustomer()
        {
            try
            {
                var customersList = _context.Customers.ToList();
                if (customersList.Count > 0)
                {
                    return customersList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
                if (customer != null)
                {
                    return customer;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Customer AddCustomer(Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    _context.Customers.Add(customer);
                    _context.SaveChanges();
                    return customer;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public string UpdateCustomer(int id, Customer customer)
        {
            try
            {
                if(id == customer.CustomerId)
                {
                    var findCustomer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
                    if (findCustomer != null)
                    {
                        findCustomer.FirstName = customer.FirstName;
                        findCustomer.LastName = customer.LastName;
                        findCustomer.Phone = customer.Phone;
                        findCustomer.Email = customer.Email;
                        findCustomer.Street = customer.Street;
                        findCustomer.City = customer.City;
                        findCustomer.State = customer.State;
                        findCustomer.ZipCode = customer.ZipCode;

                        _context.SaveChanges();
                        return "Customer Updated !!!";
                    }
                    else
                    {
                        return "CouseId Dose't Found in DB";
                    }


                }
                else
                {
                    return "CustomerId Dosent Match";
                }
            }
            catch(Exception ex) 
            {
                throw new Exception( ex.Message);
            }

            
        }

        public string DeleteCustomer(int id)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
                if (customer != null)
                {
                    _context.Remove(customer);
                    _context.SaveChanges();
                    return "Customer Deleted Successfully!";
                }
                else
                {
                    return "Customer Not Found!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
