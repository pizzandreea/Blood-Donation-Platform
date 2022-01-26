using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDonorRepository Brands { get; }
        IPatientRepository Categories { get; }
        IMedicineRepository Orders { get; }
        IAddressRepository Products { get; }
        IDoctorRepository Reviews { get; }

        void Complete();
    }
}
