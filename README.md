# Employee Management System

The Employee Management System is a web application built using ASP.NET Core MVC. It allows organizations to efficiently manage employees, departments, and user accounts. This README provides information on how to set up and run the application.

## Technologies Used:

ASP.NET Core MVC
ASP.NET Core Identity for user and role management
AutoMapper for data mapping
Entity Framework Core for database operations
Role-based access control (RBAC)
Google authentication for user login
Exception handling for robust performance
Repository Design Pattern
Unit Of work Design Pattern
Three-Tire architecture

## Controllers

The application provides several controllers to manage different aspects of the system:

- **Employee Controller**: Manage employee information, including creation, modification, and deletion.

- **Department Controller**: Organize employees into different departments, with options for creation, editing, and deletion.

- **Account Controller**: Administer user accounts, including registration, login, and password reset.

- **Role Controller**: Manage user roles and their assignment.

- **User Manager Controller**: Administer user accounts, including listing, editing, and role assignment.

## Getting Started

To get started with the Employee Management System, follow these steps:

1. Clone this repository to your local environment.

2. Configure your application settings, including the database connection, in the `appsettings.json` file.

3. Run database migrations using Entity Framework Core:

4. Build and run the application:

5. Access the application in your web browser at `https://localhost:5001`.

## Contributing

We welcome contributions from the community. If you find a bug, have an enhancement in mind, or want to contribute in any way, please feel free to create issues or pull requests.


