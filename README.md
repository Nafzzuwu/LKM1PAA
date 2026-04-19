# LKM 1 PAA - REST API Sistem Perpustakaan Sederhana

**Oleh:** [Nafariel Dwi Ambariyono] - [242410102071]

---

## a) Deskripsi Singkat Project & Domain
Project ini adalah sebuah REST API untuk **Sistem Perpustakaan Sederhana**. Domain ini dipilih karena memiliki alur pencatatan data dan relasi entitas yang jelas (Kategori, Buku, dan Peminjaman). API ini dirancang untuk menangani operasi CRUD (Create, Read, Update, Delete) dasar pada entitas buku, lengkap dengan fitur validasi, relasi antar tabel (Foreign Key), serta implementasi *Soft Delete* untuk menjaga integritas data riwayat.

## b) Teknologi yang Digunakan
* **Bahasa Pemrograman:** C#
* **Framework:** ASP.NET Core Web API (.NET 8)
* **Database:** PostgreSQL
* **ORM:** Entity Framework Core (EF Core)
* **Tools Tambahan:** Visual Studio 2022, pgAdmin 4, Swagger UI

## c) Langkah Instalasi dan Cara Menjalankan Project
1. **Clone Repository:**
   Buka terminal atau command prompt, lalu jalankan perintah berikut:
   ```bash
   git clone https://github.com/Nafzzuwu/LKM1PAA
2. **Buka Project:** Buka folder hasil clone, lalu klik ganda pada file LKM1PAA.sln untuk membukanya di Visual Studio 2022.

3. **Konfigurasi Database:** Buka file appsettings.json di dalam Visual Studio. Cari bagian ConnectionStrings dan ubah nilai Password agar sesuai dengan password user postgres di komputer lokalmu.
4. **Jalankan Aplikasi:** Tekan tombol Play (atau tekan F5) di Visual Studio. Browser akan otomatis terbuka dan mengarahkanmu ke halaman antarmuka Swagger untuk mencoba API.

## d) Cara Import Database
Project ini sudah menyertakan file database.sql yang berisi struktur tabel (DDL) dan sample data (DML). Berikut cara importnya:
1. Buka aplikasi pgAdmin.
2. Buat database baru dengan nama lkm1_paa_db.
3. Klik kanan pada database lkm1_paa_db tersebut, lalu pilih Query Tool.
4. Buka file database.sql yang ada di dalam folder project ini, copy seluruh isinya, lalu paste ke dalam layar Query Tool di pgAdmin.
5. Klik tombol Execute (ikon Play) atau tekan F5 di keyboard untuk menjalankan script.
6. Database beserta tabel dan datanya akan dapat digunakan.

## e) Daftar Endpoint Lengkap
Berikut adalah daftar endpoint API yang tersedia pada project ini beserta fungsinya:

GET,/api/buku,Menampilkan seluruh list data buku. Data yang sudah dihapus (soft delete) tidak akan ditampilkan.
GET,/api/buku/{id},Menampilkan detail spesifik data buku berdasarkan parameter ID. Mengembalikan 404 jika tidak ditemukan.
POST,/api/buku,Menambahkan data buku baru ke dalam database. Membutuhkan body request berupa format JSON.
PUT,/api/buku/{id},Memperbarui keseluruhan data buku berdasarkan ID spesifik. Membutuhkan body request berupa format JSON.
DELETE,/api/buku/{id},Menghapus data buku berdasarkan ID. Menggunakan metode Soft Delete (mengisi field deleted_at tanpa menghapus baris fisik di database).

