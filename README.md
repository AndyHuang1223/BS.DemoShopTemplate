# BS.DemoShopTemplate

## 環境需求

- .NET SDK：8.0 或以上
- Docker / Docker Compose（建議用於一鍵啟動 SQL Server + Redis + Web + Admin）

---

## 設定連線字串 / 環境變數

本專案在 Docker Compose 模式下，會透過 [docker-compose.yml](docker-compose.yml) 以環境變數注入：

- `ConnectionStrings__BSDemoShopConnection`（SQL Server）
- `ConnectionStrings__Redis`（Redis）

### 1) 建立 `.env` 檔（必要）

請在專案根目錄新增 `.env`，可以用範例檔 [.env.example](.env.example) 直接複製後修改：

```bash
cp .env.example .env
```

`.env` 內容至少要設定：

- `SA_PASSWORD`：SQL Server `sa` 密碼（需符合 SQL Server 密碼規範）

> 範例請參考 `.env.example`，並依自己的需求修改密碼。

---

## 使用 Docker 部署 / 本機啟動（推薦）

### 1) 啟動所有服務

在專案根目錄執行：

```bash
docker compose up -d
```

服務包含：

- `demoshop.web`（對外：`http://localhost:8800`）
- `demoshop.admin`（對外：`http://localhost:8801`）
- `sql-server-db`
- `redis`

### 2) 初始化資料庫（建議只需執行一次）

```bash
docker compose run --rm db-init
```

### 3) 常用指令

停止並移除容器：

```bash
docker compose down
```

（如需連同資料一起清除，會移除 volumes）

```bash
docker compose down -v
```

---

## 資料庫異動流程（使用 .NET CLI / EF Core）

> 常用於非 Docker、或你想在本機直接跑 `dotnet ef` 時使用。

### Code First（Migration）

1. 修改 Entity Model
2. 新增 Migration：
   - `dotnet ef migrations add <MigrationName> --project ./DemoShop.Infrastructure/ --startup-project ./DemoShop.Web/ --output-dir ./Data/Migrations`
3. 更新資料庫：
   - `dotnet ef database update --project ./DemoShop.Infrastructure/ --startup-project ./DemoShop.Web/`

### Code First From DB（Scaffolding / 反向工程）

1. 修改資料庫 Schema
2. Scaffolding：
   - `dotnet ef dbcontext scaffold "Name=ConnectionStrings:BSDemoShopConnection" Microsoft.EntityFrameworkCore.SqlServer --output-dir ../DemoShop.ApplicationCore/Entities --context-dir ../DemoShop.Infrastructure/Data --namespace DemoShop.ApplicationCore.Entities --context BSDemoShopContext --context-namespace DemoShop.Infrastructure.Data --startup-project ./DemoShop.Web --data-annotations --force`
3. 視需要調整 Repository 泛型約束（依專案實作而定）

---

## 參考

- Entity Framework Core CLI：https://learn.microsoft.com/zh-tw/ef/core/cli/dotnet
- Scaffolding (反向工程)：https://learn.microsoft.com/zh-tw/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli
