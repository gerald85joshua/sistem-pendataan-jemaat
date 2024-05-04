-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 04 Bulan Mei 2024 pada 19.04
-- Versi server: 10.4.22-MariaDB
-- Versi PHP: 8.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `jemaat_petra`
--

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `ddl_area`
-- (Lihat di bawah untuk tampilan aktual)
--
CREATE TABLE `ddl_area` (
`Text` varchar(100)
,`Value` varchar(10)
);

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `ddl_jemaat`
-- (Lihat di bawah untuk tampilan aktual)
--
CREATE TABLE `ddl_jemaat` (
`TEXT` varchar(100)
,`VALUE` varchar(36)
);

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `ddl_kelompok_ibadah`
-- (Lihat di bawah untuk tampilan aktual)
--
CREATE TABLE `ddl_kelompok_ibadah` (
`Text` varchar(100)
,`Value` varchar(10)
);

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `ddl_komsel`
-- (Lihat di bawah untuk tampilan aktual)
--
CREATE TABLE `ddl_komsel` (
`Text` varchar(100)
,`Value` varchar(10)
);

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `ddl_pekerjaan`
-- (Lihat di bawah untuk tampilan aktual)
--
CREATE TABLE `ddl_pekerjaan` (
`Text` varchar(100)
,`Value` varchar(10)
);

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `ddl_pendidikan`
-- (Lihat di bawah untuk tampilan aktual)
--
CREATE TABLE `ddl_pendidikan` (
`Text` varchar(100)
,`Value` varchar(10)
);

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `ddl_status_anggota`
-- (Lihat di bawah untuk tampilan aktual)
--
CREATE TABLE `ddl_status_anggota` (
`Text` varchar(100)
,`Value` varchar(2)
);

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `ddl_status_keaktifan`
-- (Lihat di bawah untuk tampilan aktual)
--
CREATE TABLE `ddl_status_keaktifan` (
`Text` varchar(100)
,`Value` varchar(5)
);

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `ddl_status_pernikahan`
-- (Lihat di bawah untuk tampilan aktual)
--
CREATE TABLE `ddl_status_pernikahan` (
`Text` varchar(100)
,`Value` varchar(10)
);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_area`
--

CREATE TABLE `tbl_area` (
  `Area_ID` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `Area` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `PIC_ID` varchar(36) COLLATE utf8_unicode_ci NOT NULL,
  `Keterangan` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `tbl_area`
--

INSERT INTO `tbl_area` (`Area_ID`, `Area`, `PIC_ID`, `Keterangan`) VALUES
('AREA000001', 'Wahana Jatiasih ', '', NULL),
('AREA000002', 'Raya Hankam', '', NULL),
('AREA000003', 'Kampung Sawah', '3f0cd334-c60e-11ed-a33a-f8e4e3b3522b', NULL),
('AREA000004', 'Sharing', '', NULL),
('AREA000005', 'PabuRamKra', '', NULL),
('AREA000006', 'Bulak Tinggi', '', NULL),
('AREA000007', 'Glow', '', NULL),
('AREA000008', 'Sukacita', '', NULL);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_jemaat`
--

