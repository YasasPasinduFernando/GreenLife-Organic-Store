# GreenLife Organic Store - Complete Application Guide

## Overview
GreenLife Organic Store is a professional Windows Forms application built with .NET 8 and MySQL database integration. It provides complete user authentication, role-based access control, and user management functionality.

## Technology Stack
- **Framework**: .NET 8 (Windows Forms)
- **Database**: MySQL 8.0+
- **Language**: C# 12.0
- **IDE**: Visual Studio 2022+
- **Package Manager**: NuGet

## Project Structure
```
GreenLife Organic Store/
??? Database/
?   ??? DatabaseConnection.cs      # MySQL connection management
?   ??? UserRepository.cs          # Data access layer for users
?   ??? database_setup.sql         # Database initialization script
??? Models/
?   ??? User.cs                    # User entity model
??? Utilities/
?   ??? PasswordHasher.cs          # SHA256 password hashing
??? Forms/
?   ??? LoginForm.cs               # User login interface
?   ??? RegisterForm.cs            # Customer self-registration
?   ??? AdminDashboard.cs          # Admin management panel
?   ??? CustomerDashboard.cs       # Customer home page
?   ??? AdminRegistrationForm.cs   # Admin registration by admin
?   ??? CustomerRegistrationForm.cs# Customer registration by admin
?   ??? UserDetailsForm.cs         # User edit dialog
?   ??? CustomerProfileEditForm.cs # Customer profile editor
?   ??? ChangePasswordForm.cs      # Password change dialog
??? Program.cs                     # Application entry point
??? GreenLife Organic Store.csproj # Project configuration
```

## Installation & Setup

### 1. Prerequisites
- Visual Studio 2022 or later
- .NET 8 SDK
- MySQL Server 8.0 or later
- MySQL Workbench (optional, for database management)

### 2. Database Setup
1. Open MySQL Workbench or MySQL Command Line Client
2. Execute the SQL script from `Database/database_setup.sql`:
   ```sql
   -- Copy entire contents of database_setup.sql and execute
   ```
3. The script will create:
   - Database: `greenlife`
   - Users table with all required fields
   - Default admin account (email: admin@greenlife.com, password: admin123)

### 3. Database Connection Configuration
Edit `Database/DatabaseConnection.cs` and update the connection string:
```csharp
private static readonly string ConnectionString = 
    "Server=localhost;Port=3306;Database=greenlife;Uid=yasas;Pwd=yasas;";
```

**Configuration Details**:
- **Server**: localhost
- **Port**: 3306
- **Database**: greenlife
- **Username**: yasas
- **Password**: yasas

### 4. Build & Run
1. Open the solution in Visual Studio
2. Build the project: `Build > Build Solution` (Ctrl+Shift+B)
3. Run the application: `Debug > Start Debugging` (F5)

## Features

### 1. Authentication & Login
- **Email-based login** with validation
- **Role-based access** (Admin/Customer)
- **Password hashing** using SHA256
- **Database validation** on startup
- **User-friendly error messages**

Default Admin Credentials:
- Email: `admin@greenlife.com`
- Password: `admin123`

### 2. Customer Registration
- Self-registration form
- Email uniqueness validation
- Full profile information collection
- Age verification (18+ years)
- Password strength validation (minimum 6 characters)
- Gender selection (Male/Female)

### 3. Admin Dashboard
Admins can:
- **Register new admins** with full details
- **Register new customers** manually
- **View all users** in a DataGridView
- **Edit user information** (name, contact, address, etc.)
- **Delete user accounts**
- **Logout** securely

Features:
- Full-featured user management table
- Sorting and filtering capabilities
- Professional UI design
- Double-click to edit user details

### 4. Customer Dashboard
Customers can:
- **View their profile information**
- **Edit their profile** (name, contact, address, gender, age)
- **Change password**
- **Logout** securely

Features:
- Clean, user-friendly interface
- Protected profile editing
- Password change functionality

## Database Schema

### Users Table
```sql
CREATE TABLE Users (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Name VARCHAR(100) NOT NULL,
    Phone VARCHAR(20),
    Age INT,
    Address VARCHAR(255),
    Sex ENUM('Male', 'Female') NOT NULL,
    UserType ENUM('Admin', 'Customer') NOT NULL DEFAULT 'Customer',
    Password VARCHAR(255) NOT NULL,  -- SHA256 hashed
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    IsActive BOOLEAN DEFAULT TRUE,
    INDEX idx_email (Email),
    INDEX idx_usertype (UserType),
    INDEX idx_createddate (CreatedDate)
);
```

