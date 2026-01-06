-- GreenLife Organic Store - Database Setup Script
-- This script creates the database and tables for the application

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

-- Insert a default admin user (password: admin123 - SHA256 hashed)
-- Note: In production, change this password immediately
INSERT IGNORE INTO Users (Email, Name, Phone, Age, Address, Sex, UserType, Password)
VALUES ('admin@greenlife.com', 'Admin User', '555-0000', 30, 'Admin Office', 'Male', 'Admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9');

-- Verify the database and table creation
SELECT 'Database and tables created successfully!' AS Status;
SELECT COUNT(*) as UserCount FROM Users;
