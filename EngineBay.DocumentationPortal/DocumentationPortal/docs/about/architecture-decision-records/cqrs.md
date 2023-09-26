---
tags:
  - Architecture Decision Record
---

# CQRS

## Date

4 January 2023

## What is this about?

This ADR captures some of the thinking around structuring API requests with the [CQRS pattern](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs).

## What characteristics did we value at the time?

* Controller logic was starting to get complex and getting harder to test, we wanted to test a slice of business logic independent of the web request context.
* Each business operation should clearly be categorized into a read operation that is potentially optimizable/cache-able or a write operation that is clearly mutating database state and therefore cache busting.

## Considerations

The [MediatR](https://github.com/jbogard/MediatR) library was considered for a more "elegant" query/command dispatch pattern. Reading at the time seemed to indicate some performance loss from MediatR and we didn't actually want the full blown [Mediator Pattern](https://refactoring.guru/design-patterns/mediator).

A more basic query/command dispatch pattern was implemented as a proof of concept, leveraging the built in dependency injection and assembly scanning. It worked, but seemed to hurt the overall legibility of endpoints invoking commands and queries.

## What did we decide on?

A basic pattern of splitting logic into commands and queries, each inheriting from a standardized interface, and respectively leveraging a write or read optimized database context was decided on. This was implemented using the built in dotnet dependency injection framework.

## What opportunities does this create?

* Queries can have a caching layer easily introduced.
* Auditing concepts can be introduced in a transparent way on all write operations.

## What risks did this introduce?

* Commands calling other commands, or queries calling other queries may cause unwanted coupling in the long term. Need to be conscious of when the need to reduce duplicate code outweighs the need to keep commands and queries decoupled from each other.
