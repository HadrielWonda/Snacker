using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Common.Models;
using Snacker.Domain.Menu.ValueObjects;

namespace Snacker.Domain.Menu.Entities;

    public sealed class MenuItems : Entity<MenuItemsId>
    {
        public string Name {get; }

        public string Description {get; }

        private MenuItems(MenuItemsId menuItemsId,string name,string description )
        : base(menuItemsId) 
        {
            Name = name;
            Description = description;
        }

        public static MenuItems Create(string name,string description)
        {
            return new(MenuItemsId.CreateUnique(),name,description);
        }



    #pragma warning disable CS8618

      private MenuItems()
      {
        
      }

    #pragma warning restore CS8618
    }
