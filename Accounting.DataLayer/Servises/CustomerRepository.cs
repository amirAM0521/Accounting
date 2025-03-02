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
        private Accounting_DBEntities db;

        public CustomerRepository(Accounting_DBEntities contxt)
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
            //try
            //{
            //    db.Customers.Add(customer);
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
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
            //try
            //{
            //    db.Entry(customer).State = EntityState.Modified;
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
            var local = db.Set<Customers>()
                 .Local
                 .FirstOrDefault(f => f.ID == customer.ID);
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(customer).State = EntityState.Modified;
            return true;
        }

        public bool DeleteCustomer(Customers customer)
        {
            //try
            //{
            //    db.Entry(customer).State = EntityState.Deleted;
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
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
            //try
            //{
            //    var customer = GetCustomerById(ID);
            //    DeleteCustomer(customer);
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
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
            //return db.Customers.Where(c =>
            //    c.FullName.Contains(Parametr) || c.Mobile.Contains(Parametr) || c.Email.Contains(Parametr)).ToList();
            return db.Customers.Where(c =>
               c.FullName.Contains(Parametr) || c.Email.Contains(Parametr) || c.Mobile.Contains(Parametr)).ToList();
        }
        public List<ListCustomerViewModel> GetNameCustomer(string filter = "")
        {
            //if (filter == "")
            //{
            //    return db.Customers.Select(c => new ListCustomerViewModel()
            //    {
            //        FullName = c.FullName,
            //        ID = c.ID
            //    }
            //    ).ToList();
            //}
            //return db.Customers.Where(c => c.FullName.Contains(filter)).Select(c => new ListCustomerViewModel()
            //{
            //    FullName = c.FullName,
            //    ID = c.ID
            //}).ToList();
            if (filter == "")
            {
                return db.Customers.Select(c => new ListCustomerViewModel()
                {
                    ID = c.ID,
                    FullName = c.FullName
                }).ToList();
            }

            return db.Customers.Where(c => c.FullName.Contains(filter)).Select(c => new ListCustomerViewModel()
            {
                ID = c.ID,
                FullName = c.FullName
            }).ToList();
        }

        public int GetCustomerIdByName(string name)
        {
            return db.Customers.First(c => c.FullName == name).ID;
        }

        public string GetCustomerNameById(int customerId)
        {
            return db.Customers.Find(customerId).FullName;
        }
    }
}
