using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAccountsService
    {
        Task Login(LoginDto model);
        Task Register(RegisterDto model);
        Task Logout();
    }
}
