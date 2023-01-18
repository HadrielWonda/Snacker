using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Menu.ValueObjects;
using Snacker.Domain.Host.ValueObjects;

namespace Snacker.Infrastructure.Persistence.Configurations;

    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);
            ConfigureMenuSectionsTable(builder);
            ConfigureMenuDinnerIdsTable(builder);
            ConfigureMenuReviewIdsTable(builder);
        }


        public void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<MenuDinnerIds> builder)
        {
           builder.OwnsMany(m => m.DinnerIds , dib =>
           {
             dib.ToTable("MenuDinnerIds");

             dib.WithOwner().HasForeignKey("MenuId");

             dib.HasKey("Id");

             dib.Property(d => d.Value)
               .HasColumnName("DinnerId")
               .ValueGeneratedNever();
           }
           );

         builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))
           .SetPropertyAccessMode(PropertyAccessMode.Field);
        }


        public void ConfigureMenuReviewIdsTable(EntityTypeBuilder<MenuReviewIds> builder)
        {
            builder.OwnsMany(r => r.MenuReviewIds , mrb =>
           {
             mrb.ToTable("MenuReviewIds");

             mrb.WithOwner().HasForeignKey("MenuId");

             mrb.HasKey("Id");

             mrb.Property(d => d.Value)
               .HasColumnName("ReviewId")
               .ValueGeneratedNever();
           }
           );

         builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))
           .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
         
        public void ConfigureMenuSectionsTable(EntityTypeBuilder<MenuSection> builder)
        {
               builder.OwnsMany(m => m.Sections,sb =>
               {
                 sb.ToTable("MenuSections");

                 sb.WithOwner().HasForeignKey("MenuId");

                 sb.HasKey(/*s => new[] {s.Id,}*/ "Id","MenuId");

                 sb.Property(s => s.Id)
                  .HasColumnName("MenuId")
                  .ValueGeneratedNever()
                  .HasConversion(
                     id => id.Value,
                     value => MenuSectionId.Create(value)
                  );

                 sb.Property(s => s.Name)
                  .HasMaxLength(100);

                  sb.Property(s => s.Description)
                  .HasMaxLength(400);

                  sb.OwnsMany(s => s.Items, ib =>{
                    ib.ToTable("MenuItems");

                    ib.WithOwner().HasForeignKey(nameof(MenuItem.Id), "MenuSectionId","MenuId");

                    ib.HasKey("MenuSectionId","MenuId");

                    ib.Property(i => i.Id)
                     .HasColumnName("MenuItemId")
                     .ValueGeneratedNever()
                     .HasConversion(
                        id => id.Value,
                        value => MenuItemId.Create(value)
                     );

                      ib.Property(i => i.Name)
                       .HasMaxLength(100);

                      ib.Property(i => i.Description)
                      .HasMaxLength(400);

                  }
                  );

                  sb.Navigation(s => s.Items)
                     .Metadata.SetField("items");

                  sb.Navigation(s => s.Items)
                     .UsePropertyAccessMode(PropertyAccessMode.Field);
               }
               );

               builder.Metadata.FindNavigation(nemeof(Menu.Sections))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }



        public void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value)
            );

            builder.Property(m => m.Name)
            .HasMaxLength(100);

            builder.Property(m => m.Description)
            .HasMaxLength(400);

            builder.OwnsOne(m => m.AverageRating, /*ab =>
            {
              ab.Property(a => a.Value)
              .HasColumnName("Ratings");
            }*/
            );

            builder.Property(m => m.HostId)
             .HasConversion(
                id => id.Value,
                value => HostId.Create(value)
            );

        }

      
    }
