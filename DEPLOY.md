# Deploy IksBlog to Azure App Service

Production site: https://iqbalkaur.azurewebsites.net

| Resource | Name |
|----------|------|
| App Service | `iqbalkaur` |
| Resource group | `iqbalkaur_group` |
| App Service plan | Free (F1), Linux, .NET 8 |
| Azure SQL server | `iksblog-server.database.windows.net` |
| Database | `IksBlogDB` |

Do not commit `publish/`, `publish.zip`, or real SQL passwords.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli-windows) (`winget install -e --id Microsoft.AzureCLI`)
- Logged in: `az login`

## 1. Build and zip (Linux App Service)

From the repo root. Use **linux-x64** publish and **`tar`** for the zip (PowerShell `Compress-Archive` uses backslashes and breaks Linux deploy).

```powershell
dotnet publish IksBlog.Web/IksBlog.Web.csproj -c Release -r linux-x64 --self-contained false -o ./publish

Remove-Item .\publish.zip -Force -ErrorAction SilentlyContinue
tar -a -c -f publish.zip -C publish .
```

`publish/` and `publish.zip` are gitignored.

## 2. Deploy zip to App Service

```powershell
$env:Path = "C:\Program Files\Microsoft SDKs\Azure\CLI2\wbin;" + $env:Path

az webapp deploy `
  --resource-group iqbalkaur_group `
  --name iqbalkaur `
  --src-path .\publish.zip `
  --type zip
```

Startup command (already set on the app): `dotnet IksBlog.Web.dll`

## 3. Database connection (Azure Portal or CLI)

Use **one** source of truth. If both are set, the **Connection strings** blade wins over application settings.

**Recommended:** App Service → **Environment variables** → **Connection strings**

- Name: `DefaultConnection`
- Type: **SQLAzure**
- Value:  
  `Server=iksblog-server.database.windows.net;Database=IksBlogDB;User Id=<user>;Password=<password>;TrustServerCertificate=True;`

Do not leave placeholder values like `YOUR_ADMIN_USER` / `YOUR_PASSWORD`.

Optional equivalent (application setting):

- Name: `ConnectionStrings__DefaultConnection`
- Same connection string value

**Azure SQL networking:** allow **Azure services** (and your client IP when running migrations from your PC).

Save settings and restart:

```powershell
az webapp restart --resource-group iqbalkaur_group --name iqbalkaur
```

## 4. Apply EF migrations (from your machine)

Only needed when new migrations exist in `IksBlog.Data/Migrations/`.

```powershell
dotnet ef database update `
  --project IksBlog.Data `
  --startup-project IksBlog.Web `
  --connection "Server=iksblog-server.database.windows.net;Database=IksBlogDB;User Id=<user>;Password=<password>;TrustServerCertificate=True;"
```

Admin user seeding runs on app startup (`DataSeeder` in `Program.cs`), not during `ef database update`. Default seed: `admin` / `ChangeMe123!` if the `Login` table is empty.

## 5. Start / verify

```powershell
az webapp start --resource-group iqbalkaur_group --name iqbalkaur

az webapp show --resource-group iqbalkaur_group --name iqbalkaur --query state -o tsv
```

Browse https://iqbalkaur.azurewebsites.net

Logs:

```powershell
az webapp log tail --resource-group iqbalkaur_group --name iqbalkaur
```

## Troubleshooting

| Symptom | Likely fix |
|---------|------------|
| `Login failed for user 'YOUR_ADMIN_USER'` | Update **Connection strings** → `DefaultConnection`; remove placeholders |
| Zip deploy / rsync `Invalid argument (22)` | Recreate zip with `tar`, not `Compress-Archive` |
| `QuotaExceeded` / 403 app stopped | Free plan daily limit; wait or scale up; `az webapp start` |
| Deploy timeout “site failed to start” | Check log stream; fix DB connection; confirm quota |
| `oryx-manifest.toml` not found | Harmless for zip deploy; ignore |

## Local development

Local SQL uses `Trusted_Connection` in `appsettings.json` / LocalDB in `appsettings.Development.json`. Never commit production passwords to git.
