# GreenLife Organic Store ??

A modern Windows Forms e-commerce application built with .NET 8, designed for managing an organic produce store with comprehensive product, category, user, order, and shopping cart management.

**Author:** Yasas Pasindu Fernando

---

## ?? Table of Contents

- [Features](#features)
- [System Requirements](#system-requirements)
- [Installation](#installation)
  - [Clone the Repository](#1-clone-the-repository)
  - [Install NuGet Packages](#2-install-nuget-packages)
  - [Database Setup](#3-database-setup)
  - [Configuration](#4-configuration)
- [Running the Application](#running-the-application)
- [Project Structure](#project-structure)
- [Image Management](#image-management)
- [Features Overview](#features-overview)
- [Technologies Used](#technologies-used)
- [Troubleshooting](#troubleshooting)
- [License](#license)

---

## ? Features

- **User Management**
  - Customer registration and login
  - Admin panel for user management
  - Password reset functionality
  - Role-based access control

- **Product Management**
  - Create, read, update, delete products
  - Product categorization
  - Stock tracking
  - Discount pricing
  - Product images with automatic path resolution
  - Featured products support

- **Shopping Cart & Orders**
  - Shopping cart management
  - Checkout functionality
  - Order history tracking
  - Order status management
  - Sales reports

- **Admin Dashboard**
  - Product management
  - Category management
  - Customer management
  - Order management
  - Sales analytics

---

## ??? System Requirements

- **Operating System:** Windows 10 or later
- **.NET Version:** .NET 8 (SDK and Runtime)
- **IDE:** Visual Studio 2022 or later
- **Database:** MySQL 5.7 or later
- **RAM:** Minimum 4GB
- **Disk Space:** Minimum 500MB

---

## ?? Installation

### 1. Clone the Repository

Open PowerShell or Command Prompt and run:

```bash
git clone https://github.com/YasasPasinduFernando/GreenLife-Organic-Store.git
cd "GreenLife Organic Store"
```

### 2. Install NuGet Packages

#### Option A: Using Visual Studio (Recommended)

1. Open the solution file in Visual Studio 2022
2. Go to **Tools ? NuGet Package Manager ? Package Manager Console**
3. Run the following command:

```powershell
Update-Package
```

Or manually install each package:

```powershell
Install-Package FontAwesome.Sharp
Install-Package MySql.Data
Install-Package iTextSharp
```

#### Option B: Using Command Line

```bash
dotnet restore
```

#### Required NuGet Packages

| Package | Version | Purpose |
|---------|---------|---------|
| **FontAwesome.Sharp** | 6.2+ | Icon support for UI |
| **MySql.Data** | 8.0+ | MySQL database connectivity |
| **iTextSharp** | 5.5+ | PDF report generation |

### 3. Database Setup

#### Step 1: Create MySQL Database

1. Open **MySQL Workbench** or your MySQL client
2. Create a new database:

```sql
CREATE DATABASE greenlife;
USE greenlife;
```

#### Step 2: Create Required Tables

Run the following SQL script to create tables:

```sql
-- Users Table
CREATE TABLE Users (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Email VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    FullName VARCHAR(100),
    Phone VARCHAR(20),
    Address TEXT,
    Role ENUM('Admin', 'Customer') DEFAULT 'Customer',
    IsActive BOOLEAN DEFAULT TRUE,
    CreatedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Categories Table
CREATE TABLE Categories (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    CategoryName VARCHAR(100) NOT NULL UNIQUE,
    Description TEXT,
    ImagePath VARCHAR(255)
);

-- Products Table
CREATE TABLE Products (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    ProductName VARCHAR(100) NOT NULL,
    CategoryID INT NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    DiscountPrice DECIMAL(10, 2),
    Stock INT NOT NULL DEFAULT 0,
    Supplier VARCHAR(100),
    ImagePath VARCHAR(255),
    IsFeatured BOOLEAN DEFAULT FALSE,
    IsActive BOOLEAN DEFAULT TRUE,
    CreatedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (CategoryID) REFERENCES Categories(ID)
);

-- Shopping Cart Table
CREATE TABLE ShoppingCart (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    UserID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    AddedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserID) REFERENCES Users(ID),
    FOREIGN KEY (ProductID) REFERENCES Products(ID)
);

-- Orders Table
CREATE TABLE Orders (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    UserID INT NOT NULL,
    OrderDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    Status ENUM('Pending', 'Confirmed', 'Shipped', 'Delivered', 'Cancelled') DEFAULT 'Pending',
    ShippingAddress TEXT,
    FOREIGN KEY (UserID) REFERENCES Users(ID)
);

-- Order Items Table
CREATE TABLE OrderItems (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(ID),
    FOREIGN KEY (ProductID) REFERENCES Products(ID)
);
```

#### Step 3: Verify Database Connection

After creating the database, verify the connection string matches your MySQL setup.

### 4. Configuration

#### Update Database Connection String

1. Open the solution in Visual Studio
2. Locate the database connection configuration (usually in `DatabaseConnection.cs`)
3. Update the connection string with your MySQL credentials:

```csharp
private const string ConnectionString = "Server=localhost;Database=greenlife;Uid=root;Pwd=your_password;";
```

**Note:** Replace `your_password` with your actual MySQL root password.

---

## ?? Running the Application

### From Visual Studio

1. **Open the Solution**
   - File ? Open ? Project/Solution
   - Navigate to `GreenLife Organic Store.sln`

2. **Build the Solution**
   - Build ? Build Solution (or press `Ctrl+Shift+B`)
   - Wait for the build to complete successfully

3. **Run the Application**
   - Press `F5` or Debug ? Start Debugging
   - The application will launch

### From Command Line

```bash
dotnet run --project "GreenLife Organic Store/GreenLife Organic Store.csproj"
```

### First Run

1. **Default Admin Account** (if not created)
   - Username: `admin`
   - Password: `admin123`

2. **Create Test Data** (in Admin Dashboard)
   - Add categories (Vegetables, Fruits, etc.)
   - Add products with images
   - Set pricing and stock levels

---

## ?? Project Structure

```
GreenLife Organic Store/
??? Forms/                          # All UI Forms
?   ??? AdminDashboard.cs          # Admin management panel
?   ??? CustomerDashboard.cs       # Customer home screen
?   ??? ManageProductsForm.cs      # Product management
?   ??? ManageCategoriesForm.cs    # Category management
?   ??? ShoppingCartForm.cs        # Shopping cart
?   ??? CheckoutForm.cs            # Order checkout
?   ??? LoginForm.cs               # User login
?   ??? RegisterForm.cs            # User registration
?   ??? ... (other forms)
?
??? Database/                       # Data access layer
?   ??? DatabaseConnection.cs      # MySQL connection
?   ??? ProductRepository.cs       # Product queries
?   ??? CategoryRepository.cs      # Category queries
?   ??? UserRepository.cs          # User queries
?   ??? OrderRepository.cs         # Order queries
?   ??? CartRepository.cs          # Cart queries
?
??? Models/                         # Data models
?   ??? Product.cs                 # Product model
?   ??? Category.cs                # Category model
?   ??? User.cs                    # User model
?   ??? Order.cs                   # Order model
?   ??? ShoppingCart.cs            # Cart model
?
??? Utilities/                      # Helper utilities
?   ??? ImageStore.cs              # Image path management
?   ??? PasswordHasher.cs          # Password hashing
?   ??? EmailService.cs            # Email functionality
?   ??? EmailConfigValidator.cs    # Email validation
?
??? Reports/                        # Report generation
?   ??? PdfReportGenerator.cs      # PDF reports
?
??? Images/                         # Product images (auto-created)
?   ??? (product images stored here)
?
??? Program.cs                      # Application entry point
??? README.md                       # This file
```

---

## ??? Image Management

The application includes automatic image path resolution that works across all environments:

### How It Works

- **Storage Location:** All product images are stored in the `Images/` folder in the project root
- **Automatic Resolution:** The `ImageStore.cs` utility class handles path resolution automatically
- **Database Storage:** Images are stored in the database as relative paths (e.g., `Images/filename.jpg`)
- **Cross-Platform:** Works whether running from Visual Studio Debug, Release, or compiled executable

### Adding Product Images

1. In **Manage Products**, click "Edit" on any product
2. Click "Choose Image..." button
3. Select an image file from your computer
4. Image preview displays immediately
5. Click "Save Product" to store the image

### Supported Image Formats

- `.jpg` / `.jpeg`
- `.png`
- `.gif`
- `.bmp`

---

## ?? Features Overview

### Customer Features

- Browse products by category
- View product details and prices
- Add products to shopping cart
- Manage shopping cart (add, remove, update quantities)
- Checkout and place orders
- View order history
- Track order status
- Update profile information
- Reset password if forgotten

### Admin Features

- Dashboard with statistics
- Manage products (CRUD operations)
- Manage categories
- Manage customers
- Manage orders and order status
- View sales reports
- Generate PDF reports
- Monitor inventory/stock levels

---

## ??? Technologies Used

| Technology | Version | Purpose |
|-----------|---------|---------|
| **.NET** | 8.0 | Framework |
| **C#** | Latest | Programming Language |
| **Windows Forms** | .NET 8 | UI Framework |
| **MySQL** | 5.7+ | Database |
| **MySql.Data** | 8.0+ | Database Driver |
| **FontAwesome.Sharp** | 6.2+ | Icons |
| **iTextSharp** | 5.5+ | PDF Generation |

---

## ?? Troubleshooting

### Issue: "Unable to connect to database"

**Solution:**
1. Verify MySQL server is running
2. Check connection string in `DatabaseConnection.cs`
3. Ensure database `greenlife` exists
4. Verify username and password are correct

```bash
# Test MySQL connection
mysql -h localhost -u root -p greenlife
```

### Issue: "Images not displaying"

**Solution:**
1. Ensure `Images/` folder exists in project root
2. Check that product ImagePath in database starts with "Images/"
3. Rebuild solution (Clean ? Build)
4. Restart application

### Issue: "NuGet packages not found"

**Solution:**
```powershell
# Clear NuGet cache
nuget locals all -clear

# Restore packages
dotnet restore
```

### Issue: "Build fails with 'Package not found'"

**Solution:**
1. Open Package Manager Console
2. Run: `Update-Package -Reinstall`
3. Rebuild solution

---

## ?? Development Notes

- **Code Style:** Follows standard C# naming conventions
- **Error Handling:** Try-catch blocks with user-friendly messages
- **Database:** Uses parameterized queries to prevent SQL injection
- **Image Storage:** Automatically resolves paths from any runtime location
- **Password Security:** Passwords are hashed using SHA256

---

## ?? License

This project is the intellectual property of **Yasas Pasindu Fernando**.

---

## ?? Author

**Yasas Pasindu Fernando**

- GitHub: [@YasasPasinduFernando](https://github.com/YasasPasinduFernando)
- Repository: [GreenLife-Organic-Store](https://github.com/YasasPasinduFernando/GreenLife-Organic-Store)

---

## ?? Contributing

For issues, suggestions, or improvements, please open an issue on the GitHub repository.

---

## ? FAQ

**Q: Can I use this on Mac or Linux?**
A: Windows Forms is Windows-only. You would need to port to WPF or another cross-platform UI framework.

**Q: How do I backup my database?**
A: Use MySQL Workbench or command line:
```bash
mysqldump -u root -p greenlife > backup.sql
```

**Q: How do I add more admin users?**
A: Use the Admin Panel ? Manage Users to create new admin accounts.

**Q: Where are product images stored?**
A: All images are in the `Images/` folder in the project root directory.

---

**Last Updated:** January 2026  
**Version:** 1.0  
**Status:** Production Ready ?
