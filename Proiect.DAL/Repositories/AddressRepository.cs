using Proiect.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Repositories
{
    public class AddressRepository : Repository<Address>
    {
        public AddressRepository(AppDbContext context) : base(context)
        {
        }
    }
}
