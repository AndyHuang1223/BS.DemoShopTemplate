# BS.DemoShop
## Get Started
1. Use EF Core Migration DataBase.
2. Run BS.DemoShop.Web.



## Initaial DB
### EF Core Add-Migration
```=
add-migration init -Project BS.DemoShop.Infrastructure -StartupProject BS.DemoShop.Web -OutputDir Data/Migrations
```
### EF Core Update-Database
```=
update-database -Project BS.DemoShop.Infrastructure -StartupProject BS.DemoShop.Web
```

### More
https://docs.microsoft.com/zh-tw/ef/core/cli/