# BS.DemoShop
## 環境設定
1. SDK : .NET 8.0(或以上)。
2. 連線字串設定 : 修改`appsettings.json`或者`使用使用者密碼(sectets.json)`(參考資料:[在 ASP.NET Core 中開發中安全儲存應用程式密碼](https://learn.microsoft.com/zh-tw/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows))。
3. 遷移(更新)資料庫 : 
	- 使用.Net Core CLI : `dotnet ef database update --project ./DemoShop.Infrastructure/ --startup-project ./DemoShop.Web/`。
	- 使用Visual Studio PMC(預設專案為DemoShop.Infrastructure) : `Update-Database`。

## 資料庫異動流程(使用.Net Core CLI)
以下兩種方式建議第一次建立Entity及DbContext時可以使用Scaffold方式還原；遷移資料庫時再使用Migration的方式更新到其他環境的資料庫。

### Code First
1. 修改Entity Model。
2. 新增Migration異動紀錄 : 指令 `dotnet ef migrations add <Migration name> --project ./DemoShop.Infrastructure/ --startup-project ./DemoShop.Web/ --output-dir ./Data/Migrations`。
3. 遷移(更新)資料庫 : `dotnet ef database update --project ./DemoShop.Infrastructure/ --startup-project ./DemoShop.Web/`。

### Code First From DB(Scaffolding)
1. 修改資料庫Schema。
2. Scaffolding資料庫 : `dotnet ef dbcontext scaffold "Name=ConnectionStrings:BSDemoShopConnection" Microsoft.EntityFrameworkCore.SqlServer --output-dir ../DemoShop.ApplicationCore/Entities --context-dir ../DemoShop.Infrastructure/Data --namespace DemoShop.ApplicationCore.Entities --context BSDemoShopContext --context-namespace DemoShop.Infrastructure.Data --startup-project ./DemoShop.Web --data-annotations --force`。
3. 修改`IRepository<T>`及`EfRepository<T>`的泛型約束 : 將`BaseEntity`修改為`class`(沒修改的話會無法建置)。

---
## 使用 Docker 部署
1. 使用 `docker compose up -d` 啟動服務。
2. 使用 `docker compose run --rm db-init` 初始化資料庫，完成後會刪除容器。

## 其他
- [Entity Framework Core 工具參考 - .NET Core CLI](https://learn.microsoft.com/zh-tw/ef/core/cli/dotnet)。
- [Scaffolding (反向工程)](https://learn.microsoft.com/zh-tw/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli)。