using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Snack.ValueObjects;

namespace Snacker.Domain.Snack.Entities;

    public sealed class SnackSection : Entity<SnackSectionId>
    {
        private readonly List<SnackItems> _items = new();

        public string Name {get; }

        public string Description {get; }

        public IReadOnlyList<SnackItems> Items => _items.AsReadOnly(); //or ToList.. cant pick


        private SnackSection(SnackSectionId SnackSectionId,string name,string description)
        :base(SnackSectionId)
        {
          Name = name;
          Description = description;
        }

        public static SnackSection Create(string name,string description )
        {
            return new(
                SnackSectionId.CreateUnique(),
                name,
                description
            );
        }
    }
