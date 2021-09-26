CREATE DATABASE  IF NOT EXISTS `foodilizer` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `foodilizer`;
-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: localhost    Database: foodilizer
-- ------------------------------------------------------
-- Server version	8.0.26

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
-- Table structure for table `custom_account`
--

DROP TABLE IF EXISTS `custom_account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `custom_account` (
  `account_id` int NOT NULL AUTO_INCREMENT,
  `account_title` varchar(100) DEFAULT NULL,
  `account_status` varchar(50) DEFAULT NULL,
  `email` varchar(100) NOT NULL,
  `username` varchar(100) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  `rest_id` int NOT NULL,
  PRIMARY KEY (`account_id`),
  UNIQUE KEY `idx_custom_account_email` (`email`),
  UNIQUE KEY `username` (`username`),
  KEY `fk_custom` (`rest_id`),
  CONSTRAINT `fk_custom` FOREIGN KEY (`rest_id`) REFERENCES `restaurant` (`rest_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_customemail` FOREIGN KEY (`email`) REFERENCES `user` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `custom_account`
--

LOCK TABLES `custom_account` WRITE;
/*!40000 ALTER TABLE `custom_account` DISABLE KEYS */;
/*!40000 ALTER TABLE `custom_account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer` (
  `customer_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  `nic` varchar(100) DEFAULT NULL,
  `username` varchar(100) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  `district` varchar(100) DEFAULT NULL,
  `province` varchar(100) DEFAULT NULL,
  `address` varchar(200) DEFAULT NULL,
  `pref_food_type` varchar(100) DEFAULT NULL,
  `dietry_restriction` varchar(100) DEFAULT NULL,
  `cemail` varchar(100) NOT NULL,
  `location_link` varchar(500) DEFAULT NULL,
  `profile_image` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`customer_id`),
  UNIQUE KEY `idx_customer_email` (`cemail`),
  UNIQUE KEY `nic` (`nic`),
  UNIQUE KEY `username` (`username`),
  UNIQUE KEY `location_link` (`location_link`),
  UNIQUE KEY `profile_image` (`profile_image`),
  CONSTRAINT `fk_custemail` FOREIGN KEY (`cemail`) REFERENCES `user` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (2,'Perera',NULL,NULL,'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',NULL,NULL,'bcd',NULL,NULL,'bcd@gmail.com',NULL,'~/images\\proi1.jpg'),(3,'Shane',NULL,NULL,'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',NULL,NULL,NULL,NULL,NULL,'mcw@gmail.com',NULL,'~/images\\proi2.jfif'),(4,'Denver',NULL,NULL,'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',NULL,NULL,NULL,NULL,NULL,'dan@d.com',NULL,'~/images\\proi3.jfif'),(5,'Fernando',NULL,NULL,'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4','Colombo','Western','109/C18',NULL,'Non Dairy','bud@b.com',NULL,'~/images\\proi4.png');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `food`
--

DROP TABLE IF EXISTS `food`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `food` (
  `food_id` int NOT NULL AUTO_INCREMENT,
  `menu_id` int NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `type` varchar(100) DEFAULT NULL,
  `price` decimal(18,0) DEFAULT NULL,
  `ingredient` varchar(200) DEFAULT NULL,
  `image_path` varchar(500) DEFAULT NULL,
  `pref_score` int DEFAULT NULL,
  `featured` varchar(5) DEFAULT NULL COMMENT 'If featured = YES and if not NO',
  `category` varchar(100) DEFAULT NULL,
  `sub_category` varchar(100) DEFAULT NULL,
  `category_rating` varchar(100) DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `veg` varchar(5) DEFAULT NULL,
  `spicy_level` varchar(5) DEFAULT NULL,
  `hot` varchar(5) DEFAULT NULL,
  `organic` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`food_id`),
  UNIQUE KEY `image_path` (`image_path`),
  KEY `fk_menu_idx` (`menu_id`),
  CONSTRAINT `fk_menu` FOREIGN KEY (`menu_id`) REFERENCES `menu` (`menu_id`)
) ENGINE=InnoDB AUTO_INCREMENT=86 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `food`
--

