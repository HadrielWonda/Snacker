using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Application.Menus.Commands.CreateMenu;
using Snacker.Contracts.Menus;
using Snacker.Domain.Menu;
using Mapster;

using MenuSection = Snacker.Domain.Menu.Entities.MenuSection;
using MenuItems = Snacker.Domain.Menu.Entities.MenuItems;

namespace Snacker.Api.Common.Mapping;

    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request,string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId,src => src.HostId)
            .Map(dest => dest, src => src.Request);

            config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id,src => src.Id.Value)
            .Map(dest => dest.AverageRating,src => src.AverageRating.NumRatings > 0 ? src.AverageRating.Value: null)
            .Map(dest => dest.HostId, src => src.Id.Value)
            .Map(dest => dest.SnackIds,src => src.SnackIds.Select(snackId => snackId.Value))
            .Map(dest => dest.MenuReviewIds,src => src.MenuReviewIds.Select(menuId => menuId.Value));


            config.NewConfig<MenuSection,MenuSectionResponse>()
            .Map(dest => dest.Id,src => src.Id.Value);

             config.NewConfig<MenuItems,MenuItemsResponse>()
            .Map(dest => dest.Id,src => src.Id.Value);
        }
    }
