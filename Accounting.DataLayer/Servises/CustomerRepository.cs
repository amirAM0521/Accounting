using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.DataLayer.Repository;
using Accounting.ViewModels.Customer;

namespace Accounting.DataLayer.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private AccountingDBEntities db;

        public CustomerRepository(AccountingDBEntities contxt)
        {
            db = contxt;
        }
        public List<Customers> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customers GetCustomerById(int ID)
        {
            return db.Customers.Find(ID);
        }

        public bool InsertCustomer(Customers customer)
        {
            try
            {
                db.Customers.Add(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCustomer(Customers customer)
        {
            var local = db.Set<Customers>()
                 .Local
                 .FirstOrDefault(f => f.CustomerID == customer.CustomerID);
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(customer).State = EntityState.Modified;
            return true;
        }

        public bool DeleteCustomer(Customers customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(int ID)
        {
            try
            {
                var customer = GetCustomerById(ID);
                DeleteCustomer(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Customers> GetCustomersByFilter(string Parametr)
        {
            return db.Customers.Where(c =>
               c.FullName.Contains(Parametr) || c.Email.Contains(Parametr) || c.Mobile.Contains(Parametr)).ToList();
        }
        public List<ListCustomerViewModel> GetNameCustomer(string filter = "")
        {
            if (filter == "")
            {
                return db.Customers.Select(c => new ListCustomerViewModel()
                {
                    ID = c.CustomerID,
                    FullName = c.FullName
                }).ToList();
            }

            return db.Customers.Where(c => c.FullName.Contains(filter)).Select(c => new ListCustomerViewModel()
            {
                ID = c.CustomerID,
                FullName = c.FullName
            }).ToList();
        }

        public int GetCustomerIdByName(string name)
        {
            return db.Customers.First(c => c.FullName == name).CustomerID;
        }

        public string GetCustomerNameById(int customerId)
        {
            //var customer = db.Customers.Find(customerId);
            //if (customer != null)
            //{
            //    return customer.FullName;
            //}
            //else
            //{
            //    return "Customer not found"; // یا هر رفتار دیگری که مناسب است
            //}
            return db.Customers.Find(customerId).FullName;
        }
    }
}
