# E-COMMERCE

A Razor Pages e-commerce application built with .NET 8 and C# 12. This repository provides a storefront, merchant/admin portal, localization, permission-based authorization, dynamic script support, reporting, and extensibility points for payments and shipping.

Table of contents
- Project overview
- Features (detailed)
- Architecture & important components
- Setup (dev) — step-by-step
- Localization and texts
- Authorization & permissions (common pitfall + fix)
- Development workflows & recommended practices
- Testing, CI/CD, and deployment
- Project layout
- Troubleshooting & diagnostics
- Contributing
- License

Project overview
- Framework: .NET 8 (C# 12)
- UI: Razor Pages (server-side)
- Purpose: Provide a composable storefront and admin portal with role/permission controls, localization, and modular extensions for payments, shipping, and reporting.
- Example model: `E-COMMERCE\Models\DailySalesViewModel.cs` — used by reporting pages/APIs.

Features (detailed)
- Product catalog
  - CRUD for products, categories, attributes and images.
  - Product variants, pricing rules, inventory basics.
  - Search & filtering endpoints/pages.
- Cart & checkout
  - Session-backed shopping cart.
  - Multi-step checkout: address, shipping, payment.
  - Pluggable payment providers (abstract integration layer).
- Orders & fulfillment
  - Order lifecycle management: placed, paid, shipped, cancelled, refunded.
  - Order history and exports (CSV/Excel).
- Customers & accounts
  - Customer profiles, addresses, order history.
  - Account management and password reset flows.
- Admin / Merchant portal
  - Product management UI, order management, reports, and user/role management.
  - Role and permission assignment UI.
- Reporting & analytics
  - Prebuilt reports (daily/weekly/monthly sales).
  - Models such as `DailySalesViewModel` for charting or tables.
- Localization & texts
  - Base texts and JSON-based localization files loaded at startup (see Localization section).
- Security & Authorization
  - Cookie authentication (with optional external providers).
  - Attribute-based page authorization using permission keys and Row metadata (e.g., `[PageAuthorize]`, `[ReadPermission]`, `[NavigationPermission]`).
- Dynamic scripts & frontend building
  - Runtime script delivery and optional build-time bundling.
- Extensibility
  - Hook points for payment/shipping providers, custom pages, and additional modules.

Architecture & important components
- Presentation: Razor Pages under `Pages/` (server-rendered).
- Static assets: `wwwroot/` (JS, CSS, localized JSON).
- Localization: `env.WebRootFileProvider` and `env.ContentRootFileProvider` sources.
- Domain: Row-based entities (Serene/Serenity-style `Row` classes) mapped to DB tables.
- Startup: `Initialization/Startup.cs` has initialization tasks: local texts, row field provider, dynamic scripts registration.
- Hosting: `Program.cs` creates the host and runs the application.
- Data access: EF Core or other ORM (migrations expected).
- DI: Services registered in startup for repositories, payment adapters, etc.

Setup (developer)
Prerequisites
- .NET 8 SDK
- Visual Studio 2022 (or VS Code + C# extension)
- Database (SQL Server / PostgreSQL) configured in `appsettings.Development.json`
- Node.js (optional, if frontend build tasks are used)

Quick start
1. Clone repository:
   - `git clone <repo-url>`
2. Configure environment:
   - Update `appsettings.Development.json` / user secrets with `ConnectionStrings:Default` and any keys (payment, external auth).
3. Restore & build:
   - `dotnet restore`
   - `dotnet build`
4. Apply migrations (if using EF):
   - `dotnet ef database update`
5. Run:
   - `dotnet run` or use Visual Studio (F5).
6. Visit the app locally (default: `https://localhost:5001`).

Localization and texts
- Application loads base and JSON texts during startup:
  - `services.AddBaseTexts(env.WebRootFileProvider)`
  - `services.AddJsonTexts(env.WebRootFileProvider, "Scripts/site/texts")`
  - `services.AddJsonTexts(env.ContentRootFileProvider, "App_Data/texts")`
- Put language JSON files under:
  - `wwwroot/Scripts/site/texts/`
  - `App_Data/texts/`
- Keys should match UI lookups. Keep these files in source control for easier translation.

---

## Localization
Place JSON translation files under:
- `wwwroot/Scripts/site/texts/`  
- `App_Data/texts/`

Startup registers texts via:

Authorization & permissions (common pitfall + fix)
- Pattern: Page/Navigation authorization frequently references Row types. The framework expects a Row type referenced by page attributes to declare a permission attribute:
  - `[ReadPermission("Module:Entity")]` or `[NavigationPermission("Module:Entity")]`
- Common runtime exception:
  - `ArgumentOutOfRangeException: PageAuthorize attribute is created with source type of produtRow, but it has no NavigationPermissionAttribute OR ReadPermissionAttribute attribute(s)`
- Why this happens:
  - Either the referenced type name is misspelled (e.g., `produtRow` vs `ProductRow`) or the Row class exists but lacks the required permission attribute, so the framework cannot derive a permission key.
- How to fix:
  1. Search for the offending reference (example PowerShell commands):
     ```powershell
     Select-String -Path .\* -Pattern "PageAuthorize" -SimpleMatch -List | Select Path, LineNumber, Line
     Select-String -Path .\* -Pattern "produtRow" -SimpleMatch -List | Select Path, LineNumber, Line
     ```
  2. Correct typos in attribute parameters or the referenced type name.
  3. If the Row class is missing attributes, add one above the Row class:
     ```csharp
     [ReadPermission("Administration:Products")]
     public sealed class ProductRow : Row<ProductRow.RowFields>
     {
         // ...
     }
     ```
  4. Alternatively, use an explicit permission key in the page attribute rather than a Row type.
- Rebuild and run after patches.

Development workflows & recommended practices
- Add unit tests for business logic and small integration tests for critical flows (checkout, orders).
- Use migrations and keep them in source control.
- Keep localization JSON files and base texts synchronized.
- Use structured logging (Serilog or Microsoft.Extensions.Logging) and correlation IDs in production.
- Validate permission attributes when creating new Row/Page pairs.

Testing, CI/CD, deployment
- Tests: `dotnet test`
- CI pipeline typical steps:
  - Restore, build, run migrations, run tests, publish artifact.
- Deployment:
  - Ensure `appsettings.Production.json` contains production connection strings and secrets are stored in a secret store (Key Vault, environment variables).
  - Enable HTTPS, HSTS, and forwarded headers if behind reverse proxy.
  - Ensure localized `wwwroot` assets and `App_Data` are published.

Project layout (high-level)
- `Pages/` — Razor Pages (storefront & admin)
- `wwwroot/` — static files, scripts, localized JSON
- `Models/` — view models (e.g., `DailySalesViewModel`)
- `Initialization/` — startup helpers (local texts, dynamic scripts)
- `Data/` or `Entities/` — Row classes / domain entities
- `Services/` — business services and adapters
- `Migrations/` — database migrations

Troubleshooting & diagnostics
- If startup fails with permission-related exceptions, follow Authorization section above.
- Use `dotnet build` and inspect compile-time warnings — often missing attributes or typos show up earlier.
- Search the repository for suspicious identifiers (typos like `produtRow`).
- Use logging in Startup to print which initialization steps run; isolate the failing step.

Contributing
- Fork, create a feature branch, add tests for new behavior, and open a PR with a clear description and screenshots where relevant.
- Follow coding style and include migrations for DB changes.

License
- Add your chosen license file (e.g., `LICENSE`) to the repository root.
