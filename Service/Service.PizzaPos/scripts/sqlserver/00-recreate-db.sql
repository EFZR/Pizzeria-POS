IF OBJECT_ID('dbo.OrderDetail', 'U') IS NOT NULL
    DROP TABLE dbo.OrderDetail;

IF OBJECT_ID('dbo.[Order]', 'U') IS NOT NULL
    DROP TABLE dbo.[Order];

IF OBJECT_ID('dbo.Customer', 'U') IS NOT NULL
    DROP TABLE dbo.Customer;

IF OBJECT_ID('dbo.[User]', 'U') IS NOT NULL
    DROP TABLE dbo.[User];

IF OBJECT_ID('dbo.Employee', 'U') IS NOT NULL
    DROP TABLE dbo.Employee;

IF OBJECT_ID('dbo.Locality', 'U') IS NOT NULL
    DROP TABLE dbo.Locality;

IF OBJECT_ID('dbo.Province', 'U') IS NOT NULL
    DROP TABLE dbo.Province;

IF OBJECT_ID('dbo.Country', 'U') IS NOT NULL
    DROP TABLE dbo.Country;

IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL
    DROP TABLE dbo.Products;
