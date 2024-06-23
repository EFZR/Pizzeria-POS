-- Create Products table
CREATE TABLE dbo.Products (
    Prod_Id INT PRIMARY KEY IDENTITY,
    Prod_Name NVARCHAR(MAX),
    Prod_Description NVARCHAR(MAX),
    Prod_Price DECIMAL(18, 2),
    Prod_Availability BIT -- Assuming Availability is represented as BIT (0 or 1)
);

-- Create Country table
CREATE TABLE dbo.Country (
    Country_Id INT PRIMARY KEY IDENTITY,
    Country_Name NVARCHAR(MAX)
);

-- Create Province table
CREATE TABLE dbo.Province (
    Provi_Id INT PRIMARY KEY IDENTITY,
    Provi_CountryId INT,
    Provi_Name NVARCHAR(MAX),
    CONSTRAINT FK_Province_Country FOREIGN KEY (Provi_CountryId) REFERENCES dbo.Country (Country_Id)
);

-- Create Locality table
CREATE TABLE dbo.Locality (
    Local_Id INT PRIMARY KEY IDENTITY,
    Local_ProviId INT,
    Local_Name NVARCHAR(MAX),
    CONSTRAINT FK_Locality_Province FOREIGN KEY (Local_ProviId) REFERENCES dbo.Province (Provi_Id)
);

-- Create Employee table
CREATE TABLE dbo.Employee (
    Emp_Id INT PRIMARY KEY IDENTITY,
    Emp_LocalId INT,
    Emp_FirstName NVARCHAR(MAX),
    Emp_LastName NVARCHAR(MAX),
    Emp_Phone NVARCHAR(MAX),
    CONSTRAINT FK_Employee_Locality FOREIGN KEY (Emp_LocalId) REFERENCES dbo.Locality (Local_Id)
);

-- Create User table
CREATE TABLE dbo.[User] (
    User_Id INT PRIMARY KEY IDENTITY,
    User_EmpId INT,
    User_Username NVARCHAR(MAX),
    User_Email NVARCHAR(MAX),
    User_Password NVARCHAR(MAX),
    User_PasswordSalt NVARCHAR(MAX),
    User_TokenSalt NVARCHAR(MAX),
    CONSTRAINT FK_User_Employee FOREIGN KEY (User_EmpId) REFERENCES dbo.Employee (Emp_Id)
);

-- Create Customer table
CREATE TABLE dbo.Customer (
    Cust_Id INT PRIMARY KEY IDENTITY,
    Cust_LocalId INT,
    Cust_FirstName NVARCHAR(MAX),
    Cust_LastName NVARCHAR(MAX),
    Cust_Phone NVARCHAR(MAX),
    Cust_Email NVARCHAR(MAX),
    CONSTRAINT FK_Customer_Locality FOREIGN KEY (Cust_LocalId) REFERENCES dbo.Locality (Local_Id)
);

-- Create Order table
CREATE TABLE dbo.[Order] (
    Ord_Id INT PRIMARY KEY IDENTITY,
    Ord_EmpId INT,
    Ord_CustId INT,
    Ord_Date DATE,
    Ord_BillNumber NVARCHAR(MAX),
    Ord_Total DECIMAL(18, 2),
    CONSTRAINT FK_Order_Employee FOREIGN KEY (Ord_EmpId) REFERENCES dbo.Employee (Emp_Id),
    CONSTRAINT FK_Order_Customer FOREIGN KEY (Ord_CustId) REFERENCES dbo.Customer (Cust_Id)
);

-- Create OrderDetail table
CREATE TABLE dbo.OrderDetail (
    OD_Id INT PRIMARY KEY IDENTITY,
    OD_OrdId INT,
    OD_ProdId INT,
    OD_Quantity INT,
    OD_Price DECIMAL(18, 2),
    CONSTRAINT FK_OrderDetail_Order FOREIGN KEY (OD_OrdId) REFERENCES dbo.[Order] (Ord_Id),
    CONSTRAINT FK_OrderDetail_Product FOREIGN KEY (OD_ProdId) REFERENCES dbo.Products (Prod_Id)
);
