using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.MenuReview.ValueObjects;

namespace Snacker.Domain.ReviewMenuReview.Entities;

    public sealed class ReviewMenuReviewSection : Entity<ReviewMenuReviewSectionId>
    {
        private readonly List<ReviewMenuReviewItems> _items = new();

        public string Name {get; }

        public string Description {get; }

        public IReadOnlyList<ReviewMenuReviewItems> Items => _items.AsReadOnly(); //or ToList.. cant pick


        private ReviewMenuReviewSection(ReviewMenuReviewSectionId ReviewMenuReviewSectionId,string name,string description)
        :base(ReviewMenuReviewSectionId)
        {
          Name = name;
          Description = description;
        }

        public static ReviewMenuReviewSection Create(string name,string description )
        {
            return new(
                ReviewMenuReviewSectionId.CreateUnique(),
                name,
                description
            );
        }
    }
