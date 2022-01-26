using Proiect.DAL.Entities;
using Proiect.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository 
    {
        public AddressRepository(AppDbContext context) : base(context)
        {
        }
    }
}
