
# E-Commerce Backend

This project builds the backend part of a mini e-commerce website to fulfill all the requirements, with a specific focus on development approaches. It is designed based on Onion Architecture principles, which divides the application into layers focusing on business logic, infrastructure, and presentation, creating a modular structure.


##  Approaches

- **Onion Architecture**: The project is designed based on Onion Architecture principles. This architectural pattern divides the application into layers focusing on business logic, infrastructure, and presentation, creating a modular and maintainable structure.

- **CQRS (Command Query Responsibility Segregation) Pattern**: The project utilizes the CQRS pattern, which separates read and write operations into separate models. This pattern enhances scalability, performance, and maintainability by allowing different models to evolve independently.

![CQRS Pattern](https://github.com/burakgunce/E-Commerce-Backend/assets/87397100/3ec38f67-7961-4119-af11-b3aed0122e31)

- **Mediator Pattern**: The project implements the Mediator pattern, which promotes loose coupling between components by centralizing communication between them. This pattern enhances reusability and testability by decoupling classes and simplifying communication.

- **Role-Based Access Control (RBAC)**: The project implements Role-Based Access Control, allowing access rights to be assigned to users based on their roles. RBAC enhances security and simplifies access control by defining roles and permissions.

![RBAC Scheme](https://github.com/burakgunce/E-Commerce-Backend/assets/87397100/b7855fe5-5dc1-417a-b296-cbce171d77c1)

- **Dependency Injection**: Dependency injection is used to inject dependencies into components rather than having the components create their dependencies. This approach promotes loose coupling, testability, and flexibility by allowing dependencies to be easily swapped or mocked.

- **Generic Repository Pattern**: The project follows the Generic Repository pattern, which provides a generic interface to perform CRUD operations on various entities. This pattern promotes code reuse and simplifies data access logic by abstracting away the underlying data storage mechanism.

![Generic Repository](https://github.com/burakgunce/E-Commerce-Backend/assets/87397100/70df21c3-d8ef-477c-83a6-ec41a95c119f)

- **JWT (JSON Web Token) Authentication**: JSON Web Tokens are used for authentication and authorization in the project. JWT provides a secure way to transmit information between parties as a JSON object and is commonly used for implementing stateless authentication mechanisms.

- **SOLID Principles**: The project adheres to the SOLID principles (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion). These principles promote clean architecture, maintainability, and extensibility by encouraging modular, loosely coupled, and testable code.


## Technologies

- **Entity Framework Core**: Entity Framework Core is used as the ORM (Object-Relational Mapping) framework in the project. It simplifies data access by allowing developers to work with databases using .NET objects, and provides features such as LINQ queries, change tracking, and migrations.

- **FluentValidation**: FluentValidation is used for input validation in the project. It provides a fluent interface for defining validation rules and helps ensure the validity of input data before processing it.

- **Mediatr**: Mediatr is used to implement the Mediator pattern, which promotes loose coupling between components by centralizing communication between them. This pattern enhances reusability and testability by decoupling classes and simplifying communication.

- **Azure Storage**: Azure Storage is utilized for storing and managing data in the cloud. It provides scalable and secure storage solutions, including Blob storage, Table storage, Queue storage, and File storage.

- **Serilog**: Serilog is used for structured logging in the project. It provides a flexible and powerful logging framework that supports structured logging formats and sinks for various log storage solutions.

- **SignalR**: SignalR is used to implement real-time communication in the project. It provides a simple and scalable API for adding real-time functionality to web applications, allowing clients to receive updates from the server in real-time.

- **ASP.NET Core Identity**: ASP.NET Core Identity is used for managing user authentication and authorization in the project. It provides built-in support for user registration, login, password management, and role-based access control.

- **JWT (JSON Web Token)**: JSON Web Tokens are used for authentication and authorization in the project. JWT provides a secure way to transmit information between parties as a JSON object and is commonly used for implementing stateless authentication mechanisms.

- **PostgreSQL**: PostgreSQL is used as the relational database management system (RDBMS) in the project. It provides robust data storage and management capabilities, along with support for advanced features such as transactions, indexing, and security.


## Layers

![General Structure](https://github.com/burakgunce/E-Commerce-Backend/assets/87397100/91a3140e-ada4-4a2f-9f90-521425c8a57a)

## Application Layer
![Application Layer](https://github.com/burakgunce/E-Commerce-Backend/assets/87397100/7a7a0768-c08d-40f3-929d-4163870d720b)

## Domain Layer
![Domain Layer](https://github.com/burakgunce/E-Commerce-Backend/assets/87397100/55ebcdd3-7957-4752-a140-881d46948031)

## Infrastructure Layer
![Infrastructure Layer](https://github.com/burakgunce/E-Commerce-Backend/assets/87397100/c8de5263-4ffe-4c6a-a3ff-e5d0e291a081)

## Persistence Layer
![Persistence Layer](https://github.com/burakgunce/E-Commerce-Backend/assets/87397100/e4357ff3-f041-45ae-b6e7-d31b8f2e94b4)

## SignalR Layer
![SignalR Layer](https://github.com/burakgunce/E-Commerce-Backend/assets/87397100/b42e4ee9-d18a-4c3a-b5a9-0a2aebf28454)

## WebAPI Layer
![WebAPI Layer](https://github.com/burakgunce/E-Commerce-Backend/assets/87397100/2d6a52ee-4aed-4983-a7e9-97e4ad67032d)


| Technology / Library                                        | Version  |
|-------------------------------------------------------------|----------|
| .NET                                                        | 6.0      |
| Microsoft.AspNetCore.Http                                   | 2.2.2    |
| Microsoft.AspNetCore.Identity                               | 2.2.0    |
| Microsoft.AspNetCore.Identity.EntityFrameworkCore           | 6.0.26   |
| Microsoft.AspNetCore.Authentication.JwtBearer               | 6.0.26   |
| Microsoft.Extensions.Configuration                          | 6.0.1    |
| Microsoft.Extensions.Configuration.Json                     | 6.0.0    |
| Microsoft.Extensions.DependencyInjection.Abstractions   | 8.0.0    |
| Microsoft.EntityFrameworkCore                              | 6.0.26   |
| Microsoft.EntityFrameworkCore.Design                        | 6.0.26   |
| Microsoft.EntityFrameworkCore.Tools                          | 6.0.26   |
| Npgsql.EntityFrameworkCore.PostgreSQL                       | 6.0.22   |
| FluentValidation                                            | 11.9.0   |
| FluentValidation.AspNetCore                                 | 11.3.0   |
| FluentValidation.DependencyInjectionExtensions              | 11.9.0   |
| MediatR                                                     | 12.2.0   |
| MediatR.Extensions.Microsoft.DependencyInjection          | 11.0.0   |
| Google.Apis.Auth                                            | 1.67.0   |
| QRCoder                                                     | 1.4.3    |
| Azure.Storage.Blobs                                         | 12.19.1  |
| Serilog                                                     | 3.1.1    |
| Serilog.AspNetCore                                          | 6.0.1    |
| Serilog.Sinks.Seq                                           | 7.0.0    |
| Serilog.Sinks.PostgreSQL                                    | 2.3.0    |
| Swashbuckle.AspNetCore                                      | 6.5.0    |

