# 🌿 GreenLife Organic Store

A modern Windows Forms e-commerce application built with .NET 8, designed for managing an organic produce store with comprehensive product, category, user, order, and shopping cart management.

**Version:** 1.0
**Author:** Yasas Pasindu Fernando
**Status:** Production Ready ✅
**Last Updated:** January 2026

---

## 📋 Table of Contents

* [Features](#-features)
* [System Requirements](#️-system-requirements)
* [Installation](#-installation)
* [Running the Application](#-running-the-application)
* [Project Structure](#-project-structure)
* [Image Management](#️-image-management)
* [Features Overview](#-features-overview)
* [Technologies Used](#️-technologies-used)
* [Troubleshooting](#-troubleshooting)
* [License](#-license)

---

## ✨ Features

### 👤 User Management

* Customer registration and login
* Admin panel for user management
* Password reset functionality
* Role-based access control

### 📦 Product Management

* Create, read, update, delete products
* Product categorization
* Stock tracking
* Discount pricing
* Product images with automatic path resolution
* Featured products support

### 🛒 Shopping Cart & Orders

* Shopping cart management
* Checkout functionality
* Order history tracking
* Order status management
* Sales reports

### 📊 Admin Dashboard

* Product management
* Category management
* Customer management
* Order management
* Sales analytics

---

## 🖥️ System Requirements

* **Operating System:** Windows 10 or later (64-bit)
* **Framework:** .NET 8 (SDK & Runtime)
* **IDE:** Visual Studio 2022 or later
* **Database:** MySQL 5.7 or later
* **RAM:** Minimum 4GB
* **Disk Space:** Minimum 500MB

---

## 📦 Installation

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/YasasPasinduFernando/GreenLife-Organic-Store.git
cd "GreenLife Organic Store"
```

### 2️⃣ Install NuGet Packages

#### Using Visual Studio (Recommended)

* Open solution in Visual Studio 2022
* Go to **Tools → NuGet Package Manager → Package Manager Console**
* Run:

```powershell
Update-Package
```

Or manually install:

```powershell
Install-Package FontAwesome.Sharp
Install-Package MySql.Data
Install-Package iTextSharp
```

#### Using Command Line

```bash
dotnet restore
```

---

### 3️⃣ Database Setup

```sql
CREATE DATABASE greenlife;
USE greenlife;
```

Run the provided SQL script to create all required tables.

---

### 4️⃣ Configuration

Update connection string in `DatabaseConnection.cs`:

```csharp
private const string ConnectionString = "Server=localhost;Database=greenlife;Uid=root;Pwd=your_password;";
```

---

## 🚀 Running the Application

### From Visual Studio

* Open the solution
* Build the project (Ctrl+Shift+B)
* Run using F5

### From Command Line

```bash
dotnet run --project "GreenLife Organic Store/GreenLife Organic Store.csproj"
```

### Default Admin Account

* **Username:** admin
* **Password:** admin123

---

## 📁 Project Structure

```
GreenLife Organic Store/
├── Forms/
├── Database/
├── Models/
├── Utilities/
├── Reports/
├── Images/
├── Program.cs
└── README.md
```

---

## 🖼️ Image Management

* Images are stored in the `Images/` folder
* Paths are saved as relative paths in database
* Supports JPG, PNG, GIF, BMP

---

## 🎯 Features Overview

### Customer

* Browse products
* Add to cart
* Checkout
* Order history

### Admin

* Dashboard
* Manage products & categories
* Manage users & orders
* PDF reports

---

## 🛠️ Technologies Used

| Technology        | Version | Purpose     |
| ----------------- | ------- | ----------- |
| .NET              | 8.0     | Framework   |
| C#                | Latest  | Programming |
| Windows Forms     | .NET 8  | UI          |
| MySQL             | 5.7+    | Database    |
| FontAwesome.Sharp | 6.2+    | Icons       |
| iTextSharp        | 5.5+    | PDF         |

---

## 🐛 Troubleshooting

### Database Connection Error

* Ensure MySQL is running
* Verify database exists
* Check credentials

```bash
mysql -u root -p greenlife
```

### Images Not Showing

* Ensure `Images/` folder exists
* Check image paths
* Rebuild solution

---

## 📄 License

This project is the intellectual property of **Yasas Pasindu Fernando**.

---

## 👤 Author

**Yasas Pasindu Fernando**
Software Developer — Sri Lanka 🇱🇰
GitHub: [https://github.com/YasasPasinduFernando](https://github.com/YasasPasinduFernando)

---

## 🤝 Contributing

Feel free to open issues or submit pull requests.

---

⭐ If you like this project, please give it a star on GitHub!
