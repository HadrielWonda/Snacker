using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Contracts.Menus;

    public record CreateMenuRequest(
        string Name,
        string Description,
        List<MenuSection> Sections
    );

    public record MenuSection(
        string Name,
        string Description,
        List<MenuItems> Items
    );

    public record MenuItems(
        string Name,
        string Description
    );
    
