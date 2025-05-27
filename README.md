# 💸 Expense Tracker API

A RESTful Web API for managing personal expenses, built with **ASP.NET Core**.  
It allows users to add, update, delete and retrieve financial transactions, making it ideal for integration with front-end apps or mobile clients.

This project was developed to practice back-end API design, database modeling, and modern .NET practices.

---

## 🚀 Features

- ✅ Create new expenses
- 🔍 Retrieve expense records
- ✏️ Update and delete entries
- 💾 Persistence with a relational database (PostgreSQL)
- 🧾 API-ready for front-end or mobile integration

---

## ⏳ To be implemented

- 📅 Filter transactions by date or category
- 🔐 JWT authentication 

---

## 💻 Technologies Used

- [.NET 8](https://dotnet.microsoft.com/en-us/)
- C#
- ASP .NET Core
- Entity Framework Core
- PostgreSQL
- Docker
- Swagger

---

## ▶️ Executing the project

### 1. Clone the repository

```bash
https://github.com/gmalisse/expense-tracker.git
```

### 2. Install EF Core packages

Navigate to the repository path and run:

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

### 3. Update the connection string in appsettings.json with your local DB credentials.

```bash
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=ExpenseDb;Username=youruser;Password=yourpassword"
}
```

docker

### 4. Apply existing migrations and populate the database

Run the command below to create the database using the migrations:

```bash
dotnet ef database update
```

![DER](ExpenseTracker/images/DER_18.03.2025.png)
