## Smart-Parking — Server API (.NET 7)

ASP.NET Core Web API for a smart parking and payments system. The solution is layered into Data Access (`Dal`), Business Logic (`BL`), and the Web API (`Server`).

### Overview
- Exposes REST endpoints for drivers, vehicles, parking, payments, routines, credit cards, and manager actions
- Swagger available in Development for easy testing
- CORS policy enabled for local development

### Architecture
- `Dal/`
  - Models (`Models/*`), services (`Services/*`), and interfaces under `Api`
  - Uses JSON files (e.g., `Dal/Json/*`) as a simple data store for local development
- `BL/`
  - Business models, services, and interfaces under `Api`
  - `BLManager` composes DAL services and applies rules
- `Server/`
  - Controllers per domain: `Driver`, `Vehicle`, `Parking`, `Payment`, `Routine`, `CreditCards`, `CPManager`
  - `Program.cs` configures DI, CORS, Swagger

### Tech Stack
- .NET 7 (ASP.NET Core Web API)
- Swashbuckle (Swagger/OpenAPI)

### Setup & Run (Local)
From `Smart-Parking-server/Server`:
```bash
dotnet restore
dotnet run
```
The API runs at `https://localhost:7164` (HTTPS) and `http://localhost:5111` (HTTP).
Swagger UI: `https://localhost:7164/swagger`

Ports and profiles are configured in `Server/Properties/launchSettings.json`.

### CORS
Development policy `AllowAll` is enabled. For production, restrict origins/headers/methods.

### Example Endpoints
- `GET /api/Parking/GetAllParkingPlaces/{level}`
- `GET /api/Routine/GetPrice/{licensePlate}`
- `GET /api/Driver/GetDriverVehicles/{name}/{password}`
- `POST /api/Payment/AddPayment/{licensePlate}/{numOfPayments}`

Example (curl):
```bash
curl -k https://localhost:7164/api/Parking/GetAllParkingPlaces/1
```

### Build & Publish
```bash
dotnet publish -c Release -o out
```
Deploy the `out` folder to your hosting environment (IIS/Kestrel/Container). Configure environment variables and base URLs.

### Data & Persistence
Local dev uses JSON files in `Dal/Json/*` such as `FloorNum1.json`, `globalDetails.json`. Ensure the process has read/write permissions.

### Security Notes
- Development certificate is used for HTTPS locally; trust/allow it on first run
- No authentication/authorization included — add proper AuthN/Z before production

### Roadmap
- Replace JSON store with a real database (EF Core, migrations)
- Introduce authentication (JWT/OAuth) and role-based authorization
- Add centralized logging and error handling

### Hebrew Summary (תקציר בעברית)
שרת Web API לניהול חניה ותשלומים. כולל שכבות DAL/BL ופרויקט Server עם Controllers לפי דומיין. להרצה: `dotnet restore` ואז `dotnet run` מתוך תיקיית `Server`. Swagger בכתובת `https://localhost:7164/swagger`. בפרודקשן מומלץ להוסיף אימות/הרשאות ומסד נתונים.
