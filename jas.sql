-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 02, 2022 at 02:39 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `jas`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id`, `username`, `password`, `email`) VALUES
(1, 'admin', 'admin', 'admin@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `applications`
--

CREATE TABLE `applications` (
  `Id` int(11) NOT NULL,
  `Job_Id` int(11) NOT NULL,
  `User` varchar(200) NOT NULL,
  `Status` varchar(200) NOT NULL,
  `Phone` varchar(200) NOT NULL,
  `Email` varchar(200) NOT NULL,
  `Created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `applications`
--

INSERT INTO `applications` (`Id`, `Job_Id`, `User`, `Status`, `Phone`, `Email`, `Created_at`) VALUES
(7, 7, 'test', 'Shortlisted', '90909', 'test@gmail.com', '2022-07-01 13:12:42');

-- --------------------------------------------------------

--
-- Table structure for table `employer`
--

CREATE TABLE `employer` (
  `id` int(11) NOT NULL,
  `username` varchar(200) NOT NULL,
  `password` varchar(200) NOT NULL,
  `fname` varchar(200) NOT NULL,
  `mname` varchar(200) NOT NULL,
  `lname` varchar(200) NOT NULL,
  `dob` varchar(200) NOT NULL,
  `phone` varchar(200) NOT NULL,
  `email` varchar(200) NOT NULL,
  `companyname` varchar(200) NOT NULL,
  `position` varchar(200) NOT NULL,
  `datehired` varchar(200) NOT NULL,
  `address_primary` varchar(200) NOT NULL,
  `address_secondary` varchar(200) NOT NULL,
  `city` varchar(200) NOT NULL,
  `province` varchar(200) NOT NULL,
  `postal` varchar(200) NOT NULL,
  `company_id` varchar(200) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `employer`
--

INSERT INTO `employer` (`id`, `username`, `password`, `fname`, `mname`, `lname`, `dob`, `phone`, `email`, `companyname`, `position`, `datehired`, `address_primary`, `address_secondary`, `city`, `province`, `postal`, `company_id`, `created_at`) VALUES
(1, 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'test@gmail.com', 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'test', 'test', '2022-06-30 14:26:48');

-- --------------------------------------------------------

--
-- Table structure for table `job`
--

CREATE TABLE `job` (
  `ID` int(11) NOT NULL,
  `Job_Category` varchar(100) NOT NULL,
  `Job_Type` varchar(100) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `Location` varchar(100) NOT NULL,
  `Salary` varchar(100) NOT NULL,
  `Description` varchar(100) NOT NULL,
  `Start_Date` varchar(100) NOT NULL,
  `Company_Name` varchar(100) DEFAULT NULL,
  `Employer` varchar(100) DEFAULT NULL,
  `Created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `Status` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `job`
--

INSERT INTO `job` (`ID`, `Job_Category`, `Job_Type`, `Title`, `Location`, `Salary`, `Description`, `Start_Date`, `Company_Name`, `Employer`, `Created_at`, `Status`) VALUES
(4, 'Project-Based', 'Aircraft Mechanic', 'title', 'location', 'dasdas', 'dasdasd', '6/30/2022', 'company', NULL, '2022-06-30 11:38:06', ''),
(7, 'Seasonal', 'Airline Pilot', 'asdasdasd', 'asdasd', 'asdasd', 'asdasdasd', '7/1/2022', 'Accenture', 'test', '2022-07-01 06:20:56', ''),
(8, 'Seasonal', 'Aircraft Mechanic', 'asdasd', 'asdasdas', 'dasdasd', 'asdasdas', '7/1/2022', 'sdasd', 'test', '2022-07-01 08:23:27', 'Open');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `fname` varchar(100) NOT NULL,
  `mname` varchar(100) NOT NULL,
  `lname` varchar(100) NOT NULL,
  `dob` varchar(100) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `email` varchar(100) NOT NULL,
  `street` varchar(100) NOT NULL,
  `city` varchar(100) NOT NULL,
  `province` varchar(100) NOT NULL,
  `postal` varchar(100) NOT NULL,
  `education` varchar(200) NOT NULL,
  `experience` varchar(200) NOT NULL,
  `last_employer` varchar(200) NOT NULL,
  `resume` varchar(300) NOT NULL,
  `valid_id` varchar(300) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `fname`, `mname`, `lname`, `dob`, `phone`, `email`, `street`, `city`, `province`, `postal`, `education`, `experience`, `last_employer`, `resume`, `valid_id`, `created_at`) VALUES
(19, 'test', 'test', 'fna', 'mna', 'lna', '6/28/2022', '0', 'test@gmail.com', 'st', 'ct', 'pr', 'po', 'ed', 'ex', 'la', 're', 'va', '2022-06-28 17:36:04'),
(20, 'asd', 'asd', 'asd', 'asd', 'asd', '6/28/2022', '0', 'asd', 'asd', 'asd', 'asd', 'asd', 'asd', 'asd', 'asd', 'jas_logo (1).ico', '', '2022-06-28 17:44:58'),
(24, 'user', 'pass', 'fname', 'mname', 'lname', '6/28/2022', '0', 'email', 'street', 'city', 'pro', 'pos', 'edu', 'expi', 'employ', '1.jpg', 'bg.jpg', '2022-06-28 17:50:52'),
(28, 'ss', 'ss', 'ss', 'ss', 'ss', '6/29/2022', 'ss', 'ss', 'ss', 'ss', 'ss', 'ss', 'ss', 'ss', 'ss', 'sample.pdf', 'sample.pdf', '2022-06-29 17:17:58'),
(30, 'testt', 'testt', 'testt', 'testt', 'testt', '6/29/2022', 'testt', 'testt', 'testt', 'testt', 'testt', 'testt', 'testt', 'testt', 'testt', 'sample.docx', '', '2022-06-29 17:29:59');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `applications`
--
ALTER TABLE `applications`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `employer`
--
ALTER TABLE `employer`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `job`
--
ALTER TABLE `job`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `applications`
--
ALTER TABLE `applications`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `employer`
--
ALTER TABLE `employer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `job`
--
ALTER TABLE `job`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
