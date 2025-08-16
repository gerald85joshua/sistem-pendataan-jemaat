-- phpMyAdmin SQL Dump
-- version 5.2.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: May 28, 2025 at 12:09 AM
-- Server version: 10.11.11-MariaDB-cll-lve
-- PHP Version: 8.3.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `u8928972_jemaat_petra`
--
CREATE DATABASE IF NOT EXISTS `jemaat_petra` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `jemaat_petra`;

-- --------------------------------------------------------

--
-- Stand-in structure for view `ddl_area`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `ddl_area`;
CREATE TABLE `ddl_area` (
`Text` varchar(100)
,`Value` varchar(10)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `ddl_jemaat`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `ddl_jemaat`;
CREATE TABLE `ddl_jemaat` (
`Text` varchar(128)
,`Value` varchar(36)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `ddl_kelompok_ibadah`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `ddl_kelompok_ibadah`;
CREATE TABLE `ddl_kelompok_ibadah` (
`Text` varchar(100)
,`Value` varchar(10)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `ddl_komsel`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `ddl_komsel`;
CREATE TABLE `ddl_komsel` (
`Text` varchar(100)
,`Value` varchar(10)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `ddl_pekerjaan`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `ddl_pekerjaan`;
CREATE TABLE `ddl_pekerjaan` (
`Text` varchar(100)
,`Value` varchar(10)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `ddl_pendidikan`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `ddl_pendidikan`;
CREATE TABLE `ddl_pendidikan` (
`Text` varchar(100)
,`Value` varchar(10)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `ddl_status_anggota`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `ddl_status_anggota`;
CREATE TABLE `ddl_status_anggota` (
`Text` varchar(100)
,`Value` varchar(2)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `ddl_status_keaktifan`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `ddl_status_keaktifan`;
CREATE TABLE `ddl_status_keaktifan` (
`Text` varchar(100)
,`Value` varchar(5)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `ddl_status_pernikahan`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `ddl_status_pernikahan`;
CREATE TABLE `ddl_status_pernikahan` (
`Text` varchar(100)
,`Value` varchar(10)
);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_area`
--

DROP TABLE IF EXISTS `tbl_area`;
CREATE TABLE `tbl_area` (
  `Area_ID` varchar(10) NOT NULL,
  `Area` varchar(100) NOT NULL,
  `PIC_ID` varchar(36) NOT NULL,
  `Keterangan` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_jemaat`
--

DROP TABLE IF EXISTS `tbl_jemaat`;
CREATE TABLE `tbl_jemaat` (
  `ID` varchar(36) NOT NULL DEFAULT 'UUID()',
  `KTP` varchar(16) DEFAULT NULL,
  `Nama_Lengkap` varchar(100) DEFAULT NULL,
  `Nama_Panggilan` varchar(50) DEFAULT NULL,
  `Jenis_Kelamin` char(1) DEFAULT NULL,
  `Pendidikan_Terakhir` varchar(50) DEFAULT NULL,
  `Pekerjaan` varchar(100) DEFAULT NULL,
  `Alamat` varchar(200) DEFAULT NULL,
  `Status_Anggota_ID` varchar(2) DEFAULT NULL,
  `Status_Keaktifan_ID` varchar(5) DEFAULT NULL,
  `Kelompok_Ibadah_ID` varchar(10) DEFAULT NULL,
  `Komsel_ID` varchar(10) DEFAULT NULL,
  `Tempat_Lahir` varchar(50) DEFAULT NULL,
  `Tanggal_Lahir` date DEFAULT NULL,
  `Golongan_Darah` varchar(5) DEFAULT NULL,
  `Bersedia_Donor_Darah` bit(1) NOT NULL DEFAULT b'0',
  `No_HP` varchar(20) DEFAULT NULL,
  `Alamat_Email` varchar(50) DEFAULT NULL,
  `Status_Pernikahan_ID` varchar(10) DEFAULT NULL,
  `Photo` longblob DEFAULT NULL,
  `Created_By` varchar(100) NOT NULL,
  `Created_Date` datetime NOT NULL,
  `Updated_By` varchar(100) NOT NULL,
  `Updated_Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_kelompok_ibadah`
--

DROP TABLE IF EXISTS `tbl_kelompok_ibadah`;
CREATE TABLE `tbl_kelompok_ibadah` (
  `Kelompok_Ibadah_ID` varchar(10) NOT NULL,
  `Kelompok_Ibadah` varchar(100) NOT NULL,
  `PIC_ID` varchar(36) NOT NULL,
  `Keterangan` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_keluarga`
--

DROP TABLE IF EXISTS `tbl_keluarga`;
CREATE TABLE `tbl_keluarga` (
  `ID` varchar(36) NOT NULL DEFAULT 'UUID()',
  `No_KK` varchar(16) DEFAULT NULL,
  `Jalan` varchar(200) DEFAULT NULL,
  `RT` varchar(5) DEFAULT NULL,
  `RW` varchar(5) DEFAULT NULL,
  `Kelurahan` varchar(100) DEFAULT NULL,
  `Kecamatan` varchar(100) DEFAULT NULL,
  `Kota` varchar(100) DEFAULT NULL,
  `Provinsi` varchar(100) DEFAULT NULL,
  `Kode_Pos` int(11) DEFAULT NULL,
  `Created_By` varchar(100) NOT NULL,
  `Created_Date` datetime NOT NULL,
  `Updated_By` varchar(100) NOT NULL,
  `Updated_Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_keluarga_detail`
--

DROP TABLE IF EXISTS `tbl_keluarga_detail`;
CREATE TABLE `tbl_keluarga_detail` (
  `ID` varchar(36) NOT NULL DEFAULT 'UUID()',
  `ID_Keluarga` varchar(36) NOT NULL,
  `ID_Jemaat` varchar(36) NOT NULL,
  `Nama_Ayah` varchar(100) DEFAULT NULL,
  `Nama_Ibu` varchar(100) DEFAULT NULL,
  `Created_By` varchar(100) NOT NULL,
  `Created_Date` datetime NOT NULL,
  `Updated_By` varchar(100) NOT NULL,
  `Updated_Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_komsel`
--

DROP TABLE IF EXISTS `tbl_komsel`;
CREATE TABLE `tbl_komsel` (
  `Komsel_ID` varchar(10) NOT NULL,
  `Area_ID` varchar(10) NOT NULL,
  `Komsel` varchar(100) NOT NULL,
  `PIC_ID` varchar(36) NOT NULL,
  `Keterangan` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_pekerjaan`
--

DROP TABLE IF EXISTS `tbl_pekerjaan`;
CREATE TABLE `tbl_pekerjaan` (
  `Pekerjaan_ID` varchar(10) NOT NULL,
  `Pekerjaan` varchar(100) NOT NULL,
  `Keterangan` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_pendidikan`
--

DROP TABLE IF EXISTS `tbl_pendidikan`;
CREATE TABLE `tbl_pendidikan` (
  `Pendidikan_ID` varchar(10) NOT NULL,
  `Pendidikan` varchar(100) NOT NULL,
  `Keterangan` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_pernikahan`
--

DROP TABLE IF EXISTS `tbl_pernikahan`;
CREATE TABLE `tbl_pernikahan` (
  `ID` varchar(36) NOT NULL DEFAULT 'UUID()',
  `Tanggal_Pernikahan` date DEFAULT NULL,
  `Gereja` varchar(100) DEFAULT NULL,
  `Pendeta` varchar(100) DEFAULT NULL,
  `Catatan_Sipil` bit(1) NOT NULL DEFAULT b'0',
  `No_Surat_Nikah` varchar(100) DEFAULT NULL,
  `Created_By` varchar(100) NOT NULL,
  `Created_Date` datetime NOT NULL,
  `Updated_By` varchar(100) NOT NULL,
  `Updated_Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_pernikahan_detail`
--

DROP TABLE IF EXISTS `tbl_pernikahan_detail`;
CREATE TABLE `tbl_pernikahan_detail` (
  `ID` varchar(36) NOT NULL DEFAULT 'UUID()',
  `ID_Pernikahan` varchar(36) NOT NULL,
  `ID_Jemaat` varchar(36) NOT NULL,
  `Anggota_Gereja` varchar(100) DEFAULT NULL,
  `Created_By` varchar(100) NOT NULL,
  `Created_Date` datetime NOT NULL,
  `Updated_By` varchar(100) NOT NULL,
  `Updated_Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_status_anggota`
--

DROP TABLE IF EXISTS `tbl_status_anggota`;
CREATE TABLE `tbl_status_anggota` (
  `Status_Anggota_ID` varchar(2) NOT NULL,
  `Status_Anggota` varchar(100) NOT NULL,
  `Keterangan` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_status_keaktifan`
--

DROP TABLE IF EXISTS `tbl_status_keaktifan`;
CREATE TABLE `tbl_status_keaktifan` (
  `Status_Keaktifan_ID` varchar(5) NOT NULL,
  `Status_Keaktifan` varchar(100) NOT NULL,
  `Keterangan` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_status_pernikahan`
--

DROP TABLE IF EXISTS `tbl_status_pernikahan`;
CREATE TABLE `tbl_status_pernikahan` (
  `Status_Pernikahan_ID` varchar(10) NOT NULL,
  `Status_Pernikahan` varchar(100) NOT NULL,
  `Keterangan` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user`
--

DROP TABLE IF EXISTS `tbl_user`;
CREATE TABLE `tbl_user` (
  `User_ID` varchar(36) NOT NULL DEFAULT 'UUID()',
  `User_Name` varchar(100) NOT NULL,
  `User_Email` varchar(100) NOT NULL,
  `User_Password` varchar(200) NOT NULL,
  `User_Role` varchar(20) DEFAULT NULL,
  `Is_Login` bit(1) NOT NULL DEFAULT b'0',
  `Last_Login` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

-- --------------------------------------------------------

--
-- Stand-in structure for view `vw_area`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `vw_area`;
CREATE TABLE `vw_area` (
`Area_ID` varchar(10)
,`Area` varchar(100)
,`PIC_ID` varchar(36)
,`Nama_Panggilan_PIC` varchar(50)
,`Nama_Lengkap_PIC` varchar(100)
,`Keterangan` varchar(200)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `vw_hut`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `vw_hut`;
CREATE TABLE `vw_hut` (
`KTP` varchar(16)
,`Nama_Lengkap` varchar(100)
,`Alamat` varchar(200)
,`No_HP` varchar(20)
,`Tanggal_Lahir` date
,`Umur` int(6)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `vw_hut_pernikahan`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `vw_hut_pernikahan`;
CREATE TABLE `vw_hut_pernikahan` (
`Nama` mediumtext
,`Alamat` mediumtext
,`No_HP` mediumtext
,`Tanggal_Pernikahan` date
,`Usia_Pernikahan` int(6)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `vw_jemaat`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `vw_jemaat`;
CREATE TABLE `vw_jemaat` (
`ID` varchar(36)
,`KTP` varchar(16)
,`Nama_Lengkap` varchar(100)
,`Nama_Panggilan` varchar(50)
,`Jenis_Kelamin` char(1)
,`Pendidikan_Terakhir` varchar(50)
,`Pekerjaan` varchar(100)
,`Alamat` varchar(200)
,`Status_Anggota_ID` varchar(2)
,`Status_Anggota` varchar(100)
,`Status_Keaktifan_ID` varchar(5)
,`Status_Keaktifan` varchar(100)
,`Kelompok_Ibadah_ID` varchar(10)
,`Kelompok_Ibadah` varchar(100)
,`Komsel_ID` varchar(10)
,`Komsel` varchar(100)
,`Tempat_Lahir` varchar(50)
,`Tanggal_Lahir` date
,`Golongan_Darah` varchar(5)
,`Bersedia_Donor_Darah` bit(1)
,`No_HP` varchar(20)
,`Alamat_Email` varchar(50)
,`Status_Pernikahan_ID` varchar(10)
,`Status_Pernikahan` varchar(100)
,`ID_Pernikahan` varchar(36)
,`ID_Keluarga` varchar(36)
,`Photo` longblob
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `vw_komsel`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `vw_komsel`;
CREATE TABLE `vw_komsel` (
`Komsel_ID` varchar(10)
,`Komsel` varchar(100)
,`Area_ID` varchar(10)
,`Area` varchar(100)
,`PIC_ID` varchar(36)
,`Nama_Panggilan_PIC` varchar(50)
,`Nama_Lengkap_PIC` varchar(100)
,`Keterangan` varchar(200)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `vw_pernikahan`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `vw_pernikahan`;
CREATE TABLE `vw_pernikahan` (
`ID` varchar(36)
,`Pasangan` mediumtext
,`Tanggal_Pernikahan` date
,`gereja` varchar(100)
,`pendeta` varchar(100)
,`catatan_sipil` bit(1)
,`no_surat_nikah` varchar(100)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `vw_pernikahan_detail`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `vw_pernikahan_detail`;
CREATE TABLE `vw_pernikahan_detail` (
`ID` varchar(36)
,`ID_Pernikahan` varchar(36)
,`ID_Jemaat` varchar(36)
,`Nama_Lengkap` varchar(100)
,`Jenis_Kelamin` char(1)
,`Status_Keaktifan_ID` varchar(5)
,`Status_Keaktifan` varchar(100)
,`Anggota_Gereja` varchar(100)
);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_area`
--
ALTER TABLE `tbl_area`
  ADD PRIMARY KEY (`Area_ID`);

--
-- Indexes for table `tbl_jemaat`
--
ALTER TABLE `tbl_jemaat`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `KTP` (`KTP`);

--
-- Indexes for table `tbl_kelompok_ibadah`
--
ALTER TABLE `tbl_kelompok_ibadah`
  ADD PRIMARY KEY (`Kelompok_Ibadah_ID`);

--
-- Indexes for table `tbl_keluarga`
--
ALTER TABLE `tbl_keluarga`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `tbl_keluarga_detail`
--
ALTER TABLE `tbl_keluarga_detail`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `tbl_komsel`
--
ALTER TABLE `tbl_komsel`
  ADD PRIMARY KEY (`Komsel_ID`);

--
-- Indexes for table `tbl_pekerjaan`
--
ALTER TABLE `tbl_pekerjaan`
  ADD PRIMARY KEY (`Pekerjaan_ID`);

--
-- Indexes for table `tbl_pendidikan`
--
ALTER TABLE `tbl_pendidikan`
  ADD PRIMARY KEY (`Pendidikan_ID`);

--
-- Indexes for table `tbl_pernikahan`
--
ALTER TABLE `tbl_pernikahan`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `tbl_pernikahan_detail`
--
ALTER TABLE `tbl_pernikahan_detail`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `tbl_status_anggota`
--
ALTER TABLE `tbl_status_anggota`
  ADD PRIMARY KEY (`Status_Anggota_ID`);

--
-- Indexes for table `tbl_status_keaktifan`
--
ALTER TABLE `tbl_status_keaktifan`
  ADD PRIMARY KEY (`Status_Keaktifan_ID`);

--
-- Indexes for table `tbl_status_pernikahan`
--
ALTER TABLE `tbl_status_pernikahan`
  ADD PRIMARY KEY (`Status_Pernikahan_ID`);

-- --------------------------------------------------------

--
-- Structure for view `ddl_area`
--
DROP TABLE IF EXISTS `ddl_area`;

DROP VIEW IF EXISTS `ddl_area`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972`@`localhost` SQL SECURITY DEFINER VIEW `ddl_area`  AS SELECT `tbl_area`.`Area` AS `Text`, `tbl_area`.`Area_ID` AS `Value` FROM `tbl_area` ;

-- --------------------------------------------------------

--
-- Structure for view `ddl_jemaat`
--
DROP TABLE IF EXISTS `ddl_jemaat`;

DROP VIEW IF EXISTS `ddl_jemaat`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972`@`localhost` SQL SECURITY DEFINER VIEW `ddl_jemaat`  AS SELECT concat(case when `tbl_jemaat`.`Nama_Panggilan` is not null then `tbl_jemaat`.`Nama_Panggilan` else `tbl_jemaat`.`Nama_Lengkap` end,' | ',case when `tbl_jemaat`.`Tanggal_Lahir` is not null then date_format(`tbl_jemaat`.`Tanggal_Lahir`,'%d-%m-%Y') else 'Tgl lahir tidak terdaftar' end) AS `Text`, `tbl_jemaat`.`ID` AS `Value` FROM `tbl_jemaat` ;

-- --------------------------------------------------------

--
-- Structure for view `ddl_kelompok_ibadah`
--
DROP TABLE IF EXISTS `ddl_kelompok_ibadah`;

DROP VIEW IF EXISTS `ddl_kelompok_ibadah`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972`@`localhost` SQL SECURITY DEFINER VIEW `ddl_kelompok_ibadah`  AS SELECT `tbl_kelompok_ibadah`.`Kelompok_Ibadah` AS `Text`, `tbl_kelompok_ibadah`.`Kelompok_Ibadah_ID` AS `Value` FROM `tbl_kelompok_ibadah` ;

-- --------------------------------------------------------

--
-- Structure for view `ddl_komsel`
--
DROP TABLE IF EXISTS `ddl_komsel`;

DROP VIEW IF EXISTS `ddl_komsel`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972`@`localhost` SQL SECURITY DEFINER VIEW `ddl_komsel`  AS SELECT `tbl_komsel`.`Komsel` AS `Text`, `tbl_komsel`.`Komsel_ID` AS `Value` FROM `tbl_komsel` ;

-- --------------------------------------------------------

--
-- Structure for view `ddl_pekerjaan`
--
DROP TABLE IF EXISTS `ddl_pekerjaan`;

DROP VIEW IF EXISTS `ddl_pekerjaan`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972`@`localhost` SQL SECURITY DEFINER VIEW `ddl_pekerjaan`  AS SELECT `tbl_pekerjaan`.`Pekerjaan` AS `Text`, `tbl_pekerjaan`.`Pekerjaan_ID` AS `Value` FROM `tbl_pekerjaan` ;

-- --------------------------------------------------------

--
-- Structure for view `ddl_pendidikan`
--
DROP TABLE IF EXISTS `ddl_pendidikan`;

DROP VIEW IF EXISTS `ddl_pendidikan`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972`@`localhost` SQL SECURITY DEFINER VIEW `ddl_pendidikan`  AS SELECT `tbl_pendidikan`.`Pendidikan` AS `Text`, `tbl_pendidikan`.`Pendidikan_ID` AS `Value` FROM `tbl_pendidikan` ;

-- --------------------------------------------------------

--
-- Structure for view `ddl_status_anggota`
--
DROP TABLE IF EXISTS `ddl_status_anggota`;

DROP VIEW IF EXISTS `ddl_status_anggota`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972`@`localhost` SQL SECURITY DEFINER VIEW `ddl_status_anggota`  AS SELECT `tbl_status_anggota`.`Status_Anggota` AS `Text`, `tbl_status_anggota`.`Status_Anggota_ID` AS `Value` FROM `tbl_status_anggota` ;

-- --------------------------------------------------------

--
-- Structure for view `ddl_status_keaktifan`
--
DROP TABLE IF EXISTS `ddl_status_keaktifan`;

DROP VIEW IF EXISTS `ddl_status_keaktifan`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972`@`localhost` SQL SECURITY DEFINER VIEW `ddl_status_keaktifan`  AS SELECT `tbl_status_keaktifan`.`Status_Keaktifan` AS `Text`, `tbl_status_keaktifan`.`Status_Keaktifan_ID` AS `Value` FROM `tbl_status_keaktifan` ;

-- --------------------------------------------------------

--
-- Structure for view `ddl_status_pernikahan`
--
DROP TABLE IF EXISTS `ddl_status_pernikahan`;

DROP VIEW IF EXISTS `ddl_status_pernikahan`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972`@`localhost` SQL SECURITY DEFINER VIEW `ddl_status_pernikahan`  AS SELECT `tbl_status_pernikahan`.`Status_Pernikahan` AS `Text`, `tbl_status_pernikahan`.`Status_Pernikahan_ID` AS `Value` FROM `tbl_status_pernikahan` ;

-- --------------------------------------------------------

--
-- Structure for view `vw_area`
--
DROP TABLE IF EXISTS `vw_area`;

DROP VIEW IF EXISTS `vw_area`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972_jemaat_petra`@`%` SQL SECURITY DEFINER VIEW `vw_area`  AS SELECT `a`.`Area_ID` AS `Area_ID`, `a`.`Area` AS `Area`, `a`.`PIC_ID` AS `PIC_ID`, `j`.`Nama_Panggilan` AS `Nama_Panggilan_PIC`, `j`.`Nama_Lengkap` AS `Nama_Lengkap_PIC`, `a`.`Keterangan` AS `Keterangan` FROM (`tbl_area` `a` left join `tbl_jemaat` `j` on(`a`.`PIC_ID` = `j`.`ID`)) ;

-- --------------------------------------------------------

--
-- Structure for view `vw_hut`
--
DROP TABLE IF EXISTS `vw_hut`;

DROP VIEW IF EXISTS `vw_hut`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972`@`localhost` SQL SECURITY DEFINER VIEW `vw_hut`  AS SELECT `tbl_jemaat`.`KTP` AS `KTP`, `tbl_jemaat`.`Nama_Lengkap` AS `Nama_Lengkap`, `tbl_jemaat`.`Alamat` AS `Alamat`, `tbl_jemaat`.`No_HP` AS `No_HP`, `tbl_jemaat`.`Tanggal_Lahir` AS `Tanggal_Lahir`, year(curdate()) - year(`tbl_jemaat`.`Tanggal_Lahir`) AS `Umur` FROM `tbl_jemaat` ;

-- --------------------------------------------------------

--
-- Structure for view `vw_hut_pernikahan`
--
DROP TABLE IF EXISTS `vw_hut_pernikahan`;

DROP VIEW IF EXISTS `vw_hut_pernikahan`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972`@`localhost` SQL SECURITY DEFINER VIEW `vw_hut_pernikahan`  AS SELECT group_concat(`select_pd`.`Nama_Lengkap` separator ' - ') AS `Nama`, group_concat(`select_pd`.`Alamat` separator ' - ') AS `Alamat`, group_concat(`select_pd`.`No_HP` separator ' - ') AS `No_HP`, `p`.`Tanggal_Pernikahan` AS `Tanggal_Pernikahan`, year(curdate()) - year(`p`.`Tanggal_Pernikahan`) AS `Usia_Pernikahan` FROM (`tbl_pernikahan` `p` left join (select `pd`.`ID_Pernikahan` AS `ID_Pernikahan`,`j`.`Nama_Lengkap` AS `Nama_Lengkap`,`j`.`Alamat` AS `Alamat`,`j`.`No_HP` AS `No_HP` from (`tbl_pernikahan_detail` `pd` left join `tbl_jemaat` `j` on(`j`.`ID` = `pd`.`ID_Jemaat`)) order by `j`.`Jenis_Kelamin`) `select_pd` on(`select_pd`.`ID_Pernikahan` = `p`.`ID`)) GROUP BY `p`.`Tanggal_Pernikahan`, year(curdate()) - year(`p`.`Tanggal_Pernikahan`) ;

-- --------------------------------------------------------

--
-- Structure for view `vw_jemaat`
--
DROP TABLE IF EXISTS `vw_jemaat`;

DROP VIEW IF EXISTS `vw_jemaat`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972_jemaat_petra`@`%` SQL SECURITY DEFINER VIEW `vw_jemaat`  AS SELECT `j`.`ID` AS `ID`, `j`.`KTP` AS `KTP`, `j`.`Nama_Lengkap` AS `Nama_Lengkap`, `j`.`Nama_Panggilan` AS `Nama_Panggilan`, `j`.`Jenis_Kelamin` AS `Jenis_Kelamin`, `j`.`Pendidikan_Terakhir` AS `Pendidikan_Terakhir`, `j`.`Pekerjaan` AS `Pekerjaan`, `j`.`Alamat` AS `Alamat`, `j`.`Status_Anggota_ID` AS `Status_Anggota_ID`, `sa`.`Status_Anggota` AS `Status_Anggota`, `j`.`Status_Keaktifan_ID` AS `Status_Keaktifan_ID`, `sk`.`Status_Keaktifan` AS `Status_Keaktifan`, `j`.`Kelompok_Ibadah_ID` AS `Kelompok_Ibadah_ID`, `ki`.`Kelompok_Ibadah` AS `Kelompok_Ibadah`, `j`.`Komsel_ID` AS `Komsel_ID`, `k`.`Komsel` AS `Komsel`, `j`.`Tempat_Lahir` AS `Tempat_Lahir`, `j`.`Tanggal_Lahir` AS `Tanggal_Lahir`, `j`.`Golongan_Darah` AS `Golongan_Darah`, `j`.`Bersedia_Donor_Darah` AS `Bersedia_Donor_Darah`, `j`.`No_HP` AS `No_HP`, `j`.`Alamat_Email` AS `Alamat_Email`, `j`.`Status_Pernikahan_ID` AS `Status_Pernikahan_ID`, `sp`.`Status_Pernikahan` AS `Status_Pernikahan`, `pd`.`ID_Pernikahan` AS `ID_Pernikahan`, `kd`.`ID_Keluarga` AS `ID_Keluarga`, `j`.`Photo` AS `Photo` FROM (((((((`tbl_jemaat` `j` left join `tbl_status_anggota` `sa` on(`sa`.`Status_Anggota_ID` = `j`.`Status_Anggota_ID`)) left join `tbl_status_keaktifan` `sk` on(`sk`.`Status_Keaktifan_ID` = `j`.`Status_Keaktifan_ID`)) left join `tbl_kelompok_ibadah` `ki` on(`ki`.`Kelompok_Ibadah_ID` = `j`.`Kelompok_Ibadah_ID`)) left join `tbl_komsel` `k` on(`k`.`Komsel_ID` = `j`.`Komsel_ID`)) left join `tbl_status_pernikahan` `sp` on(`sp`.`Status_Pernikahan_ID` = `j`.`Status_Pernikahan_ID`)) left join `tbl_pernikahan_detail` `pd` on(`pd`.`ID_Jemaat` = `j`.`ID`)) left join `tbl_keluarga_detail` `kd` on(`kd`.`ID_Jemaat` = `j`.`ID`)) ;

-- --------------------------------------------------------

--
-- Structure for view `vw_komsel`
--
DROP TABLE IF EXISTS `vw_komsel`;

DROP VIEW IF EXISTS `vw_komsel`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972_jemaat_petra`@`%` SQL SECURITY DEFINER VIEW `vw_komsel`  AS SELECT `k`.`Komsel_ID` AS `Komsel_ID`, `k`.`Komsel` AS `Komsel`, `k`.`Area_ID` AS `Area_ID`, `a`.`Area` AS `Area`, `k`.`PIC_ID` AS `PIC_ID`, `j`.`Nama_Panggilan` AS `Nama_Panggilan_PIC`, `j`.`Nama_Lengkap` AS `Nama_Lengkap_PIC`, `k`.`Keterangan` AS `Keterangan` FROM ((`tbl_komsel` `k` left join `tbl_area` `a` on(`k`.`Area_ID` = `a`.`Area_ID`)) left join `tbl_jemaat` `j` on(`k`.`PIC_ID` = `j`.`ID`)) ;

-- --------------------------------------------------------

--
-- Structure for view `vw_pernikahan`
--
DROP TABLE IF EXISTS `vw_pernikahan`;

DROP VIEW IF EXISTS `vw_pernikahan`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972_jemaat_petra`@`%` SQL SECURITY DEFINER VIEW `vw_pernikahan`  AS SELECT `p`.`ID` AS `ID`, group_concat(`pdj`.`Nama_Panggilan` order by `pdj`.`Jenis_Kelamin` ASC separator ' - ') AS `Pasangan`, `p`.`Tanggal_Pernikahan` AS `Tanggal_Pernikahan`, `p`.`Gereja` AS `gereja`, `p`.`Pendeta` AS `pendeta`, `p`.`Catatan_Sipil` AS `catatan_sipil`, `p`.`No_Surat_Nikah` AS `no_surat_nikah` FROM (`tbl_pernikahan` `p` join (select `pd`.`ID_Pernikahan` AS `ID_Pernikahan`,`j`.`Nama_Panggilan` AS `Nama_Panggilan`,`j`.`Jenis_Kelamin` AS `Jenis_Kelamin` from (`tbl_pernikahan_detail` `pd` left join `tbl_jemaat` `j` on(`pd`.`ID_Jemaat` = `j`.`ID`))) `pdj` on(`p`.`ID` = `pdj`.`ID_Pernikahan`)) GROUP BY `p`.`ID`, `p`.`Tanggal_Pernikahan` ;

-- --------------------------------------------------------

--
-- Structure for view `vw_pernikahan_detail`
--
DROP TABLE IF EXISTS `vw_pernikahan_detail`;

DROP VIEW IF EXISTS `vw_pernikahan_detail`;
CREATE ALGORITHM=UNDEFINED DEFINER=`u8928972_jemaat_petra`@`%` SQL SECURITY DEFINER VIEW `vw_pernikahan_detail`  AS SELECT `pd`.`ID` AS `ID`, `pd`.`ID_Pernikahan` AS `ID_Pernikahan`, `pd`.`ID_Jemaat` AS `ID_Jemaat`, `j`.`Nama_Lengkap` AS `Nama_Lengkap`, `j`.`Jenis_Kelamin` AS `Jenis_Kelamin`, `j`.`Status_Keaktifan_ID` AS `Status_Keaktifan_ID`, `sk`.`Status_Keaktifan` AS `Status_Keaktifan`, `pd`.`Anggota_Gereja` AS `Anggota_Gereja` FROM ((`tbl_pernikahan_detail` `pd` left join `tbl_jemaat` `j` on(`pd`.`ID_Jemaat` = `j`.`ID`)) left join `tbl_status_keaktifan` `sk` on(`j`.`Status_Keaktifan_ID` = `sk`.`Status_Keaktifan_ID`)) ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
