# 🔗 URL Shortener Service

A clean, fast URL shortening API built with **ASP.NET Core** following **Clean Architecture** principles.

## ✨ Features

- Shorten long URLs to compact, shareable links
- Redirect via short code with high performance
- RESTful API design
- Persistent storage with Entity Framework Core
- Input validation and error handling

## 🏗️ Architecture

```
ShortLink/
├── ShortLink.API/          # Presentation layer — Controllers, Middleware
├── ShortLink.Application/  # Use cases, DTOs, Interfaces
├── ShortLink.Domain/       # Entities, Value Objects, Domain Logic
└── ShortLink.Infrastructure/ # EF Core, Repositories, DB Context
```

> Follows **Clean Architecture** — dependencies point inward, domain has zero external dependencies.

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| API | ASP.NET Core Web API |
| ORM | Entity Framework Core |
| Database | SQL Server / SQLite |
| Testing | xUnit |
| Docs | Swagger / OpenAPI |

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server or SQLite

### Run Locally

```bash
git clone https://github.com/hadihamedian/generate_short_URL.git
cd generate_short_URL/ShortLink

# Update connection string in appsettings.json
dotnet ef database update --project ShortLink.Infrastructure

dotnet run --project ShortLink.API
```

API will be available at `https://localhost:5001`  
Swagger UI: `https://localhost:5001/swagger`

## 📡 API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| `POST` | `/api/shortlink` | Create a short URL |
| `GET` | `/{code}` | Redirect to original URL |
| `GET` | `/api/shortlink/{code}` | Get link details |
| `DELETE` | `/api/shortlink/{code}` | Delete a short link |

### Example

```http
POST /api/shortlink
Content-Type: application/json

{
  "originalUrl": "https://www.example.com/very/long/url/that/needs/shortening"
}
```

```json
{
  "shortCode": "abc123",
  "shortUrl": "https://yourdomain.com/abc123",
  "originalUrl": "https://www.example.com/very/long/url/that/needs/shortening",
  "createdAt": "2024-01-15T10:30:00Z"
}
```

## 🧪 Running Tests

```bash
dotnet test
```

## 📄 License

MIT License — feel free to use and modify.

---

> Built by [Hadi Hamedian](https://github.com/hadihamedian) — Senior .NET Developer
