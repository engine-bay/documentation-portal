---
tags:
  - Configuration
  - Environment Variables
---

# Environment Variables

EngineBay takes the approach of configuring most behavior through environment variables.

## Database

The following environment variables control the database configuration and behavior of EngineBay.

| Environment variable | Default value | Options | Description |
| :--------------------------- | :----: | :----: | :--- |
| `DATABASE_PROVIDER` | `SQLite` | `InMemory`, `SQLite`, `SqlServer`, `Postgres`| The relational database provider to use. Defaults to SQLite when not set. |
| `DATABASE_CONNECTION_STRING` | `none` | N/A | The connection string to use for the configured `DATABASE_PROVIDER` |
| `DATABASE_RESET` | `false` | `true`, `false`, `none`| This will ***RESET*** the database, deleting all tables and re-applying database migrations. This is intended for development and testing activities where a deterministic database state is required. Is always `true` when `DATABASE_PROVIDER` is set to `InMemory` |
| `DATABASE_RESEED` | `false` | `true`, `false`, `none` | This will ***RESEED*** the database with initial data. This is intended for development and testing activities where a deterministic database state is required. |
| `DATABASE_SEED_DATA_PATH` | `/seed-data` | `string`, `none`  | The directory to be used to look for seed data files. |
| `DATABASE_EXIT_AFTER_MIGRATIONS` | `false` | `true`, `false`, `none`| Force shutdown after migrations are completed. This is intended for use in simulating database migrations in CI environments. |
| `DATABASE_EXIT_AFTER_SEEDING` | `false` | `true`, `false`, `none`| Force shutdown after database (re)seeding is are completed. This is intended for use in simulating database migrations in CI environments. Only applies if `DATABASE_RESEED` is `true` |

## Data Protection

The following environment variables control the data protection behavior of EngineBay.

| Environment variable | Default value | Options | Description |
| :--------------------------- | :----: | :----: | :--- |
| `DATA_PROTECTION_KEY_STORE_PROVIDER` | `FileSystem` | `FileSystem`, `Redis` | The key store provider for data protection encryption keys. Defaults to FileSystem when not set. |
| `DATA_PROTECTION_NAMESPACE` | `EngineBay DataProtection Key Store` | `string`, `none` | The partitioning namespace for the key store provider for data protection encryption keys. Defaults when not set. |
| `DATA_PROTECTION_REDIS_CONNECTION_STRING` | `none` | `string`, `none` | Connection string for Redis key store provider. |
| `DATA_PROTECTION_KEY_LIFETIME_DAYS` | `7` | `number`, `none` | The lifetime of an encryption key before it is rotated internally. |

## Logging

The following environment variables control logging behavior of EngineBay.

| Environment variable | Default value | Options | Description |
| :--------------------------- | :----: | :----: | :--- |
| `LOGGING_LEVEL` | `Warning` |  `Critical`, `Error`, `Warning`, `Information` `Debug`, `Trace`, `None` | Sets the logging level of EngineBay. |
| `LOGGING_SENSITIVE_DATA_ENABLED` | `none` | `true`, `false`, `none` | Allows for logging of potentially sensitive data, for example, the contents of a database transaction. This is intended for development and troubleshooting and is **not recommended** for production use. |

## Authentication

The following environment variables control the authentication behavior of EngineBay.

