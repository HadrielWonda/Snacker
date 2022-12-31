using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Application.Common.Interfaces.Persistence;

    public interface IUserRepository
    {

     User? GetUserByEmail(string email);

     void Add(User user);  

    }
