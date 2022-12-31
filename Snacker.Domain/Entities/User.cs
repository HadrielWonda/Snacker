using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Domain.Entities;

    public class User
    {
        
     public Guid Id { get; set; } = Guid.NewGuid();

     public string firstName { get; set; } = null;

     public string lastName { get; set; } = null;

     public string email { get; set; } = null;

     public string password { get; set; } = null;



    }
