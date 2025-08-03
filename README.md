# Course Management System

A comprehensive course management system built with ASP.NET Core Razor Pages.

## Features

- Course and Department Management
- Instructor Management
- Trainee Enrollment and Progress Tracking
- User Authentication and Authorization
- Entity Framework Core with Code-First Approach

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or later
- SQL Server (or your configured database)

## Getting Started

1. **Clone the repository:**
```bash
git init
git add .
git commit -m "Initial commit: Course Management System"
git remote add origin https://github.com/Muhamad-Mahmoud/EDU_MVC.git
git branch -M main
    git push -u origin main
```
2. **Update the connection string** in `appsettings.json` to match your database setup.

3. **Apply Entity Framework migrations:**

4. **Run the application:**

5. Open in your browser at `https://localhost:5001` (or the port shown in the console).

## Project Structure

- `Areas/Identity`: Authentication and user management
- `Models`: Entity models and DbContext
- `Repository`: Data access layer
- `ViewModel`: View-specific models
- `Views`: Razor views and layouts
- `Controllers`: (if any, for API or MVC endpoints)

## Technologies Used

- ASP.NET Core Razor Pages
- Entity Framework Core
- Microsoft Identity
- Bootstrap
- jQuery

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

[MIT](LICENSE)