using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Web;
namespace Persistence
{
    public class EFLessonsContext : DbContext {

        //Debe ejecutar el constructor de la superclase
        public EFLessonsContext() : base() {
            Console.WriteLine("Constructor vacio");
        }

        //Debe ejecutar el constructor de la superclase
        public EFLessonsContext(DbContextOptions<EFLessonsContext> options) : base(options) {
            Console.WriteLine("Constructor EFLessonsContext(DbContextOptions<EFLessonsContext> options): base(options)");
        }

        // Con esta declaracion se quitan los warnings que indican que pueden ser null
        // Nunca seran null porque EF se asegura de inicializar todos los DbSet
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
        public DbSet<Product> Products => Set<Product>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            Console.WriteLine($"[OnConfiguring] Context is configured: {optionsBuilder.IsConfigured}");
            if (!optionsBuilder.IsConfigured)
            {
                Console.WriteLine("Configuring DBContext instance");

                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
#if DESARROLLO
                    .AddJsonFile("appsettings.Desarrollo.json")
#elif DEBUG
                    .AddJsonFile("appsettings.Desarrollo.json")
#elif TESTING
                    .AddJsonFile("appsettings.Testing.json")
#elif PRODUCCION
                    .AddJsonFile("appsettings.Produccion.json")
#endif
                    .Build();
                var connectionstring = configuration.GetConnectionString("EFLessons");
                Console.WriteLine($"ConnectionString: {connectionstring}");
                optionsBuilder.UseSqlServer(connectionstring);
                
                //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["EFLessons"].ToString()); No compatible {System.Configuration.ConfigurationManager}
                //optionsBuilder.UseSqlServer("Data source..") ; hardcodear la conexion no seria correcto, pero para este ejemplo no estaria mal
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
        }
    }
}
