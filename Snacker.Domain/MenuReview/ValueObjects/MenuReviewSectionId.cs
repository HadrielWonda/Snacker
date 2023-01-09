using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Common.Models;

namespace Snacker.Domain.MenuReview.ValueObjects;

    public sealed  class MenuReviewSectionId : ValueObject
    {
       public Guid Value { get; }
       
       private MenuReviewSectionId(Guid value)
        {
          Value = value;
        }

        public static MenuReviewSectionId CreateUnique() 
        { 
           return new(Guid.NewGuid());
        }

       public override IEnumerable<object> GetEqualityComponents()
        {
          yield return Value;
        }
    }
