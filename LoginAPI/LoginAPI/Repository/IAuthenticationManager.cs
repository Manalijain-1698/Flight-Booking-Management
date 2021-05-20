using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Repository
{
    public interface IAuthenticationManager
    {
        public string Authenticate(string username, string password);
        int GetUserid(string email);

    }
}
