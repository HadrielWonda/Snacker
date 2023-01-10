using System.Threading;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneOf;
using Snacker.Domain.Entities;
using Snacker.Domain.Host.ValueObjects;

namespace Snacker.Application.Menus.Commands.CreateMenu;

    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand,OneOf<IError,Menu>>
    {
       private readonly IMenuRepository _menuRepository;

       public CreateMenuCommandHandler(IMenuRepository menuRepository)
       {
         _menuRepository = menuRepository;
       }
        
       public async Task<OneOf<IError,Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
       {
        
        await Task.CompletedTask;

         //1.Create Menu
         var menu = Menu.Create(
            HostId.Create(request.HostId),
            name: request.Name,
            description: request.Description,
            section: request.Sections.ConvertAll(section => MenuSection.Create(
                section.Name,
                section.Description,
                section.Items.ConvertAll(item => MenuItems.Create(
                    items.Name,
                    items.Description
                ))
            ))
         );
           
         //2. Persist Menu

         _menuRepository.Add(menu);

         //3.Return Menu

         return menu; 
       }

    }
