using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Microsoft.Extensions.Configuration;
using Domain;

var services = new ServiceCollection();

#region Instanciar con new
//Intanciar DbContext de esta manera es adecuada para otros tipos de aplicaciones como las de escritorio
//var efContext = new EFLessonsContext();
//efContext.Database.EnsureCreated();
#endregion

#region Agregar un servicio (inyeccion de dependencias) con un ConnectionString como parametro
//De esta manera podemos indicarle el ConnectionString deseado
//Por preferencias personales prefiero que se configure por si solo
//services.AddDbContext<EFLessonsContext>(o => o.UseSqlServer(ConfigurationManager.ConnectionStrings["EFLessons"].ToString()));
#endregion

#region Otra manera de agregar un servicio para el DBContext
//Lo mismo que services.AddDbContext<EFLessonsContext>();
//services.AddScoped<EFLessonsContext>();
#endregion

#region La manera que me gusta para agregar servicios
//En aplicaciones web se recomienda usar inyecciones de dependencias con el ciclo de vida Scopped
//services.AddDbContext<TContext> Agrega un DBContext con ciclo de vida Scopped, que es el recomendado para aplicaciones web
//Se debe instanciar de esta manera si tenemos el metodo OnConfiguring que setea el ConnectionString
services.AddDbContext<EFLessonsContext>();
#endregion

var serviceProvider = services.BuildServiceProvider();
var efContext = serviceProvider.GetRequiredService<EFLessonsContext>();
try
{
    //Si no existe la base del connectionString, la crea
    Console.WriteLine("Can connect to db: " + efContext.Database.EnsureCreated());
}
catch (Exception ex)
{
    Console.WriteLine("Ocurrio un error al conectarse a la base de datos...");
#if DESARROLLO
    Console.WriteLine(ex.Message);
#endif
}

efContext.Database.EnsureCreated();
var newClient = new Client("pablo");

efContext.Clients.Add(newClient);
efContext.SaveChanges();


Console.WriteLine("Can connect to db: " + efContext.Database.CanConnect());