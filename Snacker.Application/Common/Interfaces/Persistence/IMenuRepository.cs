using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Menu;

namespace Snacker.Application.Common.Interfaces.Persistence;

    public interface IMenuRepository
    {
        void Add(Menu menu);
    }