## Security Features

### 1. Password Hashing
- **Algorithm**: SHA256
- **Implementation**: `PasswordHasher.cs`
- Passwords are never stored in plain text
- Verification method: `PasswordHasher.VerifyPassword()`

### 2. SQL Injection Prevention
- **Parameterized queries** throughout the application
- All user input is properly escaped
- `MySqlCommand.Parameters` used for all database operations

### 3. Input Validation
- Email format validation
- Email uniqueness checking
- Age range validation (18-120)
- Password strength requirements
- Required field validation on all forms

### 4. Access Control
- Role-based features (Admin vs Customer)
- Users can only access their own data
- Admins have full management access

## Usage Guide

### For Customers
1. **Register**: Click "Register here" on login form
2. **Fill in details**: Provide all required information
3. **Create account**: Password must match confirmation
4. **Login**: Use email and password to access account
5. **Manage profile**: Edit or change password anytime

### For Administrators
1. **Login**: Use admin credentials
2. **Register users**: Use "Register Admin" or "Register Customer" buttons
3. **View users**: Click "Refresh Users" to load all accounts
4. **Edit user**: Double-click on a user in the grid
5. **Delete user**: Select user and click "Delete User"

## API Reference

### DatabaseConnection
```csharp
// Get a new database connection
MySqlConnection conn = DatabaseConnection.GetConnection();

// Test connection availability
bool isConnected = DatabaseConnection.TestConnection();
```

### UserRepository
```csharp
// Authenticate user
User user = UserRepository.AuthenticateUser(email, password);

// Get user by email
User user = UserRepository.GetUserByEmail(email);

// Get user by ID
User user = UserRepository.GetUserById(id);

// Get all users
List<User> users = UserRepository.GetAllUsers();

// Create new user
int newUserId = UserRepository.CreateUser(user);

// Update user
bool success = UserRepository.UpdateUser(user);

// Change password
bool success = UserRepository.ChangePassword(userId, newPassword);

// Delete user
bool success = UserRepository.DeleteUser(userId);
```

### PasswordHasher
```csharp
// Hash a password
string hash = PasswordHasher.HashPassword(plainPassword);

// Verify a password
bool isValid = PasswordHasher.VerifyPassword(plainPassword, storedHash);
```

## Troubleshooting

### Database Connection Issues
- **Problem**: "Unable to connect to database"
  - **Solution**: Verify MySQL is running and connection string is correct in `DatabaseConnection.cs`

### Login Fails
- **Problem**: Authentication fails even with correct credentials
  - **Solution**: Ensure database is initialized with `database_setup.sql`

### Missing Controls
- **Problem**: Designer errors for form controls
  - **Solution**: Delete `.Designer.cs` cache and regenerate or rebuild solution

### Build Errors
- **Problem**: MySql.Data not found
  - **Solution**: Restore NuGet packages: `Tools > NuGet Package Manager > Manage NuGet Packages for Solution`

## Performance Considerations

### Database Indexing
The Users table includes indexes on:
- `Email` (for fast lookups)
- `UserType` (for filtering)
- `CreatedDate` (for sorting)

### Connection Pooling
MySQL.Data automatically manages connection pooling. Connections are reused and disposed properly in all methods.

## Future Enhancements

Potential features for future versions:
1. Two-factor authentication (2FA)
2. Email verification on registration
3. Audit logging for admin actions
4. Advanced user search and filtering
5. User activity history
6. Export user data to CSV/Excel
7. Bulk user operations
8. Custom dashboard reports
9. Theme customization
10. Multi-language support

## Maintenance

### Regular Tasks
1. **Backup database** regularly
2. **Monitor error logs** for issues
3. **Update MySQL.Data** package periodically
4. **Review user accounts** for inactive users
5. **Test backup and recovery** procedures

### Database Maintenance
```sql
-- Clean up old records
DELETE FROM Users WHERE IsActive = FALSE AND UpdatedDate < DATE_SUB(NOW(), INTERVAL 90 DAY);

-- Optimize tables
OPTIMIZE TABLE Users;
```

## Support & Documentation

For more information:
- Microsoft Docs: https://docs.microsoft.com/dotnet/
- MySQL Documentation: https://dev.mysql.com/doc/
- Windows Forms: https://docs.microsoft.com/dotnet/desktop/winforms/

## License & Credits

This application was developed as a complete solution for organic store management.

---

**Version**: 1.0.0  
**Last Updated**: 2024  
**Framework**: .NET 8.0  
**Status**: Production Ready
