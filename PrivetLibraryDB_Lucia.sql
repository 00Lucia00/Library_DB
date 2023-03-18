-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: librarydbmodel
-- ------------------------------------------------------
-- Server version	8.0.32

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
-- Table structure for table `authors`
--

DROP TABLE IF EXISTS `authors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `authors` (
  `idAuthors` int NOT NULL AUTO_INCREMENT,
  `Author_name` varchar(60) NOT NULL,
  PRIMARY KEY (`idAuthors`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `authors`
--

LOCK TABLES `authors` WRITE;
/*!40000 ALTER TABLE `authors` DISABLE KEYS */;
INSERT INTO `authors` VALUES (1,'Georgie Birkett'),(2,'Kathryn Smith'),(3,'Bobbie Brooks'),(4,'Hanna Albrektson'),(5,'Anett Berglin'),(6,'Catarina Kruvsval'),(7,'Elna Greig'),(8,'Elsa Beskows'),(9,'Astrid Lindgren'),(10,'Hans Sande'),(11,'Inger Sandberg'),(12,'H.C Andersen'),(13,'Katarina Ekstedt'),(14,'Thomas Halling'),(15,'Jan Lööf'),(16,'Sven Nordqvist'),(17,'Julia Donaldson'),(18,'Anna Höglund'),(19,'Rufus Butler Seder'),(20,'Annika Meijer'),(21,'Steven Smallman'),(22,'Katrin Wiehle'),(23,'Sham Khan'),(24,'Lena Lindström'),(25,'Barbro Lindgren'),(27,'Author1'),(28,'Author12'),(29,'då');
/*!40000 ALTER TABLE `authors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `book_languages`
--

