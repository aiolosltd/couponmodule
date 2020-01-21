-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 21, 2020 at 05:44 AM
-- Server version: 10.4.8-MariaDB
-- PHP Version: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `fbwcoupon`
--
CREATE DATABASE IF NOT EXISTS `fbwcoupon` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `fbwcoupon`;

-- --------------------------------------------------------

--
-- Table structure for table `tbcoupon`
--

DROP TABLE IF EXISTS `tbcoupon`;
CREATE TABLE `tbcoupon` (
  `ID` int(11) NOT NULL,
  `Couponname_` text NOT NULL,
  `Desc_` text NOT NULL,
  `Discountvalue_` text NOT NULL,
  `Referencevalue_` text NOT NULL,
  `Type` text NOT NULL,
  `Bundlebase_` text NOT NULL,
  `BBValue_` text NOT NULL,
  `Bundlepromo_` text NOT NULL,
  `BPValue_` text NOT NULL,
  `Effectivedate` text NOT NULL,
  `Expirydate` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbcoupon`
--

INSERT INTO `tbcoupon` (`ID`, `Couponname_`, `Desc_`, `Discountvalue_`, `Referencevalue_`, `Type`, `Bundlebase_`, `BBValue_`, `Bundlepromo_`, `BPValue_`, `Effectivedate`, `Expirydate`) VALUES
(1, 'Senior/PWD Discount 20%', 'Senior/PWD Discount 20% - Standard National Discount', '20', '', 'Percentage', '', '', '', '', '01/01/2020', '31/12/9998'),
(2, '100 OFF GC - Chinese New Year', '100 OFF Gift Certificate for the celebration of Chinese New Year', '100', '', 'Fix-1', '', '', '', '', '25/01/2020', '31/01/2020'),
(3, '50 OFF on your next waffle', '50 OFF on your next waffle if you buy with minimum amount of 500', '50', '500', 'Fix-2', '', '', '', '', '01/01/2020', '31/01/2020'),
(4, 'Free Choco Waffle', 'Free Choco Waffle if you buy Peanut Butter waffle', '', '', 'Bundle-1(Fix)', '2', '1', '1', '1', '01/01/2020', '31/12/2020'),
(5, '10 OFF ON DRINKS', 'P10 OFF on Drinks if you buy 2 choco waffles\r\n', '10', '', 'Bundle-2(Fix)', '1', '2', '5,6,7,8', '1', '01/01/2020', '31/12/2020'),
(6, '10% OFF ON YOUR 3RD WAFFLE', '10% OFF for the 3rd Waffle if you buy 2 Perfect Combination Waffle', '10', '', 'Bundle-3(%)', '4', '2', '1,2,3,4', '1', '01/01/2020', '31/12/2020');

-- --------------------------------------------------------

--
-- Table structure for table `tbproduct`
--

DROP TABLE IF EXISTS `tbproduct`;
CREATE TABLE `tbproduct` (
  `ProductID_` int(11) NOT NULL,
  `Productname_` text NOT NULL,
  `Category_` text NOT NULL,
  `Price_` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbproduct`
--

INSERT INTO `tbproduct` (`ProductID_`, `Productname_`, `Category_`, `Price_`) VALUES
(1, 'Chocolate Waffle', 'Simply Perfect', '45'),
(2, 'Peanut Butter Waffle', 'Simply Perfect', '45'),
(3, 'Custard Waffle', 'Simply Perfect', '45'),
(4, 'Blueberry Creamcheese Waffle', 'Simply Perfect', '65'),
(5, 'Iced Choco', 'Drinks', '55'),
(6, 'Hot Choco', 'Drinks', '45'),
(7, 'Iced  Coffee', 'Drinks', '55'),
(8, 'Hot Coffee', 'Drinks', '45');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbcoupon`
--
ALTER TABLE `tbcoupon`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `tbproduct`
--
ALTER TABLE `tbproduct`
  ADD PRIMARY KEY (`ProductID_`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbcoupon`
--
ALTER TABLE `tbcoupon`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `tbproduct`
--
ALTER TABLE `tbproduct`
  MODIFY `ProductID_` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
