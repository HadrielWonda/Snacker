using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Common.Models;

namespace Snacker.Domain.Snack.ValueObjects;

    public sealed  class SnackSectionId : ValueObject
    {
       public Guid Value { get; }
       
       private SnackSectionId(Guid value)
        {
          Value = value;
        }

        public static SnackSectionId CreateUnique() 
        { 
           return new(Guid.NewGuid());
        }

       public override IEnumerable<object> GetEqualityComponents()
        {
          yield return Value;
        }
    }
