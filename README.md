# BS.DemoShop
## EF Core Add-Migration
```=
add-migration init -Project BS.DemoShop.Infrastructure -StartupProject BS.DemoShop.Web -OutputDir Data/Migrations
```
## EF Core Update-Database
```=
update-database -Project BS.DemoShop.Infrastructure -StartupProject BS.DemoShop.Web
```