DROP TABLE IF EXISTS `book_languages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `book_languages` (
  `idbook` int NOT NULL,
  `idlanguage` int NOT NULL,
  PRIMARY KEY (`idbook`,`idlanguage`),
  KEY `fk_book_idx` (`idbook`),
  KEY `fk_language_idx` (`idlanguage`),
  CONSTRAINT `fk_book` FOREIGN KEY (`idbook`) REFERENCES `books` (`idBooks`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_language` FOREIGN KEY (`idlanguage`) REFERENCES `languages` (`idLanguages`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book_languages`
--

LOCK TABLES `book_languages` WRITE;
/*!40000 ALTER TABLE `book_languages` DISABLE KEYS */;
INSERT INTO `book_languages` VALUES (1,1),(2,1),(3,1),(4,1),(5,1),(6,1),(7,1),(8,1),(9,1),(10,1),(11,1),(12,1),(13,1),(14,1),(15,1),(16,1),(17,1),(18,1),(19,1),(20,1),(21,1),(22,1),(23,1),(24,1),(25,1),(26,1),(27,1),(28,1),(29,1),(30,2),(31,2),(32,2),(33,1),(34,2);
/*!40000 ALTER TABLE `book_languages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `books`
--

DROP TABLE IF EXISTS `books`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `books` (
  `idBooks` int NOT NULL AUTO_INCREMENT,
  `book_title` varchar(45) NOT NULL,
  `page_amount` int DEFAULT NULL,
  `year_published` int DEFAULT NULL,
  `category_id` int DEFAULT NULL,
  `Favorits_id` int DEFAULT NULL,
  `Author` int DEFAULT NULL,
  PRIMARY KEY (`idBooks`),
  KEY `fk_category_id_idx` (`category_id`),
  KEY `fk_favorit_id_idx` (`Favorits_id`),
  KEY `fk_Authors_idx` (`Author`),
  CONSTRAINT `fk_Authors` FOREIGN KEY (`Author`) REFERENCES `authors` (`idAuthors`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_category_id` FOREIGN KEY (`category_id`) REFERENCES `categorys` (`idCategorys`) ON UPDATE CASCADE,
  CONSTRAINT `fk_favorits` FOREIGN KEY (`Favorits_id`) REFERENCES `favorits` (`idFavorits`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `books`
--

LOCK TABLES `books` WRITE;
/*!40000 ALTER TABLE `books` DISABLE KEYS */;
INSERT INTO `books` VALUES (1,'Vi leker utomhus',10,2006,1,NULL,1),(2,'Mönster',10,2014,2,NULL,2),(3,'Jag leker Bondgård',8,2021,5,2,3),(4,'Hönan och ägget',22,2021,3,1,4),(5,'Vi Hjälper!',10,2007,5,NULL,5),(6,'Imse vimse spindel',12,2019,3,NULL,6),(7,'Barnets första ord',12,2012,3,NULL,7),(8,'Pettson och findus bygger bil',12,2020,5,4,16),(9,'Titta Djur!',16,2021,2,2,8),(10,'Lille Katt',14,2015,4,NULL,9),(11,'Min Dag',10,2017,2,5,10),(12,'Lilla Anna tittar på djur',16,2021,3,3,11),(13,'Laban mina första ord',20,2020,3,1,11),(14,'Ville går på pottan',24,2020,3,3,13),(15,'Den fula ankungen',23,2005,4,NULL,12),(16,'Tass tass tass - Smyg smyg smyg',30,2006,3,4,14),(17,'Födelsedagspresenten',24,2021,3,5,15),(18,'När findus var liten och försvann',23,2009,4,NULL,16),(19,'Pannkakstårtan',22,1996,4,NULL,16),(20,'Lille Gruffalon',29,2004,4,2,17),(21,'Sagan om pannkakan',22,2010,4,5,18),(22,'Gruffalon',22,2009,4,4,17),(23,'Galopp',19,2009,5,2,19),(24,'Är du där lilla elefant?',12,2018,2,3,20),(25,'Vilket Ankrabalder',24,2020,3,NULL,21),(26,'Kittliga Fåret',24,2019,3,3,21),(27,'Min Trädgård',14,2019,3,3,22),(28,'Min Skog',14,2019,3,3,22),(29,'Bu och Bä i blås väder',24,2009,3,1,24),(30,'Bu wa-Ba fi yawm asif',24,2009,3,1,24),(31,'Bu wa-Ba fi al ghabah',24,2009,3,1,24),(32,'kakat maks',20,2003,3,NULL,25),(33,'Max Kaka',20,2003,3,NULL,25),(34,'Al-bahr al-azraq al-kabir',20,2019,3,4,23),(38,'hej',10,11,1,NULL,29);
/*!40000 ALTER TABLE `books` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categorys`
--

DROP TABLE IF EXISTS `categorys`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categorys` (
  `idCategorys` int NOT NULL AUTO_INCREMENT,
  `category_name` varchar(45) NOT NULL,
  `genre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idCategorys`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorys`
--

LOCK TABLES `categorys` WRITE;
/*!40000 ALTER TABLE `categorys` DISABLE KEYS */;
INSERT INTO `categorys` VALUES (1,'FiltBok','Barnbok'),(2,'Pekbok','Barnbok'),(3,'BildBok','Barnbok'),(4,'Klassisk saga','Barnbok'),(5,'Aktivbok','Barnbok');
/*!40000 ALTER TABLE `categorys` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `favorits`
--

DROP TABLE IF EXISTS `favorits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `favorits` (
  `idFavorits` int NOT NULL,
  `clarify_favorit` varchar(45) NOT NULL,
  PRIMARY KEY (`idFavorits`,`clarify_favorit`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `favorits`
--

LOCK TABLES `favorits` WRITE;
/*!40000 ALTER TABLE `favorits` DISABLE KEYS */;
INSERT INTO `favorits` VALUES (1,'Liked'),(2,'Liked'),(3,'Quite Favored'),(4,'Favorite'),(5,'Favorite');
/*!40000 ALTER TABLE `favorits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `languages`
--

DROP TABLE IF EXISTS `languages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `languages` (
  `idLanguages` int NOT NULL AUTO_INCREMENT,
  `languageName` varchar(45) NOT NULL,
  PRIMARY KEY (`idLanguages`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `languages`
--

LOCK TABLES `languages` WRITE;
/*!40000 ALTER TABLE `languages` DISABLE KEYS */;
INSERT INTO `languages` VALUES (1,'Svenska'),(2,'Arabiska'),(3,'Svenska'),(4,''),(5,'Svenska');
/*!40000 ALTER TABLE `languages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `view_books_author_favorits`
--

DROP TABLE IF EXISTS `view_books_author_favorits`;
/*!50001 DROP VIEW IF EXISTS `view_books_author_favorits`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_books_author_favorits` AS SELECT 
 1 AS `ID`,
 1 AS `Title`,
 1 AS `Pages`,
 1 AS `Publication_year`,
 1 AS `AuthorId`,
 1 AS `idAuthors`,
 1 AS `Author_name`,
 1 AS `FaveId`,
 1 AS `clarify_favorit`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `view_books_author_favorits`
--

/*!50001 DROP VIEW IF EXISTS `view_books_author_favorits`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_books_author_favorits` AS select `books`.`idBooks` AS `ID`,`books`.`book_title` AS `Title`,`books`.`page_amount` AS `Pages`,`books`.`year_published` AS `Publication_year`,`books`.`Author` AS `AuthorId`,`authors`.`idAuthors` AS `idAuthors`,`authors`.`Author_name` AS `Author_name`,`books`.`Favorits_id` AS `FaveId`,`favorits`.`clarify_favorit` AS `clarify_favorit` from ((`books` join `authors` on((`books`.`Author` = `authors`.`idAuthors`))) join `favorits` on((`books`.`Favorits_id` = `favorits`.`idFavorits`))) order by `authors`.`Author_name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-02-01 10:58:03
