using Proiect.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.BLL.Interfaces
{
    public interface ITokenHelper
    {
        Task<String> CreateAccessToken(User _User);
        

    }
}
