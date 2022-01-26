using Proiect.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Donors = new DonorRepository(context);
            Patients = new PatientRepository(context);
            /*Medicines = new MedicineRepository(context);
            Addresses = new AddressRepository(context);
            Doctors = new DoctorRepository(context);*/
        }

        public IDonorRepository Donors { get; private set; }
        public IPatientRepository Patients { get; private set; }
        public IMedicineRepository Medicines { get; private set; }
        public IAddressRepository Addresses { get; private set; }
        public IDoctorRepository Doctors { get; private set; }


        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
