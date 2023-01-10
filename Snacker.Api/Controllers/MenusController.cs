using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Snacker.Contracts.Menus;
using MediatR;

namespace Snacker.Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        private readonly ILogger<MenusController> _logger;
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public MenusController(ILogger<MenusController> logger,IMapper _mapper,ISender _mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }
           

        [HttpPost]
        public async Task<IActionResult> CreateMenu(
            CreateMenuRequest request,
            string hostId
        )
        {
            var command = _mapper.Map<CreateMenuCommand>((request,hostId));

            var createMenuResult = await _mediator.Send(command);
            return createMenuResult.Match(
                menu => Ok(_mapper.Map<MenuResponse>(menu))//CreatedAtAction(nameof(GetMenu), new (hostId, menuId = menu.Id), menu )
                error => Problem(error)
            );
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
       // public IActionResult Error()
       // {
            //return View("Error!");
      //  }
    }
}