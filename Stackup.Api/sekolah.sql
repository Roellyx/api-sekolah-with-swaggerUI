-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 24 Nov 2023 pada 06.56
-- Versi server: 10.4.28-MariaDB
-- Versi PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sekolah`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `hari_pelajaran`
--

CREATE TABLE `hari_pelajaran` (
  `id_hari` int(11) NOT NULL,
  `kode_hari` varchar(10) NOT NULL,
  `hari` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `hari_pelajaran`
--

INSERT INTO `hari_pelajaran` (`id_hari`, `kode_hari`, `hari`) VALUES
(1, 'H001', 'senin'),
(2, 'H002', 'selasa'),
(3, 'H003', 'rabu'),
(4, 'H004', 'kamis'),
(5, 'H005', 'jum\'at');

-- --------------------------------------------------------

--
-- Struktur dari tabel `jam_pelajaran`
--

CREATE TABLE `jam_pelajaran` (
  `id_jam` int(11) NOT NULL,
  `kode_jam` varchar(10) NOT NULL,
  `jam_mulai` varchar(10) NOT NULL,
  `jam_akhir` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `jam_pelajaran`
--

INSERT INTO `jam_pelajaran` (`id_jam`, `kode_jam`, `jam_mulai`, `jam_akhir`) VALUES
(1, 'J001', '07:45', '10:00'),
(2, 'J002', '10:30', '12:00'),
(3, 'J003', '13:00', '14:30');

-- --------------------------------------------------------

--
-- Struktur dari tabel `kelas`
--

CREATE TABLE `kelas` (
  `id_kelas` int(11) NOT NULL,
  `kode_kelas` varchar(10) NOT NULL,
  `kelas` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `kelas`
--

INSERT INTO `kelas` (`id_kelas`, `kode_kelas`, `kelas`) VALUES
(1, 'K001', '10'),
(2, 'K002', '11'),
(3, 'K003', '12');

-- --------------------------------------------------------

--
-- Struktur dari tabel `pelajaran`
--

CREATE TABLE `pelajaran` (
  `id_mapel` int(11) NOT NULL,
  `kode_mapel` varchar(11) NOT NULL,
  `mata_pelajaran` varchar(100) NOT NULL,
  `nama_guru` varchar(100) NOT NULL,
  `kode_jam` varchar(10) NOT NULL,
  `kode_hari` varchar(10) NOT NULL,
  `kode_kelas` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `pelajaran`
--

INSERT INTO `pelajaran` (`id_mapel`, `kode_mapel`, `mata_pelajaran`, `nama_guru`, `kode_jam`, `kode_hari`, `kode_kelas`) VALUES
(1, 'M001', 'Matematika ', 'susilo', 'J001', 'H001', 'K001'),
(2, 'M001', 'bahasa indo', 'wiwik', 'J002', 'H001', 'K001'),
(3, 'M002', 'Bahasa inggris', 'budi', 'J001', 'H001', 'K003');

-- --------------------------------------------------------

--
-- Struktur dari tabel `siswa`
--

CREATE TABLE `siswa` (
  `id_siswa` varchar(11) NOT NULL,
  `kode_mapel` varchar(10) NOT NULL,
  `nama_siswa` varchar(100) NOT NULL,
  `kode_kelas` varchar(10) NOT NULL,
  `jurusan` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `siswa`
--

INSERT INTO `siswa` (`id_siswa`, `kode_mapel`, `nama_siswa`, `kode_kelas`, `jurusan`) VALUES
('S001', 'M002', 'Maya', 'K003', 'RPL'),
('S002', 'M001', 'Rudi', 'K001', 'mesin');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `hari_pelajaran`
--
ALTER TABLE `hari_pelajaran`
  ADD PRIMARY KEY (`id_hari`);

--
-- Indeks untuk tabel `jam_pelajaran`
--
ALTER TABLE `jam_pelajaran`
  ADD PRIMARY KEY (`id_jam`);

--
-- Indeks untuk tabel `kelas`
--
ALTER TABLE `kelas`
  ADD PRIMARY KEY (`id_kelas`);

--
-- Indeks untuk tabel `pelajaran`
--
ALTER TABLE `pelajaran`
  ADD PRIMARY KEY (`id_mapel`),
  ADD KEY `kode_jam` (`kode_jam`),
  ADD KEY `kode_hari` (`kode_hari`),
  ADD KEY `kode_kelas` (`kode_kelas`);

--
-- Indeks untuk tabel `siswa`
--
ALTER TABLE `siswa`
  ADD PRIMARY KEY (`id_siswa`),
  ADD UNIQUE KEY `kode_kelas` (`kode_kelas`),
  ADD KEY `id_detail` (`kode_mapel`),
  ADD KEY `nama_detail` (`kode_mapel`),
  ADD KEY `kode_mapel` (`kode_mapel`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `hari_pelajaran`
--
ALTER TABLE `hari_pelajaran`
  MODIFY `id_hari` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT untuk tabel `jam_pelajaran`
--
ALTER TABLE `jam_pelajaran`
  MODIFY `id_jam` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT untuk tabel `kelas`
--
ALTER TABLE `kelas`
  MODIFY `id_kelas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT untuk tabel `pelajaran`
--
ALTER TABLE `pelajaran`
  MODIFY `id_mapel` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
