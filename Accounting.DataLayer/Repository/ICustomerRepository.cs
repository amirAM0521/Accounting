using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.ViewModels.Customer;

namespace Accounting.DataLayer.Repository
{
    public interface ICustomerRepository
    {
        List<Customers> GetAllCustomers();
        IEnumerable<Customers> GetCustomersByFilter(string Parametr);
        List<ListCustomerViewModel> GetNameCustomer(string filter = "");
        Customers GetCustomerById(int ID);
        bool InsertCustomer(Customers Customer);
        bool UpdateCustomer(Customers Customer);
        bool DeleteCustomer(Customers Customer);
        bool DeleteCustomer(int ID);
        int GetCustomerIdByName(string name);
        string GetCustomerNameById(int customerId);
    }
}
