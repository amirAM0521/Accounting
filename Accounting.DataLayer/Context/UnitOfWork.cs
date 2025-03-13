using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.DataLayer.Repository;
using Accounting.DataLayer.Servises;
using Accounting.DataLayer.Services;

namespace Accounting.DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        AccountingDBEntities1 db = new AccountingDBEntities1();

        private ICustomerRepository _customerRepository;

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(db);
                }

                return _customerRepository;
            }
        }

        private GenericRepository<Accounting> _accontingRepository;

        public GenericRepository<Accounting> AccontingRepository
        {
            get
            {
                if (_accontingRepository == null)
                {
                    _accontingRepository = new GenericRepository<Accounting>(db);
                }

                return _accontingRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