| Environment variable | Default value | Options | Description |
| :--------------------------- | :----: | :----: | :--- |
| `AUTHENTICATION_SECRET` | `none` | `string` | The secret used for verifying JWT Bearer tokens |
| `AUTHENTICATION_ISSUER` | `http://localhost:5050` | `string`, `none` | The value used for verifying JWT Audience (aud) claims |
| `AUTHENTICATION_AUDIENCE` | `http://localhost:5050` |  `string`, `none` | The value used for verifying JWT Issuer (iss) claims |
| `AUTHENTICATION_AUTHORITY` | `none` |  `string`, `none` | The value used for verifying JWT Authority claims |
| `AUTHENTICATION_ALGORITHM` | `HS256` |  `HS256`, `HS512` | The algorithm used for verifying JWT tokens |
| `AUTHENTICATION_METHOD` | `JwtBearer` | `JwtBearer`, `Basic`, `None` | The authentication method used. `Basic`, `None` are **not recommended** as these are intended for troubleshooting and testing, not production use.   |
| `AUTHENTICATION_VALIDATE_EXPIRY` | `true` |  `true`, `false`, `none` | Enabled JWT Expiry (exp) validation. Disabling this is **not recommended**. |
| `AUTHENTICATION_VALIDATE_AUDIENCE` | `true` |  `true`, `false`, `none` | Enabled JWT Audience (aud) validation. Disabling this is **not recommended**.|
| `AUTHENTICATION_VALIDATE_ISSUER` | `true` |  `true`, `false`, `none` | Enabled JWT Issuer (iss) validation. Disabling this is **not recommended**. |
| `AUTHENTICATION_VALIDATE_ISSUER_SIGNING_KEY` | `true` |  `true`, `false`, `none` | Enabled JWT Issuer signing keys validation. Disabling this is **not recommended**.|
| `AUTHENTICATION_VALIDATE_SIGNED_TOKENS` | `true` |  `true`, `false`, `none` | Enabled JWT signed tokens validation. Disabling this is **not recommended**. |

## API Documentation

The following environment variables control the OpenAPI 3.0 api documentation behavior of EngineBay.

| Environment variable | Default value | Options | Description |
| :--------------------------- | :----: | :----: | :--- |
| `API_DOCUMENTATION_ENABLED` | `false` |  `true`, `false`, `none` | Enables OpenApi 3.0 API documentation on paths `/swagger/v1/swagger.json` and `/swagger/index.html`. |

## Auditing

The following environment variables control the auditing behavior of EngineBay.

| Environment variable | Default value |         Options         | Description                                                                                                                                                                                                                                        |
|:---------------------|:-------------:|:-----------------------:|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `AUDITING_ENABLED`   |    `true`     | `true`, `false`, `none` | This can disable tracking and auditing of changes saved to the database. It is not recommended to disable this unless EngineBay is processing PII data. Disabling auditing can provide a slight performance boost if traceability is not required. |

## Rate Limiting

The following environment variables control the rate limiting behavior of EngineBay.

| Environment variable | Default value |         Options         | Description                                                                                                                                                                                                                                        |
|:---------------------|:-------------:|:-----------------------:|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `RATE_LIMITING_AUTO_REPLENISHMENT`   |    `true`     | `true`, `false` |  Specified whether the bucket is automatically refreshed or if TryReplenish will be called manually. Applies to the `token bucket` limit algorithm. |
| `RATE_LIMITING_PERMIT_LIMIT`   |    `100`     | `number` | Maximum number of allowed requests after which new requests will be queued or blocked. Applies to the `fixed window`, `sliding window`, and `concurrency` limit algorithms. |
| `RATE_LIMITING_QUEUE_LIMIT`   |    `10`     | `number` | Determines the number of requests that will be queued after the limit has been reached. Applies to the `fixed window`, `sliding window`, `token bucket`, and `concurrency` limit algorithms. |
| `RATE_LIMITING_QUEUE_PROCESSING_ORDER`   |    `OldestFirst`     | `OldestFirst`, `NewestFirst` | Controls the order in which queued requests will be dequeued and processed. Applies to the `fixed window`, `sliding window`, `token bucket`, and `concurrency` limit algorithms. |
| `RATE_LIMITING_REPLENISHMENT_PERIOD`   |    `5`     | `number` | Time (in seconds) before tokens will be added to the bucket. Applies to the `token bucket` limit algorithm. |
| `RATE_LIMITING_SEGMENTS_PER_WINDOW`   |    `5`     | `number` | Specifies the number of segments a window will be divided into. Applies to the `sliding window` limit algorithm. |
| `RATE_LIMITING_TOKEN_LIMIT`   |    `100`     | `number` | Maximum number of tokens that can be in the bucket at any time. Applies to the `token bucket` limit algorithm. |
| `RATE_LIMITING_TOKENS_PER_PERIOD`   |    `10`     | `number` | Number of tokens to add to the bucket each period. Applies to the `token bucket` limit algorithm. |
| `RATE_LIMITING_WINDOW`   |    `60`     | `number` | Time (in seconds) of the window that the limit is applied to before moving on to the next window. Applies to the `fixed window` and `sliding window` limit algorithms. |
