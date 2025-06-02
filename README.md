# ProductDemo 
# To Run the Application, Please follow below steps:

1. How to add migration ?
  => Open package manager console
  => type command :  add-migration InitialMigration -output ./Infrastructure/Migrations

2. How to update Database
   => update-database


3. Please follow below sample input for the "Products" table in MS SqlServer

INSERT INTO Products (Name, Description, Category, UnitPrice, Discontinued, ProductionData)
VALUES 
    ('Laptop', 'High-performance laptop', 'Electronics', 1200.50, 0, '2025-06-02'),
    ('Smartphone', 'Latest 5G smartphone', 'Electronics', 899.99, 0, '2025-05-15'),
    ('Office Chair', 'Ergonomic chair with lumbar support', 'Furniture', 199.99, 0, '2025-04-10'),
    ('Running Shoes', 'Lightweight and breathable running shoes', 'Sportswear', 129.50, 0, '2025-03-22'),
    ('Coffee Maker', 'Automatic drip coffee machine', 'Appliances', 79.99, 0, '2025-02-05');
