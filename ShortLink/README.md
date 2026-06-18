🔗 URL Shortener Service

A clean, fast URL shortening API built with **ASP.NET Core (.NET 6)**.

## ✨ Features

- Shorten long URLs to compact, shareable links.
- Redirect via short code.
- Persistent storage with Entity Framework Core (SQL Server).
- API Documentation with Swagger.

## 🏗️ Architecture & Project Structure

The project is structured into Core, Infrastructure, and Endpoints layers:


```
ShortLink/
├── src/
│   ├── 1.Core/
│   │   ├── ShortLink.Domain/              # Core Entities (Link)
│   │   ├── ShortLink.Contracts/           # Repository Interfaces (ILinkRepository)
│   │   ├── ShortLink.ApplicationService/  # Business Logic (ManageLinkService)
│   │   └── ShortLink.Utilities/           # Helpers (UrlHelper)
│   ├── 2.Infra/
│   │   └── ShortLink.Infra.SQL/           # EF Core DBContext, Migrations & Repositories
│   └── 3.Endpoints/
│       └── ShortLink/                     # ASP.NET Core Web API (Presentation)
└── ShortLink.sln
```

## 🛠️ Tech Stack

* **Framework:** .NET 6.0
* **ORM:** Entity Framework Core 6.0.21
* **Database:** SQL Server
* **API Docs:** Swagger (Swashbuckle)

## 🚀 Getting Started

### Prerequisites

* .NET 6 SDK
* SQL Server

### Run Locally

1. Clone the repository:
```bash
git clone [https://github.com/hadihamedian/generate_short_URL.git](https://github.com/hadihamedian/generate_short_URL.git)
cd generate_short_URL/ShortLink

```


2. Update the connection string or configuration in `src/3.Endpoints/ShortLink/appsettings.json`.
3. Apply database migrations:
```bash
dotnet ef database update --project src/2.Infra/ShortLink.Infra.SQL --startup-project src/3.Endpoints/ShortLink

```


4. Run the Web API:
```bash
dotnet run --project src/3.Endpoints/ShortLink

```



Swagger UI will be available at: `http://localhost:5015/swagger` (or `https://localhost:7018/swagger`)

## 📡 API Endpoints

| Method | Endpoint | Query Param | Description |
| --- | --- | --- | --- |
| `POST` | `/api/Url/CreateShortUrl` | `url={longUrl}` | Generates a short URL token. |
| `GET` | `/api/Url/GetFullUrlAndRedirect` | `url={token}` | Resolves the token and redirects to the original URL. |

---

> Built by [Hadi Hamedian](https://www.google.com/search?q=https://github.com/hadihamedian) — Senior .NET Developer