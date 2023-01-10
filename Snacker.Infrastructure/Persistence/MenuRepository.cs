using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Infrastructure.Persistence;

    public class MenuRepository : IMenuRepository
    {
        private static readonly List<Menu> _menu = new();

        public void Add(Menu menu)
        {
          _menu.Add(menu);
        }
    }
