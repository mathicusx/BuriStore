namespace BuriStore.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BuriStore.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Laptops" });
            await dbContext.Categories.AddAsync(new Category { Name = "Mobile Phones" });
            await dbContext.Categories.AddAsync(new Category { Name = "Desktops" });
            await dbContext.Categories.AddAsync(new Category { Name = "Gaming Accesories" });
            await dbContext.Categories.AddAsync(new Category { Name = "Components" });

            dbContext.SaveChanges();
        }
    }
}
