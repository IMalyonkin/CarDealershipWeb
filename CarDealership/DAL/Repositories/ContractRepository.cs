using CarDealership.DAL.Interfaces;
using CarDealership.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.DAL.Repositories
{
    public class ContractRepository : IContractRepository, IDisposable
    {
        private CarsContext context;

        public ContractRepository(CarsContext context)
        {
            this.context = context;
        }

        public IEnumerable<Contract> GetAll()
        {
            return context.Contract.ToList();
        }

        public Contract GetByID(int id)
        {
            return context.Contract.Find(id);
        }

        public void Create(Contract contract)
        {
            context.Contract.Add(contract);
        }

        public void Delete(int id)
        {
            Contract contract = context.Contract.Find(id);
            context.Contract.Remove(contract);
        }

        public void Update(Contract contract)
        {
            context.Entry(contract).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
