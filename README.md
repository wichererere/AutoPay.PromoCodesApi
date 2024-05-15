# AutoPay PromoCodes API

Welcome to **AutoPay PromoCodes API**, application to manage promotional codes. Allows you to add, delete, display promo codes.
## Features

- **Add** a new code.
- Ability to **rename** a promotional code.
- **Download** the code (display).
- Downloading the **list** of all codes.
- **Marking** the code **as inactive**.
- **Deletion** of the code.
- Store basic information about the **history of changes**.

## Getting Started

### Prerequisites

Before you can run the application, make sure you have the following installed:
- [.NET Core SDK](https://dotnet.microsoft.com/download) (version specified in `global.json`)
- An IDE like [Visual Studio](https://visualstudio.microsoft.com/), [VS Code](https://code.visualstudio.com/) or similar

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/wichererere/AutoPay.PromoCodesApi
2. Change to the project directory:
   ```bash
   cd AutoPay.PromoCodesApi
3. Restore all necessary .NET Core packages needed for the project:
   ```bash
   dotnet restore
4. Build the project to ensure there are no compilation errors:
   ```bash
   dotnet build

5. Start the application by running:
   ```bash
   dotnet run --project src/AutoPay.PromoCodesApi.Web

### Dockerize

1. Change to the project directory:
   ```bash
   cd AutoPay.PromoCodesApi

2. Start the application by running:
   ```bash
   docker compose run
   
## Used technologies
.NET8, Sqlite, SqlServer, Docker, Clean Architecture, MediatR, CQRS, EF Core, FastEndpoints, FluentValidation xunit, TestContainers, FluentAssertions, NSubstitute, testhost