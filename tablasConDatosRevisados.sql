-- MariaDB dump 10.17  Distrib 10.4.13-MariaDB, for Linux (x86_64)
--
-- Host: localhost    Database: hellocare
-- ------------------------------------------------------
-- Server version	10.4.13-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `administrativos`
--

DROP TABLE IF EXISTS `administrativos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `administrativos` (
  `ID_FUNCIONARIO` int(11) NOT NULL,
  `ES_ENCARGADO` tinyint(1) NOT NULL,
  PRIMARY KEY (`ID_FUNCIONARIO`),
  CONSTRAINT `administrativos_ibfk_1` FOREIGN KEY (`ID_FUNCIONARIO`) REFERENCES `funcionarios` (`ID_PERSONA`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `administrativos`
--

LOCK TABLES `administrativos` WRITE;
/*!40000 ALTER TABLE `administrativos` DISABLE KEYS */;
INSERT INTO `administrativos` VALUES (1,0),(2,1),(3,1),(4,1),(60,1),(61,1),(62,1),(63,1);
/*!40000 ALTER TABLE `administrativos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuadro_sintomatico`
--

DROP TABLE IF EXISTS `cuadro_sintomatico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cuadro_sintomatico` (
  `ID_SINTOMA` int(11) NOT NULL,
  `ID_ENFERMEDAD` int(11) NOT NULL,
  `FRECUENCIA` double NOT NULL,
  PRIMARY KEY (`ID_SINTOMA`,`ID_ENFERMEDAD`),
  KEY `ID_ENFERMEDAD` (`ID_ENFERMEDAD`),
  CONSTRAINT `cuadro_sintomatico_ibfk_1` FOREIGN KEY (`ID_SINTOMA`) REFERENCES `sintomas` (`ID`),
  CONSTRAINT `cuadro_sintomatico_ibfk_2` FOREIGN KEY (`ID_ENFERMEDAD`) REFERENCES `enfermedades` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuadro_sintomatico`
--

