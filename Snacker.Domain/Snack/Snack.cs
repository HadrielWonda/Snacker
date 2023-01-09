using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Domain.Snack;

    public class Snack
    {
        private readonly List<Snack> _sections = new();

        public string Name {get; }

        public string Description {get; }

        public float AverageRating {get; }

        public IReadOnlyList<Snack> Sections => _sections
    }
