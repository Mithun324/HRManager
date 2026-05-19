# 💼 HRManager Dashboard

HRManager is a premium, modern, and light-weight Human Resources management web application built entirely on **.NET 9 (ASP.NET Core MVC)** and **Entity Framework Core**. It is designed with a sleek, custom-crafted SaaS-style interface that bypasses heavy commercial CSS frameworks for hyper-optimized performance.

---

## 🚀 Key Features

* **Employee Directory:** A fluid, card-contained table with responsive, fixed-width grids, query sorting, and inline action triggers.
* **Comprehensive Data Structures:** Built-to-scale database schema handling multi-faceted relationships, including Personal Information, Employment Details, Address tracking, and Social Media references.
* **Modern Dependency Injection:** Completely decoupled backend controllers using modern .NET constructor injection to handle context pooling safely.
* **Premium Custom UI Engine:** Features a fully tailored, zero-dependency `site.css` dashboard featuring variables (`:root`), dynamic fieldset layouts, and color-coded entity status badges.
* **Cascade Safeguards:** Custom relational database rules configured via Fluent API to prevent accidental data cascades during administrative removals.

---

## 🛠️ Tech Stack & Framework Specs

* **Runtime:** .NET 9.0 (ASP.NET Core MVC)
* **Data Access:** Entity Framework Core 9.0
* **Database Engine:** Microsoft SQL Server (SSMS Integration)
* **Front-end Design:** Pure HTML5, Modern CSS3 Grid/Flexbox architectures, and Native Razor View Syntax.

---

## 📂 Project Structure


HRManager/
├── Controllers/         # MVC Controllers with constructor injection
├── Data/                # HRManagerDbContext and Migrations profiles
├── Models/              # Employee and relational application entities
├── Views/               # Strongly-typed responsive Razor templates
└── wwwroot/             
    └── css/             # Custom site.css engine with cache-busting configurations
⚙️ Getting Started & Setup
1. Prerequisites
.NET 9.0 SDK

Visual Studio 2022 (Version 17.12 or newer)

SQL Server Management Studio (SSMS)

2. Configure the Connection String
Open the appsettings.json file in the root folder and update the connection details to point to your local SQL Server instance. Ensure it matches the syntax below:

JSON
{
  "ConnectionStrings": {
    "HRManagerConnection": "Server=.;Database=HrMDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}
3. Initialize the Database Schema
Open your Package Manager Console in Visual Studio (Tools ➔ NuGet Package Manager ➔ Package Manager Console) and execute the following commands to create and apply the database migrations:

PowerShell
# Compiles your model structures and builds the code snapshot
add-migration InitialCreate

# Executes structural changes, creating the HrMDB schema in SSMS
update-database

4. Running the App
Press Ctrl + F5 inside Visual Studio to build and start the server without debugging. The application will leverage .NET 9's structural static file pipelines (MapStaticAssets) to automatically render the production-ready interface.

🎨 Layout Specifications
The design language utilizes a refined, accessible UI palette built out of customized variable tokens:

Primary Accent Blue: #4f46e5

Background Canvas tint: #f8fafc

Typography Elements: Premium deep-slate variables with balanced micro-paddings to maximize information density for human resource personnel.
