using Domain;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.Extensions.Configuration;
namespace Persistence
{
    public class AppDBContext: DbContext
    {

        //Debe ejecutar el constructor de la superclase
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine($"OnConfiguring: {optionsBuilder.IsConfigured}");
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("") ;
        }

    }
}
