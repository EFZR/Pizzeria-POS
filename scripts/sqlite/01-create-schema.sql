-- Foreign key constraints enabled.
PRAGMA foreign_keys = ON;

-- Create Products table
CREATE TABLE
  IF NOT EXISTS `Products` (
    `ID` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Name` TEXT,
    `Description` TEXT,
    `Price` DECIMAL,
    `Availability` INTEGER -- Assuming Availability is represented as 0 (not available) or 1 (available)
  );

-- Create Country table
CREATE TABLE
  IF NOT EXISTS `Country` (
    `ID` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Name` TEXT
  );

-- Create Province table
CREATE TABLE
  IF NOT EXISTS `Province` (
    `ID` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Country_ID` INTEGER,
    `Name` TEXT,
    FOREIGN KEY (`Country_ID`) REFERENCES `Country` (`ID`)
  );

-- Create Locality table
CREATE TABLE
  IF NOT EXISTS `Locality` (
    `ID` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Province_ID` INTEGER,
    `Name` TEXT,
    FOREIGN KEY (`Province_ID`) REFERENCES `Province` (`ID`)
  );

-- Create Employee table
CREATE TABLE
  IF NOT EXISTS `Employee` (
    `ID` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Locality_ID` INTEGER,
    `First_name` TEXT,
    `Last_name` TEXT,
    `Phone` TEXT,
    FOREIGN KEY (`Locality_ID`) REFERENCES `Locality` (`ID`)
  );

-- Create User table
CREATE TABLE
  IF NOT EXISTS `User` (
    `ID` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Employee_ID` INTEGER,
    `Username` TEXT,
    `Email` TEXT,
    `Password` TEXT,
    `Password_salt` TEXT,
    `Token_salt` TEXT,
    FOREIGN KEY (`Employee_ID`) REFERENCES `Employee` (`ID`)
  );

-- Create Customer table
CREATE TABLE
  IF NOT EXISTS `Customer` (
    `ID` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Locality_ID` INTEGER,
    `First_name` TEXT,
    `Last_name` TEXT,
    `Phone` TEXT,
    `Email` TEXT,
    FOREIGN KEY (`Locality_ID`) REFERENCES `Locality` (`ID`)
  );

-- Create Order table
CREATE TABLE
  IF NOT EXISTS `Order` (
    `ID` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Employee_ID` INTEGER,
    `Customer_ID` INTEGER,
    `Date` DATE,
    `BillNumber` TEXT,
    `Total` DECIMAL,
    FOREIGN KEY (`Employee_ID`) REFERENCES `Employee` (`ID`),
    FOREIGN KEY (`Customer_ID`) REFERENCES `Customer` (`ID`)
  );

-- Create OrderDetail table
CREATE TABLE
  IF NOT EXISTS `OrderDetail` (
    `ID` INTEGER PRIMARY KEY AUTOINCREMENT,
    `Order_ID` INTEGER,
    `Product_ID` INTEGER,
    `Quantity` INTEGER,
    `Price` DECIMAL,
    FOREIGN KEY (`Order_ID`) REFERENCES `Order` (`ID`),
    FOREIGN KEY (`Product_ID`) REFERENCES `Products` (`ID`)
  );