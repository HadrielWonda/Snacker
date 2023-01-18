using System.Reflection.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Snacker.Infrastructure.Persistence;

    public class SnackerDbContext : DbContext
    {
        public SnackerDbContext(DbContextOptions<SnackerDbContext> options)
        : base(options)
        {
            
        } 


        public DbSet<Menu> Menus { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder
              .ApplyConfigurationsFromAssembly(typeof(SnackerDbContext).Assembly);



            base.OnModelCreating(modelBuilder);
        }

    }
