# Start developing on your own machine

## Prerequisites

- Visual Studio (Code)
- .NET Core SDK
- Docker

## Getting started

To start developing, simply run the following command:

```bash
docker-compose up -d
```

This will run a local instance of the database and the API. The API will be available on port 8080. You can check if the API is running by navigating to [http://localhost:8080/api/users](http://localhost:8080/api/users). This will return a empty array if this is the first time you are running the API.

### Developing on a Apple Silicon MAC (M1, M2)

As of today, the SQL Server image does not support running on a Mac. To get around this, you can run the following command:

```bash
docker compose -f docker-compose.arm64.yml up -d
```
