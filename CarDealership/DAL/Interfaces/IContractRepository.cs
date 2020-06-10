using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.DAL.Interfaces
{
    public interface IContractRepository : IDisposable
    {
        IEnumerable<Contract> GetAll();
        Contract GetByID(int id);
        void Create(Contract contract);
        void Update(Contract contract);
        void Delete(int id);
        void Save();
    }
}
