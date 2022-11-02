CREATE DATABASE  IF NOT EXISTS `surveymoduledb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `surveymoduledb`;
-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: surveymoduledb
-- ------------------------------------------------------
-- Server version	8.0.31

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
-- Table structure for table `tbl_login`
--

DROP TABLE IF EXISTS `tbl_login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_login` (
  `id` int NOT NULL,
  `loginid` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `createdby` int DEFAULT NULL,
  `createdat` datetime DEFAULT NULL,
  `modifiedby` int DEFAULT NULL,
  `modifiedat` datetime DEFAULT NULL,
  `isactive` tinyint DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_login`
--

LOCK TABLES `tbl_login` WRITE;
/*!40000 ALTER TABLE `tbl_login` DISABLE KEYS */;
INSERT INTO `tbl_login` VALUES (1,'admin','admin',1,'2022-11-01 11:56:46',1,'2022-11-01 11:56:46',1);
/*!40000 ALTER TABLE `tbl_login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_project`
--

DROP TABLE IF EXISTS `tbl_project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_project` (
  `id` int NOT NULL,
  `project_name` varchar(45) DEFAULT NULL,
  `project_desc` varchar(500) DEFAULT NULL,
  `scheduled` tinyint DEFAULT NULL,
  `scheduled_start_datetime` datetime DEFAULT NULL,
  `scheduled_end_datetime` datetime DEFAULT NULL,
  `createdby` int DEFAULT NULL,
  `createdat` datetime DEFAULT NULL,
  `modifiedby` int DEFAULT NULL,
  `modifiedat` datetime DEFAULT NULL,
  `isactive` tinyint DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_project`
--

LOCK TABLES `tbl_project` WRITE;
/*!40000 ALTER TABLE `tbl_project` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_questionnaire`
--

DROP TABLE IF EXISTS `tbl_questionnaire`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_questionnaire` (
  `id` int NOT NULL,
  `project_id` int DEFAULT NULL,
  `question` varchar(50) DEFAULT NULL,
  `question_desc` varchar(500) DEFAULT NULL,
  `question_order` int DEFAULT NULL,
  `createdby` int DEFAULT NULL,
  `createdat` datetime DEFAULT NULL,
  `modifiedby` int DEFAULT NULL,
  `modifiedat` datetime DEFAULT NULL,
  `isactive` tinyint DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_project_id_idx` (`project_id`),
  CONSTRAINT `fk_project_id` FOREIGN KEY (`project_id`) REFERENCES `tbl_project` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_questionnaire`
--

LOCK TABLES `tbl_questionnaire` WRITE;
/*!40000 ALTER TABLE `tbl_questionnaire` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_questionnaire` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_questionnaire_options`
--

DROP TABLE IF EXISTS `tbl_questionnaire_options`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_questionnaire_options` (
  `id` int NOT NULL,
  `tbl_questionnaire_id` int DEFAULT NULL,
  `option_desc` varchar(45) DEFAULT NULL,
  `option_order` int DEFAULT NULL,
  `option_score` int DEFAULT NULL,
  `createdby` int DEFAULT NULL,
  `createdat` datetime DEFAULT NULL,
  `modifiedby` int DEFAULT NULL,
  `modifiedat` datetime DEFAULT NULL,
  `isactive` tinyint DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_questionnaire_id_idx` (`tbl_questionnaire_id`),
  CONSTRAINT `fk_questionnaire_id` FOREIGN KEY (`tbl_questionnaire_id`) REFERENCES `tbl_questionnaire` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_questionnaire_options`
--

LOCK TABLES `tbl_questionnaire_options` WRITE;
/*!40000 ALTER TABLE `tbl_questionnaire_options` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_questionnaire_options` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `view_projectlist`
--

DROP TABLE IF EXISTS `view_projectlist`;
/*!50001 DROP VIEW IF EXISTS `view_projectlist`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_projectlist` AS SELECT 
 1 AS `project_name`,
 1 AS `project_desc`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `view_projectlist`
--

/*!50001 DROP VIEW IF EXISTS `view_projectlist`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_projectlist` AS select `tbl_project`.`project_name` AS `project_name`,`tbl_project`.`project_desc` AS `project_desc` from `tbl_project` */;
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

-- Dump completed on 2022-11-02 23:12:51
