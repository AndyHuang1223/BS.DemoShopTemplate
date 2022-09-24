# BS.DemoShop
## Get Started
1. Ensure your connection string(appsettings.json).
2. Migration Database : In development environment will drop and create new db then insert seed data, in production environment will migrate all migrations and insert seed data.
3. Run BS.DemoShop.Web.



## EF Core CLI

### EF Core Update-Database

```
dotnet ef database update -p BS.DemoShop.Infrastructure -s BS.DemoShop.Web
```

### EF Core Add-Migration

```
dotnet ef migrations add <your migration name> -p BS.DemoShop.Infrastructure -s BS.DemoShop.Web -o Data/Migrations
```

### More
https://docs.microsoft.com/zh-tw/ef/core/cli/
