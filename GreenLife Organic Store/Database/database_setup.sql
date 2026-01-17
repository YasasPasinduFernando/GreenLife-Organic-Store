-- ============================================
-- GREENLIFE E-COMMERCE DATABASE SCHEMA
-- ============================================

-- Create the database if it doesn't exist
CREATE DATABASE IF NOT EXISTS greenlife;
USE greenlife;

-- Create Users table
CREATE TABLE IF NOT EXISTS Users (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Name VARCHAR(100) NOT NULL,
    Phone VARCHAR(20),
    Age INT,
    Address VARCHAR(255),
    Sex ENUM('Male', 'Female') NOT NULL,
    UserType ENUM('Admin', 'Customer') NOT NULL DEFAULT 'Customer',
    Password VARCHAR(255) NOT NULL,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    IsActive BOOLEAN DEFAULT TRUE,
    INDEX idx_email (Email),
    INDEX idx_usertype (UserType),
    INDEX idx_createddate (CreatedDate)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- CartItems Table (store user cart between sessions)
CREATE TABLE IF NOT EXISTS CartItems (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    UserID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (UserID) REFERENCES Users(ID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Products(ID) ON DELETE CASCADE,
    UNIQUE KEY ux_user_product (UserID, ProductID),
    INDEX idx_user (UserID),
    INDEX idx_product (ProductID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Categories Table
CREATE TABLE IF NOT EXISTS Categories (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    CategoryName VARCHAR(100) UNIQUE NOT NULL,
    Description TEXT,
    ImagePath VARCHAR(500),
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN DEFAULT TRUE,
    INDEX idx_active (IsActive)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Products Table
CREATE TABLE IF NOT EXISTS Products (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    ProductName VARCHAR(255) NOT NULL,
    CategoryID INT NOT NULL,
    Description TEXT,
    Price DECIMAL(10,2) NOT NULL,
    DiscountPrice DECIMAL(10,2),
    Stock INT NOT NULL DEFAULT 0,
    Supplier VARCHAR(255),
    ImagePath VARCHAR(500),
    IsFeatured BOOLEAN DEFAULT FALSE,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    IsActive BOOLEAN DEFAULT TRUE,
    FOREIGN KEY (CategoryID) REFERENCES Categories(ID),
    INDEX idx_category (CategoryID),
    INDEX idx_active (IsActive),
    INDEX idx_name (ProductName),
    INDEX idx_featured (IsFeatured)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Orders Table
CREATE TABLE IF NOT EXISTS Orders (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    OrderNumber VARCHAR(50) UNIQUE NOT NULL,
    CustomerID INT NOT NULL,
    CustomerName VARCHAR(255) NOT NULL,
    CustomerPhone VARCHAR(20) NOT NULL,
    CustomerEmail VARCHAR(255) NOT NULL,
    OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    TotalAmount DECIMAL(10,2) NOT NULL,
    Status ENUM('Pending', 'Processing', 'Shipped', 'Delivered', 'Cancelled') DEFAULT 'Pending',
    ShippingAddress TEXT NOT NULL,
    Notes TEXT,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (CustomerID) REFERENCES Users(ID),
    INDEX idx_customer (CustomerID),
    INDEX idx_status (Status),
    INDEX idx_order_date (OrderDate),
    INDEX idx_order_number (OrderNumber)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- OrderItems Table
CREATE TABLE IF NOT EXISTS OrderItems (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    ProductName VARCHAR(255) NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (OrderID) REFERENCES Orders(ID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Products(ID),
    INDEX idx_order (OrderID),
    INDEX idx_product (ProductID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- OrderReviews Table (order-level reviews by customers)
CREATE TABLE IF NOT EXISTS OrderReviews (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    OrderID INT NOT NULL,
    CustomerID INT NOT NULL,
    Rating INT NOT NULL,
    Comment TEXT,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (OrderID) REFERENCES Orders(ID) ON DELETE CASCADE,
    FOREIGN KEY (CustomerID) REFERENCES Users(ID) ON DELETE CASCADE,
    UNIQUE KEY ux_order_customer (OrderID, CustomerID),
    INDEX idx_order (OrderID),
    INDEX idx_customer (CustomerID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Insert a default admin user (password: admin123 - SHA256 hashed)
-- Note: In production, change this password immediately
INSERT IGNORE INTO Users (Email, Name, Phone, Age, Address, Sex, UserType, Password)
VALUES ('admin@greenlife.com', 'Admin User', '555-0000', 30, 'Admin Office', 'Male', 'Admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9');

-- Sample Data: Categories
INSERT IGNORE INTO Categories (CategoryName, Description) VALUES
('Organic Fruits', 'Fresh organic fruits from local farms'),
('Organic Vegetables', 'Fresh organic vegetables'),
('Dairy Products', 'Organic milk, butter, cheese and yogurt'),
('Grains & Cereals', 'Organic rice, wheat, and cereals'),
('Beverages', 'Organic juices, teas and drinks'),
('Spices', 'Organic Sri Lankan spices');

-- Sample Data: Products (Sri Lankan context)
INSERT IGNORE INTO Products (ProductName, CategoryID, Description, Price, Stock, Supplier) VALUES
-- Fruits
('Organic Papaya', 1, 'Fresh organic papaya from local farms', 200.00, 50, 'Green Valley Farms'),
('Organic Bananas (1kg)', 1, 'Sweet organic bananas', 180.00, 100, 'Green Valley Farms'),
('Organic Pineapple', 1, 'Juicy organic pineapple', 250.00, 30, 'Fresh Fruits Co.'),
('King Coconut (each)', 1, 'Fresh king coconut water', 150.00, 80, 'Coconut Suppliers'),
-- Vegetables
('Organic Tomatoes (1kg)', 2, 'Fresh organic tomatoes', 220.00, 60, 'Veggie Farm'),
('Organic Carrots (1kg)', 2, 'Crunchy organic carrots', 180.00, 50, 'Veggie Farm'),
('Organic Cabbage', 2, 'Fresh organic cabbage', 120.00, 40, 'Veggie Farm'),
('Organic Beans (500g)', 2, 'Fresh green beans', 150.00, 35, 'Veggie Farm'),
-- Dairy
('Organic Milk (1L)', 3, 'Fresh organic cow milk', 300.00, 45, 'Dairy Fresh'),
('Organic Yogurt (400g)', 3, 'Creamy organic yogurt', 250.00, 40, 'Dairy Fresh'),
('Organic Butter (250g)', 3, 'Pure organic butter', 450.00, 25, 'Dairy Fresh'),
-- Grains
('Organic Brown Rice (1kg)', 4, 'Healthy organic brown rice', 350.00, 100, 'Rice Mill Co.'),
('Organic Red Rice (1kg)', 4, 'Traditional Sri Lankan red rice', 400.00, 80, 'Rice Mill Co.'),
('Organic Wheat Flour (1kg)', 4, 'Stone ground wheat flour', 280.00, 60, 'Grain House'),
-- Beverages
('Organic Green Tea (100g)', 5, 'Pure Ceylon green tea', 450.00, 50, 'Tea Factory'),
('Organic Herbal Tea (100g)', 5, 'Mixed herbal tea blend', 500.00, 40, 'Tea Factory'),
('Organic Coconut Water (500ml)', 5, 'Pure coconut water', 180.00, 70, 'Coconut Co.'),
-- Spices
('Organic Cinnamon (50g)', 6, 'Pure Ceylon cinnamon powder', 350.00, 45, 'Spice Traders'),
('Organic Turmeric (100g)', 6, 'Fresh organic turmeric powder', 280.00, 50, 'Spice Traders'),
('Organic Pepper (50g)', 6, 'Black pepper from Sri Lanka', 400.00, 35, 'Spice Traders');

-- Verify the database and table creation
SELECT 'Database and tables created successfully!' AS Status;
SELECT COUNT(*) as UserCount FROM Users;
SELECT COUNT(*) as CategoryCount FROM Categories;
SELECT COUNT(*) as ProductCount FROM Products;
