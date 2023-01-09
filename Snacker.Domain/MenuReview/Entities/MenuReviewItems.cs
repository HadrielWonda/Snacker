using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Common.Models;
using Snacker.Domain.MenuReview.ValueObjects;

namespace Snacker.Domain.MenuReview.Entities;

    public sealed class MenuReviewItems : Entity<MenuReviewItemsId>
    {
        public string Name {get; }

        public string Description {get; }

        private MenuReviewItems(MenuReviewItemsId menuReviewMenuReviewItemsId,string name,string description )
        : base(menuReviewMenuReviewItemsId) 
        {
            Name = name;
            Description = description;
        }

        public static MenuReviewItems Create(string name,string description)
        {
            return new(MenuReviewItemsId.CreateUnique(),name,description);
        }
    }
