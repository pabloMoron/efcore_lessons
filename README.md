# Acerca de mi 
[Perfil](https://github.com/pabloMoron/profile)

## Acerca de este proyecto
Este es un proyecto personal, que forma parte de mi [portfolio](https://github.com/pabloMoron/profile#portfolio-personal).

Este proyecto es un ejemplo de Entity Framework Core con .NET 6.

# ¿Qué es Entity Framework Core?

Entity Framework Core es un ORM para aplicaciones .NET desarrollado por Microsoft, permite a los desarrolladores trabajar las estructuras de datos en clases para poder trabajar la informacion con objetos de .NET.

## Algunos Features de Entity Framework Core

- Cross-platform: EF Core es un framework que funciona en Windows, Linux o Mac.
- Transacciones: EF usa transacciones por defecto al realizar consultas a la base de datos. Adicionalmente permite modificar la gestion de transacciones en caso de necesitar algo más específico.
- Cache: EF Core incluye una cache que previene sobrecargas de la base de datos en caso de recibir una misma consulta numerosas veces.
- Configuracion: EF Core permite ajustar los modelos generados añadiendo Data Annotatios para sobreescribir el comportamiento por defecto.
- Migraciones: EF Core incluye comandos para generar y ejecutar migraciones, para modificar el esquema de la base de datos.
- Consultas: EF Core permite usar consultas LINQ como opción alternativa para consulta de datos. El gestor de la base de datos se encargará de traducir las consultas LINQ al lenguaje con que trabaje nuestra base de datos. Por último EF tambien permite ejecutar consultas nativas o 'raw'.


## Codefirst
La aproximacion codefirst consiste en codificar primero nuestras clases del dominio, luego EF crea la base de datos, ahorrandonos los scripts de creacion de tablas. 


### Configuraciones
- Un connectionString
- Las clases del dominio
- Una clase que herede de DBContext, abstrae un contexto dentro de un dominio.

En domain driven design un dominio está dividido en subdominios más pequeños conocidos como bounded contexts. Por lo tanto en algunos casos será conveniente tener más de 1 DBContext.

![](./Images/context_ddd.jpg)

#### La clase DBContext
// TODO

- DBSets
- Constructores
- OnConfiguring
- Es el punto de entrada de Add-Migration o dotnet ef migration add

Si la gestion del contexto y migraciones estan en un proyecto de biblioteca de clases se necesita implementar adicionalmente

- IDesignTimeDbContextFactory
    - Hace un bypass al constructor del DBContext


- Instalar el paquete Microsoft.Extensions.Configuration.Json

#### ¿Por qué es necesario el paquete Microsoft.Extensions.Configuration.Json?
 // TODO

 - Error al leer connection string con el paquete System.Configuration.ConfigurationManager 

#### Posibles errores
// TODO
(Revisar proyecto predeterminado)
### Migraciones
// TODO
<pre>
//Luego de definir nuestro DBContext se lanza el siguiente comando, que toma nuestro DBContext y lo traduce a una clase de tipo Migration

add-migration {name}

//Ejecuta las migraciones pendientes

update-database
</pre>

## Modelfirst

// TODO

### Configuraciones
// TODO
<pre>
Scaffold-DbContext -Connection "{connection_string}" -Provider "Microsoft.EntityFrameworkCore.SQLServer" -outputdir {directorio_salida} -context {context}
</pre>
