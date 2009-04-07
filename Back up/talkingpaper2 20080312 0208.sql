-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.0.45-community-nt


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema talkingpaper2
--

CREATE DATABASE IF NOT EXISTS talkingpaper2;
USE talkingpaper2;

--
-- Definition of table `altra_contenuto`
--

DROP TABLE IF EXISTS `altra_contenuto`;
CREATE TABLE `altra_contenuto` (
  `IDaltra` int(10) unsigned NOT NULL,
  `IDcontenuto` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`IDcontenuto`,`IDaltra`),
  KEY `FK_altra_contenuto_1` (`IDaltra`),
  CONSTRAINT `FK_altra_contenuto_1` FOREIGN KEY (`IDaltra`) REFERENCES `altrarisorsa` (`IDaltra`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_altra_contenuto_2` FOREIGN KEY (`IDcontenuto`) REFERENCES `contenuto` (`IDcontenuto`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `altra_contenuto`
--

/*!40000 ALTER TABLE `altra_contenuto` DISABLE KEYS */;
/*!40000 ALTER TABLE `altra_contenuto` ENABLE KEYS */;


--
-- Definition of table `altrarisorsa`
--

DROP TABLE IF EXISTS `altrarisorsa`;
CREATE TABLE `altrarisorsa` (
  `IDaltra` int(10) unsigned NOT NULL auto_increment,
  `Nome` text NOT NULL,
  `Path` text NOT NULL,
  `Tipo` varchar(45) NOT NULL,
  PRIMARY KEY  (`IDaltra`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `altrarisorsa`
--

/*!40000 ALTER TABLE `altrarisorsa` DISABLE KEYS */;
/*!40000 ALTER TABLE `altrarisorsa` ENABLE KEYS */;


--
-- Definition of table `contenuto`
--

DROP TABLE IF EXISTS `contenuto`;
CREATE TABLE `contenuto` (
  `IDcontenuto` int(10) unsigned NOT NULL auto_increment,
  `Livello` tinyint(3) unsigned NOT NULL default '0' COMMENT 'Se zero è principale, 1 è approfondimento',
  `Ordine` tinyint(3) unsigned NOT NULL default '0' COMMENT 'L''ordine con cui devono essere eseguiti i contenuti',
  `Tipo` int(10) unsigned default NULL,
  `RisorsaMultimediale` int(10) unsigned default NULL,
  `Poster` int(10) unsigned default NULL,
  `Barcode` varchar(45) default NULL,
  `Rfidtag` varchar(45) default NULL,
  `Nome` text NOT NULL COMMENT 'Il nome del contenuto',
  PRIMARY KEY  (`IDcontenuto`),
  KEY `FK_contenuto_Tipologia` (`Tipo`),
  KEY `FK_contenuto_Poster` (`Poster`),
  KEY `FK_contenuto_Risorsa` (`RisorsaMultimediale`),
  CONSTRAINT `FK_contenuto_Poster` FOREIGN KEY (`Poster`) REFERENCES `poster` (`IDposter`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_contenuto_Risorsa` FOREIGN KEY (`RisorsaMultimediale`) REFERENCES `risorsamultimediale` (`IDrisorsa`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_contenuto_Tipologia` FOREIGN KEY (`Tipo`) REFERENCES `tipologia` (`IDtipologia`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=1388 DEFAULT CHARSET=latin1 COMMENT='Contenuti del poster';

--
-- Dumping data for table `contenuto`
--

/*!40000 ALTER TABLE `contenuto` DISABLE KEYS */;
/*!40000 ALTER TABLE `contenuto` ENABLE KEYS */;


--
-- Definition of table `mostra`
--

DROP TABLE IF EXISTS `mostra`;
CREATE TABLE `mostra` (
  `IDmostra` int(10) unsigned NOT NULL auto_increment COMMENT 'Chiave della tabella',
  `Nome` varchar(45) NOT NULL default '' COMMENT 'Nome della mostra',
  `Autore` varchar(45) NOT NULL default '' COMMENT 'Gli autori della mostra',
  `Credits` varchar(45) default NULL COMMENT 'Credits della mostra',
  `DataInizio` datetime default NULL,
  PRIMARY KEY  (`IDmostra`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Mostra';

--
-- Dumping data for table `mostra`
--

/*!40000 ALTER TABLE `mostra` DISABLE KEYS */;
/*!40000 ALTER TABLE `mostra` ENABLE KEYS */;


--
-- Definition of table `poster`
--

DROP TABLE IF EXISTS `poster`;
CREATE TABLE `poster` (
  `IDposter` int(10) unsigned NOT NULL auto_increment,
  `Descrizione` text,
  `Ordine` tinyint(3) unsigned NOT NULL default '0',
  `Mostra` int(10) unsigned default NULL COMMENT 'FK all''omonima tabella',
  `Nome` varchar(45) NOT NULL default '',
  PRIMARY KEY  (`IDposter`),
  KEY `FK_poster_Mostra` (`Mostra`),
  CONSTRAINT `FK_poster_Mostra` FOREIGN KEY (`Mostra`) REFERENCES `mostra` (`IDmostra`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=317 DEFAULT CHARSET=latin1 COMMENT='Poster di una mostra';

--
-- Dumping data for table `poster`
--

/*!40000 ALTER TABLE `poster` DISABLE KEYS */;
/*!40000 ALTER TABLE `poster` ENABLE KEYS */;


--
-- Definition of table `profilo`
--

DROP TABLE IF EXISTS `profilo`;
CREATE TABLE `profilo` (
  `IDprofilo` int(10) unsigned NOT NULL auto_increment,
  `Descrizione` text NOT NULL,
  `Nome` varchar(45) NOT NULL default '',
  PRIMARY KEY  (`IDprofilo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Profilo degli utenti legati alla mostra';

--
-- Dumping data for table `profilo`
--

/*!40000 ALTER TABLE `profilo` DISABLE KEYS */;
/*!40000 ALTER TABLE `profilo` ENABLE KEYS */;


--
-- Definition of table `risorsa_profilo`
--

DROP TABLE IF EXISTS `risorsa_profilo`;
CREATE TABLE `risorsa_profilo` (
  `ID_risorsa` int(10) unsigned NOT NULL default '0',
  `ID_profilo` int(10) unsigned NOT NULL default '0',
  PRIMARY KEY  (`ID_risorsa`,`ID_profilo`),
  KEY `FK_risorsa_profilo_Profilo` (`ID_profilo`),
  CONSTRAINT `FK_risorsa_profilo_Profilo` FOREIGN KEY (`ID_profilo`) REFERENCES `profilo` (`IDprofilo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_risorsa_profilo_Risorse` FOREIGN KEY (`ID_risorsa`) REFERENCES `risorsamultimediale` (`IDrisorsa`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC COMMENT='Tabella N:M tra risorsamultimediale e profilo; InnoDB free: ';

--
-- Dumping data for table `risorsa_profilo`
--

/*!40000 ALTER TABLE `risorsa_profilo` DISABLE KEYS */;
/*!40000 ALTER TABLE `risorsa_profilo` ENABLE KEYS */;


--
-- Definition of table `risorsamultimediale`
--

DROP TABLE IF EXISTS `risorsamultimediale`;
CREATE TABLE `risorsamultimediale` (
  `IDrisorsa` int(10) unsigned NOT NULL auto_increment,
  `Nome` text NOT NULL,
  `Path` text NOT NULL,
  `Estensione` varchar(6) NOT NULL default '',
  `Dimensione` int(10) unsigned default NULL,
  PRIMARY KEY  (`IDrisorsa`)
) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=latin1 COMMENT='Risorsa multimediale legata al contenuto';

--
-- Dumping data for table `risorsamultimediale`
--

/*!40000 ALTER TABLE `risorsamultimediale` DISABLE KEYS */;
/*!40000 ALTER TABLE `risorsamultimediale` ENABLE KEYS */;


--
-- Definition of table `tipologia`
--

DROP TABLE IF EXISTS `tipologia`;
CREATE TABLE `tipologia` (
  `IDtipologia` int(10) unsigned NOT NULL auto_increment,
  `Descrizione` text NOT NULL,
  `Tipo` varchar(45) NOT NULL default '',
  PRIMARY KEY  (`IDtipologia`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 COMMENT='Tipologia dei contenuti';

--
-- Dumping data for table `tipologia`
--

/*!40000 ALTER TABLE `tipologia` DISABLE KEYS */;
INSERT INTO `tipologia` (`IDtipologia`,`Descrizione`,`Tipo`) VALUES 
 (1,'Musica','Risorsa'),
 (2,'Play','Controllo'),
 (3,'Pausa','Controllo'),
 (4,'Stop','Controllo'),
 (5,'Video','Risorsa'),
 (6,'Altro','Risorsa');
/*!40000 ALTER TABLE `tipologia` ENABLE KEYS */;


--
-- Definition of table `utente`
--

DROP TABLE IF EXISTS `utente`;
CREATE TABLE `utente` (
  `IDutente` int(10) unsigned NOT NULL auto_increment,
  `Nome` varchar(45) NOT NULL default '',
  `Cognome` varchar(45) NOT NULL default '',
  `Classe` varchar(5) default NULL,
  `AnnoNascita` datetime default '0000-00-00 00:00:00',
  `Profilo` int(10) unsigned default NULL,
  `Rfidtag` varchar(45) default NULL,
  `Barcode` varchar(45) default NULL,
  PRIMARY KEY  (`IDutente`),
  KEY `FK_utente_Profilo` (`Profilo`),
  CONSTRAINT `FK_utente_Profilo` FOREIGN KEY (`Profilo`) REFERENCES `profilo` (`IDprofilo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Utenti del sistema';

--
-- Dumping data for table `utente`
--

/*!40000 ALTER TABLE `utente` DISABLE KEYS */;
/*!40000 ALTER TABLE `utente` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
