# BS.DemoShop
## Get Started
1. Use EF Core Migration DataBase(Update database).
2. Run BS.DemoShop.Web.



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