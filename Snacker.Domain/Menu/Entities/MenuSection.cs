using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Menu.ValueObjects;

namespace Snacker.Domain.Menu.Entities;

    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItems> _items = new();

        public string Name {get; }

        public string Description {get; }

        public IReadOnlyList<MenuItems> Items => _items.AsReadOnly(); //or ToList.. cant pick


        private MenuSection(MenuSectionId MenuSectionId,string name,string description)
        :base(menuSectionId)
        {
          Name = name;
          Description = description;
        }

        public static MenuSection Create(string name,string description )
        {
            return new(
                MenuSectionId.CreateUnique(),
                name,
                description
            );
        }
    }
