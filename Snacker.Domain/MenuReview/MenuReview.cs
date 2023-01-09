using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Domain.MenuReview;

    public class MenuReview
    {
        private readonly List<MenuReviewSection> _sections = new();

        public string Name {get; }

        public string Description {get; }

        public float AverageRating {get; }

        public IReadOnlyList<MenuReviewSection> Sections => _sections
    }
