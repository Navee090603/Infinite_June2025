create database ElectricityBillDB

-- Admin login table
CREATE TABLE AdminLogin (
    Username VARCHAR(20) PRIMARY KEY,
    Password VARCHAR(20) NOT NULL
);

-- Customers table
CREATE TABLE Customers (
    ConsumerNumber VARCHAR(20) PRIMARY KEY CHECK (ConsumerNumber LIKE 'EB[0-9][0-9][0-9][0-9][0-9]'),
    ConsumerName VARCHAR(50) NOT NULL,
    JoinDate DATETIME DEFAULT GETDATE()
);

-- Electricity bills table
CREATE TABLE ElectricityBill (
    BillId INT IDENTITY(1,1) PRIMARY KEY,
    ConsumerNumber VARCHAR(20) FOREIGN KEY REFERENCES Customers(ConsumerNumber),
    UnitsConsumed INT NOT NULL CHECK (UnitsConsumed >= 0),
    BillAmount FLOAT NOT NULL,
    BillMonth VARCHAR(20) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE()
);

-- Insert admin credentials
INSERT INTO AdminLogin VALUES ('n@e.com', '10');

select * from ElectricityBill
select * from Customers
select * from AdminLogin


