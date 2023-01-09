using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Common.Models;

namespace Snacker.Domain.Menu.ValueObjects;

    public sealed  class MenuItemsId : ValueObject
    {
       public Guid Value { get; }
       
       private MenuItemsId(Guid value)
        {
          Value = value;
        }

        public static MenuItemsId CreateUnique() 
        { 
           return new(Guid.NewGuid());
        }

       public override IEnumerable<object> GetEqualityComponents()
        {
          yield return Value;
        }
    }
