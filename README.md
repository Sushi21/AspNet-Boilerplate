# AspNet-Boilerplate
Playing with some concepts.
Very overkill for what it's doing but is to get general ideas on some concepts and tools that can be use with .net

## Packages used

- MediatR - Helps implementing CQRS pattern
- MiniProfiler - profiling calls and sql
- Bogus - Generating Fake data for Unit Tests
- HealthChecks and HealthChecks UI (Monitoring systems)
- Entity Framework (with sqlite for now)
- Swagger 
- XUnit



## Highlights

- .net 7 with entity-framework and sqlite database
- clean architecture approach 
- CQRS approach with a decorator for logging and profiling ( see `LoggingDecorator`)
- Use InMemory DB for unit testing.

## Usage

- Navigate to `https://localhost:7292/profiler/results` while making calling to the api to see the profiling result
- Navigate to `https://localhost:7292/health` to see the json version of the health report
- Navigate to `https://localhost:7292/healthchecks-ui#/healthchecks` to see the ui dashboard version of the health report

## Upcoming

- Controller Unit Test
- SQL Migration using `Fluent Migrator`
- Postgres Database
- Caching
- Feature Toggles
