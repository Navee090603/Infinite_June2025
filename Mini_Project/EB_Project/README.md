# Electricity Board Billing Automation (ASP.NET WebForms)

This is a simple, professional web application for automating electricity bill management, built with ASP.NET WebForms and a clean Bootstrap UI. It supports admin login, customer management, bill generation, and bill viewing.

## Features

- **Admin Login:** Secure login with session management.
- **Customer Management:** Add and view customers.
- **Bill Management:** Generate electricity bills, view recent bills.
- **Professional UI:** Responsive Bootstrap design with a master page.
- **Separation of Concerns:** Business logic in a separate class library (DLL).

## Solution Structure

- **EBillDLL (Class Library):** Contains business logic and data access classes.
- **EBillApp (Web Application):** ASP.NET WebForms UI (Login, Dashboard, Add/View Bill, Add/View Customer).

## Setup Instructions

### 1. Database Setup

1. Open SQL Server Management Studio.
2. Run the SQL script (provided below) to create the database and required tables.

```sql
CREATE DATABASE ElectricityBillDB;
GO

USE ElectricityBillDB;
GO

CREATE TABLE AdminLogin (
    Username VARCHAR(20) PRIMARY KEY,
    Password VARCHAR(20) NOT NULL
);

CREATE TABLE Customers (
    ConsumerNumber VARCHAR(20) PRIMARY KEY CHECK (ConsumerNumber LIKE 'EB[0-9][0-9][0-9][0-9][0-9]'),
    ConsumerName VARCHAR(50) NOT NULL,
    JoinDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE ElectricityBill (
    BillId INT IDENTITY(1,1) PRIMARY KEY,
    ConsumerNumber VARCHAR(20) FOREIGN KEY REFERENCES Customers(ConsumerNumber),
    UnitsConsumed INT NOT NULL CHECK (UnitsConsumed >= 0),
    BillAmount FLOAT NOT NULL,
    BillMonth VARCHAR(20) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE()
);

INSERT INTO AdminLogin VALUES ('n@e.com', '10');
```
</details>

### 2. Configuration

```xml
<connectionStrings>
  <add name="EBillDB" connectionString="Data Source=our's;Initial Catalog=ElectricityBillDB;User Id= our's; Password= Our's" providerName="System.Data.SqlClient"/>
</connectionStrings>
```

### 3. Build and Run

1. Build the solution in Visual Studio.
2. Set `EBillApp` as the start-up project.
3. Run the application (F5).

### 4. Login

- **Username:** n@e.com
- **Password:** 10

## Pages

- **Login:** `/Login.aspx`
- **Dashboard (after login):** `/AddBill.aspx`
- **Add Bill:** `/AddBill.aspx`
- **View Bills:** `/ViewBills.aspx`
- **Add Customer:** `/AddCustomer.aspx`
- **View Customers:** `/Customers.aspx`

## Notes

- All pages except Login are protected (require authentication).
- The project uses ASP.NET validators and proper error messages for user-friendly feedback.
- Code is organized for easy maintenance and extension.

---

**Enjoy using the Electricity Board Billing Automation System!**