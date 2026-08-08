

# BS.DemoShop
## Configuración del entorno
1. SDK: .NET 7.0 (o superior).
2. Configuración de la cadena de conexión: Modifique `appsettings.json` o `user secrets (sectets.json)` (Referencia: [Almacenar de forma segura las contraseñas de la aplicación durante el desarrollo en ASP.NET Core](https://learn.microsoft.com/zh-tw/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows)).
3. Migrar (actualizar) la base de datos: 
	- Usando .NET Core CLI: `dotnet ef database update --project ./DemoShop.Infrastructure/ --startup-project ./DemoShop.Web/`.
	- Usando PMC de Visual Studio (proyecto predeterminado: DemoShop.Infrastructure): `Update-Database`.

## Flujo de cambios en la base de datos (usando .NET Core CLI)
Se recomienda utilizar el método Scaffold para generar por primera vez las Entidades y el DbContext; al migrar la base de datos, utilice luego el método Migration para actualizar las bases de datos en otros entornos.

### Code First
1. Modifique el modelo de entidad (Entity Model).
2. Agregar registro de cambio de migración: Comando `dotnet ef migrations add <Migration name> --project ./DemoShop.Infrastructure/ --startup-project ./DemoShop.Web/ --output-dir ./Data/Migrations`.
3. Migrar (actualizar) la base de datos: `dotnet ef database update --project ./DemoShop.Infrastructure/ --startup-project ./DemoShop.Web/`.

### Code First From DB (Scaffolding)
1. Modifique el esquema (Schema) de la base de datos.
2. Scaffolding de la base de datos: `dotnet ef dbcontext scaffold "Name=ConnectionStrings:BSDemoShopConnection" Microsoft.EntityFrameworkCore.SqlServer --output-dir ../DemoShop.ApplicationCore/Entities --context-dir ../DemoShop.Infrastructure/Data --namespace DemoShop.ApplicationCore.Entities --context BSDemoShopContext --context-namespace DemoShop.Infrastructure.Data --startup-project ./DemoShop.Web --data-annotations --force`.
3. Modifique las restricciones genéricas de `IRepository<T>` y `EfRepository<T>`: Cambie `BaseEntity` por `class` (si no se modifica, la compilación fallará).

## Otros
- [Referencia de herramientas de Entity Framework Core - .NET Core CLI](https://learn.microsoft.com/zh-tw/ef/core/cli/dotnet).
- [Scaffolding (ingeniería inversa)](https://learn.microsoft.com/zh-tw/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli).
