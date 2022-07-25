using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Persistence
{
    internal class DesignTimeDbContextFactory 
        //: IDesignTimeDbContextFactory<EFLessonsContext> //Comparar comentando y descomentando toda esta linea
    {
        public EFLessonsContext CreateDbContext(string[] args)
        {
            Console.WriteLine("DesignTimeDbContextFactory");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                #if DESARROLLO
                .AddJsonFile("appsettings.Desarrollo.json")
                #elif TESTING
                .AddJsonFile("appsettings.Testing.json")
                #elif PRODUCCION
                .AddJsonFile("appsettings.Produccion.json")
                #endif
                .Build();

            var builder = new DbContextOptionsBuilder<EFLessonsContext>();
            var connectionString = configuration.GetConnectionString("EFLessons");
            Console.WriteLine(connectionString);
            builder.UseSqlServer(connectionString);
            return new EFLessonsContext(builder.Options);
        }
    }
}
