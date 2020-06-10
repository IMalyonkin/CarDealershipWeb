using CarDealership.DAL.Interfaces;
using CarDealership.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CarDealership.DAL.Repositories
{
    public class ClientRepository : IClientRepository, IDisposable
    {
        private CarsContext context;

        public ClientRepository(CarsContext context)
        {
            this.context = context;
        }

        public IEnumerable<Client> GetAll()
        {
            return context.Client.ToList();
        }

        public Client GetByID(int id)
        {
            return context.Client.Find(id);
        }

        public void Create(Client client)
        {
            context.Client.Add(client);
        }

        public void Delete(int id)
        {
            Client client = context.Client.Find(id);
            context.Client.Remove(client);
        }

        public void Update(Client client)
        {
            context.Entry(client).State = EntityState.Modified;
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