LOCK TABLES `cuadro_sintomatico` WRITE;
/*!40000 ALTER TABLE `cuadro_sintomatico` DISABLE KEYS */;
INSERT INTO `cuadro_sintomatico` VALUES (1,1,90),(1,4,76),(5,1,40),(5,4,50),(13,10,35),(14,11,50),(15,12,45),(16,13,65),(16,14,35),(16,15,35),(17,16,55),(17,17,55),(17,18,55),(18,19,30),(18,20,30),(19,21,60),(19,22,60),(21,23,60),(22,24,20);
/*!40000 ALTER TABLE `cuadro_sintomatico` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departamentos`
--

DROP TABLE IF EXISTS `departamentos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departamentos` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `NOMBRE` (`NOMBRE`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departamentos`
--

LOCK TABLES `departamentos` WRITE;
/*!40000 ALTER TABLE `departamentos` DISABLE KEYS */;
INSERT INTO `departamentos` VALUES (1,'Artigas'),(2,'Canelones'),(3,'Cerro Largo'),(4,'Colonia'),(5,'Durazno'),(6,'Flores'),(7,'Florida'),(8,'Lavalleja'),(9,'Maldonado'),(10,'Montevideo'),(11,'Paysandú'),(12,'Río Negro'),(13,'Rivera'),(14,'Rocha'),(15,'Salto'),(16,'San José'),(17,'Soriano'),(18,'Tacuarembó'),(19,'Treinta y Tres');
/*!40000 ALTER TABLE `departamentos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `diagnosticos_diferenciales`
--

DROP TABLE IF EXISTS `diagnosticos_diferenciales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `diagnosticos_diferenciales` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA` int(11) NOT NULL,
  `ID_ENFERMEDAD` int(11) NOT NULL,
  `CONDUCTA_A_SEGUIR` varchar(1000) NOT NULL,
  `FECHAHORA` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `ID_ENFERMEDAD` (`ID_ENFERMEDAD`),
  KEY `diagnosticos_diferenciales_ibfk_3` (`ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA`),
  CONSTRAINT `diagnosticos_diferenciales_ibfk_2` FOREIGN KEY (`ID_ENFERMEDAD`) REFERENCES `enfermedades` (`ID`),
  CONSTRAINT `diagnosticos_diferenciales_ibfk_3` FOREIGN KEY (`ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA`) REFERENCES `diagnosticos_primarios_con_consulta` (`ID_DIAGNOSTICO_PRIMARIO`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `diagnosticos_primarios`
--

DROP TABLE IF EXISTS `diagnosticos_primarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `diagnosticos_primarios` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PACIENTE` int(11) NOT NULL,
  `FECHA_HORA` datetime NOT NULL,
  `TIPO` enum('Sin_Consulta','Con_Consulta') NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `diagnosticos_primarios_ibfk_1` (`ID_PACIENTE`),
  CONSTRAINT `diagnosticos_primarios_ibfk_1` FOREIGN KEY (`ID_PACIENTE`) REFERENCES `pacientes` (`ID_PERSONA`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `diagnosticos_primarios_con_consulta`
--

DROP TABLE IF EXISTS `diagnosticos_primarios_con_consulta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `diagnosticos_primarios_con_consulta` (
  `ID_DIAGNOSTICO_PRIMARIO` int(11) NOT NULL,
  `ID_MEDICO` int(11) DEFAULT NULL,
  `COMENTARIOS_ADICIONALES` varchar(1000) NOT NULL,
  PRIMARY KEY (`ID_DIAGNOSTICO_PRIMARIO`),
  KEY `ID_MEDICO` (`ID_MEDICO`),
  CONSTRAINT `diagnosticos_primarios_con_consulta_ibfk_1` FOREIGN KEY (`ID_DIAGNOSTICO_PRIMARIO`) REFERENCES `diagnosticos_primarios` (`ID`) ON DELETE CASCADE,
  CONSTRAINT `diagnosticos_primarios_con_consulta_ibfk_2` FOREIGN KEY (`ID_MEDICO`) REFERENCES `medicos` (`ID_FUNCIONARIO`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `enfermedades`
--

DROP TABLE IF EXISTS `enfermedades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `enfermedades` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(100) NOT NULL,
  `DESCRIPCION` varchar(1000) DEFAULT NULL,
  `RECOMENDACIONES` varchar(1000) DEFAULT NULL,
  `GRAVEDAD` int(11) NOT NULL,
  `ID_ESPECIALIDAD` int(11) NOT NULL,
  `HABILITADO` tinyint(4) NOT NULL DEFAULT 1,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `NOMBRE` (`NOMBRE`),
  KEY `ID_ESPECIALIDAD` (`ID_ESPECIALIDAD`),
  CONSTRAINT `enfermedades_ibfk_1` FOREIGN KEY (`ID_ESPECIALIDAD`) REFERENCES `especialidades` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enfermedades`
--

LOCK TABLES `enfermedades` WRITE;
/*!40000 ALTER TABLE `enfermedades` DISABLE KEYS */;
INSERT INTO `enfermedades` VALUES (1,'COVID19','Infección respiratoria causada por un patógeno viral','Realizar cuarentena y practicar el distanciamiento social.',60,6,1),(4,'Tuberculosis','Infeccion bacteriana causada un germen llamada Mycocabcterium tuberculosis,','Tener el tratamiento adecuado',80,1,1),(10,'Neurinoma del acústico','Tumor poco frecuente no canceroso y, por lo general, de crecimiento lento que se forma en el nervio principal (vestibular) que va del oído interno hasta el cerebro.','consultar al medico',50,1,1),(11,'Asma','Tafección en la que se estrechan y se hinchan las vías respiratorias, lo cual produce mayor mucosidad. Esto podría dificultar la respiración y provocar tos, silbido al respirar y falta de aire.','consultar al medico',50,6,1),(12,'Migraña','dolor pulsátil intenso o una sensación de latido en la cabeza, generalmente de un solo lado.','consultar al medico',50,5,1),(13,'Neumonía','infección que inflama los sacos aéreos de uno o ambos pulmones.','consultar al medico',70,6,1),(14,'Fibrosis quística','rastorno heredado que causa daños graves en los pulmones, el sistema digestivo y otros órganos del cuerpo.','requiere cuidados médicos diarios',70,6,1),(15,'Embolia pulmonar','obstrucción en una de las arterias de los pulmones.','Tomar medidas para prevenir los coágulos sanguíneos en las piernas ayudará a protegerte contra la embolia pulmonar.',60,6,1),(16,'Resfriado común','infección viral de la nariz y la garganta (tracto respiratorio superior).','cuidar tracto respiratorio, si persiste en unas semanas consultar al medico',10,6,1),(17,'Conjuntivitis','inflamación o una infección en la membrana transparente (conjuntiva) que recubre el párpado y la parte blanca del globo ocular.','No te toques los ojos con las manos. Lávate las manos con frecuencia. Usa una toalla y un paño limpios cada día. No compartas las toallas y los paños. Cambia la funda de la almohada a menudo. Desecha los cosméticos para los ojos, como el rímel.',15,2,1),(18,'Orzuelo','es un bulto rojo y doloroso cerca del borde del párpado, que puede verse como un grano o una espinilla.','Aplica compresas tibias. Si tuviste un orzuelo antes, el uso regular de una compresa puede ayudar a prevenir que regrese. Lávate las manos. Lávate las manos varias veces al día con agua tibia y jabón o usa un desinfectante a base de alcohol. Mantén las manos alejadas de los ojos.',15,2,1),(19,'Celiaquía','es una reacción del sistema inmunitario al consumo de gluten','comer sin gluten y ver si los gases disminuyen.',40,3,1),(20,'Diabetes','grupo de enfermedades que afectan la forma en que tu organismo utiliza el azúcar en sangre','comer alimentos saludabeles, realizar actividad fisica, eliminar sobrepeso',40,3,1),(21,'Fisura anal','pequeño desgarro en el tejido delgado y húmedo (mucosa) que recubre el ano.','mayor ingesta de fibra o baños de asiento.',30,3,1),(22,'Estreñimiento','evacuaciones intestinales poco frecuentes o dificultad para evacuar que persiste durante varias semanas o más.','mayor ingesta de fibra.',35,3,1),(23,'Insuficiencia hepática aguda','pérdida de función del hígado que ocurre de forma rápida, en días o semanas, generalmente en personas sin enfermedades hepáticas preexistentes.','Según la causa, en ocasiones, la insuficiencia hepática aguda puede revertirse con tratamiento. Sin embargo, en muchas situaciones, un trasplante de hígado puede ser la única cura.',65,3,1),(24,'Insuficiencia renal aguda','ocurre cuando los riñones pierden de repente la capacidad de filtrar los desechos de la sangre.','puede ser fatal y requiere de tratamiento intensivo.',85,7,1);
/*!40000 ALTER TABLE `enfermedades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `especialidades`
--

DROP TABLE IF EXISTS `especialidades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `especialidades` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(100) NOT NULL,
  `HABILITADO` tinyint(4) NOT NULL DEFAULT 1,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `NOMBRE` (`NOMBRE`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `especialidades`
--

LOCK TABLES `especialidades` WRITE;
/*!40000 ALTER TABLE `especialidades` DISABLE KEYS */;
INSERT INTO `especialidades` VALUES (1,'Otorrinolaringólogo',1),(2,'General',1),(3,'Gastroenterólogo',1),(4,'Reumatologia',1),(5,'Neurologia',1),(6,'Neumologia',1),(7,'Nefrología',1),(8,'Alergología',1),(9,'Anestesiología',1),(10,'Cardiología',1),(11,'Endocrinología',1),(12,'Geriatría',1),(13,'Hematología',1),(14,'Infectología',1),(15,'Fisiatría',1),(16,'Nutriología',1),(17,'Oftalmología',1),(18,'Oncología',1),(19,'Pediatría',1),(20,'Psiquiatría',1),(21,'Toxicología',1),(22,'Dermatología',1),(23,'Angiología',1),(24,'Odontología',1),(25,'Ginecología',1),(26,'Urología',1),(27,'Traumatología',1),(28,'Farmacología',1),(29,'Inmunología',1);
/*!40000 ALTER TABLE `especialidades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `especialidades_medicos`
--

DROP TABLE IF EXISTS `especialidades_medicos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `especialidades_medicos` (
  `ID_ESPECIALIDAD` int(11) NOT NULL,
  `ID_MEDICO` int(11) NOT NULL,
  PRIMARY KEY (`ID_ESPECIALIDAD`,`ID_MEDICO`),
  KEY `ID_MEDICO` (`ID_MEDICO`),
  CONSTRAINT `especialidades_medicos_ibfk_1` FOREIGN KEY (`ID_ESPECIALIDAD`) REFERENCES `especialidades` (`ID`),
  CONSTRAINT `especialidades_medicos_ibfk_2` FOREIGN KEY (`ID_MEDICO`) REFERENCES `medicos` (`ID_FUNCIONARIO`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `especialidades_medicos`
--

LOCK TABLES `especialidades_medicos` WRITE;
/*!40000 ALTER TABLE `especialidades_medicos` DISABLE KEYS */;
INSERT INTO `especialidades_medicos` VALUES (1,7),(1,8),(1,37),(2,6),(2,7),(2,36),(3,5),(3,7),(3,35),(4,7),(4,9),(4,34),(5,7),(5,33),(6,7),(6,32),(7,31),(8,38),(9,39),(10,40),(11,41),(12,42),(13,43),(14,44),(15,45),(16,46),(17,47),(18,48),(19,49),(20,50),(21,51),(22,52),(23,53),(24,54),(25,55),(26,56),(27,57),(28,58),(29,59);
/*!40000 ALTER TABLE `especialidades_medicos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `funcionarios`
--

DROP TABLE IF EXISTS `funcionarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `funcionarios` (
  `ID_PERSONA` int(11) NOT NULL,
  `TIPO` enum('Medico','Administrativo') NOT NULL,
  `HABILITADO` tinyint(4) NOT NULL DEFAULT 1,
  PRIMARY KEY (`ID_PERSONA`),
  CONSTRAINT `funcionarios_ibfk_1` FOREIGN KEY (`ID_PERSONA`) REFERENCES `personas` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `funcionarios`
--

LOCK TABLES `funcionarios` WRITE;
/*!40000 ALTER TABLE `funcionarios` DISABLE KEYS */;
INSERT INTO `funcionarios` VALUES (1,'Administrativo',1),(2,'Administrativo',1),(3,'Administrativo',1),(4,'Administrativo',1),(5,'Medico',1),(6,'Medico',1),(7,'Medico',1),(8,'Medico',1),(9,'Medico',1),(31,'Medico',1),(32,'Medico',1),(33,'Medico',1),(34,'Medico',1),(35,'Medico',1),(36,'Medico',1),(37,'Medico',1),(38,'Medico',1),(39,'Medico',1),(40,'Medico',1),(41,'Medico',1),(42,'Medico',1),(43,'Medico',1),(44,'Medico',1),(45,'Medico',1),(46,'Medico',1),(47,'Medico',1),(48,'Medico',1),(49,'Medico',1),(50,'Medico',1),(51,'Medico',1),(52,'Medico',1),(53,'Medico',1),(54,'Medico',1),(55,'Medico',1),(56,'Medico',1),(57,'Medico',1),(58,'Medico',1),(59,'Medico',1),(60,'Administrativo',1),(61,'Administrativo',1),(62,'Administrativo',1),(63,'Administrativo',1);
/*!40000 ALTER TABLE `funcionarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `localidades`
--

DROP TABLE IF EXISTS `localidades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `localidades` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(100) NOT NULL,
  `ID_DEPARTAMENTO` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `NOMBRE` (`NOMBRE`,`ID_DEPARTAMENTO`),
  KEY `ID_DEPARTAMENTO` (`ID_DEPARTAMENTO`),
  CONSTRAINT `localidades_ibfk_1` FOREIGN KEY (`ID_DEPARTAMENTO`) REFERENCES `departamentos` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `localidades`
--

LOCK TABLES `localidades` WRITE;
/*!40000 ALTER TABLE `localidades` DISABLE KEYS */;
INSERT INTO `localidades` VALUES (35,' Bella Unión',1),(5,'Abayuba',10),(38,'Aguas Corrientes',2),(20,'Andresito',6),(41,'Arachania',14),(21,'Arenales',17),(17,'Beisso',11),(49,'Belén',15),(28,'Biassini',15),(42,'Bolívar',2),(9,'Ciudad de la Costa',2),(13,'Constitucion',15),(43,'Dolores',17),(25,'Estación Solís',8),(31,'Florida',7),(22,'La Paloma',14),(26,'La Paz',2),(10,'Las Piedras',2),(23,'Libertad',16),(34,'Melo',3),(47,'Mercedes',17),(50,'Monte Coral',7),(1,'Montevideo',10),(3,'Montevideo Rural',10),(15,'Ombu',1),(32,'Ombúes de Lavalle',4),(2,'Pajas Blancas',10),(18,'Palmitas',17),(7,'Pan de Azucar',9),(11,'Pando',2),(30,'Paso de los Toros',18),(19,'Piedras Coloradas',11),(8,'Piriapolis',9),(6,'Punta del Este',9),(48,'Rincón de la Bolsa',16),(12,'Salto',15),(24,'San Antonio',2),(14,'San Antonio',15),(51,'San Javier',12),(4,'Santiago Vazquez',10),(33,'Sarandí de Navarro',12),(27,'Sarandí del Yí',5),(39,'Sequeira',1),(46,'Solymar',2),(36,'Tala',2),(44,'Tarariras',4),(45,'Valle Edén',18),(29,'Villa del Mar',9),(16,'Villa Rodriguez',16);
/*!40000 ALTER TABLE `localidades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medicos`
--

DROP TABLE IF EXISTS `medicos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `medicos` (
  `ID_FUNCIONARIO` int(11) NOT NULL,
  PRIMARY KEY (`ID_FUNCIONARIO`),
  CONSTRAINT `medicos_ibfk_1` FOREIGN KEY (`ID_FUNCIONARIO`) REFERENCES `funcionarios` (`ID_PERSONA`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicos`
--

LOCK TABLES `medicos` WRITE;
/*!40000 ALTER TABLE `medicos` DISABLE KEYS */;
INSERT INTO `medicos` VALUES (5),(6),(7),(8),(9),(31),(32),(33),(34),(35),(36),(37),(38),(39),(40),(41),(42),(43),(44),(45),(46),(47),(48),(49),(50),(51),(52),(53),(54),(55),(56),(57),(58),(59);
/*!40000 ALTER TABLE `medicos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mensajes`
--

DROP TABLE IF EXISTS `mensajes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mensajes` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FECHAHORA` datetime NOT NULL,
  `FORMATO` enum('PNG','JPG','JPEG','PDF','TXT') NOT NULL,
  `NOMBRE_ARCHIVO` varchar(255) DEFAULT NULL,
  `CONTENIDO` mediumblob NOT NULL,
  `REMITENTE` enum('Medico','Paciente') NOT NULL,
  `ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `mensajes_ibfk_1` (`ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA`),
  CONSTRAINT `mensajes_ibfk_1` FOREIGN KEY (`ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA`) REFERENCES `diagnosticos_primarios_con_consulta` (`ID_DIAGNOSTICO_PRIMARIO`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pacientes`
--

DROP TABLE IF EXISTS `pacientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pacientes` (
  `ID_PERSONA` int(11) NOT NULL,
  `TELEFONOMOVIL` char(9) NOT NULL,
  `TELEFONOFIJO` char(8) NOT NULL,
  `SEXO` enum('M','F','O') NOT NULL,
  `FECHANACIMIENTO` date NOT NULL,
  `FECHADEFUNCION` date DEFAULT NULL,
  `CALLE` varchar(100) NOT NULL,
  `NUMEROPUERTA` varchar(100) NOT NULL,
  `APARTAMENTO` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID_PERSONA`),
  CONSTRAINT `pacientes_ibfk_1` FOREIGN KEY (`ID_PERSONA`) REFERENCES `personas` (`ID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pacientes`
--

LOCK TABLES `pacientes` WRITE;
/*!40000 ALTER TABLE `pacientes` DISABLE KEYS */;
INSERT INTO `pacientes` VALUES (10,'91498520','26960008','F','1998-04-30',NULL,'Stewart Vargas','1100',NULL),(11,'99384940','28394038','M','1970-06-14',NULL,'21 de Setiembre','4300',NULL),(12,'92938490','28375834','F','1966-09-11',NULL,'Camino Carrasco','1233',NULL),(13,'92948502','23845940','F','1980-02-23',NULL,'Jose Battle y Ordoñez','6748',NULL),(14,'91827382','29090381','M','1960-03-27',NULL,'Camino Don Bosco','3958',NULL),(17,'95844850','25061692','M','1950-05-20',NULL,'Plutarco','3993',NULL),(18,'91144972','49729114','M','1955-01-25',NULL,'Molle','5109',NULL),(20,'99609873','98739114','M','1991-09-18',NULL,'Costanera','4436',NULL),(21,'91962080','20809114','M','1995-08-15',NULL,'Ituzaingó','3308',NULL),(22,'98459695','20809695','M','1976-03-04',NULL,'Juncal','7996',NULL),(23,'94357595','75959695','F','1975-12-14',NULL,'Neruda','7207',NULL),(24,'96719546','95469695','M','1960-12-27','2011-05-01','Monteadores','7786',NULL),(25,'91205947','59479695','M','1958-02-05',NULL,'Democracia','2534',NULL),(26,'94867234','59472343','M','1936-01-21',NULL,'Copacabana','2039',NULL),(27,'93839335','93352343','F','1954-11-14','2017-11-18','Neruda','6353',NULL),(28,'93698235','93358235','M','1983-04-14',NULL,'Democracia','9411',NULL),(29,'97110237','02378235','M','1999-09-21',NULL,'Coquimbo','3776',NULL);
/*!40000 ALTER TABLE `pacientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personas`
--

DROP TABLE IF EXISTS `personas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `personas` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CI` varchar(8) NOT NULL,
  `NOMBRE` varchar(100) NOT NULL,
  `APELLIDO` varchar(100) NOT NULL,
  `CORREO` varchar(100) NOT NULL,
  `ID_LOCALIDAD` int(11) NOT NULL,
  `TIPO` enum('Funcionario','Paciente') NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `CI_TIPO` (`CI`,`TIPO`),
  KEY `ID_LOCALIDAD` (`ID_LOCALIDAD`),
  CONSTRAINT `personas_ibfk_1` FOREIGN KEY (`ID_LOCALIDAD`) REFERENCES `localidades` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personas`
--

LOCK TABLES `personas` WRITE;
/*!40000 ALTER TABLE `personas` DISABLE KEYS */;
INSERT INTO `personas` VALUES (1,'51712272','Fabricio','Scarone','fafoscar30@hotmail.com',1,'Funcionario'),(2,'52315584','Pepe','Rodriguez','rodriguezpepe@hotmail.com',1,'Funcionario'),(3,'50681129','Sandra','Guillermes','carloguille21@hotmail.com',1,'Funcionario'),(4,'51593248','Roberto','Sampaoli','rober39@hotmail.com',1,'Funcionario'),(5,'58493851','Guillermo','Francello','guillefranc@hotmail.com',2,'Funcionario'),(6,'12948591','Josefina','Santos','josesanti20@hotmail.com',2,'Funcionario'),(7,'28495065','Agustina','Pose','poseagus10@hotmail.com',3,'Funcionario'),(8,'43847904','Franco','Britos','britos2002@hotmail.com',4,'Funcionario'),(9,'42823105','Lucas','Prigue','priguelucas12@hotmail.com',1,'Funcionario'),(10,'44623501','Luciana','Teseira','lucianateseira22@hotmail.com',9,'Paciente'),(11,'36561579','Nicolas','Ferreiro','nicoferre@hotmail.com',10,'Paciente'),(12,'15057266','Veronica','Borrelli','borreveronica2@hotmail.com',11,'Paciente'),(13,'45117094','Estefania','Ezquivel','estefaniaez@hotmail.com',12,'Paciente'),(14,'25207495','Luciano','DeLaFuente','luci2001@hotmail.com',13,'Paciente'),(17,'54626777','Pepe','Marrero','pepema@gmail.com',1,'Paciente'),(18,'26715504','Lourdes','Sotelo','sotelolourdes@gmail.com',1,'Paciente'),(20,'5132521','Cathy','Mora Bermúdez','CathyMoraBermudez@gustr.com',1,'Paciente'),(21,'85836268','Sansón','Quintanilla Cortés','SansonQuintanillaCortes@gustr.com',16,'Paciente'),(22,'3363560','Casandro','Tórrez Cadena','CasandroTorrezCadena@superrito.com',11,'Paciente'),(23,'27848172','Clide','Rendón Montanez','ClideRendonMontanez@gustr.com',17,'Paciente'),(24,'72780404','Clidia','Rosas Padrón','ClidiaRosasPadron@superrito.com',11,'Paciente'),(25,'66236788','Numa','Fonseca Bravo','NumaFonsecaBravo@gustr.com',6,'Paciente'),(26,'43178408','Anelisa','Arriaga Elizondo','AnelisaArriagaElizondo@gustr.com',17,'Paciente'),(27,'24478879','Eladio','Saenz Colón','EladioSaenzColon@gustr.com',14,'Paciente'),(28,'9664691','Natalí','Espinal Peralta','NataliEspinalPeralta@gustr.com',16,'Paciente'),(29,'59958123','Giuseppe','Cardona Prado','GiuseppeCardonaPrado@superrito.com',2,'Paciente'),(31,'94095241','Raymond','Pagan Venegas','RaymondPaganVenegas@gustr.com',8,'Funcionario'),(32,'68288896','Lorna','Galindo Velázquez','LornaGalindoVelazquez@superrito.com',1,'Funcionario'),(33,'88526789','Jalil','Oquendo Bravo','JalilOquendoBravo@superrito.com',2,'Funcionario'),(34,'45574311','Huapi','Betancourt Solís','HuapiBetancourtSolis@gustr.com',5,'Funcionario'),(35,'73207051','Alison','Bravo Montez','alisonBravoMontez@superrito.com',15,'Funcionario'),(36,'27030892','Alide','Valenzuela Lara','AlideValenzuelaLara@gustr.com',9,'Funcionario'),(37,'8826452','Gisberto','Ojeda Flórez','GisbertoOjedaFlorez@gustr.com',18,'Funcionario'),(38,'94039960','Petrona','Pena Rael','PetronaPenaRael@gustr.com',18,'Funcionario'),(39,'66089913','Ramses','Reséndez Valentín','RamsesResendezValentin@superrito.com',7,'Funcionario'),(40,'81382542','Emily','Navarrete Frías','EmilyNavarreteFrias@gustr.com',4,'Funcionario'),(41,'97307655','Eros','Ojeda Olivas','ErosOjedaOlivas@superrito.com',12,'Funcionario'),(42,'74781115','Gianluca','Medina Aguirre','GianlucaMedinaAguirre@gustr.com',3,'Funcionario'),(43,'340917','Numa ','Cazares Samaniego','NumaCazaresSamaniego@gustr.com',1,'Funcionario'),(44,'61428500','Melín ','Cortés Chacón','MelinCortesChacon@superrito.com',1,'Funcionario'),(45,'86690576','Fermina','Figueroa Medina','FerminaFigueroaMedina@superrito.com',2,'Funcionario'),(46,'23199399','Ebony','Magana Alba','EbonyMaganaAlba@gustr.com',2,'Funcionario'),(47,'12804682','Cirenia','Tijerina Alcaraz','CireniaTijerinaAlcaraz@gustr.com',2,'Funcionario'),(48,'88977930','Vella','Sanches Munguia','VellaSanchesMunguia@superrito.com',4,'Funcionario'),(49,'31889114','Kevin','Jaramillo Abreu','KevinJaramilloAbreu@superrito.com',1,'Funcionario'),(50,'87255793','Mirtha ','Valladares Ornelas','MirthaValladaresOrnelas@gustr.com',14,'Funcionario'),(51,'71234658','Zilla','Villagómez Ledesma','ZillaVillagomezLedesma@gustr.com',14,'Funcionario'),(52,'96565288','Generosa','Ruelas Baez','GenerosaRuelasBaez@superrito.com',17,'Funcionario'),(53,'64540888','Ezra','Alemán Acevedo','EzraAlemanAcevedo@gustr.com',4,'Funcionario'),(54,'38311817','Morgana','Valverde Badillo','MorganaValverdeBadillo@gustr.com',18,'Funcionario'),(55,'33555563','Kemberley','Saucedo Pulido','KemberleySaucedoPulido@gustr.com',2,'Funcionario'),(56,'59483978','Nicasio','Padrón Guajardo','NicasioPadronGuajardo@superrito.com',17,'Funcionario'),(57,'77466075','Aluhe','Colunga Rascón','AluheColungaRascon@superrito.com',10,'Funcionario'),(58,'14782575','Otelo','Cotto Ozuna','OteloCottoOzuna@gustr.com',10,'Funcionario'),(59,'68427826','Flaminia','Arce Ayala','FlaminiaArceAyala@gustr.com',16,'Funcionario'),(60,'46273942','Troya','Galván Corona','TroyaGalvanCorona@gustr.com',15,'Funcionario'),(61,'72888533','Romano','Valentín Quintero','RomanoValentinQuintero@superrito.com',7,'Funcionario'),(62,'36684739','Calixto','Gaona Solano','CalixtoGaonaSolano@gustr.com',12,'Funcionario'),(63,'3203786','Armanda','Rascón Arteaga','ArmandaRasconArteaga@gustr.com',10,'Funcionario');
/*!40000 ALTER TABLE `personas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sintomas`
--

DROP TABLE IF EXISTS `sintomas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sintomas` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(100) NOT NULL,
  `DESCRIPCION` varchar(1000) DEFAULT NULL,
  `RECOMENDACIONES` varchar(1000) DEFAULT NULL,
  `URGENCIA` int(11) NOT NULL,
  `HABILITADO` tinyint(4) NOT NULL DEFAULT 1,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `NOMBRE` (`NOMBRE`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sintomas`
--

LOCK TABLES `sintomas` WRITE;
/*!40000 ALTER TABLE `sintomas` DISABLE KEYS */;
INSERT INTO `sintomas` VALUES (1,'Tos seria','Inflamación de las vías respiratorias altas','Beber líquidos calientes puede ayudar a disminuir la irritación',30,1),(5,'Fiebre','Aumento de temperatura corporal y baja defensas','Abrigarse y tomar fioidigrip',50,1),(6,'Dolor estomacal','Dolor en la zona del estomago o abdomnial','Vaya al baño y evite comer comida que sea perjudicial para la salud',20,1),(13,'Entumecimiento','El entumecimiento describe la perdida de sensibilidad en una parte del cuerpo','Sumergir las manos en agua fría hasta que se pase la sensación de hormigueo',20,1),(14,'Hipoxemia','nivel de oxígeno en sangre inferior al normal, específicamente en las arterias.','terapia con oxígeno será necesaria',60,1),(15,'Mareos','Aturdimiento, como si estuvieras por perder el conocimiento. Inseguridad, o pérdida del equilibrio. Sensación falsa de que tú o tus alrededores giran o se mueven (vértigo).','Esperar unos dias y consultar al medico',30,1),(16,'Tos con sangre','Tos con sangre','Llama al 911 o busca atención de emergencia si toses con sangre en grandes cantidades o a intervalos frecuentes.',90,1),(17,'Ojos llorosos','lágrimas de forma continua y excesiva.','los ojos llorosos pueden curarse por sí solos. Ciertas medidas de cuidado personal en el hogar pueden ayudar a tratar los ojos llorosos, particularmente si la causa es una inflamación o sequedad de los ojos.',20,1),(18,'Gas intestinal','cantidad excesiva de gases intestinales.','evitar ingerir mucha fibra o bebidas con gas.',20,1),(19,'Sangrado rectal','sangrado de la última porción del colon o recto.','si el sangrado es muy intenso recurrir a medico.',20,1),(21,'Vómitos con sangre','Vómitos con sangre','Llama al 911 o a tu número local de emergencias si los vómitos con sangre causan mareos al ponerte de pie, respiración rápida y superficial u otras señales de choque.',60,1),(22,'Hinchazón de pierna','puede deberse a la retención de líquido o a la inflamación de tejidos o articulaciones que tienen una lesión o una enfermedad.','Busca atención médica de inmediato si la hinchazón de piernas se produce sin causa aparente o si además tienes problemas para respirar, dolor en el pecho u otra señal de alerta de un coágulo de sangre en los pulmones o una enfermedad grave del corazón.',60,1);
/*!40000 ALTER TABLE `sintomas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sistema_diagnostica`
--

DROP TABLE IF EXISTS `sistema_diagnostica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sistema_diagnostica` (
  `ID_DIAGNOSTICO_PRIMARIO` int(11) NOT NULL,
  `ID_ENFERMEDAD` int(11) NOT NULL,
  `PROBABILIDAD` double NOT NULL,
  PRIMARY KEY (`ID_DIAGNOSTICO_PRIMARIO`,`ID_ENFERMEDAD`),
  KEY `ID_ENFERMEDAD` (`ID_ENFERMEDAD`),
  CONSTRAINT `sistema_diagnostica_ibfk_1` FOREIGN KEY (`ID_DIAGNOSTICO_PRIMARIO`) REFERENCES `diagnosticos_primarios` (`ID`) ON DELETE CASCADE,
  CONSTRAINT `sistema_diagnostica_ibfk_2` FOREIGN KEY (`ID_ENFERMEDAD`) REFERENCES `enfermedades` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sistema_evalua`
--

DROP TABLE IF EXISTS `sistema_evalua`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sistema_evalua` (
  `ID_DIAGNOSTICO_PRIMARIO` int(11) NOT NULL,
  `ID_SINTOMA` int(11) NOT NULL,
  PRIMARY KEY (`ID_DIAGNOSTICO_PRIMARIO`,`ID_SINTOMA`),
  KEY `ID_SINTOMA` (`ID_SINTOMA`),
  CONSTRAINT `sistema_evalua_ibfk_1` FOREIGN KEY (`ID_DIAGNOSTICO_PRIMARIO`) REFERENCES `diagnosticos_primarios` (`ID`),
  CONSTRAINT `sistema_evalua_ibfk_2` FOREIGN KEY (`ID_SINTOMA`) REFERENCES `sintomas` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuarios` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CONTRASENIA` varchar(1000) NOT NULL,
  `TIPO` enum('Paciente','Medico','Administrativo') NOT NULL,
  `ID_PERSONA` int(11) NOT NULL,
  `HABILITADO` tinyint(4) NOT NULL DEFAULT 1,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_PERSONA` (`ID_PERSONA`),
  CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`ID_PERSONA`) REFERENCES `personas` (`ID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-10-06 19:47:57