LOCK TABLES `food` WRITE;
/*!40000 ALTER TABLE `food` DISABLE KEYS */;
INSERT INTO `food` VALUES (43,2,'Fried Rice with Chicken','Main',690,'Basmathi rice, Chicken, Eggs, Vegetables','~/images/Food/3/Fried Rice with Chicken\\38.4_1.jpg',85,'1','Rice','Fried Rice','5',3,'1','1','1','0'),(44,2,'Spicy Rice with Seafood','Main',1200,'Basmathi rice, Seafood, Eggs, Vegetables','~/images/Food/3/Spicy Rice With Seafood\\web_2_1.jpg',80,'1','Rice','Fried Rice','5',4,'1','3','1','0'),(45,2,'Vegetable Foo Young Hai','Appetrizer',690,'Eggs, Vegetables','~/images/Food/3/VEGETABLE FOO YOUNG HAI\\157.jpg',83,'0','Egg','Omelette','3',4,'0','1','1','0'),(46,2,'Hot and Sour Prawn Soup','Appetrizer',790,'Egg, Prawn, Natural flavors, tomatoes ','~/images/Food/3/Hot and Sour Prawn Soup\\web1_12_1.jpg',73,'1','Soup','Prawn Soup','3',3,'1','2','1','0'),(47,2,'Sweet Corn Soup with Egg','Main',490,'Sweet corn, vegetables, egg, natural flavors','~/images/Food/3/Sweet Corn Soup With Egg\\web1_11_1.jpg',81,'1','Soup','Sweet Corn Soup','3',3,'1','0','1','0'),(48,2,'Hot and Sour Chicken Soup','Appetrizer',690,'Egg, Chicken, Natural flavors, tomatoes ','~/images/Food/3x/Hot and Sour Prawn Soup\\web1_12_1.jpg',76,'0','Soup','Chicken Soup','3',3,'1','2','1','0'),(49,2,'Chicken Dragon Shake','Main',1690,'Noodles, Chicken, Gravy, Vegetables','~/images/Food/3/Chicken Dragon Shake\\dragon-shake---dry-red-chilli-chicken.jpg',58,'0','Noodles','Chicken Noodles','6',2,'1','3','1','0'),(50,2,'Fried Chicken Noodles','Main',990,'Noodles, Chicken, Eggs, Gravy, Vegetables','~/images/Food/3/Fried Chicken Noodles\\134.jpg',91,'1','Noodles','Chicken Noodles','6',4,'1','2','1','0'),(51,2,'Carrot Juice','Beverage',260,'Carrots, Water','~/images/Food/3/Carrot Juice\\224.jpg',86,'1','Fruit juice','Carrot Juice','3',3,'0','0','0','1'),(52,2,'Watermelon Juice','Beverage',355,'Watermelon, Water, Sugar','~/images/Food/3/Watermelon Juice\\222.jpg',84,'1','Fruit juice','Watermelon Juice','3',3,'0','0','0','1'),(54,4,'Spicy Crispy Chicken Burger','Main',662,'Chicken, Bun','~/images/Food/4/Spicy Crispy Chicken Burger\\c51adea9d284353f890808a54df049a02247d85c-1333x1333.png',91,'1','Burger','Chicken Burger','8',3,'1','1','1','0'),(55,4,'Chicken Whopper Burger','Main',733,'Chicken, Bun, Cheese','~/images/Food/4x/Spicy Crispy Chicken Burger\\c51adea9d284353f890808a54df049a02247d85c-1333x1333.png',89,'1','Burger','Chicken Whoppr','8',3,'1','2','1','0'),(56,4,'Bacon King','Main',990,'Bacon, Bun, Cheese','~/images/Food/4/Bacon King\\60712f81a07316d3300b65823ab68b59def70c8e-1333x1333.png',91,'1','Burger','Bacon Burger','8',4,'1','2','1','0'),(57,4,'Double Quarter Pound King','Main',1400,'Bacon, Bun, Cheese','~/images/Food/4/Double Quarter Pound King\\643662bac7e939515020fbecc57f313adf99751d-1333x1333.png',88,'0','Burger','Bacon Burger','8',5,'1','2','1','0'),(60,4,'Big Fish','Main',800,'Fish, Bun','~/images/Food/4/Big Fish\\4e7c420c66f98697bc847ae8906fc8b73e9c1ddc-1333x1333.png',87,'0','Burger','Fish Burger','8',3,'1','1','1','0'),(61,4,'Bk Iced coffee','Beverage',400,'Coffee, Milk','~/images/Food/4/Bk Iced coffee\\fa8c977f31cce380c6a2d8492a3b144b1af6453d-1333x1333.png',82,'1','Coffee','Iced Coffee','5',3,'0','0','0','1'),(62,4,'Simply Orange Juice','Beverage',300,'Oranges, Water, Sugar','~/images/Food/4/Simply Orange Juice\\ec5c915aa470f4b7b846bcc31acff88f19bc6a18-1333x1333.png',76,'0','Fruit juice','','3',3,'0','0','0','1'),(63,3,'Popcorn Veggie Pizza','Main',510,'carrots, mushrooms & potatoes accompanied by green chillies, onions & a layer of mozzarella & cream cheese, upon a sriracha & tomato sauce base','~/images/Food/5/Popcorn Veggie Pizza\\52a6b8d4-7693-478c-8d97-0e7649f325a6 (1).jpg',100,'0','Pizza','Veggie Pizza','10',2,'0','2','1','1'),(64,3,'Devilled Beef Pizza','Main',1500,'Pieces of devilled beef complemented by fresh capsicums, onions and a double layer of mozzarella cheese.','~/images/Food/5/Devilled Beef Pizza\\devilledbeefaeb5c1c7670341839a00890b13a9ae6c.jpg',90,'1','Pizza','Beef Pizza','10',4,'1','3','1','0'),(65,3,'Hot Garlic Prawn Pizza','Main',1900,'Spicy prawns, hot garlic sauce, onions, peppers and tomatoes with a double layer of mozzarella cheese.','~/images/Food/5/Hot Garlic Prawn Pizza\\52a6b8d4-7693-478c-8d97-0e7649f325a6 (1).jpg',79,'1','Pizza','Prawn Pizza','10',4,'1','3','1','0'),(66,3,'Chicken Hawaiian Pizza','Main',1700,'Chicken ham & pineapple with a double layer of mozzarella cheese.','~/images/Food/5/Chicken Hawaiian Pizza\\chickenhawaiiana1998da14add4d788c937c8f87b68518.jpg',84,'0','Pizza','Chicken Pizza','10',4,'1','2','1','0'),(67,3,'Cheesy Garlic Bread Supreme','Appetrizer',500,'Layered with garlic butter & mozzarella cheese!','~/images/Food/5/Cheesy garlic bread supreme\\67e7c92c-4215-4c8c-a778-1eaa51c21ea2.jpg',87,'1','Garlic bread','Cheesy Garlic Bread','4',4,'0','1','1','1'),(68,3,'Chicken Roll','Side',190,'Chicken, Bun','~/images/Food/5/Chicken Roll\\4831e74a-dedf-477d-9f74-27f60c7e5831.jpg',74,'1','Bun','190','1',3,'1','1','1','0'),(69,3,'Vanilla MilkShake','Beverage',400,'Milk,Vanilla','~/images/Food/5/Vanilla MilkShake\\vanillamilkshake300ml9a70dfd72d9d4f3eb56c1a2514bd4149.jpg',81,'0','Milkshake','Vanilla MilkShake','4',3,'0','0','0','1'),(70,3,'Lava Cake','Dessert',560,'Chocolate,Eggs','~/images/Food/5/Lava Cake\\chocolatelavacakewebec80c8c759bb465a959033006c9dd9aa.jpg',93,'1','Cake','Lava Cake','9',2,'0','0','1','1'),(71,5,'Chicken Burger','Main',550,'Chicken, Bun, Cheese','~/images/Food/6/Chicken Burger\\178134565_4029482187141740_1900856712927861886_n.jpg',95,'1','Burger','Chicken Burger','8',3,'1','1','1','0'),(72,5,'Triple Chicken Burger','Main',880,'Chicken, Bun, Cheese','~/images/Food/6/Triple Chicken Burger\\241359027_4441700029253285_940121291663626539_n.jpg',100,'0','Burger','Chicken Burger','8',5,'1','1','1','0'),(73,5,'Beef Submarine','Main',400,'Chicken, Bun, Cheese','~/images/Food/6/Beef Submarine\\202125157_4188681344555156_6688736114526906625_n.jpg',100,'1','Submarine','Beef submarine','8',4,'1','2','1','0'),(74,5,'Crispy Chicken Submarine','Main',590,'Chicken, Bun, Cheese','~/images/Food/6/Crispy Chicken Submarine\\212524102_4205523736204250_4525342944910819539_n.jpg',100,'1','Submarine','Chicken Sub','8',4,'1','1','1','0'),(75,5,'Chicken Legs','Appetrizer',700,'Chicken','~/images/Food/6/Chicken Legs\\__opt__aboutcom__coeus__resources__content_migration__serious_eats__seriouseats.com__2015__07__20210324-SouthernFriedChicken-Andrew-Janjigian-21-cea1fe39234844638018b15259cabdc2.jpg',89,'1','Chicken','Chicken Legs','6',4,'1','2','1','0'),(76,5,'Iced Tea','Beverage',300,'Tea','~/images/Food/6/Iced Tea\\1371597847872.jpeg',85,'1','Iced tea','Iced Tea','5',3,'0','0','0','1'),(77,5,'Vanilla MilkShake','Beverage',350,'Milk,Vanilla','~/images/Food/6/Vanilla MilkShake\\download.jpg',88,'1','Milkshake','Vanilla MilkShake','4',4,'0','0','0','0'),(78,5,'Iced Coffee','Beverage',350,'Coffee, Milk','~/images/Food/4x/Bk Iced coffee\\fa8c977f31cce380c6a2d8492a3b144b1af6453d-1333x1333.png',75,'1','Coffee','Iced Coffee','5',2,'0','0','0','1'),(79,6,'Chicken Shawarma','Main',650,'Chicken, Wrap','~/images/Food/7/Chicken Shawarma\\download.jpg',87,'1','Shawarma','Chicken Shawarma','7',3,'1','2','1','1'),(80,6,'Beef Lasagna','Main',850,'Beef','~/images/Food/7x/Chicken Shawarma\\download.jpg',97,'1','Lasagna','Beef Lasgna','10',3,'1','2','1','0'),(81,6,'Chicken Lasagna','Main',780,'Chicken','~/images/Food/7/Chicken Lasagna\\download (2).jpg',99,'1','Lasagna','Chicken Lasagna ','10',3,'1','2','1','0'),(82,6,'Cheese sandwich','Appetrizer',250,'Bun, Cheese','~/images/Food/7/Cheese sandwich\\60018142.jpg',88,'0','Sandwich','Cheese Sandwich','7',2,'0','1','1','1'),(83,6,'Chicken Kebab','Main',1700,'Chicken, Sause','~/images/Food/7/Chicken Kebab\\download (3).jpg',81,'1','Kebab','Chicken Kebab','10',4,'1','2','1','0'),(84,6,'Tea','Beverage',300,'Tea','~/images/Food/7/Tea\\download (4).jpg',76,'1','Tea','Tea','3',3,'0','0','1','1'),(85,6,'Chicken Pie','Side',200,'Chicken, Bun, Cheese','~/images/Food/7/Chicken Pie\\download (5).jpg',75,'0','Pastry','Chicken Pie','2',3,'1','1','1','0');
/*!40000 ALTER TABLE `food` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item`
--

DROP TABLE IF EXISTS `item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `item` (
  `rest_id` int NOT NULL,
  `item_id` int NOT NULL AUTO_INCREMENT,
  `item_name` varchar(100) DEFAULT NULL,
  `item_quantity` int DEFAULT NULL,
  `measurement` varchar(50) DEFAULT NULL,
  `quantity_limit` int DEFAULT NULL,
  `alert` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`item_id`),
  KEY `fk_restit` (`rest_id`),
  CONSTRAINT `fk_restit` FOREIGN KEY (`rest_id`) REFERENCES `restaurant` (`rest_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item`
--

LOCK TABLES `item` WRITE;
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
/*!40000 ALTER TABLE `item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu`
--

DROP TABLE IF EXISTS `menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu` (
  `menu_id` int NOT NULL AUTO_INCREMENT,
  `rest_id` int DEFAULT NULL,
  PRIMARY KEY (`menu_id`),
  KEY `fk_mr` (`rest_id`),
  CONSTRAINT `fk_mr` FOREIGN KEY (`rest_id`) REFERENCES `restaurant` (`rest_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu`
--

LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` VALUES (1,2),(2,3),(4,4),(3,5),(5,6),(6,7);
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_includes_food`
--

DROP TABLE IF EXISTS `order_includes_food`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_includes_food` (
  `order_id` int NOT NULL,
  `food_id` int NOT NULL,
  `qty` int DEFAULT NULL,
  PRIMARY KEY (`order_id`,`food_id`) USING BTREE,
  KEY `fk_foodorder_idx` (`food_id`),
  CONSTRAINT `fk_foodorder` FOREIGN KEY (`food_id`) REFERENCES `food` (`food_id`),
  CONSTRAINT `fk_order` FOREIGN KEY (`order_id`) REFERENCES `restaurant_order` (`order_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_includes_food`
--

LOCK TABLES `order_includes_food` WRITE;
/*!40000 ALTER TABLE `order_includes_food` DISABLE KEYS */;
/*!40000 ALTER TABLE `order_includes_food` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_with_payment`
--

DROP TABLE IF EXISTS `order_with_payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_with_payment` (
  `order_id` int NOT NULL,
  `payment_gateway_details` longtext COMMENT 'payment gateway and any ther details',
  PRIMARY KEY (`order_id`),
  CONSTRAINT `fk_order_paid` FOREIGN KEY (`order_id`) REFERENCES `restaurant_order` (`order_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_with_payment`
--

LOCK TABLES `order_with_payment` WRITE;
/*!40000 ALTER TABLE `order_with_payment` DISABLE KEYS */;
/*!40000 ALTER TABLE `order_with_payment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `package`
--

DROP TABLE IF EXISTS `package`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `package` (
  `package_id` int NOT NULL AUTO_INCREMENT,
  `package_type` varchar(100) DEFAULT NULL,
  `registered_date` datetime DEFAULT NULL,
  `rest_id` int DEFAULT NULL,
  PRIMARY KEY (`package_id`),
  KEY `fk_pckg` (`rest_id`),
  CONSTRAINT `fk_pckg` FOREIGN KEY (`rest_id`) REFERENCES `restaurant` (`rest_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `package`
--

LOCK TABLES `package` WRITE;
/*!40000 ALTER TABLE `package` DISABLE KEYS */;
INSERT INTO `package` VALUES (10,'silver',NULL,2),(11,'gold','2021-09-18 00:00:00',2),(12,'silver','2021-09-18 00:00:00',3),(13,'silver','2021-09-18 00:00:00',4);
/*!40000 ALTER TABLE `package` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `restaurant`
--

DROP TABLE IF EXISTS `restaurant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `restaurant` (
  `rest_id` int NOT NULL AUTO_INCREMENT,
  `rname` varchar(200) DEFAULT NULL,
  `owner_name` varchar(200) DEFAULT NULL,
  `owner_contact` char(10) DEFAULT NULL,
  `owner_email` varchar(200) DEFAULT NULL,
  `rabout` varchar(500) DEFAULT NULL,
  `rest_type` varchar(200) DEFAULT NULL,
  `remail` varchar(200) NOT NULL,
  `raddress` varchar(500) DEFAULT NULL,
  `rdistrict` varchar(200) DEFAULT NULL,
  `price_range` varchar(200) DEFAULT NULL,
  `rusername` varchar(200) DEFAULT NULL,
  `rpassword` varchar(200) DEFAULT NULL,
  `rprovince` varchar(200) DEFAULT NULL,
  `open_hour` varchar(200) DEFAULT NULL,
  `open_status` int DEFAULT NULL,
  `website_link` longtext,
  `map_link` longtext,
  `meal_type` varchar(200) DEFAULT NULL,
  `cuisine` varchar(200) DEFAULT NULL,
  `feature` varchar(200) DEFAULT NULL,
  `special_diet` varchar(100) DEFAULT NULL,
  `rest_contact` char(10) DEFAULT NULL,
  PRIMARY KEY (`rest_id`),
  UNIQUE KEY `idx_restaurant_remail` (`remail`),
  CONSTRAINT `fk_restemail` FOREIGN KEY (`remail`) REFERENCES `user` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `restaurant`
--

LOCK TABLES `restaurant` WRITE;
/*!40000 ALTER TABLE `restaurant` DISABLE KEYS */;
INSERT INTO `restaurant` VALUES (2,'Coco Palm Beach Hotel','A. Fernando','0112555299','abc@g.com','blabla','bronze','hello@hello.com','113,Galle Road Boossa, Galle, Sri Lanka','Galle','LKR 500 - LKR 3000','hello@hello.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4','Southern','7 a.m. - 9 p.m.',1,'https://localhost:44378/store_front/bronze_home','https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d63480.752699834266!2d80.17754539919146!3d6.056697080624833!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3ae173bb6932fce3%3A0x4a35b903f9c64c03!2sGalle!5e0!3m2!1sen!2slk!4v1626950638039!5m2!1sen!2slk','Breakfast','International, Asian, Indian, Sri Lankan, Pub','no','Vegetarian Friendly, Vegan options',NULL),(3,'Chinese Dragon Restaurant','K. Perera','0112345678',NULL,'Chinese Dragon Cafe have been the pioneer of Authentic Chinese Food in Colombo since 1942. With a heritage of 76 years, you\'re bound to have a truly great Chinese Experience. 78 years of excellence. Delivery within 45mins. Open 365 Days. Free Delivery.','silver','abc@gmail.com','112, Flower Road, Nugegoda, Colombo','Colombo','2','abc@gmail.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',NULL,'7 a.m. - 9 p.m.',1,'https://localhost:44378/store_front/bronze_home','https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d126743.5858662712!2d79.78599236679042!3d6.922003921990968!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3ae253d10f7a7003%3A0x320b2e4d32d3838d!2sColombo!5e0!3m2!1sen!2slk!4v1629883484456!5m2!1sen!2slk\"','Breakfast, Lunch, Dinner, Snacks','Chinese','no','Vegetarian Friendly, Vegan options','0117808080'),(4,'Burger King','S. Withana','0344567832',NULL,'Burger King is an American multinational chain of hamburger fast food restaurants. Headquartered in Miami-Dade County, Florida, the company was founded in 1953 as Insta-Burger King, a Jacksonville, Florida–based restaurant chain.','bronze','rest2@gmail.com','No.234 , Sabaragamuwa rd , Sabaragamuwa','Colombo','2','rest2@gmail.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',NULL,'6 a.m. - 11 p.m.',1,'https://www.bk.com/','https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d126743.5858662712!2d79.78599236679042!3d6.922003921990968!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3ae253d10f7a7003%3A0x320b2e4d32d3838d!2sColombo!5e0!3m2!1sen!2slk!4v1629883484456!5m2!1sen!2slk\"','All','Burgers, Beverages, Snacks','Dine in, Take out, Indoor seating','Vegetarian Friendly, Vegan options','0344567832'),(5,'Pizza Hut','J. Dias','0112342378',NULL,'Pizza Hut, a subsidiary of Yum! Brands, is the world\'s largest pizza company and home of Pan Pizza. Pizza Hut began 60 years ago in Wichita, Kansas, and today is an iconic global brand that delivers more pizza, pasta and wings than any other restaurant in the world.\r\nSince its inception in 1993, Pizza Hut has fast become a household name across Sri Lanka. With its first restaurant at Union Place, Colombo 2, Pizza Hut became the first international restaurant chain to begin operations in Sri Lan','gold','rest3@gmail.com','No. 997/8, Sri Jayawardenepura Mawatha, Colombo','Colombo','3','rest3@gmail.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',NULL,'11 a.m. - 9 p.m.',1,'https://www.pizzahut.lk/home/about','https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d63320.41799141781!2d80.5906757934501!3d7.2946290837100225!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3ae366266498acd3%3A0x411a3818a1e03c35!2sKandy!5e0!3m2!1sen!2slk!4v1629883571400!5m2!1sen!2slk','Lunch, Dinner','Pizza, Sides, Snacks','Indoor dining, Take away, Delivery','Vegetarian Friendly, Vegan options','0112729729'),(6,'Royal Burger','A. Silva','0112309778',NULL,'One stop for burgers.','silver','rest4@gmail.com','85 Elvitigala Mawatha, Colombo 00500','Colombo','1','rest4@gmail.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',NULL,'10 a.m. - 11 p.m.',1,'https://www.facebook.com/royalburger2014/?ref=page_internal','https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d126743.5858662712!2d79.78599236679042!3d6.922003921990968!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3ae253d10f7a7003%3A0x320b2e4d32d3838d!2sColombo!5e0!3m2!1sen!2slk!4v1629883484456!5m2!1sen!2slk\"','All','Fast food','Takeaway, Delivery','Vegetarian Friendly, Vegan options','0112696009'),(7,'Java Lounge','Buddhi Wick chath','0775811245',NULL,'Brewed to Perfection','gold','greg@greg.com','76 Barnes Pl, Colombo 00700','Anuradhapura','1','greg@greg.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',NULL,'9AM-7PM',1,'https://www.javalounge.lk/?gclid=Cj0KCQjwqKuKBhCxARIsACf4XuEo0kzSvGCAjoz0vO_mPvq1BWIQFAKKxt7IsZrq4C3Cp31w3JnMukoaAgoXEALw_wcB','https://g.page/javaloungebarnesplace?share','Breakfast, lunch, Dinner','International','Outdoor, Indoor, Bar','Vegan','0775811245');
/*!40000 ALTER TABLE `restaurant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `restaurant_image`
--

DROP TABLE IF EXISTS `restaurant_image`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `restaurant_image` (
  `rest_id` int NOT NULL,
  `main_image_path` varchar(2000) DEFAULT NULL,
  `banner_image_path` varchar(2000) DEFAULT NULL,
  `gallery_image_1_path` varchar(2000) DEFAULT NULL,
  `gallery_image_2_path` varchar(2000) DEFAULT NULL,
  `gallery_image_3_path` varchar(2000) DEFAULT NULL,
  `gallery_image_4_path` varchar(2000) DEFAULT NULL,
  `gallery_image_5_path` varchar(2000) DEFAULT NULL,
  PRIMARY KEY (`rest_id`),
  CONSTRAINT `fk_resti` FOREIGN KEY (`rest_id`) REFERENCES `restaurant` (`rest_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `restaurant_image`
--

LOCK TABLES `restaurant_image` WRITE;
/*!40000 ALTER TABLE `restaurant_image` DISABLE KEYS */;
INSERT INTO `restaurant_image` VALUES (2,'~/images/restaurant/2\\restmain1.jpg',NULL,'~/images/restaurant/2\\restmain1.jpg',NULL,NULL,NULL,NULL),(3,'~/images/restaurant/3\\ENGLISH-LOGO-JPEG_1.jpg','~/images/restaurant/3\\promo.lk-promo-f64a4b4f0e514d52a157bce5a7ec0cc2.png','~/images/restaurant/3\\download (1).jpg','~/images/restaurant/3\\download (2).jpg','~/images/restaurant/3\\download (3).jpg','~/images/restaurant/3\\download.jpg',NULL),(4,'~/images/restaurant/4\\download.png','~/images/restaurant/4\\images.jpg','~/images/restaurant/4\\799525cf-e7ca-4cef-8b87-5fbd6a8ca2f6.jpeg','~/images/restaurant/4\\BurgerKing_Colombo.png','~/images/restaurant/4\\download.jpg',NULL,NULL),(5,'~/images/restaurant/5\\download.jpg','~/images/restaurant/5\\download (1).jpg','~/images/restaurant/5\\images.jpg','~/images/restaurant/5\\Pizza-Hut-RajagiriyaSri-Jayawardenepura-Kotte.jpg','~/images/restaurant/5\\z_pii-Differently1.jpg',NULL,NULL),(6,'~/images/restaurant/6\\240958962_4416675151755773_6236673754888742004_n.png','~/images/restaurant/6\\241443072_4416673961755892_4982052405768906752_n.png','~/images/restaurant/6\\185876165_4078507065572585_3670860952974891114_n.jpg','~/images/restaurant/6\\211182224_4240449046045052_635021097879321694_n.jpg','~/images/restaurant/6\\214465552_4240448222711801_2502623979500921533_n.jpg','~/images/restaurant/6\\216400029_4245874338835856_8895273236526002606_n.jpg',NULL),(7,'~/images/restaurant/7\\logo-footer-sidearea.png','~/images/restaurant/7\\home-1-slider-image-1.jpg','~/images/restaurant/7\\thumbs_java12.jpg','~/images/restaurant/7\\thumbs_java13.jpg','~/images/restaurant/7\\WhatsApp Image 2018-06-27 at 1.42.53 AM.jpeg',NULL,NULL);
/*!40000 ALTER TABLE `restaurant_image` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `restaurant_order`
--

DROP TABLE IF EXISTS `restaurant_order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `restaurant_order` (
  `order_id` int NOT NULL AUTO_INCREMENT,
  `customer_id` int DEFAULT NULL,
  `delivery_address` longtext,
  `content` longtext,
  `total_amount` int DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `rest_id` int NOT NULL,
  PRIMARY KEY (`order_id`),
  KEY `fk_restau` (`rest_id`),
  KEY `fk_custorder_idx` (`customer_id`),
  CONSTRAINT `fk_custorder` FOREIGN KEY (`customer_id`) REFERENCES `customer` (`customer_id`),
  CONSTRAINT `fk_restau` FOREIGN KEY (`rest_id`) REFERENCES `restaurant` (`rest_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `restaurant_order`
--

LOCK TABLES `restaurant_order` WRITE;
/*!40000 ALTER TABLE `restaurant_order` DISABLE KEYS */;
/*!40000 ALTER TABLE `restaurant_order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `review`
--

DROP TABLE IF EXISTS `review`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `review` (
  `review_id` int NOT NULL AUTO_INCREMENT,
  `rating` int DEFAULT NULL COMMENT 'rating is saved as  one number',
  `feedback` varchar(200) DEFAULT NULL,
  `title` varchar(200) DEFAULT NULL,
  `customer_id` int NOT NULL,
  `rest_id` int NOT NULL,
  `review_image1` longtext,
  `review_image2` longtext,
  `review_image3` longtext,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`review_id`),
  KEY `fk_rest1` (`rest_id`),
  KEY `fk_cust1_idx` (`customer_id`),
  CONSTRAINT `fk_cust1` FOREIGN KEY (`customer_id`) REFERENCES `customer` (`customer_id`),
  CONSTRAINT `fk_rest1` FOREIGN KEY (`rest_id`) REFERENCES `restaurant` (`rest_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `review`
--

LOCK TABLES `review` WRITE;
/*!40000 ALTER TABLE `review` DISABLE KEYS */;
INSERT INTO `review` VALUES (2,3,'Never forget the place!It’s a great experience. The ambiance is very welcoming and charming. Amazing wines, food and service.','Never forget the place!',2,2,'~/images\\rev1.jfif','~/images\\rev2.jfif','~/images\\rev3.jfif','2020-08-12'),(6,5,'amazing','Great!',2,2,'~/images\\rev2.jfif','~/images\\rev1.jfif','~/images\\rev3.jfif','2021-08-12'),(7,5,'Never forget the place!It’s a great experience. The ambiance is very welcoming and charming. Amazing wines, food and service.','Never forget the place!',2,3,'~/images\\rev3.jfif','~/images\\rev1.jfif','~/images\\rev2.jfif','2020-09-23'),(9,4,'Beautiful place with delicious food!','A great Experience',3,2,'~/images\\rev2.jfif','~/images\\rev3.jfif','~/images\\rev1.jfif','2021-09-20'),(10,5,'Delicious Food with a great atmosphere. Highly recommended.','Superb!',3,3,'~/images\\rev2.jfif','~/images\\rev3.jfif','~/images\\rev1.jfif','2021-09-20'),(11,4,'good','Good and can be improved',5,2,'~/images\\rev1.jfif','~/images\\rev2.jfif','~/images\\rev3.jfif','2021-09-21');
/*!40000 ALTER TABLE `review` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sales_report`
--

DROP TABLE IF EXISTS `sales_report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sales_report` (
  `report_id` int NOT NULL AUTO_INCREMENT,
  `rest_id` int NOT NULL,
  `date` datetime DEFAULT NULL,
  `content` longtext COMMENT 'Insert sales report content and any additional content',
  PRIMARY KEY (`report_id`),
  KEY `fk_rests` (`rest_id`),
  CONSTRAINT `fk_rests` FOREIGN KEY (`rest_id`) REFERENCES `restaurant` (`rest_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_report`
--

LOCK TABLES `sales_report` WRITE;
/*!40000 ALTER TABLE `sales_report` DISABLE KEYS */;
/*!40000 ALTER TABLE `sales_report` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `email` varchar(50) NOT NULL,
  `password` varchar(100) DEFAULT NULL,
  `user_type` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  KEY `idx_user_email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (2,'hello@hello.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4','REST'),(3,'abc@gmail.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4','REST'),(4,'rest2@gmail.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4','REST'),(5,'rest3@gmail.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4','REST'),(6,'rest4@gmail.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4','REST'),(7,'bcd@gmail.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4','CUST'),(8,'greg@greg.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4','REST'),(14,'mcw@gmail.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4','CUST'),(15,'dan@d.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4','CUST'),(16,'bud@b.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4','CUST'),(18,'w@w.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4','CUST');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'foodilizer'
--

--
-- Dumping routines for database 'foodilizer'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-09-23  7:46:14
