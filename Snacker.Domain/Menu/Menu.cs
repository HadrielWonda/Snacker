using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Common.Models;
using Snacker.Domain.Menu.ValueObjects;
using Snacker.Domain.Menu.Entities;

namespace Snacker.Domain.Menu;

    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();

        private readonly List<SnackId> _snackId = new(); 

        private readonly List<MenuReviewId> _menuReviewId = new(); 

        public string Name {get; }

        public string Description {get; }

        public float AverageRating {get; }

        public IReadOnlyList<MenuSection> Sections => _sections;




        public HostId HostIds {get;}

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds;

        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds;

        public DateTime CreatedDateTime { get; }

        public DateTime UpdatedDateTime { get; }




        private Menu(
            MenuId menuId,
            string name,
            string description,
            HostId hostId,
            DateTime createdDateTime,
            DateTime updatedDateTime
        ) : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(string name, string description, HostId hostId)
        {
            return new(
               MenuId.CreateUnique(),
               name,
               description,
               hostId,
               DateTime.UtcNow,
               DateTime.UtcNow
            );
        }
    }
