# Start developing on your own machine

## Prerequisites

- Visual Studio (Code)
- .NET Core SDK
- Docker

## Setting up your `.env` file

In the root of the project, you'll find a file named `.env.example`. This file outlines the necessary environment variables needed for the application to run correctly.

To set these variables:

1. Copy the `.env.example` file and rename the copied file to `.env`.
2. Inside the `.env` file, replace the placeholder values with the actual values relevant to your local development environment.

Remember, the `.env` file will not and should not be committed to GitHub.

## Start developing

To start developing, simply run the following command:

```bash
docker compose up -d
```

This will run a local instance of the database and the API. The API will be available on port 8080. You can check if the API is running by navigating to [http://localhost:8080/api/users](http://localhost:8080/api/users). This will return a empty array if this is the first time you are running the API.

# Stopping the Database and API

```bash
docker compose stop
```

OR

```bash
docker compose down
# Remember that this command removes all the data from the database. If you want to keep the data, use the first command.
```

# Looking into telemetry using Jaeger

Jaeger is a distributed tracing system. It is used to monitor and troubleshoot transactions in complex distributed systems. It is used in microservice architectures to monitor the communication between services.

Jaeger is included in the Docker Compose file, so you will only need to start it like you always would using the commands in the previous section.
