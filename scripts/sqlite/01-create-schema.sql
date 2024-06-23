-- Foreign key constraints enabled.
PRAGMA foreign_keys = ON;

-- Create Products table
CREATE TABLE
  IF NOT EXISTS `Products` (
    `Prod_Id` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Prod_Name` TEXT,
    `Prod_Description` TEXT,
    `Prod_Price` DECIMAL,
    `Prod_Availability` INTEGER -- Assuming Availability is represented as 0 (not available) or 1 (available)
  );

-- Create Country table
CREATE TABLE
  IF NOT EXISTS `Country` (
    `Country_Id` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Country_Name` TEXT
  );

-- Create Province table
CREATE TABLE
  IF NOT EXISTS `Province` (
    `Provi_Id` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Provi_CountryId` INTEGER,
    `Provi_Name` TEXT,
    FOREIGN KEY (`Provi_CountryId`) REFERENCES `Country` (`Country_Id`)
  );

-- Create Locality table
CREATE TABLE
  IF NOT EXISTS `Locality` (
    `Local_Id` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Local_ProviId` INTEGER,
    `Local_Name` TEXT,
    FOREIGN KEY (`Local_ProviId`) REFERENCES `Province` (`Provi_Id`)
  );

-- Create Employee table
CREATE TABLE
  IF NOT EXISTS `Employee` (
    `Emp_Id` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Emp_LocalId` INTEGER,
    `Emp_FirstName` TEXT,
    `Emp_LastName` TEXT,
    `Emp_Phone` TEXT,
    FOREIGN KEY (`Emp_LocalId`) REFERENCES `Locality` (`Local_Id`)
  );

-- Create User table
CREATE TABLE
  IF NOT EXISTS `User` (
    `User_Id` INTEGER PRIMARY KEY AUTOINCREMENT,
    `User_EmpId` INTEGER,
    `User_Username` TEXT,
    `User_Email` TEXT,
    `User_Password` TEXT,
    `User_PasswordSalt` TEXT,
    `User_TokenSalt` TEXT,
    FOREIGN KEY (`User_EmpId`) REFERENCES `Employee` (`Emp_Id`)
  );

-- Create Customer table
CREATE TABLE
  IF NOT EXISTS `Customer` (
    `Cust_Id` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Cust_LocalId` INTEGER,
    `Cust_FirstName` TEXT,
    `Cust_LastName` TEXT,
    `Cust_Phone` TEXT,
    `Cust_Email` TEXT,
    FOREIGN KEY (`Cust_LocalId`) REFERENCES `Locality` (`Local_Id`)
  );

-- Create Order table
CREATE TABLE
  IF NOT EXISTS `Order` (
    `Ord_Id` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Ord_EmpId` INTEGER,
    `Ord_CustId` INTEGER,
    `Ord_Date` DATE,
    `Ord_BillNumber` TEXT,
    `Ord_Total` DECIMAL,
    FOREIGN KEY (`Ord_EmpId`) REFERENCES `Employee` (`Emp_Id`),
    FOREIGN KEY (`Ord_CustId`) REFERENCES `Customer` (`Cust_Id`)
  );

-- Create OrderDetail table
CREATE TABLE
  IF NOT EXISTS `OrderDetail` (
    `OD_Id` INTEGER PRIMARY KEY AUTOINCREMENT,
    `OD_OrdId` INTEGER,
    `OD_ProdId` INTEGER,
    `OD_Quantity` INTEGER,
    `OD_Price` DECIMAL,
    FOREIGN KEY (`OD_OrdId`) REFERENCES `Order` (`Ord_Id`),
    FOREIGN KEY (`OD_ProdId`) REFERENCES `Products` (`Prod_Id`)
  );