-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 15, 2024 at 02:18 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cs311c2024`
--

-- --------------------------------------------------------

--
-- Table structure for table `tblaccounts`
--

CREATE TABLE `tblaccounts` (
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `usertype` varchar(50) NOT NULL,
  `status` varchar(20) NOT NULL,
  `createdby` varchar(50) NOT NULL,
  `datecreated` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `tblaccounts`
--

INSERT INTO `tblaccounts` (`username`, `password`, `usertype`, `status`, `createdby`, `datecreated`) VALUES
('adadada', 'daddada', 'ADMINISTRATOR', 'ACTIVE', 'admin', '05/11/2024'),
('admin', '1234', 'ADMINISTRATOR', 'ACTIVE', 'admin', '04/09/2024'),
('branchadmin', '1234', 'BRANCH ADMINISTRATOR', 'ACTIVE', 'admin', '04/09/2024'),
('staff', '1234', 'STAFF', 'ACTIVE', 'admin', '04/09/2024');

-- --------------------------------------------------------

--
-- Table structure for table `tblcases`
--

CREATE TABLE `tblcases` (
  `caseID` varchar(50) NOT NULL,
  `studentID` varchar(50) NOT NULL,
  `vcode` varchar(50) NOT NULL,
  `status` varchar(20) NOT NULL,
  `vcount` varchar(40) NOT NULL,
  `action` varchar(50) DEFAULT NULL,
  `schoolyear` varchar(30) NOT NULL,
  `concernlevel` varchar(50) NOT NULL,
  `disiplinaryaction` varchar(50) NOT NULL,
  `createdby` varchar(50) NOT NULL,
  `datecreated` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `tblcases`
--

INSERT INTO `tblcases` (`caseID`, `studentID`, `vcode`, `status`, `vcount`, `action`, `schoolyear`, `concernlevel`, `disiplinaryaction`, `createdby`, `datecreated`) VALUES
('case-2024-11-11-18-01-58', '123', 'walang', 'RESOLVED', 'FIRST OFFENSE', 'YATA', '2023-2024', 'Council of Discipline', 'ok na ba?', 'admin', '2024-11-11'),
('case-2024-11-11-18-17-08', '123', 'test', 'ONGOING', 'FIRST OFFENSE', NULL, '2024-2025', 'Prespect of Discipline', '213', 'admin', '2024-11-11'),
('case-2024-11-15-21-06-44', '123', 'test', 'RESOLVED', 'SECOND OFFENSE', 'LKL', '2024', 'Prespect of Discipline', 'awit', 'admin', '2024-11-15');

-- --------------------------------------------------------

--
-- Table structure for table `tblcourses`
--

CREATE TABLE `tblcourses` (
  `coursecode` varchar(50) NOT NULL,
  `description` varchar(50) NOT NULL,
  `datecreated` varchar(50) NOT NULL,
  `createdby` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `tblcourses`
--

INSERT INTO `tblcourses` (`coursecode`, `description`, `datecreated`, `createdby`) VALUES
('BSA', 'DASDASDAS', '08/10/2024', 'admin'),
('BSIS', 'BSISSSS', '09/10/2024', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `tbllogs`
--

CREATE TABLE `tbllogs` (
  `datelog` varchar(15) NOT NULL,
  `timelog` varchar(15) NOT NULL,
  `action` varchar(20) NOT NULL,
  `module` varchar(30) NOT NULL,
  `ID` varchar(50) NOT NULL,
  `performedby` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `tbllogs`
--

INSERT INTO `tbllogs` (`datelog`, `timelog`, `action`, `module`, `ID`, `performedby`) VALUES
('16/10/2024', '5:19 pm', 'Add', 'Violations Management', '0908', 'admin'),
('16/10/2024', '5:19 pm', 'Add', 'Violations Management', 'das', 'admin'),
('16/10/2024', '5:20 pm', 'Add', 'Violations Management', '12345', 'admin'),
('16/10/2024', '5:21 pm', 'Update', 'Violations Management', '12345', 'admin'),
('16/10/2024', '5:21 pm', 'Delete', 'Violations Management', '12345', 'admin'),
('16/10/2024', '5:35 pm', 'Add', 'Violations Management', '78974', 'admin'),
('16/10/2024', '5:35 pm', 'Update', 'Violations Management', '78974', 'admin'),
('16/10/2024', '5:36 pm', 'Delete', 'Violations Management', '78974', 'admin'),
('16/10/2024', '5:39 pm', 'Add', 'Violations Management', '12345', 'admin'),
('16/10/2024', '5:39 pm', 'Update', 'Violations Management', '12345', 'admin'),
('16/10/2024', '5:40 pm', 'Add', 'Violations Management', '321', 'admin'),
('16/10/2024', '5:40 pm', 'Update', 'Violations Management', '321', 'admin'),
('16/10/2024', '5:41 pm', 'Add', 'Violations Management', '222', 'admin'),
('16/10/2024', '5:41 pm', 'Update', 'Violations Management', '222', 'admin'),
('16/10/2024', '5:41 pm', 'Delete', 'Violations Management', '222', 'admin'),
('18/10/2024', '8:48 pm', 'Add', 'Students Management', '123', 'admin'),
('19/10/2024', '8:36 am', 'Add', 'Violations Management', '00', 'admin'),
('19/10/2024', '8:37 am', 'Delete', 'Violations Management', '321', 'admin'),
('19/10/2024', '8:37 am', 'Delete', 'Violations Management', '12345', 'admin'),
('19/10/2024', '8:37 am', 'Delete', 'Violations Management', '123', 'admin'),
('19/10/2024', '8:37 am', 'Add', 'Violations Management', 'test', 'admin'),
('19/10/2024', '8:37 am', 'Add', 'Violations Management', 'seryoso?', 'admin'),
('19/10/2024', '10:35 am', 'Add', 'Cases Management', '2024-10-19-10-35-45', 'admin'),
('19/10/2024', '10:39 am', 'Add', 'Cases Management', '2024-10-19-10-39-11', 'admin'),
('19/10/2024', '10:47 am', 'Add', 'Cases Management', '2024-10-19-10-47-52', 'admin'),
('19/10/2024', '10:52 am', 'Add', 'Cases Management', '2024-10-19-10-52-30', 'admin'),
('19/10/2024', '10:55 am', 'Add', 'Cases Management', '2024-10-19-10-55-04', 'admin'),
('19/10/2024', '11:02 am', 'Add', 'Cases Management', '2024-10-19-11-02-25', 'admin'),
('19/10/2024', '11:03 am', 'Add', 'Cases Management', '2024-10-19-11-02-59', 'admin'),
('2024-10-19', '11:11:23', 'Add', 'Cases Management', '2024-10-19-11-11-19', 'admin'),
('2024-10-19', '11:11:34', 'Add', 'Cases Management', '2024-10-19-11-11-29', 'admin'),
('2024-10-19', '11:14:17', 'Add', 'Cases Management', '2024-10-19-11-14-12', 'admin'),
('2024-10-19', '11:14:27', 'Add', 'Cases Management', '2024-10-19-11-14-22', 'admin'),
('2024-10-19', '11:17:04', 'Add', 'Cases Management', '2024-10-19-11-16-59', 'admin'),
('2024-10-19', '11:23:10', 'Add', 'Cases Management', '2024-10-19-11-23-02', 'admin'),
('2024-10-19', '11:23:29', 'Add', 'Cases Management', '2024-10-19-11-23-15', 'admin'),
('2024-10-19', '11:43:21', 'Add', 'Cases Management', '2024-10-19-11-43-16', 'admin'),
('2024-10-19', '11:43:38', 'Add', 'Cases Management', '2024-10-19-11-43-33', 'admin'),
('2024-10-19', '11:48:10', 'Add', 'Cases Management', '2024-10-19-11-48-04', 'admin'),
('2024-10-19', '11:51:49', 'Add', 'Cases Management', '2024-10-19-11-51-44', 'admin'),
('2024-10-19', '11:52:03', 'Add', 'Cases Management', '2024-10-19-11-51-54', 'admin'),
('2024-10-19', '13:40:17', 'Add', 'Cases Management', '2024-10-19-13-40-10', 'admin'),
('2024-10-19', '13:43:07', 'Add', 'Cases Management', '2024-10-19-13-43-00', 'admin'),
('2024-10-19', '13:48:08', 'Add', 'Cases Management', '2024-10-19-13-48-05', 'admin'),
('2024-10-19', '13:55:38', 'Add', 'Cases Management', '2024-10-19-13-55-33', 'admin'),
('2024-10-19', '14:13:51', 'Add', 'Cases Management', '2024-10-19-14-13-48', 'admin'),
('2024-10-19', '14:14:22', 'Add', 'Cases Management', '2024-10-19-14-14-19', 'admin'),
('2024-10-19', '14:14:29', 'Add', 'Cases Management', '2024-10-19-14-14-25', 'admin'),
('19/10/2024', '2:37 pm', 'Update', 'Case Management', 'admin', 'admin'),
('19/10/2024', '2:43 pm', 'Update', 'Case Management', '2024-10-19-14-13-48', 'admin'),
('19/10/2024', '2:43 pm', 'Update', 'Case Management', '2024-10-19-14-14-25', 'admin'),
('2024-10-19', '14:43:25', 'Add', 'Cases Management', '2024-10-19-14-43-20', 'admin'),
('19/10/2024', '2:43 pm', 'Update', 'Case Management', '2024-10-19-14-43-20', 'admin'),
('2024-10-19', '14:47:09', 'Add', 'Cases Management', 'case-2024-10-19-14-47-05', 'admin'),
('2024-10-19', '14:47:17', 'Add', 'Cases Management', 'case-2024-10-19-14-47-14', 'admin'),
('2024-10-19', '14:47:24', 'Add', 'Cases Management', 'case-2024-10-19-14-47-22', 'admin'),
('19/10/2024', '2:47 pm', 'Update', 'Case Management', 'case-2024-10-19-14-47-22', 'admin'),
('19/10/2024', '2:47 pm', 'Update', 'Case Management', 'case-2024-10-19-14-47-14', 'admin'),
('19/10/2024', '2:47 pm', 'Update', 'Case Management', 'case-2024-10-19-14-47-05', 'admin'),
('2024-10-19', '15:49:44', 'Add', 'Cases Management', 'case-2024-10-19-15-49-42', 'admin'),
('2024-10-19', '16:21:35', 'Add', 'Cases Management', 'case-2024-10-19-16-21-28', 'admin'),
('2024-10-19', '16:21:43', 'Add', 'Cases Management', 'case-2024-10-19-16-21-40', 'admin'),
('19/10/2024', '4:27 pm', 'Update', 'Case Management', 'case-2024-10-19-16-21-40', 'admin'),
('2024-10-19', '16:30:21', 'Add', 'Cases Management', 'case-2024-10-19-16-30-17', 'admin'),
('2024-10-19', '16:30:29', 'Add', 'Cases Management', 'case-2024-10-19-16-30-26', 'admin'),
('2024-10-19', '16:30:34', 'Add', 'Cases Management', 'case-2024-10-19-16-30-31', 'admin'),
('2024-10-19', '16:30:58', 'Add', 'Cases Management', 'case-2024-10-19-16-30-40', 'admin'),
('19/10/2024', '4:31 pm', 'Update', 'Case Management', 'case-2024-10-19-16-30-17', 'admin'),
('19/10/2024', '4:37 pm', 'Update', 'Case Management', 'case-2024-10-19-16-21-28', 'admin'),
('05/11/2024', '7:01 pm', 'Add', 'Accounts Management', 'staff1', 'admin'),
('05/11/2024', '7:02 pm', 'Update', 'Accounts Management', 'staff1', 'admin'),
('05/11/2024', '7:05 pm', 'Update', 'Accounts Management', 'staff1', 'admin'),
('05/11/2024', '7:05 pm', 'Update', 'Accounts Management', 'staff1', 'admin'),
('05/11/2024', '7:05 pm', 'Delete', 'Accounts Management', 'staff1', 'admin'),
('05/11/2024', '7:09 pm', 'Add', 'Accounts Management', 'test1', 'admin'),
('05/11/2024', '7:09 pm', 'Update', 'Accounts Management', 'test1', 'admin'),
('05/11/2024', '7:09 pm', 'Delete', 'Accounts Management', 'test1', 'admin'),
('05/11/2024', '7:17 pm', 'Add', 'Students Management', 'test', 'admin'),
('05/11/2024', '7:17 pm', 'Update', 'Students Management', 'test', 'admin'),
('05/11/2024', '7:17 pm', 'Delete', 'Students Management', 'test', 'admin'),
('05/11/2024', '7:22 pm', 'Add', 'Courses Management', 'test', 'admin'),
('05/11/2024', '7:22 pm', 'Update', 'Courses Management', 'test', 'admin'),
('05/11/2024', '7:22 pm', 'Delete', 'Courses Management', 'test', 'admin'),
('05/11/2024', '7:26 pm', 'Add', 'Strands Management', 'testu', 'admin'),
('05/11/2024', '7:26 pm', 'Update', 'Strands Management', 'testu', 'admin'),
('05/11/2024', '7:26 pm', 'Delete', 'Strands Management', 'testu', 'admin'),
('05/11/2024', '7:27 pm', 'Add', 'Strands Management', 'te', 'admin'),
('05/11/2024', '7:27 pm', 'Delete', 'Strands Management', 'te', 'admin'),
('2024-11-05', '19:31:22', 'Add', 'Cases Management', 'case-2024-11-05-19-31-15', 'admin'),
('2024-11-05', '19:35:35', 'Add', 'Cases Management', 'case-2024-11-05-19-35-29', 'admin'),
('05/11/2024', '7:36 pm', 'Update', 'Case Management', 'case-2024-11-05-19-31-15', 'admin'),
('05/11/2024', '7:37 pm', 'Update', 'Case Management', 'case-2024-11-05-19-31-15', 'admin'),
('05/11/2024', '7:39 pm', 'Update', 'Case Management', 'case-2024-11-05-19-35-29', 'admin'),
('05/11/2024', '7:45 pm', 'Update', 'Case Management', 'case-2024-11-05-19-35-29', 'admin'),
('05/11/2024', '7:45 pm', 'Update', 'Case Management', 'case-2024-11-05-19-35-29', 'admin'),
('05/11/2024', '7:45 pm', 'Update', 'Case Management', 'case-2024-11-05-19-35-29', 'admin'),
('05/11/2024', '7:50 pm', 'Add', 'Accounts Management', 'test1', 'admin'),
('05/11/2024', '7:51 pm', 'Delete', 'Accounts Management', 'test1', 'admin'),
('05/11/2024', '7:51 pm', 'Add', 'Accounts Management', 'fas', 'admin'),
('2024-11-05', '20:03:04', 'Add', 'Cases Management', 'case-2024-11-05-20-03-00', 'admin'),
('05/11/2024', '8:04 pm', 'Add', 'Accounts Management', 'zaza', 'admin'),
('05/11/2024', '8:05 pm', 'Delete', 'Accounts Management', 'test', 'admin'),
('05/11/2024', '8:05 pm', 'Delete', 'Accounts Management', 'brench', 'admin'),
('05/11/2024', '8:05 pm', 'Delete', 'Accounts Management', 'fas', 'admin'),
('05/11/2024', '8:05 pm', 'Delete', 'Accounts Management', 'zaza', 'admin'),
('05/11/2024', '8:05 pm', 'Add', 'Accounts Management', 'zaza', 'admin'),
('05/11/2024', '8:06 pm', 'Delete', 'Accounts Management', 'zaza', 'admin'),
('05/11/2024', '8:06 pm', 'Add', 'Accounts Management', 'adadada', 'admin'),
('2024-11-11', '18:02:10', 'Add', 'Cases Management', 'case-2024-11-11-18-01-58', 'admin'),
('2024-11-11', '18:17:19', 'Add', 'Cases Management', 'case-2024-11-11-18-17-08', 'admin'),
('11/11/2024', '6:27 pm', 'Update', 'Case Management', 'case-2024-11-11-18-01-58', 'admin'),
('11/11/2024', '6:32 pm', 'Update', 'Case Management', 'case-2024-11-11-18-01-58', 'admin'),
('11/11/2024', '6:34 pm', 'Update', 'Case Management', 'case-2024-11-11-18-01-58', 'admin'),
('2024-11-15', '21:07:03', 'Add', 'Cases Management', 'case-2024-11-15-21-06-44', 'admin'),
('15/11/2024', '9:07 pm', 'Update', 'Case Management', 'case-2024-11-15-21-06-44', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `tblstrands`
--

CREATE TABLE `tblstrands` (
  `strandcode` varchar(50) NOT NULL,
  `description` varchar(50) NOT NULL,
  `datecreated` varchar(50) NOT NULL,
  `createdby` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `tblstrands`
--

INSERT INTO `tblstrands` (`strandcode`, `description`, `datecreated`, `createdby`) VALUES
('ICT', 'INFORMATION', '09/10/2024', 'admin'),
('tvl', 'TECHINICAL', '09/10/2024', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `tblstudents`
--

CREATE TABLE `tblstudents` (
  `studentID` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) DEFAULT NULL,
  `level` varchar(20) NOT NULL,
  `strandcourse` varchar(50) DEFAULT NULL,
  `datecreated` varchar(50) NOT NULL,
  `createdby` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `tblstudents`
--

INSERT INTO `tblstudents` (`studentID`, `lastname`, `firstname`, `middlename`, `level`, `strandcourse`, `datecreated`, `createdby`) VALUES
('123', 'me', 'you', 'I', 'COLLEGE', 'BSIS', '18/10/2024', 'admin'),
('22', 'fasfas', 'col', 'ex', 'SENIOR HIGH SCHOOL', 'ICT', '09/10/2024', 'admin'),
('2233', 'jonathan', 'umali', 'intal', 'SENIOR HIGH SCHOOL', 'ICT', '09/10/2024', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `tblviolations`
--

CREATE TABLE `tblviolations` (
  `vcode` varchar(50) NOT NULL,
  `description` varchar(50) NOT NULL,
  `vtype` varchar(20) NOT NULL,
  `status` varchar(20) NOT NULL,
  `createdby` varchar(50) NOT NULL,
  `datecreated` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `tblviolations`
--

INSERT INTO `tblviolations` (`vcode`, `description`, `vtype`, `status`, `createdby`, `datecreated`) VALUES
('00', 'ano to', 'MINOR', 'ACTIVE', 'admin', '19/10/2024'),
('0908', 'talo na', 'MAJOR', 'ACTIVE', 'admin', '16/10/2024'),
('das', 'dsad', 'MINOR', 'ACTIVE', 'admin', '16/10/2024'),
('seryoso?', 'oo', 'MINOR', 'ACTIVE', 'admin', '19/10/2024'),
('test', 'tes', 'MINOR', 'ACTIVE', 'admin', '19/10/2024'),
('walang', 'wala na talo na', 'MAJOR', 'ACTIVE', 'admin', '16/10/2024');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tblaccounts`
--
ALTER TABLE `tblaccounts`
  ADD PRIMARY KEY (`username`);

--
-- Indexes for table `tblcases`
--
ALTER TABLE `tblcases`
  ADD PRIMARY KEY (`caseID`);

--
-- Indexes for table `tblcourses`
--
ALTER TABLE `tblcourses`
  ADD PRIMARY KEY (`coursecode`);

--
-- Indexes for table `tblstrands`
--
ALTER TABLE `tblstrands`
  ADD PRIMARY KEY (`strandcode`);

--
-- Indexes for table `tblstudents`
--
ALTER TABLE `tblstudents`
  ADD PRIMARY KEY (`studentID`);

--
-- Indexes for table `tblviolations`
--
ALTER TABLE `tblviolations`
  ADD PRIMARY KEY (`vcode`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
