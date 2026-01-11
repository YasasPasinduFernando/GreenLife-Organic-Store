CREATE DATABASE  IF NOT EXISTS `greenlife` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `greenlife`;
-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: greenlife
-- ------------------------------------------------------
-- Server version	8.0.39

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cartitems`
--

DROP TABLE IF EXISTS `cartitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cartitems` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `UserID` int NOT NULL,
  `ProductID` int NOT NULL,
  `Quantity` int NOT NULL DEFAULT '1',
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `UpdatedDate` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ux_user_product` (`UserID`,`ProductID`),
  KEY `idx_user` (`UserID`),
  KEY `idx_product` (`ProductID`),
  CONSTRAINT `cartitems_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `users` (`ID`) ON DELETE CASCADE,
  CONSTRAINT `cartitems_ibfk_2` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cartitems`
--

LOCK TABLES `cartitems` WRITE;
/*!40000 ALTER TABLE `cartitems` DISABLE KEYS */;
INSERT INTO `cartitems` VALUES (1,2,23,3,'2026-01-07 10:56:28','2026-01-07 11:09:50'),(2,2,22,3,'2026-01-07 10:56:32','2026-01-07 23:40:13'),(3,2,26,2,'2026-01-07 10:57:12','2026-01-07 10:57:44'),(4,2,21,3,'2026-01-07 23:17:57','2026-01-07 23:40:19'),(12,7,25,1,'2026-01-08 20:13:34','2026-01-08 20:13:34'),(13,7,23,1,'2026-01-08 20:13:40','2026-01-08 20:13:40'),(21,7,16,1,'2026-01-10 23:22:54','2026-01-10 23:22:54');
/*!40000 ALTER TABLE `cartitems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Description` text COLLATE utf8mb4_unicode_ci,
  `ImagePath` varchar(500) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `IsActive` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `CategoryName` (`CategoryName`),
  KEY `idx_active` (`IsActive`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Organic Fruits','Fresh organic fruits from local farms','Images/WhatsApp Image 2026-01-10 at 21.56.44.jpeg','2026-01-07 00:19:29',1),(2,'Organic Vegetables','Fresh organic vegetables','Images/WhatsApp Image 2026-01-10 at 21.55.45.jpeg','2026-01-07 00:19:29',1),(3,'Dairy Products','Organic milk, butter, cheese and yogurt','Images/WhatsApp Image 2026-01-10 at 23.06.51.jpeg','2026-01-07 00:19:29',1),(4,'Grains & Cereals','Organic rice, wheat, and cereals','Images/WhatsApp Image 2026-01-10 at 23.09.39.jpeg','2026-01-07 00:19:29',1),(5,'Beverages','Organic juices, teas and drinks','Images/WhatsApp Image 2026-01-10 at 23.08.44.jpeg','2026-01-07 00:19:29',1),(6,'Spices','Organic Sri Lankan spices','Images/WhatsApp Image 2026-01-10 at 23.06.05.jpeg','2026-01-07 00:19:29',1),(8,'Biscuits','cat1','Images/WhatsApp Image 2026-01-10 at 23.09.08.jpeg','2026-01-07 21:16:18',1);
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderitems`
--

DROP TABLE IF EXISTS `orderitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderitems` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `OrderID` int NOT NULL,
  `ProductID` int NOT NULL,
  `ProductName` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Quantity` int NOT NULL,
  `UnitPrice` decimal(10,2) NOT NULL,
  `Subtotal` decimal(10,2) NOT NULL,
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `idx_order` (`OrderID`),
  KEY `idx_product` (`ProductID`),
  CONSTRAINT `orderitems_ibfk_1` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`ID`) ON DELETE CASCADE,
  CONSTRAINT `orderitems_ibfk_2` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderitems`
--

LOCK TABLES `orderitems` WRITE;
/*!40000 ALTER TABLE `orderitems` DISABLE KEYS */;
INSERT INTO `orderitems` VALUES (1,2,4,'King Coconut (each)',2,150.00,300.00,'2026-01-07 09:33:54'),(2,2,3,'Organic Pineapple',1,250.00,250.00,'2026-01-07 09:33:54'),(3,3,23,'Organic Pineapple',1,250.00,250.00,'2026-01-07 10:36:19'),(4,3,22,'Organic Bananas (1kg)',1,180.00,180.00,'2026-01-07 10:36:19'),(5,3,26,'Organic Carrots (1kg)',1,180.00,180.00,'2026-01-07 10:36:19'),(6,4,22,'Organic Bananas (1kg)',1,180.00,180.00,'2026-01-08 18:18:22'),(7,4,23,'Organic Pineapple',1,250.00,250.00,'2026-01-08 18:18:22'),(8,5,22,'Organic Bananas (1kg)',1,180.00,180.00,'2026-01-08 18:21:39'),(9,5,23,'Organic Pineapple',2,250.00,500.00,'2026-01-08 18:21:39'),(10,6,22,'Organic Bananas (1kg)',1,180.00,180.00,'2026-01-08 18:23:52'),(11,6,23,'Organic Pineapple',3,250.00,750.00,'2026-01-08 18:23:52'),(12,7,25,'Organic Tomatoes (1kg)',1,220.00,220.00,'2026-01-08 18:25:05'),(13,8,22,'Organic Bananas (1kg)',1,180.00,180.00,'2026-01-08 19:40:18'),(14,8,23,'Organic Pineapple',3,250.00,750.00,'2026-01-08 19:40:18'),(15,8,25,'Organic Tomatoes (1kg)',1,220.00,220.00,'2026-01-08 19:40:18'),(16,9,25,'Organic Tomatoes (1kg)',2,220.00,440.00,'2026-01-08 19:43:19'),(17,9,22,'Organic Bananas (1kg)',1,180.00,180.00,'2026-01-08 19:43:19'),(18,9,23,'Organic Pineapple',3,250.00,750.00,'2026-01-08 19:43:19'),(19,10,22,'Organic Bananas (1kg)',1,180.00,180.00,'2026-01-08 19:46:25'),(20,10,23,'Organic Pineapple',3,250.00,750.00,'2026-01-08 19:46:25'),(21,10,25,'Organic Tomatoes (1kg)',2,220.00,440.00,'2026-01-08 19:46:25'),(22,11,24,'King Coconut (each)',1,150.00,150.00,'2026-01-08 19:59:12'),(23,11,25,'Organic Tomatoes (1kg)',1,220.00,220.00,'2026-01-08 19:59:12'),(24,12,24,'King Coconut (each)',1,150.00,150.00,'2026-01-08 20:04:35'),(25,12,23,'Organic Pineapple',1,250.00,250.00,'2026-01-08 20:04:35'),(26,13,23,'Organic Pineapple',2,250.00,500.00,'2026-01-09 14:52:39'),(27,13,21,'Organic Papaya',1,200.00,200.00,'2026-01-09 14:52:39'),(28,13,22,'Organic Bananas (1kg)',1,180.00,180.00,'2026-01-09 14:52:39'),(29,14,32,'Organic Brown Rice (1kg)',1,350.00,350.00,'2026-01-09 14:52:58'),(30,14,30,'Organic Yogurt (400g)',1,250.00,250.00,'2026-01-09 14:52:58'),(31,14,29,'Organic Milk (1L)',1,300.00,300.00,'2026-01-09 14:52:58'),(32,14,24,'King Coconut (each)',1,150.00,150.00,'2026-01-09 14:52:58');
/*!40000 ALTER TABLE `orderitems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `OrderNumber` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `CustomerID` int NOT NULL,
  `CustomerName` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `CustomerPhone` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `CustomerEmail` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `OrderDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `TotalAmount` decimal(10,2) NOT NULL,
  `Status` enum('Pending','Processing','Shipped','Delivered','Cancelled') COLLATE utf8mb4_unicode_ci DEFAULT 'Pending',
  `ShippingAddress` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `Notes` text COLLATE utf8mb4_unicode_ci,
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `UpdatedDate` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `OrderNumber` (`OrderNumber`),
  KEY `idx_customer` (`CustomerID`),
  KEY `idx_status` (`Status`),
  KEY `idx_order_date` (`OrderDate`),
  KEY `idx_order_number` (`OrderNumber`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`CustomerID`) REFERENCES `users` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (2,'ORD-20260107093354',2,'customer@gmail.com','32323232','customer@gmail.com','2026-01-07 09:33:54',550.00,'Pending','galle,nayapamula,hikkaduwa',NULL,'2026-01-07 09:33:54','2026-01-08 00:31:07'),(3,'ORD-20260107103619',2,'customer@gmail.com','customer@gmail.com','customer@gmail.com','2026-01-07 10:36:19',610.00,'Delivered','sdsds',NULL,'2026-01-07 10:36:19','2026-01-07 16:47:38'),(4,'ORD-20260108181822',7,'yasas','0773664090','yasaspasindufernando@gmail.com','2026-01-08 18:18:22',430.00,'Pending','nalagasdeniya,hikkaduwa','','2026-01-08 18:18:22','2026-01-08 18:18:22'),(5,'ORD-20260108182139',7,'yasaspasindufernando@gmail.com','0773664090','yasaspasindufernando@gmail.com','2026-01-08 18:21:40',680.00,'Delivered','yasaspasindufernando@gmail.com','','2026-01-08 18:21:39','2026-01-08 18:27:29'),(6,'ORD-20260108182352',7,'yasaspasindufernando@gmail.com','07273','yasaspasindufernando@gmail.com','2026-01-08 18:23:53',930.00,'Processing','yasaspasindufernando@gmail.com','','2026-01-08 18:23:52','2026-01-08 18:27:19'),(7,'ORD-20260108182505',7,'yasaspasindufernando@gmail.com','424','yasaspasindufernando@gmail.com','2026-01-08 18:25:05',220.00,'Processing','yasaspasindufernando@gmail.com','','2026-01-08 18:25:05','2026-01-08 18:27:13'),(8,'ORD-20260108194018',7,'yasaspasindufernando@gmail.com','0774564563','yasaspasindufernando@gmail.com','2026-01-08 19:40:19',1150.00,'Pending','yasaspasindufernando@gmail.com','','2026-01-08 19:40:18','2026-01-08 19:40:18'),(9,'ORD-20260108194319',7,'yasaspasindufernando@gmail.com','0773664090','yasaspasindufernando@gmail.com','2026-01-08 19:43:20',1370.00,'Pending','yasaspasindufernando@gmail.com','','2026-01-08 19:43:19','2026-01-08 19:43:19'),(10,'ORD-20260108194625',7,'yasas','0776905654','yasaspasindufernando@gmail.com','2026-01-08 19:46:26',1370.00,'Pending','nalagasdeniya,hikkaduwa','','2026-01-08 19:46:25','2026-01-08 19:46:25'),(11,'ORD-20260108195912',7,'yasas','0776905654','yasaspasindufernando@gmail.com','2026-01-08 19:59:13',370.00,'Pending','nalagasdeniya,hikkaduwa','','2026-01-08 19:59:12','2026-01-08 19:59:12'),(12,'ORD-20260108200435',7,'yasas','0776905654','yasaspasindufernando@gmail.com','2026-01-08 20:04:36',400.00,'Pending','nalagasdeniya,hikkaduwa','','2026-01-08 20:04:35','2026-01-08 20:04:35'),(13,'ORD-20260109145239',11,'yasantha elanayake','0777169043','yasantha.ekanayake@ideahub.lk','2026-01-09 14:52:40',880.00,'Cancelled','nuwara handiya','','2026-01-09 14:52:39','2026-01-09 15:07:57'),(14,'ORD-20260109145258',11,'yasantha elanayake','0777169043','yasantha.ekanayake@ideahub.lk','2026-01-09 14:52:59',1050.00,'Cancelled','nuwara handiya','','2026-01-09 14:52:58','2026-01-09 15:08:07');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `CategoryID` int NOT NULL,
  `Description` text COLLATE utf8mb4_unicode_ci,
  `Price` decimal(10,2) NOT NULL,
  `DiscountPrice` decimal(10,2) DEFAULT NULL,
  `Stock` int NOT NULL DEFAULT '0',
  `Supplier` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `ImagePath` varchar(500) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `IsFeatured` tinyint(1) DEFAULT '0',
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `UpdatedDate` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `IsActive` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`ID`),
  KEY `idx_category` (`CategoryID`),
  KEY `idx_active` (`IsActive`),
  KEY `idx_name` (`ProductName`),
  KEY `idx_featured` (`IsFeatured`),
  CONSTRAINT `products_ibfk_1` FOREIGN KEY (`CategoryID`) REFERENCES `categories` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Organic Ambarella',1,'Fresh organic papaya from local farms',200.00,NULL,50,'Green Valley Farms','Images/WhatsApp Image 2026-01-10 at 23.00.29.jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(2,'Organic Mang(1kg)',1,'Sweet organic bananas',180.00,NULL,100,'Green Valley Farms','Images/WhatsApp Image 2026-01-10 at 23.00.28.jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(3,'Organic Cucumbur',2,'Juicy organic pineapple',250.00,NULL,29,'Fresh Fruits Co.','Images/WhatsApp Image 2026-01-10 at 23.00.28 (1).jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(4,'Coconut (each)',2,'Fresh king coconut water',150.00,NULL,78,'Coconut Suppliers','Images/WhatsApp Image 2026-01-10 at 23.04.23.jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(5,'Organic Pumpking(1kg)',2,'Fresh organic tomatoes',220.00,NULL,60,'Veggie Farm','Images/WhatsApp Image 2026-01-10 at 22.46.42.jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(6,'Organic Potato(1kg)',2,'Crunchy organic carrots',180.00,NULL,50,'Veggie Farm','Images/WhatsApp Image 2026-01-10 at 22.46.43.jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(7,'Sweet Potato (500g)',2,'Fresh organic cabbage',120.00,NULL,40,'Veggie Farm','Images/WhatsApp Image 2026-01-10 at 22.46.43 (1).jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(8,'Beetroot (500g)',2,'Fresh green beans',150.00,NULL,35,'Veggie Farm','Images/WhatsApp Image 2026-01-10 at 22.46.43 (2).jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(9,'Bran Cracker 200g)',8,'Fresh organic cow milk',300.00,NULL,45,'Dairy Fresh','Images/WhatsApp Image 2026-01-10 at 22.53.25.jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(10,'Raisin Biscut(100g)',8,'Creamy organic yogurt',250.00,NULL,40,'Dairy Fresh','Images/WhatsApp Image 2026-01-10 at 22.52.15.jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(11,'Rice Cracker (250g)',8,'Pure organic butter',450.00,NULL,25,'Dairy Fresh','Images/WhatsApp Image 2026-01-10 at 22.50.36.jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(13,'Organic Red Rose Rice (1kg)',4,'Traditional Sri Lankan red rice',400.00,NULL,80,'Rice Mill Co.','Images/WhatsApp Image 2026-01-10 at 22.02.22.jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(14,'Organic Wheat Flour (1kg)',4,'Stone ground wheat flour',280.00,NULL,60,'Grain House','Images/WhatsApp Image 2026-01-10 at 22.41.46.jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(15,'Organic Green Tea (100g)',5,'Pure Ceylon green tea',450.00,NULL,50,'Tea Factory','Images/WhatsApp Image 2026-01-10 at 22.37.04 (1).jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(16,'KarapinchaTea (100g)',5,'Mixed herbal tea blend',500.00,NULL,40,'Tea Factory','Images/WhatsApp Image 2026-01-10 at 22.43.46.jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(17,'Coconut Water (500ml)',5,'Pure coconut water',180.00,NULL,70,'Coconut Co.','Images/WhatsApp Image 2026-01-10 at 22.15.55_3518b8f9.jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(18,'Organic Cinnamon (50g)',6,'Pure Ceylon cinnamon powder',350.00,NULL,45,'Spice Traders','Images/WhatsApp Image 2026-01-10 at 22.25.31.jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(19,'Organic Turmeric (100g)',6,'Fresh organic turmeric powder',280.00,NULL,50,'Spice Traders','Images/WhatsApp Image 2026-01-10 at 22.24.51.jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(20,'Organic Pepper (50g)',6,'Black pepper from Sri Lanka',400.00,NULL,35,'Spice Traders','Images/WhatsApp Image 2026-01-10 at 22.14.35_56d8d83c.jpeg',0,'2026-01-07 00:19:29','2026-01-11 00:51:40',1),(21,'Organic Papaya',1,'Fresh organic papaya from local farms',200.00,NULL,1,'Green Valley Farms','Images/WhatsApp Image 2026-01-10 at 21.49.58_dd855435.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:58:08',1),(22,'Organic Bananas (1kg)',1,'Sweet organic bananas',180.00,NULL,92,'Green Valley Farms','Images/WhatsApp Image 2026-01-10 at 22.11.36.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(23,'Organic Pineapple',1,'Juicy organic pineapple',250.00,NULL,11,'Fresh Fruits Co.','Images/WhatsApp Image 2026-01-10 at 22.13.28.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(24,'King Coconut (each)',1,'Fresh king coconut water',150.00,NULL,77,'Coconut Suppliers','Images/WhatsApp Image 2026-01-10 at 22.17.55.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(25,'Organic Tomatoes (1kg)',2,'Fresh organic tomatoes',220.00,NULL,53,'Veggie Farm','Images/WhatsApp Image 2026-01-10 at 22.18.50.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(26,'Organic Carrots (1kg)',2,'Crunchy organic carrots',180.00,NULL,49,'Veggie Farm','Images/WhatsApp Image 2026-01-10 at 21.51.24.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(27,'Organic Cabbage',2,'Fresh organic cabbage',120.00,NULL,40,'Veggie Farm','Images/WhatsApp Image 2026-01-10 at 22.19.59.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(28,'Organic Green Beans (500g)',2,'Fresh green beans',150.00,NULL,35,'Veggie Farm','Images/WhatsApp Image 2026-01-10 at 21.52.53.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(29,'Organic Milk (1L)',3,'Fresh organic cow milk',300.00,NULL,44,'Dairy Fresh','Images/WhatsApp Image 2026-01-10 at 22.32.57.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(30,'Organic Yogurt (400g)',3,'Creamy organic yogurt',250.00,NULL,39,'Dairy Fresh','Images/WhatsApp Image 2026-01-10 at 22.32.57 (2).jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(31,'Organic Butter (250g)',3,'Pure organic butter',450.00,NULL,25,'Dairy Fresh','Images/WhatsApp Image 2026-01-10 at 22.32.57 (1).jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(32,'Organic Brown Rice (1kg)',4,'Healthy organic brown rice',350.00,NULL,99,'Rice Mill Co.','Images/WhatsApp Image 2026-01-10 at 22.07.27.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(33,'Organic Red Rice (1kg)',4,'Traditional Sri Lankan red rice',400.00,NULL,80,'Rice Mill Co.','Images/WhatsApp Image 2026-01-10 at 22.02.23.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(34,'Organic Flour (1kg)',4,'Stone ground wheat flour',280.00,NULL,60,'Grain House','Images/WhatsApp Image 2026-01-10 at 22.45.19.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(35,'Organic Green Tea (100g)',5,'Pure Ceylon green tea',450.00,NULL,50,'Tea Factory','Images/WhatsApp Image 2026-01-10 at 22.37.30.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(36,'Organic Herbal Tea (100g)',5,'Mixed herbal tea blend',500.00,NULL,40,'Tea Factory','Images/WhatsApp Image 2026-01-10 at 22.37.04.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(37,'Organic Coconut Water (500ml)',5,'Pure coconut water',180.00,NULL,70,'Coconut Co.','Images/WhatsApp Image 2026-01-10 at 22.37.05.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(38,'Chili Powder(50g)',6,'Pure Ceylon cinnamon powder',350.00,NULL,45,'Spice Traders','Images/WhatsApp Image 2026-01-10 at 23.18.38.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(39,'Masala Powder(100g)',6,'Fresh organic turmeric powder',280.00,NULL,50,'Spice Traders','Images/WhatsApp Image 2026-01-10 at 23.18.37.jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1),(40,'Curry Powder (50g)',6,'Black pepper from Sri Lanka',400.00,NULL,0,'Spice Traders','Images/WhatsApp Image 2026-01-10 at 23.18.37 (1).jpeg',0,'2026-01-07 10:30:53','2026-01-11 00:51:40',1);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Email` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Name` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Phone` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Age` int DEFAULT NULL,
  `Address` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Sex` enum('Male','Female') COLLATE utf8mb4_unicode_ci NOT NULL,
  `UserType` enum('Admin','Customer') COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT 'Customer',
  `Password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `UpdatedDate` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `IsActive` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Email` (`Email`),
  KEY `idx_email` (`Email`),
  KEY `idx_usertype` (`UserType`),
  KEY `idx_createddate` (`CreatedDate`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'admin@greenlife.com','Admin User','555-0000',30,'Admin Office','Male','Admin','240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9','2026-01-07 00:19:29','2026-01-07 00:19:29',1),(2,'customer@gmail.com','customer@gmail.com','0774665657',34,'customer@gmail.com','Male','Customer','f0f3c04291ce360d63dc9a0b04e74b74c98149120b4e37cf07c241f5e2456680','2026-01-07 00:21:10','2026-01-07 08:59:58',1),(4,'customer2@gmail.com','customer2@greenlife.com','0776905653',34,'admin@greenlife.com,admin@greenlife.com','Male','Customer','be010345078ebdd905226ade492f9dbca8d964d5c12f004860fb8f70fccf9ed7','2026-01-07 15:07:14','2026-01-07 15:25:44',1),(5,'yasasnew@gmail.com','yasas','0773665090',26,'No228,Baddegamaroad,Nalagasdeniya,Hikkaduwa','Male','Customer','15427b9c8e12dd9f58d5221ad53a7af7d40d47431b9eec4ba7a65a01b37af14b','2026-01-08 10:46:04','2026-01-08 17:26:11',1),(6,'nayanakumarimama@gmail.com','nayana kumari','0914903554',55,'soamavilla,nalagasdeniya','Female','Customer','049b47a70e91460040220cd4d1c6d6cc424c856f7e62e315ba69d37130243f26','2026-01-08 17:37:29','2026-01-08 17:37:29',1),(7,'yasaspasindufernando@gmail.com','yasas','0776905654',26,'nalagasdeniya,hikkaduwa','Male','Customer','563563553255495ce895736a503d22d7625d815a81b6a975f62cc75d1c9f94b4','2026-01-08 17:46:46','2026-01-08 17:46:46',1),(8,'apodanta@gmail.com','apo dananatha','0773664567',22,'yakkala handiya,galle','Male','Customer','b4fa2ca6c69029e87ef65120c576ae37718c63c84b328e73a90d86cabfc220bf','2026-01-08 17:51:01','2026-01-08 17:51:01',1),(9,'aapodanta@gmail.com','aapodanta@gmail.com','aapodanta@gmail.com',113,'aapodanta@gmail.com','Male','Customer','c8dab85ccde3d16f494f60a56efe59b3fa1fd970b069abac6ef7a8e3e2247c56','2026-01-08 17:52:04','2026-01-08 17:52:04',1),(10,'apodanata@gmail.com','apodanata@gmail.com','0785675674',45,'apodanata@gmail.com','Male','Customer','ff82b0ca9c792e71eebae10aaae2ed4e7dd57ade5fd9fd8ef0c420d58c766d28','2026-01-08 17:55:34','2026-01-08 17:55:34',1),(11,'yasantha.ekanayake@ideahub.lk','yasantha elanayake','0777169043',25,'nuwara handiya','Male','Customer','90936064d27a18f2c616fcf6518b54fc3317b07c179407204dec6b15d0f8b58b','2026-01-09 14:51:48','2026-01-09 14:51:48',1);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'greenlife'
--

--
-- Dumping routines for database 'greenlife'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-01-11  1:29:32