CREATE TABLE `tbl_jemaat` (
  `ID` varchar(36) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'UUID()',
  `KTP` varchar(16) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Nama_Lengkap` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Nama_Panggilan` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Jenis_Kelamin` char(1) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Pendidikan_Terakhir` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Pekerjaan` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Alamat` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Status_Anggota_ID` varchar(2) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Status_Keaktifan_ID` varchar(5) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Kelompok_Ibadah_ID` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Komsel_ID` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Tempat_Lahir` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Tanggal_Lahir` date DEFAULT NULL,
  `Golongan_Darah` varchar(5) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Bersedia_Donor_Darah` bit(1) NOT NULL DEFAULT b'0',
  `No_HP` varchar(20) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Alamat_Email` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Status_Pernikahan_ID` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Created_By` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Created_Date` datetime NOT NULL,
  `Updated_By` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Updated_Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `tbl_jemaat`
--

INSERT INTO `tbl_jemaat` (`ID`, `KTP`, `Nama_Lengkap`, `Nama_Panggilan`, `Jenis_Kelamin`, `Pendidikan_Terakhir`, `Pekerjaan`, `Alamat`, `Status_Anggota_ID`, `Status_Keaktifan_ID`, `Kelompok_Ibadah_ID`, `Komsel_ID`, `Tempat_Lahir`, `Tanggal_Lahir`, `Golongan_Darah`, `Bersedia_Donor_Darah`, `No_HP`, `Alamat_Email`, `Status_Pernikahan_ID`, `Created_By`, `Created_Date`, `Updated_By`, `Updated_Date`) VALUES
('004e354b-c610-11ed-a33a-f8e4e3b3522b', NULL, 'Irawati Doloksaribu', 'Ira', 'P', NULL, NULL, NULL, 'P', 'TA', '-', '-', NULL, '1992-02-26', '-', b'0', NULL, NULL, 'STPER00002', '', '0001-01-01 00:00:00', 'System', '2023-06-17 10:07:57'),
('0ae35b12-c60c-11ed-a33a-f8e4e3b3522b', '1111333333333333', 'Joshua Gerald Benedict Hutasoit', 'Joshua', 'L', NULL, NULL, 'Bojong Nangka IV/21', '-', 'JS', '-', '-', 'Jakarta', '1993-08-23', '-', b'0', NULL, NULL, '-', '', '0001-01-01 00:00:00', 'System', '2023-06-17 10:07:41'),
('0ae372de-c60c-11ed-a33a-f8e4e3b3522b', '1111444444444444', 'Jonathan Reinhart Audric Hutasoit', 'Jonathan ', 'L', NULL, NULL, 'Bojong Nangka IV/21', 'P', 'JA', NULL, NULL, 'jakarta', '1994-11-25', NULL, b'0', NULL, NULL, 'STPER00001', '', '2023-03-19 05:03:54', '', '2023-03-19 05:03:54'),
('0b098544-c60b-11ed-a33a-f8e4e3b3522b', '1111111111111111', 'Jerry hutasoit', 'Jerry', 'L', NULL, NULL, NULL, 'D', 'JA', NULL, NULL, NULL, '1965-07-23', NULL, b'0', NULL, NULL, 'STPER00001', '', '2023-03-19 04:53:33', '', '2023-03-19 04:53:33'),
('0b09c08e-c60b-11ed-a33a-f8e4e3b3522b', '1111222222222222', 'Emmy Christiana', 'Emmy', 'P', NULL, NULL, 'Bojong Nangka IV/21', 'D', 'JA', NULL, NULL, 'Palu', '1969-01-18', '<unkn', b'0', NULL, NULL, 'STPER00001', '', '0001-01-01 00:00:00', '', '0001-01-01 00:00:00'),
('3f0cba0c-c60e-11ed-a33a-f8e4e3b3522b', '1111777777777777', 'Josafat Hanzel Adonis Hutasoit', 'Josafat', 'L', NULL, NULL, 'Bojong nangka IV/21', 'R', 'JA', NULL, NULL, 'Jakarta', '2004-11-14', NULL, b'0', NULL, NULL, 'STPER00002', '', '2023-03-19 05:17:03', '', '2023-03-19 05:17:03'),
('3f0cd334-c60e-11ed-a33a-f8e4e3b3522b', '1111888888888888', 'Pieter Anggiat Napitupulu', 'Pieter', 'L', NULL, NULL, 'Puri Gading', 'D', 'JA', NULL, 'KOMS000005', 'Sidamanik', '1965-04-10', 'B', b'0', '081319924693', 'pieternapitupulu@yahoo.co.id', 'STPER00001', '', '2023-03-19 05:17:03', '', '2023-03-19 05:17:03'),
('6c1beeed-c612-11ed-a33a-f8e4e3b3522b', '2222444444444444', 'Lois Lusi Megawati', 'Lusi', 'P', NULL, NULL, NULL, 'D', 'JA', NULL, NULL, NULL, '1975-09-23', NULL, b'0', NULL, NULL, 'STPER00001', '', '2023-03-19 05:54:39', '', '2023-03-19 05:54:39'),
('a4802110-c60f-11ed-a33a-f8e4e3b3522b', '1111999999999999', 'Paricia Bong Napitupulu', 'Patricia ', 'P', NULL, NULL, 'Puri Gading ', 'p', 'JA', 'KELIB00003', NULL, 'Jakarta', '2002-03-20', NULL, b'0', NULL, NULL, 'STPER00002', '', '2023-03-19 05:26:44', '', '2023-03-19 05:26:44'),
('a4804029-c60f-11ed-a33a-f8e4e3b3522b', '2222222222222222', 'Bong Petra Napitupulu', 'Petra', 'L', NULL, NULL, NULL, 'A', 'JA', 'KELIB00004', 'KOMS000005', 'jakarta', '2010-08-13', NULL, b'0', '081212264662', NULL, 'STPER00002', '', '2023-03-19 05:26:44', '', '2023-03-19 05:26:44'),
('e035156e-c60c-11ed-a33a-f8e4e3b3522b', '1111555555555555', 'Joshepine Eunike Aurellia Hutasoit', 'Jossi', 'P', NULL, NULL, 'Bojong Nangka IV/21', 'P', 'JA', NULL, NULL, 'Jakarta', '1997-11-12', NULL, b'0', NULL, NULL, 'STPER00002', '', '2023-03-19 05:11:11', '', '2023-03-19 05:11:11'),
('e0353732-c60c-11ed-a33a-f8e4e3b3522b', '1111666666666666', 'Joenna Priscilla Agripina Hutasoit', 'Joen', 'P', NULL, NULL, 'Bojong Nangka IV/21', 'P', 'JX', NULL, NULL, 'Pondok Gede', '1999-07-27', NULL, b'0', NULL, NULL, 'STPER00002', '', '2023-03-19 05:11:11', '', '2023-03-19 05:11:11');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_kelompok_ibadah`
--

CREATE TABLE `tbl_kelompok_ibadah` (
  `Kelompok_Ibadah_ID` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `Kelompok_Ibadah` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `PIC_ID` varchar(36) COLLATE utf8_unicode_ci NOT NULL,
  `Keterangan` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `tbl_kelompok_ibadah`
--

INSERT INTO `tbl_kelompok_ibadah` (`Kelompok_Ibadah_ID`, `Kelompok_Ibadah`, `PIC_ID`, `Keterangan`) VALUES
('KELIB00001', 'IBADAH RAYA', '', NULL),
('KELIB00002', 'YOUTH/GLOW', 'Joshua', 'Test keterangan2'),
('KELIB00003', 'YOUTH/STAR', '', NULL),
('KELIB00004', 'TOPKIDS', '', NULL),
('KELIB00005', 'PPA/IPIA', '', NULL);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_keluarga`
--

CREATE TABLE `tbl_keluarga` (
  `ID` varchar(36) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'UUID()',
  `No_KK` varchar(16) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Jalan` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `RT` varchar(5) COLLATE utf8_unicode_ci DEFAULT NULL,
  `RW` varchar(5) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Kelurahan` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Kecamatan` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Kota` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Provinsi` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Kode_Pos` int(11) DEFAULT NULL,
  `Created_By` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Created_Date` datetime NOT NULL,
  `Updated_By` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Updated_Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `tbl_keluarga`
--

INSERT INTO `tbl_keluarga` (`ID`, `No_KK`, `Jalan`, `RT`, `RW`, `Kelurahan`, `Kecamatan`, `Kota`, `Provinsi`, `Kode_Pos`, `Created_By`, `Created_Date`, `Updated_By`, `Updated_Date`) VALUES
('1e7d6ae2-c614-11ed-a33a-f8e4e3b3522b', '6666666666666666', 'Bojong Nangka IV/21', NULL, NULL, 'Jatirahayu', 'Pondok Melati', 'Bekasi ', 'Jawa Barat', 17414, '', '2023-03-19 06:07:10', '', '2023-03-19 06:07:10'),
('a9ff3415-c613-11ed-a33a-f8e4e3b3522b', '5555555555555555', 'Puri Gading', NULL, NULL, 'Jati Melati', 'Pondok Melati', 'Bekasi', 'Jawa Barat', NULL, '', '2023-03-19 05:58:52', '', '2023-03-19 05:58:52'),
('b71e5799-c614-11ed-a33a-f8e4e3b3522b', '7777777777777777', 'Dolok Nauli ', NULL, NULL, 'Bakaran Batu', 'Sei Bamban', 'Tebing tinggi', 'Sumatera Utara', 20929, '', '2023-03-19 06:10:17', '', '2023-03-19 06:10:17');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_keluarga_detail`
--

CREATE TABLE `tbl_keluarga_detail` (
  `ID` varchar(36) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'UUID()',
  `ID_Keluarga` varchar(36) COLLATE utf8_unicode_ci NOT NULL,
  `ID_Jemaat` varchar(36) COLLATE utf8_unicode_ci NOT NULL,
  `Nama_Ayah` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Nama_Ibu` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Created_By` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Created_Date` datetime NOT NULL,
  `Updated_By` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Updated_Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `tbl_keluarga_detail`
--

INSERT INTO `tbl_keluarga_detail` (`ID`, `ID_Keluarga`, `ID_Jemaat`, `Nama_Ayah`, `Nama_Ibu`, `Created_By`, `Created_Date`, `Updated_By`, `Updated_Date`) VALUES
('0252dcc0-c616-11ed-a33a-f8e4e3b3522b', '1e7d6ae2-c614-11ed-a33a-f8e4e3b3522b', '0ae372de-c60c-11ed-a33a-f8e4e3b3522b', 'Jerry hutasoit', 'Emmy Christiana', '', '2023-03-19 06:21:07', '', '2023-03-19 06:21:07'),
('23fd5160-c617-11ed-a33a-f8e4e3b3522b', 'b71e5799-c614-11ed-a33a-f8e4e3b3522b', '004e354b-c610-11ed-a33a-f8e4e3b3522b', 'Bismar Doloksaribu', 'Tiarma Hutajulu', '', '2023-03-19 06:29:15', '', '2023-03-19 06:29:15'),
('53c8df90-c615-11ed-a33a-f8e4e3b3522b', '1e7d6ae2-c614-11ed-a33a-f8e4e3b3522b', '0b09c08e-c60b-11ed-a33a-f8e4e3b3522b', 'Benny Sumarauw', 'Charlotte Lalamentik', '', '2023-03-19 06:13:10', '', '2023-03-19 06:13:10'),
('53c8f29d-c615-11ed-a33a-f8e4e3b3522b', 'a9ff3415-c613-11ed-a33a-f8e4e3b3522b', '3f0cd334-c60e-11ed-a33a-f8e4e3b3522b', '-', '-', '', '2023-03-19 06:13:10', '', '2023-03-19 06:13:10'),
('5b3fadaa-c616-11ed-a33a-f8e4e3b3522b', '1e7d6ae2-c614-11ed-a33a-f8e4e3b3522b', 'e035156e-c60c-11ed-a33a-f8e4e3b3522b', 'Jerry hutasoit', 'Emmy Christiana', '', '2023-03-19 06:22:17', '', '2023-03-19 06:22:17'),
('5b3fc027-c616-11ed-a33a-f8e4e3b3522b', '1e7d6ae2-c614-11ed-a33a-f8e4e3b3522b', '3f0cba0c-c60e-11ed-a33a-f8e4e3b3522b', 'Jerry hutasoit', '	\r\nEmmy Christiana', '', '2023-03-19 06:22:17', '', '2023-03-19 06:22:17'),
('9933b5da-c616-11ed-a33a-f8e4e3b3522b', 'a9ff3415-c613-11ed-a33a-f8e4e3b3522b', '6c1beeed-c612-11ed-a33a-f8e4e3b3522b', '-', '-', '', '2023-03-19 06:25:07', '', '2023-03-19 06:25:07'),
('b6e9ea63-c618-11ed-a33a-f8e4e3b3522b', '1e7d6ae2-c614-11ed-a33a-f8e4e3b3522b', '0b098544-c60b-11ed-a33a-f8e4e3b3522b', 'Amang Hutasoit', 'Nurlian Hutapea', '', '2023-03-19 06:40:46', '', '2023-03-19 06:40:46'),
('ccc4995c-c618-11ed-a33a-f8e4e3b3522b', '1e7d6ae2-c614-11ed-a33a-f8e4e3b3522b', 'e0353732-c60c-11ed-a33a-f8e4e3b3522b', 'Jerry Hutasoit', 'Emmy Christiana', '', '2023-03-19 06:41:41', '', '2023-03-19 06:41:41'),
('d85e7c1b-c615-11ed-a33a-f8e4e3b3522b', '1e7d6ae2-c614-11ed-a33a-f8e4e3b3522b', '0ae35b12-c60c-11ed-a33a-f8e4e3b3522b', 'Jerry hutasoit', 'Emmy Christiana', '', '2023-03-19 06:17:30', '', '2023-03-19 06:17:30'),
('ebcad20e-c616-11ed-a33a-f8e4e3b3522b', 'a9ff3415-c613-11ed-a33a-f8e4e3b3522b', 'a4802110-c60f-11ed-a33a-f8e4e3b3522b', 'Pieter Anggiat Napitupulu', 'lois Lusi Megawati\r\n', '', '2023-03-19 06:26:30', '', '2023-03-19 06:26:30'),
('ebcae4b5-c616-11ed-a33a-f8e4e3b3522b', 'a9ff3415-c613-11ed-a33a-f8e4e3b3522b', 'e035156e-c60c-11ed-a33a-f8e4e3b3522b', 'Pieter Anggiat Napitupulu', 'lois Lusi Megawati\r\n', '', '2023-03-19 06:26:30', '', '2023-03-19 06:26:30');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_komsel`
--

CREATE TABLE `tbl_komsel` (
  `Komsel_ID` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `Area_ID` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `Komsel` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `PIC_ID` varchar(36) COLLATE utf8_unicode_ci NOT NULL,
  `Keterangan` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `tbl_komsel`
--

INSERT INTO `tbl_komsel` (`Komsel_ID`, `Area_ID`, `Komsel`, `PIC_ID`, `Keterangan`) VALUES
('KOMS000001', 'AREA000001', 'Jatiasih', '', NULL),
('KOMS000002', 'AREA000001', 'Wahana', '', NULL),
('KOMS000003', 'AREA000002', 'Raya Hankam', '', NULL),
('KOMS000004', 'AREA000002', 'Bojong Kulur', '', NULL),
('KOMS000005', 'AREA000003', 'Kampus 1', '', NULL),
('KOMS000006', 'AREA000003', 'Kampus 2', '', NULL),
('KOMS000007', 'AREA000003', 'Kampus 3', '', NULL),
('KOMS000008', 'AREA000003', 'Kampus 4', '', NULL),
('KOMS000009', 'AREA000003', 'Kampus 5', '', NULL),
('KOMS000010', 'AREA000003', 'Kampus 6', '', NULL),
('KOMS000011', 'AREA000004', 'Sharing 1', '', NULL),
('KOMS000012', 'AREA000004', 'Sharing 2', '', NULL),
('KOMS000013', 'AREA000004', 'Sharing 3', '', NULL),
('KOMS000014', 'AREA000004', 'Sharing 4', '', NULL),
('KOMS000015', 'AREA000005', 'Pabuaran', '', NULL),
('KOMS000016', 'AREA000005', 'Kp. Rambutan', '', NULL),
('KOMS000017', 'AREA000005', 'Kranggan', '', NULL),
('KOMS000018', 'AREA000006', 'Bulak Tinggi', '', NULL),
('KOMS000019', 'AREA000007', 'Glow\'s Home 1', '', NULL),
('KOMS000020', 'AREA000007', 'Glow\'s Home 2', '', NULL),
('KOMS000021', 'AREA000007', 'Blessing 1', '', NULL),
('KOMS000022', 'AREA000007', 'Blessing 2', '', NULL),
('KOMS000023', 'AREA000007', 'Pembina Topkids', '', NULL),
('KOMS000024', 'AREA000008', 'Sukacita', '', NULL);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_pekerjaan`
--

CREATE TABLE `tbl_pekerjaan` (
  `Pekerjaan_ID` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `Pekerjaan` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Keterangan` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `tbl_pekerjaan`
--

INSERT INTO `tbl_pekerjaan` (`Pekerjaan_ID`, `Pekerjaan`, `Keterangan`) VALUES
('PKR0000001', 'Belum/Tidak Bekerja', NULL),
('PKR0000002', 'Pelajar/Mahasiswa', NULL),
('PKR0000003', 'Pegawai Swasta', NULL),
('PKR0000004', 'PNS', 'Pegawai Negri Sipil'),
('PKR0000005', 'Guru', NULL),
('PKR0000006', 'TNI', 'Tentara Nasional Indonesia'),
('PKR0000007', 'Polisi', NULL),
('PKR0000008', 'Wiraswasta', NULL),
('PKR0000009', 'Pendeta', NULL),
('PKR0000010', 'Pensiunan', NULL);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_pendidikan`
--

CREATE TABLE `tbl_pendidikan` (
  `Pendidikan_ID` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `Pendidikan` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Keterangan` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `tbl_pendidikan`
--

INSERT INTO `tbl_pendidikan` (`Pendidikan_ID`, `Pendidikan`, `Keterangan`) VALUES
('PND0000001', 'SD', 'Sekolah Dasar'),
('PND0000002', 'SMP', 'Sekolah Menengah Pertama'),
('PND0000003', 'SMA', 'Sekolah Menengah Atas'),
('PND0000004', 'S1', 'Sarjana'),
('PND0000005', 'S2', 'Magister'),
('PND0000006', 'S3', 'Doktor'),
('PND0000007', 'Profesor', NULL);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_pernikahan`
--

CREATE TABLE `tbl_pernikahan` (
  `ID` varchar(36) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'UUID()',
  `Tanggal_Pernikahan` date DEFAULT NULL,
  `Gereja` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Pendeta` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Catatan_Sipil` bit(1) NOT NULL DEFAULT b'0',
  `No_Surat_Nikah` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Created_By` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Created_Date` datetime NOT NULL,
  `Updated_By` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Updated_Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `tbl_pernikahan`
--

INSERT INTO `tbl_pernikahan` (`ID`, `Tanggal_Pernikahan`, `Gereja`, `Pendeta`, `Catatan_Sipil`, `No_Surat_Nikah`, `Created_By`, `Created_Date`, `Updated_By`, `Updated_Date`) VALUES
('5648a7dc-c611-11ed-a33a-f8e4e3b3522b', '1992-10-20', 'GPIB Nazareth', 'Pdt.Kaligis', b'0', NULL, '', '2023-03-19 05:45:38', '', '2023-03-19 05:45:38'),
('5648bc33-c611-11ed-a33a-f8e4e3b3522b', '2001-03-24', 'GPI Pondok Gede', 'Daniel Dianto', b'0', NULL, '', '2023-03-19 05:45:38', '', '2023-03-19 05:45:38');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_pernikahan_detail`
--

CREATE TABLE `tbl_pernikahan_detail` (
  `ID` varchar(36) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'UUID()',
  `ID_Pernikahan` varchar(36) COLLATE utf8_unicode_ci NOT NULL,
  `ID_Jemaat` varchar(36) COLLATE utf8_unicode_ci NOT NULL,
  `Anggota_Gereja` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Created_By` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Created_Date` datetime NOT NULL,
  `Updated_By` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Updated_Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `tbl_pernikahan_detail`
--

INSERT INTO `tbl_pernikahan_detail` (`ID`, `ID_Pernikahan`, `ID_Jemaat`, `Anggota_Gereja`, `Created_By`, `Created_Date`, `Updated_By`, `Updated_Date`) VALUES
('91f04480-c612-11ed-a33a-f8e4e3b3522b', '5648bc33-c611-11ed-a33a-f8e4e3b3522b', '3f0cd334-c60e-11ed-a33a-f8e4e3b3522b', 'GPI PETRA', '', '2023-03-19 05:52:45', '', '2023-03-19 05:52:45'),
('91f056a4-c612-11ed-a33a-f8e4e3b3522b', '5648bc33-c611-11ed-a33a-f8e4e3b3522b', '6c1beeed-c612-11ed-a33a-f8e4e3b3522b', 'GPI PETRA', '', '2023-03-19 05:52:45', '', '2023-03-19 05:52:45'),
('de61ca5f-c611-11ed-a33a-f8e4e3b3522b', '5648a7dc-c611-11ed-a33a-f8e4e3b3522b', '0b098544-c60b-11ed-a33a-f8e4e3b3522b', 'GPI PETRA', '', '2023-03-19 05:50:27', '', '2023-03-19 05:50:27'),
('de61dc94-c611-11ed-a33a-f8e4e3b3522b', '5648a7dc-c611-11ed-a33a-f8e4e3b3522b', '0b09c08e-c60b-11ed-a33a-f8e4e3b3522b', 'GPI PETRA', '', '2023-03-19 05:50:27', '', '2023-03-19 05:50:27');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_status_anggota`
--

CREATE TABLE `tbl_status_anggota` (
  `Status_Anggota_ID` varchar(2) COLLATE utf8_unicode_ci NOT NULL,
  `Status_Anggota` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Keterangan` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `tbl_status_anggota`
--

INSERT INTO `tbl_status_anggota` (`Status_Anggota_ID`, `Status_Anggota`, `Keterangan`) VALUES
('A', 'Anak', NULL),
('D', 'Dewasa', NULL),
('L', 'Usia Lanjut', NULL),
('P', 'Pemuda ', NULL),
('R', 'Remaja', NULL);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_status_keaktifan`
--

CREATE TABLE `tbl_status_keaktifan` (
  `Status_Keaktifan_ID` varchar(5) COLLATE utf8_unicode_ci NOT NULL,
  `Status_Keaktifan` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Keterangan` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `tbl_status_keaktifan`
--

INSERT INTO `tbl_status_keaktifan` (`Status_Keaktifan_ID`, `Status_Keaktifan`, `Keterangan`) VALUES
('JA', 'Jemaat Aktif', NULL),
('JM', 'Jemaat Meninggal', NULL),
('JS', 'Simpatisan', NULL),
('JX', 'Pindah atau Keluar', NULL),
('TA', 'Jemaat Tidak Aktif', NULL);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_status_pernikahan`
--

CREATE TABLE `tbl_status_pernikahan` (
  `Status_Pernikahan_ID` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `Status_Pernikahan` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Keterangan` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `tbl_status_pernikahan`
--

INSERT INTO `tbl_status_pernikahan` (`Status_Pernikahan_ID`, `Status_Pernikahan`, `Keterangan`) VALUES
('STPER00001', 'Menikah', NULL),
('STPER00002', 'Belum menikah', NULL),
('STPER00003', 'Duda/Janda', NULL);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_user`
--

CREATE TABLE `tbl_user` (
  `User_ID` varchar(36) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'UUID()',
  `User_Name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `User_Email` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `User_Password` varchar(200) COLLATE utf8_unicode_ci NOT NULL,
  `User_Role` varchar(20) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Is_Login` bit(1) NOT NULL DEFAULT b'0',
  `Last_Login` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data untuk tabel `tbl_user`
--

INSERT INTO `tbl_user` (`User_ID`, `User_Name`, `User_Email`, `User_Password`, `User_Role`, `Is_Login`, `Last_Login`) VALUES
('08dc6c2b-757e-42da-8403-76541ee41cca', 'joshua_hutasoit', 'gerald85joshua@gmail.com', '$2a$11$wBtvbEOa7xAIkzreHqnYMuLKTtqA2Gv6LTMRDj4FNfuXMJrrKHLa2', 'User', b'1', '0001-01-01 00:00:00');

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `vw_area`
-- (Lihat di bawah untuk tampilan aktual)
--
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
-- Stand-in struktur untuk tampilan `vw_hut`
-- (Lihat di bawah untuk tampilan aktual)
--
CREATE TABLE `vw_hut` (
`KTP` varchar(16)
,`Nama_Lengkap` varchar(100)
,`Alamat` varchar(200)
,`No_HP` varchar(20)
,`Tanggal_Lahir` date
,`Umur` int(5)
);

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `vw_hut_pernikahan`
-- (Lihat di bawah untuk tampilan aktual)
--
CREATE TABLE `vw_hut_pernikahan` (
`Nama` mediumtext
,`Alamat` mediumtext
,`No_HP` mediumtext
,`Tanggal_Pernikahan` date
,`Usia_Pernikahan` int(5)
);

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `vw_jemaat`
-- (Lihat di bawah untuk tampilan aktual)
--
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
);

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `vw_komsel`
-- (Lihat di bawah untuk tampilan aktual)
--
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
-- Stand-in struktur untuk tampilan `vw_pernikahan`
-- (Lihat di bawah untuk tampilan aktual)
--
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
-- Stand-in struktur untuk tampilan `vw_pernikahan_detail`
-- (Lihat di bawah untuk tampilan aktual)
--
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

-- --------------------------------------------------------

--
-- Struktur untuk view `ddl_area`
--
DROP TABLE IF EXISTS `ddl_area`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ddl_area`  AS SELECT `tbl_area`.`Area` AS `Text`, `tbl_area`.`Area_ID` AS `Value` FROM `tbl_area` ;

-- --------------------------------------------------------

--
-- Struktur untuk view `ddl_jemaat`
--
DROP TABLE IF EXISTS `ddl_jemaat`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ddl_jemaat`  AS SELECT `j`.`Nama_Lengkap` AS `TEXT`, `j`.`ID` AS `VALUE` FROM `tbl_jemaat` AS `j` ;

-- --------------------------------------------------------

--
-- Struktur untuk view `ddl_kelompok_ibadah`
--
DROP TABLE IF EXISTS `ddl_kelompok_ibadah`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ddl_kelompok_ibadah`  AS SELECT `tbl_kelompok_ibadah`.`Kelompok_Ibadah` AS `Text`, `tbl_kelompok_ibadah`.`Kelompok_Ibadah_ID` AS `Value` FROM `tbl_kelompok_ibadah` ;

-- --------------------------------------------------------

--
-- Struktur untuk view `ddl_komsel`
--
DROP TABLE IF EXISTS `ddl_komsel`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ddl_komsel`  AS SELECT `tbl_komsel`.`Komsel` AS `Text`, `tbl_komsel`.`Komsel_ID` AS `Value` FROM `tbl_komsel` ;

-- --------------------------------------------------------

--
-- Struktur untuk view `ddl_pekerjaan`
--
DROP TABLE IF EXISTS `ddl_pekerjaan`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ddl_pekerjaan`  AS SELECT `tbl_pekerjaan`.`Pekerjaan` AS `Text`, `tbl_pekerjaan`.`Pekerjaan_ID` AS `Value` FROM `tbl_pekerjaan` ;

-- --------------------------------------------------------

--
-- Struktur untuk view `ddl_pendidikan`
--
DROP TABLE IF EXISTS `ddl_pendidikan`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ddl_pendidikan`  AS SELECT `tbl_pendidikan`.`Pendidikan` AS `Text`, `tbl_pendidikan`.`Pendidikan_ID` AS `Value` FROM `tbl_pendidikan` ;

-- --------------------------------------------------------

--
-- Struktur untuk view `ddl_status_anggota`
--
DROP TABLE IF EXISTS `ddl_status_anggota`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ddl_status_anggota`  AS SELECT `tbl_status_anggota`.`Status_Anggota` AS `Text`, `tbl_status_anggota`.`Status_Anggota_ID` AS `Value` FROM `tbl_status_anggota` ;

-- --------------------------------------------------------

--
-- Struktur untuk view `ddl_status_keaktifan`
--
DROP TABLE IF EXISTS `ddl_status_keaktifan`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ddl_status_keaktifan`  AS SELECT `tbl_status_keaktifan`.`Status_Keaktifan` AS `Text`, `tbl_status_keaktifan`.`Status_Keaktifan_ID` AS `Value` FROM `tbl_status_keaktifan` ;

-- --------------------------------------------------------

--
-- Struktur untuk view `ddl_status_pernikahan`
--
DROP TABLE IF EXISTS `ddl_status_pernikahan`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ddl_status_pernikahan`  AS SELECT `tbl_status_pernikahan`.`Status_Pernikahan` AS `Text`, `tbl_status_pernikahan`.`Status_Pernikahan_ID` AS `Value` FROM `tbl_status_pernikahan` ;

-- --------------------------------------------------------

--
-- Struktur untuk view `vw_area`
--
DROP TABLE IF EXISTS `vw_area`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_area`  AS SELECT `a`.`Area_ID` AS `Area_ID`, `a`.`Area` AS `Area`, `a`.`PIC_ID` AS `PIC_ID`, `j`.`Nama_Panggilan` AS `Nama_Panggilan_PIC`, `j`.`Nama_Lengkap` AS `Nama_Lengkap_PIC`, `a`.`Keterangan` AS `Keterangan` FROM (`tbl_area` `a` left join `tbl_jemaat` `j` on(`a`.`PIC_ID` = `j`.`ID`)) ;

-- --------------------------------------------------------

--
-- Struktur untuk view `vw_hut`
--
DROP TABLE IF EXISTS `vw_hut`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_hut`  AS SELECT `tbl_jemaat`.`KTP` AS `KTP`, `tbl_jemaat`.`Nama_Lengkap` AS `Nama_Lengkap`, `tbl_jemaat`.`Alamat` AS `Alamat`, `tbl_jemaat`.`No_HP` AS `No_HP`, `tbl_jemaat`.`Tanggal_Lahir` AS `Tanggal_Lahir`, year(curdate()) - year(`tbl_jemaat`.`Tanggal_Lahir`) AS `Umur` FROM `tbl_jemaat` ;

-- --------------------------------------------------------

--
-- Struktur untuk view `vw_hut_pernikahan`
--
DROP TABLE IF EXISTS `vw_hut_pernikahan`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_hut_pernikahan`  AS SELECT group_concat(`select_pd`.`Nama_Lengkap` separator ' - ') AS `Nama`, group_concat(`select_pd`.`Alamat` separator ' - ') AS `Alamat`, group_concat(`select_pd`.`No_HP` separator ' - ') AS `No_HP`, `p`.`Tanggal_Pernikahan` AS `Tanggal_Pernikahan`, year(curdate()) - year(`p`.`Tanggal_Pernikahan`) AS `Usia_Pernikahan` FROM (`tbl_pernikahan` `p` left join (select `pd`.`ID_Pernikahan` AS `ID_Pernikahan`,`j`.`Nama_Lengkap` AS `Nama_Lengkap`,`j`.`Alamat` AS `Alamat`,`j`.`No_HP` AS `No_HP` from (`tbl_pernikahan_detail` `pd` left join `tbl_jemaat` `j` on(`j`.`ID` = `pd`.`ID_Jemaat`)) order by `j`.`Jenis_Kelamin`) `select_pd` on(`select_pd`.`ID_Pernikahan` = `p`.`ID`)) GROUP BY `p`.`Tanggal_Pernikahan`, year(curdate()) - year(`p`.`Tanggal_Pernikahan`) ;

-- --------------------------------------------------------

--
-- Struktur untuk view `vw_jemaat`
--
DROP TABLE IF EXISTS `vw_jemaat`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_jemaat`  AS SELECT `j`.`ID` AS `ID`, `j`.`KTP` AS `KTP`, `j`.`Nama_Lengkap` AS `Nama_Lengkap`, `j`.`Nama_Panggilan` AS `Nama_Panggilan`, `j`.`Jenis_Kelamin` AS `Jenis_Kelamin`, `j`.`Pendidikan_Terakhir` AS `Pendidikan_Terakhir`, `j`.`Pekerjaan` AS `Pekerjaan`, `j`.`Alamat` AS `Alamat`, `j`.`Status_Anggota_ID` AS `Status_Anggota_ID`, `sa`.`Status_Anggota` AS `Status_Anggota`, `j`.`Status_Keaktifan_ID` AS `Status_Keaktifan_ID`, `sk`.`Status_Keaktifan` AS `Status_Keaktifan`, `j`.`Kelompok_Ibadah_ID` AS `Kelompok_Ibadah_ID`, `ki`.`Kelompok_Ibadah` AS `Kelompok_Ibadah`, `j`.`Komsel_ID` AS `Komsel_ID`, `k`.`Komsel` AS `Komsel`, `j`.`Tempat_Lahir` AS `Tempat_Lahir`, `j`.`Tanggal_Lahir` AS `Tanggal_Lahir`, `j`.`Golongan_Darah` AS `Golongan_Darah`, `j`.`Bersedia_Donor_Darah` AS `Bersedia_Donor_Darah`, `j`.`No_HP` AS `No_HP`, `j`.`Alamat_Email` AS `Alamat_Email`, `j`.`Status_Pernikahan_ID` AS `Status_Pernikahan_ID`, `sp`.`Status_Pernikahan` AS `Status_Pernikahan`, `pd`.`ID_Pernikahan` AS `ID_Pernikahan`, `kd`.`ID_Keluarga` AS `ID_Keluarga` FROM (((((((`tbl_jemaat` `j` left join `tbl_status_anggota` `sa` on(`sa`.`Status_Anggota_ID` = `j`.`Status_Anggota_ID`)) left join `tbl_status_keaktifan` `sk` on(`sk`.`Status_Keaktifan_ID` = `j`.`Status_Keaktifan_ID`)) left join `tbl_kelompok_ibadah` `ki` on(`ki`.`Kelompok_Ibadah_ID` = `j`.`Kelompok_Ibadah_ID`)) left join `tbl_komsel` `k` on(`k`.`Komsel_ID` = `j`.`Komsel_ID`)) left join `tbl_status_pernikahan` `sp` on(`sp`.`Status_Pernikahan_ID` = `j`.`Status_Pernikahan_ID`)) left join `tbl_pernikahan_detail` `pd` on(`pd`.`ID_Jemaat` = `j`.`ID`)) left join `tbl_keluarga_detail` `kd` on(`kd`.`ID_Jemaat` = `j`.`ID`)) ;

-- --------------------------------------------------------

--
-- Struktur untuk view `vw_komsel`
--
DROP TABLE IF EXISTS `vw_komsel`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_komsel`  AS SELECT `k`.`Komsel_ID` AS `Komsel_ID`, `k`.`Komsel` AS `Komsel`, `k`.`Area_ID` AS `Area_ID`, `a`.`Area` AS `Area`, `k`.`PIC_ID` AS `PIC_ID`, `j`.`Nama_Panggilan` AS `Nama_Panggilan_PIC`, `j`.`Nama_Lengkap` AS `Nama_Lengkap_PIC`, `k`.`Keterangan` AS `Keterangan` FROM ((`tbl_komsel` `k` left join `tbl_area` `a` on(`k`.`Area_ID` = `a`.`Area_ID`)) left join `tbl_jemaat` `j` on(`k`.`PIC_ID` = `j`.`ID`)) ;

-- --------------------------------------------------------

--
-- Struktur untuk view `vw_pernikahan`
--
DROP TABLE IF EXISTS `vw_pernikahan`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_pernikahan`  AS SELECT `p`.`ID` AS `ID`, group_concat(`pdj`.`Nama_Panggilan` order by `pdj`.`Jenis_Kelamin` ASC separator ' - ') AS `Pasangan`, `p`.`Tanggal_Pernikahan` AS `Tanggal_Pernikahan`, `p`.`Gereja` AS `gereja`, `p`.`Pendeta` AS `pendeta`, `p`.`Catatan_Sipil` AS `catatan_sipil`, `p`.`No_Surat_Nikah` AS `no_surat_nikah` FROM (`tbl_pernikahan` `p` join (select `pd`.`ID_Pernikahan` AS `ID_Pernikahan`,`j`.`Nama_Panggilan` AS `Nama_Panggilan`,`j`.`Jenis_Kelamin` AS `Jenis_Kelamin` from (`tbl_pernikahan_detail` `pd` left join `tbl_jemaat` `j` on(`pd`.`ID_Jemaat` = `j`.`ID`))) `pdj` on(`p`.`ID` = `pdj`.`ID_Pernikahan`)) GROUP BY `p`.`ID`, `p`.`Tanggal_Pernikahan` ;

-- --------------------------------------------------------

--
-- Struktur untuk view `vw_pernikahan_detail`
--
DROP TABLE IF EXISTS `vw_pernikahan_detail`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_pernikahan_detail`  AS SELECT `pd`.`ID` AS `ID`, `pd`.`ID_Pernikahan` AS `ID_Pernikahan`, `pd`.`ID_Jemaat` AS `ID_Jemaat`, `j`.`Nama_Lengkap` AS `Nama_Lengkap`, `j`.`Jenis_Kelamin` AS `Jenis_Kelamin`, `j`.`Status_Keaktifan_ID` AS `Status_Keaktifan_ID`, `sk`.`Status_Keaktifan` AS `Status_Keaktifan`, `pd`.`Anggota_Gereja` AS `Anggota_Gereja` FROM ((`tbl_pernikahan_detail` `pd` left join `tbl_jemaat` `j` on(`pd`.`ID_Jemaat` = `j`.`ID`)) left join `tbl_status_keaktifan` `sk` on(`j`.`Status_Keaktifan_ID` = `sk`.`Status_Keaktifan_ID`)) ;

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `tbl_area`
--
ALTER TABLE `tbl_area`
  ADD PRIMARY KEY (`Area_ID`);

--
-- Indeks untuk tabel `tbl_jemaat`
--
ALTER TABLE `tbl_jemaat`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `KTP` (`KTP`);

--
-- Indeks untuk tabel `tbl_kelompok_ibadah`
--
ALTER TABLE `tbl_kelompok_ibadah`
  ADD PRIMARY KEY (`Kelompok_Ibadah_ID`);

--
-- Indeks untuk tabel `tbl_keluarga`
--
ALTER TABLE `tbl_keluarga`
  ADD PRIMARY KEY (`ID`);

--
-- Indeks untuk tabel `tbl_keluarga_detail`
--
ALTER TABLE `tbl_keluarga_detail`
  ADD PRIMARY KEY (`ID`);

--
-- Indeks untuk tabel `tbl_komsel`
--
ALTER TABLE `tbl_komsel`
  ADD PRIMARY KEY (`Komsel_ID`);

--
-- Indeks untuk tabel `tbl_pekerjaan`
--
ALTER TABLE `tbl_pekerjaan`
  ADD PRIMARY KEY (`Pekerjaan_ID`);

--
-- Indeks untuk tabel `tbl_pendidikan`
--
ALTER TABLE `tbl_pendidikan`
  ADD PRIMARY KEY (`Pendidikan_ID`);

--
-- Indeks untuk tabel `tbl_pernikahan`
--
ALTER TABLE `tbl_pernikahan`
  ADD PRIMARY KEY (`ID`);

--
-- Indeks untuk tabel `tbl_pernikahan_detail`
--
ALTER TABLE `tbl_pernikahan_detail`
  ADD PRIMARY KEY (`ID`);

--
-- Indeks untuk tabel `tbl_status_anggota`
--
ALTER TABLE `tbl_status_anggota`
  ADD PRIMARY KEY (`Status_Anggota_ID`);

--
-- Indeks untuk tabel `tbl_status_keaktifan`
--
ALTER TABLE `tbl_status_keaktifan`
  ADD PRIMARY KEY (`Status_Keaktifan_ID`);

--
-- Indeks untuk tabel `tbl_status_pernikahan`
--
ALTER TABLE `tbl_status_pernikahan`
  ADD PRIMARY KEY (`Status_Pernikahan_ID`);

--
-- Indeks untuk tabel `tbl_user`
--
ALTER TABLE `tbl_user`
  ADD PRIMARY KEY (`User_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
