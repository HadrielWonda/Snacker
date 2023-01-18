using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Infrastructure.Persistence.Repositories;

    public class MenuRepository : IMenuRepository
    {
       ///<summary> Got rid of the In-Memory use to prioritize the incoming db
       ///  private static readonly List<Menu> _menu = new();
       /// </summary>
         

        private readonly SnackerDbContext _dbContext;

        public MenuRepository(SnackerDbContext dbContext)
        {
          _dbContext = dbContext;
        }

        public void Add(Menu menu)
        {
          _dbContext.Add(menu);
          _dbContext.SaveChanges();
        }
    }
