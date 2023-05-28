# Start developing on your own machine

## Prerequisites

- Visual Studio (Code)
- .NET Core SDK
- Docker

## Getting started

To start developing, simply run the following command:

```bash
docker compose up -d
```

This will run a local instance of the database and the API. The API will be available on port 8080. You can check if the API is running by navigating to [http://localhost:8080/api/users](http://localhost:8080/api/users). This will return a empty array if this is the first time you are running the API.


## Setting up your `.env` file
In the root of the project, you'll find a file named `.env.example.` This file outlines the necessary environment variables needed for the application to run correctly.

To set these variables:

1. Copy the `.env.example` file and rename the copied file to `.env`.
2. Inside the `.env` file, replace the placeholder values with the actual values relevant to your local development environment.

Remember, the `.env` file will not and should not be committed to GitHub.


# Considering PostgreSQL over SQL Server

PostgreSQL stands as a strong candidate for our project's database management system. Its open-source nature ensures cross-platform compatibility, promising consistent performance across various operating systems.

With a proven track record in handling large databases and complex queries, PostgreSQL could potentially provide faster API responses, thus improving our application's overall performance.

A significant advantage of PostgreSQL over SQL Server is its support for Apple's Silicon Chip. Given the increasing adoption of devices using this chip, this support could greatly enhance our project's compatibility and usability.
