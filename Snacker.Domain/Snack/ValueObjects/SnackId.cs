using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Common.Models;

namespace Snacker.Domain.Snack.ValueObjects;

    public sealed  class SnackId : ValueObject
    {
       public Guid Value { get; }
       
       private SnackId(Guid value)
        {
          Value = value;
        }

        public static SnackId CreateUnique() 
        { 
           return new(Guid.NewGuid());
        }

       public override IEnumerable<object> GetEqualityComponents()
        {
          yield return Value;
        }
    }
