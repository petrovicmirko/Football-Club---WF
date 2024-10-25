-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: fudbalski_klub_is
-- ------------------------------------------------------
-- Server version	8.0.33

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
-- Table structure for table `i_na_ut`
--

DROP TABLE IF EXISTS `i_na_ut`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `i_na_ut` (
  `IDOsobe` int NOT NULL,
  `IDUtakmice` int NOT NULL,
  `UProtokolu` tinyint unsigned NOT NULL,
  `MinutaUIgri` int unsigned NOT NULL,
  `Golovi` int unsigned NOT NULL,
  `Asistencije` int unsigned NOT NULL,
  `ZutiKarton` int unsigned NOT NULL,
  `CrveniKarton` int unsigned NOT NULL,
  PRIMARY KEY (`IDOsobe`,`IDUtakmice`),
  KEY `fk_i_na_ut_utakmica_idx` (`IDUtakmice`),
  CONSTRAINT `fk_i_na_ut_igrac` FOREIGN KEY (`IDOsobe`) REFERENCES `igrac` (`IDOsobe`),
  CONSTRAINT `fk_i_na_ut_utakmica` FOREIGN KEY (`IDUtakmice`) REFERENCES `utakmica` (`IDUtakmice`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `i_na_ut`
--

LOCK TABLES `i_na_ut` WRITE;
/*!40000 ALTER TABLE `i_na_ut` DISABLE KEYS */;
INSERT INTO `i_na_ut` VALUES (1,1,0,0,0,0,0,0),(1,6,1,80,0,0,1,0),(1,14,0,0,0,0,0,0),(1,33,0,0,0,0,0,0),(1,39,1,90,0,1,0,0),(1,40,0,0,0,0,0,0),(1,45,1,90,0,1,0,0),(1,47,1,1,0,0,1,1),(1,53,0,0,0,0,0,0),(1,55,0,0,0,0,0,0),(1,57,1,80,1,1,1,0),(1,60,1,90,0,0,2,1),(1,64,1,70,0,0,1,0),(1,69,0,0,0,0,0,0),(1,71,1,34,0,0,1,1),(1,72,1,90,0,0,1,0),(1,73,0,0,0,0,0,0),(1,77,0,0,0,0,0,0),(2,1,1,90,2,1,1,0),(2,6,1,2,2,2,0,0),(2,14,1,90,3,0,0,0),(2,33,1,90,4,0,1,1),(2,39,1,90,1,0,0,0),(2,40,0,0,0,0,0,0),(2,45,1,90,3,0,0,0),(2,47,1,90,4,0,0,0),(2,53,1,90,1,0,0,0),(2,55,1,90,2,1,0,0),(2,57,1,90,1,1,0,0),(2,60,1,90,2,0,0,0),(2,64,1,90,3,0,0,0),(2,69,1,90,2,0,0,0),(2,71,1,90,3,0,0,0),(2,72,1,90,2,0,0,0),(2,73,1,90,2,0,0,0),(2,77,1,90,3,0,1,0),(4,1,1,90,0,2,0,1),(4,6,1,90,2,2,0,0),(4,14,1,90,0,3,0,0),(4,33,1,90,0,3,1,0),(4,39,0,0,0,0,0,0),(4,40,1,90,5,0,0,0),(4,45,0,0,0,0,0,0),(4,47,1,90,0,4,0,0),(4,53,1,90,0,1,1,0),(4,55,1,90,1,2,1,0),(4,57,1,87,0,0,1,1),(4,60,0,0,0,0,0,0),(4,64,0,0,0,0,0,0),(4,69,0,0,0,0,0,0),(4,71,0,0,0,0,0,0),(4,72,1,90,0,0,1,0),(4,73,1,90,0,2,0,0),(4,77,1,90,0,1,1,0),(62,73,0,0,0,0,0,0),(62,77,1,90,0,0,0,0),(63,73,0,0,0,0,0,0),(63,77,0,0,0,0,0,0);
/*!40000 ALTER TABLE `i_na_ut` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `igrac`
--

DROP TABLE IF EXISTS `igrac`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `igrac` (
  `IDOsobe` int NOT NULL,
  `Pozicija` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  `BrojDresa` int NOT NULL,
  PRIMARY KEY (`IDOsobe`),
  CONSTRAINT `FK_igrac_osoba` FOREIGN KEY (`IDOsobe`) REFERENCES `osoba` (`IDOsobe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `igrac`
--

LOCK TABLES `igrac` WRITE;
/*!40000 ALTER TABLE `igrac` DISABLE KEYS */;
INSERT INTO `igrac` VALUES (1,'golman',1),(2,'napad',7),(4,'odbrana',17),(62,'golman',12),(63,'vezni',10);
/*!40000 ALTER TABLE `igrac` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `broj_dresa_trigger` BEFORE INSERT ON `igrac` FOR EACH ROW begin
declare message_text varchar(255);
if new.BrojDresa < 1 or new.BrojDresa > 99 then
	signal sqlstate '45000'
    set message_text = 'Vrijednost atributa mora biti između 1 i 99';
end if;
end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `igrac_na_utakmici_info`
--

DROP TABLE IF EXISTS `igrac_na_utakmici_info`;
/*!50001 DROP VIEW IF EXISTS `igrac_na_utakmici_info`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `igrac_na_utakmici_info` AS SELECT 
 1 AS `IDOsobe`,
 1 AS `IDUtakmice`,
 1 AS `Ime`,
 1 AS `Prezime`,
 1 AS `UProtokolu`,
 1 AS `MinutaUIgri`,
 1 AS `ZutiKarton`,
 1 AS `CrveniKarton`,
 1 AS `Asistencije`,
 1 AS `Golovi`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `klub`
--

DROP TABLE IF EXISTS `klub`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `klub` (
  `IDKluba` int NOT NULL AUTO_INCREMENT,
  `NazivKluba` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  `DatumOsnivanja` date NOT NULL,
  `Grad` varchar(40) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  `Stadion` varchar(40) COLLATE utf8mb3_unicode_ci NOT NULL,
  PRIMARY KEY (`IDKluba`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `klub`
--

LOCK TABLES `klub` WRITE;
/*!40000 ALTER TABLE `klub` DISABLE KEYS */;
INSERT INTO `klub` VALUES (1,'Ljubić','1946-06-15','Prnjavor','\"Siniša Peulić\"');
/*!40000 ALTER TABLE `klub` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `korisnik`
--

DROP TABLE IF EXISTS `korisnik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `korisnik` (
  `IDOsobe` int NOT NULL,
  `KorisnickoIme` varchar(50) COLLATE utf8mb3_unicode_ci NOT NULL,
  `Lozinka` varchar(50) COLLATE utf8mb3_unicode_ci NOT NULL,
  `Uloga` tinyint NOT NULL,
  `Tema` int NOT NULL,
  PRIMARY KEY (`IDOsobe`),
  UNIQUE KEY `KorisnickoIme_UNIQUE` (`KorisnickoIme`),
  CONSTRAINT `fk_KORISNIK_OSOBA1` FOREIGN KEY (`IDOsobe`) REFERENCES `osoba` (`IDOsobe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `korisnik`
--

LOCK TABLES `korisnik` WRITE;
/*!40000 ALTER TABLE `korisnik` DISABLE KEYS */;
INSERT INTO `korisnik` VALUES (26,'admin1','admin1',1,2),(27,'admin2','admin2',1,2),(51,'mirko','mirko',0,1),(52,'andrej','andrej',0,1),(59,'jovan','jovan',0,3),(61,'djordje','djordje',0,3);
/*!40000 ALTER TABLE `korisnik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `odigrane_utakmice_info`
--

DROP TABLE IF EXISTS `odigrane_utakmice_info`;
/*!50001 DROP VIEW IF EXISTS `odigrane_utakmice_info`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `odigrane_utakmice_info` AS SELECT 
 1 AS `IDUtakmice`,
 1 AS `Protivnik`,
 1 AS `Rezultat`,
 1 AS `Domaćin ili Gost`,
 1 AS `DatumVrijeme`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `osoba`
--

DROP TABLE IF EXISTS `osoba`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `osoba` (
  `IDOsobe` int NOT NULL AUTO_INCREMENT,
  `Ime` varchar(40) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  `Prezime` varchar(40) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  `Nacionalnost` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  PRIMARY KEY (`IDOsobe`)
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `osoba`
--

LOCK TABLES `osoba` WRITE;
/*!40000 ALTER TABLE `osoba` DISABLE KEYS */;
INSERT INTO `osoba` VALUES (1,'Petar','Petrović','Srbija'),(2,'Cristiano','Ronaldo','Portugal'),(4,'Bojan','Jazić','Srbija'),(7,'Carlo','Ancelotti','Italija'),(17,'Željko','Buvač','Bosna i Hercegovina'),(26,'Admin1','Admin1','Admin1'),(27,'Admin2','Admin2','Admin2'),(51,'Mirko','Petrovic','-'),(52,'Andrej','Tomić','-'),(56,'Goran','Petrović','Srbija'),(59,'Jovan','Petrović','-'),(61,'Djordje','Kalaba','-'),(62,'Đorđe','Kalaba','Bosna i Hercegovina'),(63,'Lionel','Messi','Argentina');
/*!40000 ALTER TABLE `osoba` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `protivnicki_klub`
--

DROP TABLE IF EXISTS `protivnicki_klub`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `protivnicki_klub` (
  `IDProtivnickogKluba` int NOT NULL AUTO_INCREMENT,
  `NazivProtivnickogKluba` varchar(40) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  `Mjesto` varchar(40) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  PRIMARY KEY (`IDProtivnickogKluba`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `protivnicki_klub`
--

LOCK TABLES `protivnicki_klub` WRITE;
/*!40000 ALTER TABLE `protivnicki_klub` DISABLE KEYS */;
INSERT INTO `protivnicki_klub` VALUES (1,'Partizan','Beograd'),(3,'Dinamo','Pančevo'),(4,'Arsenal','London'),(5,'Real','Madrid');
/*!40000 ALTER TABLE `protivnicki_klub` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sezona`
--

DROP TABLE IF EXISTS `sezona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sezona` (
  `IDSezone` int NOT NULL AUTO_INCREMENT,
  `NazivSezone` varchar(10) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  PRIMARY KEY (`IDSezone`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sezona`
--

LOCK TABLES `sezona` WRITE;
/*!40000 ALTER TABLE `sezona` DISABLE KEYS */;
INSERT INTO `sezona` VALUES (1,'19/20'),(5,'21/22'),(9,'23/24'),(20,'20/21'),(22,'22/23');
/*!40000 ALTER TABLE `sezona` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `dodaj_sezonu_trigger` AFTER INSERT ON `sezona` FOR EACH ROW BEGIN
    INSERT INTO TAKMICENJE_SEZONA (IDTakmicenja, IDSezone, Uspjeh)
    SELECT IDTakmicenja, NEW.IDSezone, '-'
    FROM TAKMICENJE;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `brisanje_sezona` BEFORE DELETE ON `sezona` FOR EACH ROW BEGIN
    DELETE FROM TAKMICENJE_SEZONA WHERE IDSezone = OLD.IDSezone;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `takmicenja_po_sezonama_info`
--

DROP TABLE IF EXISTS `takmicenja_po_sezonama_info`;
/*!50001 DROP VIEW IF EXISTS `takmicenja_po_sezonama_info`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `takmicenja_po_sezonama_info` AS SELECT 
 1 AS `IDSezone`,
 1 AS `IDTakmicenja`,
 1 AS `Sezona`,
 1 AS `Takmicenje`,
 1 AS `Uspjeh`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `takmicenje`
--

DROP TABLE IF EXISTS `takmicenje`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `takmicenje` (
  `IDTakmicenja` int NOT NULL AUTO_INCREMENT,
  `NazivTakmicenja` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  PRIMARY KEY (`IDTakmicenja`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `takmicenje`
--

LOCK TABLES `takmicenje` WRITE;
/*!40000 ALTER TABLE `takmicenje` DISABLE KEYS */;
INSERT INTO `takmicenje` VALUES (1,'Liga Evrope'),(2,'Kup Srbije'),(5,'Liga šampiona'),(6,'Liga Konferencije');
/*!40000 ALTER TABLE `takmicenje` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `dodaj_takmicenje_trigger` AFTER INSERT ON `takmicenje` FOR EACH ROW BEGIN
    INSERT INTO TAKMICENJE_SEZONA (IDTakmicenja, IDSezone, Uspjeh)
    SELECT NEW.IDTakmicenja, IDSezone, '-'
    FROM SEZONA;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `brisanje_takmicenja` BEFORE DELETE ON `takmicenje` FOR EACH ROW BEGIN
    DELETE FROM TAKMICENJE_SEZONA WHERE IDTakmicenja = OLD.IDTakmicenja;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `takmicenje_sezona`
--

DROP TABLE IF EXISTS `takmicenje_sezona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `takmicenje_sezona` (
  `IDTakmicenja` int NOT NULL,
  `IDSezone` int NOT NULL,
  `Uspjeh` varchar(40) COLLATE utf8mb3_unicode_ci NOT NULL,
  PRIMARY KEY (`IDTakmicenja`,`IDSezone`),
  KEY `fk_TAKMICENJE_has_SEZONA_SEZONA1_idx` (`IDSezone`),
  KEY `fk_TAKMICENJE_has_SEZONA_TAKMICENJE1_idx` (`IDTakmicenja`),
  CONSTRAINT `fk_takmicenje_sezona_sezona` FOREIGN KEY (`IDSezone`) REFERENCES `sezona` (`IDSezone`),
  CONSTRAINT `fk_takmicenje_sezona_takmicenje` FOREIGN KEY (`IDTakmicenja`) REFERENCES `takmicenje` (`IDTakmicenja`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `takmicenje_sezona`
--

LOCK TABLES `takmicenje_sezona` WRITE;
/*!40000 ALTER TABLE `takmicenje_sezona` DISABLE KEYS */;
INSERT INTO `takmicenje_sezona` VALUES (1,1,'prvo mjesto'),(1,9,'-'),(1,20,'-'),(1,22,'-'),(2,1,'grupna faza'),(2,9,'četvrtfinale'),(2,20,'-'),(2,22,'-'),(5,5,'grupna faza'),(5,9,'polufinale'),(5,20,'-'),(5,22,'-'),(6,1,'-'),(6,5,'-'),(6,9,'polufinale'),(6,20,'-'),(6,22,'finale');
/*!40000 ALTER TABLE `takmicenje_sezona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trener`
--

DROP TABLE IF EXISTS `trener`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `trener` (
  `IDOsobe` int NOT NULL,
  `Specijalizacija` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  PRIMARY KEY (`IDOsobe`),
  CONSTRAINT `FK_trener_osoba` FOREIGN KEY (`IDOsobe`) REFERENCES `osoba` (`IDOsobe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trener`
--

LOCK TABLES `trener` WRITE;
/*!40000 ALTER TABLE `trener` DISABLE KEYS */;
INSERT INTO `trener` VALUES (7,'glavni trener'),(17,'pomoćni trener'),(56,'kondicioni trener');
/*!40000 ALTER TABLE `trener` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `trener_info`
--

DROP TABLE IF EXISTS `trener_info`;
/*!50001 DROP VIEW IF EXISTS `trener_info`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `trener_info` AS SELECT 
 1 AS `Ime`,
 1 AS `Prezime`,
 1 AS `Nacionalnost`,
 1 AS `Specijalizacija`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `utakmica`
--

DROP TABLE IF EXISTS `utakmica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utakmica` (
  `IDUtakmice` int NOT NULL AUTO_INCREMENT,
  `DatumVrijeme` datetime NOT NULL,
  `Domacin` tinyint NOT NULL,
  `BrojDatihGolova` int NOT NULL,
  `BrojPrimljenihGolova` int NOT NULL,
  `FazaKolo` varchar(20) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  `StatusUtakmice` tinyint NOT NULL,
  `IDProtivnickogKluba` int NOT NULL,
  `IDTakmicenja` int NOT NULL,
  `IDSezone` int NOT NULL,
  PRIMARY KEY (`IDUtakmice`),
  KEY `fk_UTAKMICA_PROTIVNICKI_KLUB1_idx` (`IDProtivnickogKluba`),
  KEY `fk_UTAKMICA_TAKMICENJE_SEZONA1_idx` (`IDTakmicenja`,`IDSezone`),
  CONSTRAINT `fk_utakmica_protivnicki_klub` FOREIGN KEY (`IDProtivnickogKluba`) REFERENCES `protivnicki_klub` (`IDProtivnickogKluba`),
  CONSTRAINT `fk_utakmica_takmicenje_sezona` FOREIGN KEY (`IDTakmicenja`, `IDSezone`) REFERENCES `takmicenje_sezona` (`IDTakmicenja`, `IDSezone`)
) ENGINE=InnoDB AUTO_INCREMENT=82 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utakmica`
--

LOCK TABLES `utakmica` WRITE;
/*!40000 ALTER TABLE `utakmica` DISABLE KEYS */;
INSERT INTO `utakmica` VALUES (1,'2023-08-27 15:30:00',1,3,4,'3. kolo',1,1,1,1),(6,'2023-10-12 14:00:00',0,4,2,'polufinale',1,3,2,1),(14,'2023-09-06 15:00:00',1,3,2,'osmina',1,3,1,1),(33,'2023-08-12 21:00:00',0,4,4,'osmina finala',1,4,5,5),(39,'2024-01-05 15:00:00',0,1,0,'finale',1,1,1,1),(40,'2024-01-08 17:15:00',0,5,3,'5. kolo',1,3,1,1),(45,'2024-01-11 12:30:00',0,3,1,'polufinale',1,1,1,1),(47,'2024-01-16 12:30:00',0,4,1,'grupna faza',1,1,6,9),(53,'2024-01-25 13:00:00',1,1,1,'finale',1,1,2,9),(55,'2024-02-02 13:30:00',0,3,2,'osmina finala',1,4,5,9),(57,'2024-01-16 12:30:00',0,2,1,'grupna faza',1,3,6,9),(60,'2024-01-23 12:20:00',1,2,0,'osmina finala',1,3,5,9),(64,'2024-01-29 13:30:00',0,3,1,'osmina finala',1,4,5,9),(69,'2024-03-16 13:30:00',1,2,1,'finale',1,5,5,9),(71,'2024-03-21 13:30:00',1,3,1,'finale',1,1,2,9),(72,'2024-04-06 13:30:00',0,2,2,'polufinale',1,4,5,9),(73,'2024-05-22 13:30:00',1,2,0,'finale',1,4,1,9),(74,'2024-05-23 13:30:00',0,0,0,'finale',0,3,5,5),(75,'2024-05-22 14:00:00',1,0,0,'polufinale',0,1,2,9),(77,'2024-05-22 13:30:00',1,3,1,'finale',1,5,5,9),(81,'2024-06-08 13:30:00',0,0,0,'polufinale',0,1,5,9);
/*!40000 ALTER TABLE `utakmica` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `broj_golova_trigger` BEFORE INSERT ON `utakmica` FOR EACH ROW begin
if new.BrojDatihGolova < 0 then
	set new.BrojDatihGolova = 0;
end if;
if new.BrojPrimljenihGolova < 0 then
	set new.BrojPrimljenihGolova = 0;
end if;
end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `obrisi_igrace_na_utakmici` BEFORE DELETE ON `utakmica` FOR EACH ROW BEGIN
    DELETE FROM I_NA_UT WHERE IDUtakmice = OLD.IDUtakmice;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `utakmice_info`
--

DROP TABLE IF EXISTS `utakmice_info`;
/*!50001 DROP VIEW IF EXISTS `utakmice_info`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `utakmice_info` AS SELECT 
 1 AS `IDUtakmice`,
 1 AS `DatumVrijeme`,
 1 AS `Domacin`,
 1 AS `BrojDatihGolova`,
 1 AS `BrojPrimljenihGolova`,
 1 AS `FazaKolo`,
 1 AS `StatusUtakmice`,
 1 AS `IDProtivnickogKluba`,
 1 AS `IDTakmicenja`,
 1 AS `IDSezone`,
 1 AS `NazivProtivnickogKluba`,
 1 AS `NazivTakmicenja`,
 1 AS `NazivSezone`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `zakazane_utakmice_info`
--

DROP TABLE IF EXISTS `zakazane_utakmice_info`;
/*!50001 DROP VIEW IF EXISTS `zakazane_utakmice_info`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `zakazane_utakmice_info` AS SELECT 
 1 AS `IDUtakmice`,
 1 AS `Protivnik`,
 1 AS `Termin`,
 1 AS `Domaćin ili Gost`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping routines for database 'fudbalski_klub_is'
--
/*!50003 DROP PROCEDURE IF EXISTS `dodaj_igraca` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `dodaj_igraca`(in pIme varchar(40), in pPrezime varchar(40), in pNacionalnost varchar(100), in pPozicija varchar(50), in pBrojDresa int)
begin
	declare id int;
    insert into osoba(Ime, Prezime, Nacionalnost) values (pIme, pPrezime, pNacionalnost);
    set id =  last_insert_id();
    insert into igrac(IDOsobe, Pozicija, BrojDresa) values (id, pPozicija, pBrojDresa);
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `dodaj_korisnika` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `dodaj_korisnika`(
    IN pIme VARCHAR(40), 
    IN pPrezime VARCHAR(40), 
    IN pNacionalnost VARCHAR(100), 
    IN pKorisnickoIme VARCHAR(50), 
    IN pLozinka VARCHAR(50), 
    IN pUloga VARCHAR(50), 
    IN pTema VARCHAR(50)
)
BEGIN
    DECLARE idOsoba INT;
    
    -- Dodavanje osobe
    INSERT INTO osoba(Ime, Prezime, Nacionalnost) VALUES (pIme, pPrezime, pNacionalnost);
    SET idOsoba = LAST_INSERT_ID();
    
    -- Dodavanje korisnika
    INSERT INTO korisnik(IDOsobe, KorisnickoIme, Lozinka, Uloga, Tema) 
    VALUES (idOsoba, pKorisnickoIme, pLozinka, pUloga, pTema);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `dodaj_trenera` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `dodaj_trenera`(in pIme varchar(40), in pPrezime varchar(40), in pNacionalnost varchar(100), in pSpecijalizacija varchar(100))
begin
	declare id int;
    insert into osoba(Ime, Prezime, Nacionalnost) values (pIme, pPrezime, pNacionalnost);
    set id =  last_insert_id();
    insert into trener(IDOsobe, Specijalizacija) values (id, pSpecijalizacija);
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `update_igrac_info` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `update_igrac_info`(
IN pIDOsobe INT,
IN NovoIme VARCHAR(40),
IN NovoPrezime VARCHAR(40),
IN NovaNacionalnost VARCHAR(100),
IN NovaPozicija VARCHAR(100),
IN NoviBrojDresa INT
)
begin
update IGRAC I
set I.Pozicija = NovaPozicija, I.BrojDresa = NoviBrojDresa
where I.IDOsobe = pIDOsobe;
set @IDOsobe = (select IDOsobe from IGRAC I where I.IDOsobe = pIDOsobe);
update OSOBA O
set O.Ime = NovoIme, O.Prezime = NovoPrezime, O.Nacionalnost = NovaNacionalnost
where O.IDOsobe = @IDOsobe;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `update_korisnik_info` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `update_korisnik_info`(
IN pIDOsobe INT,
IN NovoIme VARCHAR(40),
IN NovoPrezime VARCHAR(40),
IN NovoKorisnickoIme VARCHAR(50)
)
begin
update KORISNIK K
set K.KorisnickoIme = NovoKorisnickoIme
where K.IDOsobe = pIDOsobe;
set @IDOsobe = (select IDOsobe from KORISNIK K where K.IDOsobe = pIDOsobe);
update OSOBA O
set O.Ime = NovoIme, O.Prezime = NovoPrezime
where O.IDOsobe = @IDOsobe;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `update_trener_info` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `update_trener_info`(
IN pIDOsobe INT,
IN NovoIme VARCHAR(40),
IN NovoPrezime VARCHAR(40),
IN NovaNacionalnost VARCHAR(100),
IN NovaSpecijalizacija VARCHAR(100)
)
begin
update TRENER T
set T.Specijalizacija = NovaSpecijalizacija
where T.IDOsobe = pIDOsobe;
set @IDOsobe = (select IDOsobe from TRENER T where T.IDOsobe = pIDOsobe);
update OSOBA O
set O.Ime = NovoIme, O.Prezime = NovoPrezime, O.Nacionalnost = NovaNacionalnost
where O.IDOsobe = @IDOsobe;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `igrac_na_utakmici_info`
--

/*!50001 DROP VIEW IF EXISTS `igrac_na_utakmici_info`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `igrac_na_utakmici_info` AS select `o`.`IDOsobe` AS `IDOsobe`,`iu`.`IDUtakmice` AS `IDUtakmice`,`o`.`Ime` AS `Ime`,`o`.`Prezime` AS `Prezime`,`iu`.`UProtokolu` AS `UProtokolu`,`iu`.`MinutaUIgri` AS `MinutaUIgri`,`iu`.`ZutiKarton` AS `ZutiKarton`,`iu`.`CrveniKarton` AS `CrveniKarton`,`iu`.`Asistencije` AS `Asistencije`,`iu`.`Golovi` AS `Golovi` from (`osoba` `o` join `i_na_ut` `iu` on((`o`.`IDOsobe` = `iu`.`IDOsobe`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `odigrane_utakmice_info`
--

/*!50001 DROP VIEW IF EXISTS `odigrane_utakmice_info`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `odigrane_utakmice_info` AS select `u`.`IDUtakmice` AS `IDUtakmice`,`pk`.`NazivProtivnickogKluba` AS `Protivnik`,(case when (`u`.`Domacin` = 1) then concat(`u`.`BrojDatihGolova`,' - ',`u`.`BrojPrimljenihGolova`) else concat(`u`.`BrojPrimljenihGolova`,' - ',`u`.`BrojDatihGolova`) end) AS `Rezultat`,(case when (`u`.`Domacin` = 1) then 'Domaćin' else 'Gost' end) AS `Domaćin ili Gost`,`u`.`DatumVrijeme` AS `DatumVrijeme` from (`protivnicki_klub` `pk` join `utakmica` `u` on((`pk`.`IDProtivnickogKluba` = `u`.`IDProtivnickogKluba`))) where (`u`.`DatumVrijeme` < now()) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `takmicenja_po_sezonama_info`
--

/*!50001 DROP VIEW IF EXISTS `takmicenja_po_sezonama_info`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `takmicenja_po_sezonama_info` AS select `s`.`IDSezone` AS `IDSezone`,`t`.`IDTakmicenja` AS `IDTakmicenja`,`s`.`NazivSezone` AS `Sezona`,`t`.`NazivTakmicenja` AS `Takmicenje`,`ts`.`Uspjeh` AS `Uspjeh` from ((`sezona` `s` join `takmicenje_sezona` `ts` on((`s`.`IDSezone` = `ts`.`IDSezone`))) join `takmicenje` `t` on((`ts`.`IDTakmicenja` = `t`.`IDTakmicenja`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `trener_info`
--

/*!50001 DROP VIEW IF EXISTS `trener_info`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `trener_info` AS select `o`.`Ime` AS `Ime`,`o`.`Prezime` AS `Prezime`,`o`.`Nacionalnost` AS `Nacionalnost`,`t`.`Specijalizacija` AS `Specijalizacija` from (`osoba` `o` join `trener` `t` on((`o`.`IDOsobe` = `t`.`IDOsobe`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `utakmice_info`
--

/*!50001 DROP VIEW IF EXISTS `utakmice_info`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `utakmice_info` AS select `u`.`IDUtakmice` AS `IDUtakmice`,`u`.`DatumVrijeme` AS `DatumVrijeme`,`u`.`Domacin` AS `Domacin`,`u`.`BrojDatihGolova` AS `BrojDatihGolova`,`u`.`BrojPrimljenihGolova` AS `BrojPrimljenihGolova`,`u`.`FazaKolo` AS `FazaKolo`,`u`.`StatusUtakmice` AS `StatusUtakmice`,`u`.`IDProtivnickogKluba` AS `IDProtivnickogKluba`,`u`.`IDTakmicenja` AS `IDTakmicenja`,`u`.`IDSezone` AS `IDSezone`,`pk`.`NazivProtivnickogKluba` AS `NazivProtivnickogKluba`,`t`.`NazivTakmicenja` AS `NazivTakmicenja`,`s`.`NazivSezone` AS `NazivSezone` from (((`utakmica` `u` join `protivnicki_klub` `pk` on((`u`.`IDProtivnickogKluba` = `pk`.`IDProtivnickogKluba`))) join `takmicenje` `t` on((`t`.`IDTakmicenja` = `u`.`IDTakmicenja`))) join `sezona` `s` on((`s`.`IDSezone` = `u`.`IDSezone`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `zakazane_utakmice_info`
--

/*!50001 DROP VIEW IF EXISTS `zakazane_utakmice_info`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `zakazane_utakmice_info` AS select `u`.`IDUtakmice` AS `IDUtakmice`,concat(`pk`.`NazivProtivnickogKluba`,' - ',`pk`.`Mjesto`) AS `Protivnik`,`u`.`DatumVrijeme` AS `Termin`,(case when (`u`.`Domacin` = 1) then 'Domaćin' else 'Gost' end) AS `Domaćin ili Gost` from (`protivnicki_klub` `pk` join `utakmica` `u` on((`pk`.`IDProtivnickogKluba` = `u`.`IDProtivnickogKluba`))) where (`u`.`DatumVrijeme` > now()) */;
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

-- Dump completed on 2024-10-26  0:49:13
