using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Contracts.Menus;


    public record MenuResponse(
      string Id,
      string Name,
      string Description,
      float? AverageRating,
      List<MenuSectionResponse> Sections,
      string HostId,
      List<string> DinnerIds,
      List<string> MenuReviewIds,
      DateTime CreatedDateTime,
      DateTime UpdatedDateTime
    );
    
    public record MenuSectionResponse(
        string Id,
        string Name,
        string Description,
        List<MenuItemsResponse> Items
    );

    public record MenuItemsResponse(
      string Id,
      string Name,
      string Description
    );
