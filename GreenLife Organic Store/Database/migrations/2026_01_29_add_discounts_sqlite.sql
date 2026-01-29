-- SQLite migration: add discounts support
-- Run this against greenlife.db (SQLite)

-- 1) Add DiscountPrice to Products (run only if column is missing)
-- Check first:
-- PRAGMA table_info(Products);
-- If "DiscountPrice" is missing, run:
-- ALTER TABLE Products ADD COLUMN DiscountPrice REAL;

-- 2) Create Discounts table
CREATE TABLE IF NOT EXISTS Discounts (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    DiscountName TEXT NOT NULL,
    Description TEXT,
    DiscountPercent REAL NOT NULL,
    ProductID INTEGER NOT NULL,
    StartDate TEXT DEFAULT CURRENT_TIMESTAMP,
    EndDate TEXT NOT NULL,
    IsActive INTEGER DEFAULT 1,
    CreatedDate TEXT DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate TEXT DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ProductID) REFERENCES Products(ID) ON DELETE CASCADE
);

CREATE INDEX IF NOT EXISTS idx_discounts_product_id ON Discounts(ProductID);
CREATE INDEX IF NOT EXISTS idx_discounts_active ON Discounts(IsActive);
