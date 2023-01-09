using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Common.Models;

namespace Snacker.Domain.Host.ValueObjects;

    public sealed  class HostSectionId : ValueObject
    {
       public Guid Value { get; }
       
       private HostSectionId(Guid value)
        {
          Value = value;
        }

        public static HostSectionId CreateUnique() 
        { 
           return new(Guid.NewGuid());
        }

       public override IEnumerable<object> GetEqualityComponents()
        {
          yield return Value;
        }
    }
