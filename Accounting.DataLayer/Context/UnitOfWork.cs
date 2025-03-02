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
        Accounting_DBEntities db = new Accounting_DBEntities();

        private ICustomerRepository _customerRepository;

        public ICustomerRepository CustomerRepository
        {
            get
            {
                //if (_customerRepository == null)
                //{
                //    _customerRepository = new CustomerRepository(db);
                //}

                //return _customerRepository;
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(db);
                }

                return _customerRepository;
            }
        }

        private GenericRepository<Acconting> _accontingRepository;

        public GenericRepository<Acconting> AccontingRepository
        {
            //get
            //{
            //    if (_accontingRepository == null)
            //    {
            //        _accontingRepository = new GenericRepository<Acconting>(db);
            //    }
            //    return _accontingRepository;
            //}
            get
            {
                if (_accontingRepository == null)
                {
                    _accontingRepository = new GenericRepository<Acconting>(db);
                }

                return _accontingRepository;
            }
        }
        //public void Save()
        //{
        //    db.SaveChanges();
        //}

        //public void Dispose()
        //{
        //    db.Dispose();
        //}
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
