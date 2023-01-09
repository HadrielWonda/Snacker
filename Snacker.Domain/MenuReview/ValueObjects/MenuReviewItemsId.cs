using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Common.Models;

namespace Snacker.Domain.MenuReview.ValueObjects;

    public sealed  class MenuReviewItemsId : ValueObject
    {
       public Guid Value { get; }
       
       private MenuReviewItemsId(Guid value)
        {
          Value = value;
        }

        public static MenuReviewItemsId CreateUnique() 
        { 
           return new(Guid.NewGuid());
        }

       public override IEnumerable<object> GetEqualityComponents()
        {
          yield return Value;
        }
    }
