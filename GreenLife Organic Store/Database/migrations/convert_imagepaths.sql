-- Migration: Convert ImagePath values to normalized relative paths under Images/
-- Backup your database before running this script.

-- This updates ImagePath to 'Images/<filename>' for any non-empty ImagePath
-- that does not already start with 'Images/'. It extracts the filename
-- from the existing path (handles backslashes and forward slashes).

UPDATE Products
SET ImagePath = CONCAT('Images/', SUBSTRING_INDEX(REPLACE(ImagePath, '\\', '/'), '/', -1))
WHERE ImagePath IS NOT NULL
  AND ImagePath <> ''
  AND ImagePath NOT LIKE 'Images/%';

-- Verify changes (run separately):
-- SELECT ID, ImagePath FROM Products WHERE ImagePath LIKE 'Images/%' LIMIT 100;
