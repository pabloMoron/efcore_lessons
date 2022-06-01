using Persistence;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

var services = new ServiceCollection();
//var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
//Console.WriteLine(optionsBuilder.IsConfigured);
//optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["EFLessons"].ToString());
//Console.WriteLine(optionsBuilder.IsConfigured);
//var dbContext = new AppDBContext(optionsBuilder.Options);
services.AddDbContext<AppDBContext>(o => o.UseSqlServer(ConfigurationManager.ConnectionStrings["EFLessons"].ToString()));
//services.AddSqlServer<AppDBContext>(ConfigurationManager.ConnectionStrings["EFLessons"].ToString());
//services.AddScoped<DbContext, AppDBContext>();
try
{
    //Si no existe la base del connectionString, la crea
    //Console.WriteLine("Can connect to db: " + context.Database.EnsureCreated());
}
catch (Exception ex)
{
    Console.WriteLine("Ocurrio un error al conectarse a la base de datos...");
#if DEBUG
    Console.WriteLine(ex.Message);
#endif
}
var serviceProvider = services.BuildServiceProvider();
var dbContext = serviceProvider.GetRequiredService<AppDBContext>();
Console.WriteLine("Can connect to db: " + dbContext.Database.EnsureCreated());

Console.WriteLine(ConfigurationManager.AppSettings["test"]);
Console.WriteLine(ConfigurationManager.AppSettings["test2"]);
Console.WriteLine(ConfigurationManager.ConnectionStrings["EFLessons"]);
Console.WriteLine("Hello, World!");


