using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.DAL.Interfaces
{
    public interface IClientRepository : IDisposable
    {
        IEnumerable<Client> GetAll();
        Client GetByID(int id);
        void Create(Client client);
        void Update(Client client);
        void Delete(int id);
        void Save();
    }
}
