-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jun 14, 2020 at 01:12 PM
-- Server version: 5.7.26
-- PHP Version: 7.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `asgn`
--

-- --------------------------------------------------------

--
-- Table structure for table `page`
--

DROP TABLE IF EXISTS `page`;
CREATE TABLE IF NOT EXISTS `page` (
  `P_id` int(11) NOT NULL AUTO_INCREMENT,
  `Page_Name` varchar(32) NOT NULL,
  `U_id` int(11) NOT NULL,
  PRIMARY KEY (`P_id`),
  UNIQUE KEY `Page_Name` (`Page_Name`),
  KEY `fk_page` (`U_id`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `page`
--

INSERT INTO `page` (`P_id`, `Page_Name`, `U_id`) VALUES
(1, 'Smith', 1),
(2, 'harry', 1),
(3, 'hell', 1),
(4, 'hell2', 1),
(5, 'sam', 1),
(6, 'mnx', 1),
(7, 'hgy', 2),
(8, 'huff', 2),
(9, 'ppx', 2),
(10, 'ssm', 2);

-- --------------------------------------------------------

--
-- Table structure for table `page_access`
--

DROP TABLE IF EXISTS `page_access`;
CREATE TABLE IF NOT EXISTS `page_access` (
  `P_id` int(11) NOT NULL,
  `U_id` int(11) NOT NULL,
  `Status` varchar(9) NOT NULL DEFAULT 'INACTIVE',
  PRIMARY KEY (`P_id`,`U_id`),
  KEY `fk_uid` (`U_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `page_access`
--

INSERT INTO `page_access` (`P_id`, `U_id`, `Status`) VALUES
(1, 1, 'ACTIVE'),
(2, 1, 'ACTIVE'),
(3, 1, 'ACTIVE'),
(4, 1, 'ACTIVE'),
(5, 1, 'ACTIVE'),
(6, 1, 'ACTIVE'),
(7, 2, 'ACTIVE'),
(8, 2, 'ACTIVE'),
(9, 2, 'ACTIVE'),
(10, 2, 'ACTIVE');

-- --------------------------------------------------------

--
-- Table structure for table `page_history`
--

DROP TABLE IF EXISTS `page_history`;
CREATE TABLE IF NOT EXISTS `page_history` (
  `P_id` int(11) NOT NULL,
  `U_id` int(11) NOT NULL,
  `Last_visit` varchar(50) NOT NULL,
  PRIMARY KEY (`P_id`,`U_id`,`Last_visit`),
  KEY `fk_huid` (`U_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `page_history`
--

INSERT INTO `page_history` (`P_id`, `U_id`, `Last_visit`) VALUES
(8, 2, '6/14/2020 6:32:45 PM'),
(8, 2, '6/14/2020 6:33:04 PM'),
(8, 2, '6/14/2020 6:33:27 PM'),
(8, 2, '6/14/2020 6:33:47 PM'),
(8, 2, '6/14/2020 6:37:07 PM'),
(8, 2, '6/14/2020 6:37:17 PM'),
(8, 2, '6/14/2020 6:37:19 PM'),
(8, 2, '6/14/2020 6:37:24 PM'),
(9, 2, '6/14/2020 6:39:57 PM'),
(9, 2, '6/14/2020 6:40:00 PM'),
(9, 2, '6/14/2020 6:40:03 PM'),
(9, 2, '6/14/2020 6:40:05 PM'),
(10, 2, '6/14/2020 6:40:17 PM'),
(10, 2, '6/14/2020 6:40:20 PM'),
(10, 2, '6/14/2020 6:40:24 PM');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `U_id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(70) NOT NULL,
  `Email` varchar(320) NOT NULL,
  `Password` varchar(128) NOT NULL,
  `Pic` varchar(120) NOT NULL,
  PRIMARY KEY (`U_id`),
  UNIQUE KEY `Email` (`Email`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`U_id`, `Name`, `Email`, `Password`, `Pic`) VALUES
(2, 'Shristi Shikha', 'shristi.shikha@gmail.com', 'shristi1996', '~/Upload/Screenshot (49).png');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
