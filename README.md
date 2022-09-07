# BS.DemoShop
## Get Started
1. Make sure your connection string(appsettings.json).
2. Migration Database : In development environment will drop and create new db then insert seed data, in production environment will migrate all migrations and insert seed data.
3. Run BS.DemoShop.Web.



## EF Core CLI

### EF Core Update-Database
```=powershall
update-database -Project BS.DemoShop.Infrastructure -StartupProject BS.DemoShop.Web
```

### EF Core Add-Migration
```=powershall
add-migration init -Project BS.DemoShop.Infrastructure -StartupProject BS.DemoShop.Web -OutputDir Data/Migrations
```

### More
https://docs.microsoft.com/zh-tw/ef/core/cli/