using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Common.Models;

namespace Snacker.Domain.Menu.ValueObjects;

    public sealed  class MenuSectionId : ValueObject
    {
       public Guid Value { get; }
       
       private MenuSectionId(Guid value)
        {
          Value = value;
        }

        public static MenuSectionId CreateUnique() 
        { 
           return new(Guid.NewGuid());
        }

       public override IEnumerable<object> GetEqualityComponents()
        {
          yield return Value;
        }
    }
