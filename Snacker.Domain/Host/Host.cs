using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Domain.Host;

    public class Host
    {
        private readonly List<HostSection> _sections = new();

        public string Name {get; }

        public string Description {get; }

        public float AverageRating {get; }

        public IReadOnlyList<HostSection> Sections => _sections
    }
