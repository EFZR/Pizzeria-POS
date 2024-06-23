-- Insert into Country table
INSERT INTO
  `Country` (`Country_Name`)
VALUES
  ('Honduras'),
  ('United States'),
  ('Canada'),
  ('United Kingdom'),
  ('Australia');

-- Insert into Province table
INSERT INTO
  `Province` (`Provi_CountryId`, `Provi_Name`)
VALUES
  (1, 'Francisco Morazan'),
  (1, 'Cortes'),
  (2, 'California'),
  (2, 'New York'),
  (3, 'Ontario'),
  (3, 'Quebec'),
  (4, 'England'),
  (4, 'Scotland'),
  (5, 'New South Wales'),
  (5, 'Victoria');

-- Insert into Locality table
INSERT INTO
  `Locality` (`Local_ProviId`, `Local_Name`)
VALUES
  (1, 'Distrito Central'),
  (1, 'Ojojona'),
  (2, 'Puerto Cortes'),
  (2, 'Omoa'),
  (3, 'Los Angeles'),
  (3, 'San Francisco'),
  (4, 'New York City'),
  (4, 'Buffalo'),
  (5, 'Toronto'),
  (5, 'Ottawa'),
  (6, 'Montreal'),
  (6, 'Quebec City'),
  (7, 'London'),
  (7, 'Manchester'),
  (8, 'Edinburgh'),
  (9, 'Sydney'),
  (9, 'Melbourne'),
  (10, 'Canberra');

-- Insert into Products table (adding pizzas)
INSERT INTO
  `Products` (`Prod_Name`, `Prod_Description`, `Prod_Price`, `Prod_Availability`)
VALUES
  (
    'Pepperoni Pizza',
    'Classic pizza topped with pepperoni and mozzarella cheese',
    10.99,
    1
  ),
  (
    'Margherita Pizza',
    'Traditional Italian pizza with tomato sauce, mozzarella cheese, and fresh basil',
    9.99,
    1
  ),
  (
    'Vegetarian Pizza',
    'Delicious pizza loaded with assorted vegetables and cheese',
    11.99,
    1
  ),
  (
    'BBQ Chicken Pizza',
    'Tender chicken pieces, BBQ sauce, red onions, and mozzarella cheese',
    12.99,
    1
  ),
  (
    'Hawaiian Pizza',
    'Pizza topped with ham, pineapple, and mozzarella cheese',
    10.99,
    1
  );

-- Insert into Employee table
INSERT INTO
  `Employee` (`Emp_LocalId`, `Emp_FirstName`, `Emp_LastName`, `Emp_Phone`)
VALUES
  (1, 'John', 'Doe', '123-456-7890'),
  (2, 'Jane', 'Smith', '987-654-3210'),
  (3, 'Michael', 'Johnson', '555-123-4567'),
  (4, 'Emily', 'Williams', '444-555-6666');

-- Insert into User table
INSERT INTO
  `User` (
    `User_EmpId`,
    `User_Username`,
    `User_Email`,
    `User_Password`,
    `User_PasswordSalt`,
    `User_TokenSalt`
  )
VALUES
  (
    1,
    'johndoe',
    'john.doe@example.com',
    'hashed_password',
    'salt_for_password',
    'salt_for_token'
  ),
  (
    2,
    'janesmith',
    'jane.smith@example.com',
    'hashed_password',
    'salt_for_password',
    'salt_for_token'
  ),
  (
    3,
    'michaelj',
    'michael.johnson@example.com',
    'hashed_password',
    'salt_for_password',
    'salt_for_token'
  ),
  (
    4,
    'emilyw',
    'emily.williams@example.com',
    'hashed_password',
    'salt_for_password',
    'salt_for_token'
  );

-- Insert into Customer table
INSERT INTO
  `Customer` (
    `Cust_LocalId`,
    `Cust_FirstName`,
    `Cust_LastName`,
    `Cust_Phone`,
    `Cust_Email`
  )
VALUES
  (
    1,
    'Alice',
    'Johnson',
    '111-222-3333',
    'alice.johnson@example.com'
  ),
  (
    2,
    'Bob',
    'Smith',
    '444-555-6666',
    'bob.smith@example.com'
  ),
  (
    3,
    'Eva',
    'Brown',
    '777-888-9999',
    'eva.brown@example.com'
  ),
  (
    4,
    'Jack',
    'Davis',
    '333-444-5555',
    'jack.davis@example.com'
  );

-- Insert into Order table
INSERT INTO
  `Order` (
    `Ord_EmpId`,
    `Ord_CustId`,
    `Ord_Date`,
    `Ord_BillNumber`,
    `Ord_Total`
  )
VALUES
  (1, 1, '2024-06-22', 'BILL001', 21.98),
  (2, 2, '2024-06-22', 'BILL002', 9.99),
  (3, 3, '2024-06-21', 'BILL003', 11.99),
  (4, 4, '2024-06-21', 'BILL004', 15.99);

-- Insert into OrderDetail table
INSERT INTO
  `OrderDetail` (`OD_OrdId`, `OD_ProdId`, `OD_Quantity`, `OD_Price`)
VALUES
  (1, 1, 2, 21.98), -- Order ID 1, Product ID 1 (Pepperoni Pizza), Quantity 2, Price 21.98
  (2, 2, 1, 9.99), -- Order ID 2, Product ID 2 (Margherita Pizza), Quantity 1, Price 9.99
  (3, 3, 1, 11.99), -- Order ID 3, Product ID 3 (Vegetarian Pizza), Quantity 1, Price 11.99
  (4, 1, 1, 10.99), -- Order ID 4, Product ID 1 (Pepperoni Pizza), Quantity 1, Price 10.99
  (4, 5, 1, 10.99) -- Order ID 4, Product ID 1 (Pepperoni Pizza), Quantity 1, Price 10.99
;