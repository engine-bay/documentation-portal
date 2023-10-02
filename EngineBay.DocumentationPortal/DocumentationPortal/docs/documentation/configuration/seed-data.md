---
tags:
  - Configuration
  - Seed Data
---

# Seed Data

EngineBay is not intended to be pre-configured with any data (workbooks, blueprints etc.). However, it is convenient for testing purposes to have EngineBay in a repeatable and deterministic state.

The [Database Environment Variables](./environment-variables.md#database) provide functionality to create, reset, or re-seed the database on startup.

!!! warning

    Data seeding is a dangerous operation in that it ***destroys the existing database***. It is not recommended for production.

## Workbook JSON Files

JSON files with the ```*.workbooks.json``` extension located in the `/seed-data` directory in EngineBay's container will be validated and inserted into the database on startup.

The `/seed-data` directory is configurable through the environment variable `DATABASE_SEED_DATA_PATH`.

Workbooks inserted during startup are owned by the System User.
