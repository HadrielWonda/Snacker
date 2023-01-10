using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneOf;
using MediatR;

namespace Snacker.Application.Menus.Commands.CreateMenu;

    public record CreateMenuCommand(
        string HostId,
        string Name,
        string Description,
        List<MenuSectionCommand> Sections,
        string HostId
    ): IRequest<OneOf<IError,MenuResponse>>;

     public record MenuSectionCommand(
        string Name,
        string Description,
        List<MenuItemsCommand> Items
    );

    public record MenuItemsCommand(
        string Name,
        string Description
    );
    
