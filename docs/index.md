# Documentation

> **Note**: this docs will change a lot because this is still a work in progress

This is the development documentation

## How is code organized

Every service -``except for Identity``- includes 3 subprojects:

* **Shared**: information shared with other services, that make simple development, this include -``mostly``- abstract declarations like: GraphQL client, Models of the Entity Framework Code entities and Data Models -`` Payloads, Input Models and Response Models`` used in the package;
* **Domain**: data domain related information like EntityType configuration and the repository interfaces declarations.
* **API**: the API server application.

It also include a business logic plugin for each entity. This design allows us to make more modular the application design, this allows to manage -``update, upgrade, etc``- functionalities in the server without any required server restart or shutdown.