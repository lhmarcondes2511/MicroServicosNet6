using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(){}
        
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options){}

        public DbSet<Product> Products { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            for(int i = 2; i < 15; i++)
            {
                modelBuilder.Entity<Product>().HasData(new Product
                {
                    Id = i,
                    Name = "Name" + i,
                    Price = new decimal(10 * i),
                    Description = "Description" + i,
                    ImageURL = "https://www.google.com/" + i,
                    CategoryName = "Category" + i,
                });
            }
        }
    }
}
