using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDonorRepository Donors { get; }
        IPatientRepository Patients { get; }
        IMedicineRepository Medicines { get; }
        IAddressRepository Addresses { get; }
        IDoctorRepository Doctors { get; }

        void Complete();
    }
}
