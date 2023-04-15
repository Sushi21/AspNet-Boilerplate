# AspNet-Boilerplate
Playing with some concepts.
Very overkill for what it's doing but is to get general ideas on some concepts and tools that can be use with .net

## Packages used

- MediatR - Helps implementing CQRS pattern
- MiniProfiler - profiling calls and sql
- Bogus - Generating Fake data for Unit Tests
- HealthChecks and HealthChecks UI (Monitoring systems)
- Entity Framework
- Postgres Database (running in Docker)
- Swagger 
- XUnit


## Highlights

- .Net 7 with entity-framework and postgres db
- clean architecture approach 
- CQRS approach with a decorator for logging and profiling ( see `LoggingDecorator`)
- Use real temporary database for unit tests.

## Usage
- Before running `dotnet run` make sure you run the command `docker-compose up -d` 
- Navigate to `https://localhost:7292/profiler/results` while making calling to the api to see the profiling result
- Navigate to `https://localhost:7292/health` to see the json version of the health report
- Navigate to `https://localhost:7292/healthchecks-ui#/healthchecks` to see the ui dashboard version of the health report

## Unit Tests
- The unit test are creating a template database for every tests collection and then each test is creating it's own temparary database created from the template one. See `DatabaseFixture` and `DatabaseTestCase` class for more details on how it works.

## Upcoming

- Controller Unit Test
- SQL Migration using `Fluent Migrator` - `Done`
- Postgres Database - `Done`
- Caching
- Feature Toggles
- Create `TestDB` on startup if it doesn't exist
