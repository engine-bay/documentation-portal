# Features

* Multiple database providers
  * Postgres
  * SQLServer
  * SQLite
  * InMemory
* REST API for managing configuration
* Auditing

## Roadmap

The following roadmap is planned, however, this is likely to change as development progresses.

### MVP

* [x] Module framework
* [] Authentication
  * [x] Basic Auth
  * [ ] JWT Bearer Auth
* [x] Actor Engine module
* [x] Blueprints API
  * [x] Blueprints API module
  * [ ] Blueprints E2E tests module
* [ ] Auditing API
  * [ ] Auditing API module
  * [ ] Auditing E2E tests module
  * [x] Entity change tracking
* [ ] Multiple database providers
  * [x] Postgres
  * [x] SQLServer
  * [ ] SQLite
  * [ ] InMemory
  * [x] Database providers E2E tests framework
  * [x] Migrations framework
* [ ] File Loader
  * [ ] JSON format workbooks
  * [ ] Excel files
* [ ] Logging Module
  * [x] Configurable logging
  * [ ] Logging framework
  * [ ] Consistent logging
* [ ] Documentation
  * [ ] Getting started
  * [x] Configuration
  * [x] OpenAPI 3.0 document generation
  * [ ] API Reference
  * [ ] Use cases
  * [ ] Examples
* [ ] Community Edition
* [ ] Enterprise (Sponsored) Edition

### Phase 2 - governance and compliance

* [ ] Authorization
* [ ] Column Encryption
* [ ] Auditing retention features
* [ ] Changelogs
* [ ] Contribution guidelines

### Phase 3 - Observability

* [ ] Performance metrics
* [ ] Stress testing frameworks
* [ ] Distributed tracing

### Phase 4 - Speed

* [ ] Rate limiting
* [ ] Caching
* [ ] Startup speed (pre-compiled EF models)

### Phase 5 - Features

* [ ] Sessions

### Phase 5

* [ ] OSS SSO providers
