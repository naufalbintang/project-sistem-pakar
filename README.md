# 🎓 Sistem Pakar Penentuan Topik Skripsi (Thesis Matcher)

Project ini adalah aplikasi desktop berbasis Sistem Pakar untuk membantu mahasiswa Teknik Informatika menentukan topik/peminatan skripsi yang sesuai dengan minat dan kemampuan teknis mereka.

Dibangun dengan pendekatan *Hybrid*: Menggunakan **Visual Basic .NET** sebagai antarmuka pengguna (UI) dan **Python** sebagai mesin inferensi (logika perhitungan).

## 🚀 Fitur Utama
- **User Authentication:** Login dan Register sederhana menggunakan NIM.
- **Interactive Questionnaire:** Pertanyaan diagnosa mencakup bidang RPL, AI, Jaringan, dan IoT.
- **Hybrid Architecture:** VB.NET menangani UI/UX, Python menangani pemrosesan logika.
- **Instant Recommendation:** Hasil rekomendasi peminatan muncul secara *real-time* setelah tes.
- **History Log:** Riwayat tes tersimpan di database.

## 🛠️ Teknologi yang Digunakan
- **Frontend:** Visual Basic .NET (Windows Forms Application).
- **Backend Logic:** Python 3.x.
- **Database:** MySQL.
- **Communication:** CLI Arguments & JSON Parsing.

## 📋 Prasyarat (Prerequisites)
Sebelum menjalankan aplikasi, pastikan komputer Anda memiliki:
1.  **Visual Studio** (Versi 2019/2022) dengan workload *.NET Desktop Development*.
2.  **Python 3.x** (Pastikan dicentang "Add Python to PATH" saat instalasi).
3.  **XAMPP** (atau server MySQL lainnya).
4.  **MySQL Connector for .NET** (Agar VB bisa terkoneksi ke MySQL).

## ⚙️ Cara Instalasi & Menjalankan

### 1. Setup Database
1. Nyalakan modul **Apache** dan **MySQL** di XAMPP.
2. Buka `phpMyAdmin` atau tool database lainnya.
3. Buat database baru dengan nama `db_skripsi_lite`.
4. Import file SQL yang ada di folder `/database/db_skripsi_lite.sql` (atau jalankan query manual yang tersedia).

### 2. Konfigurasi Python
Pastikan script Python dapat dijalankan melalui CMD. Coba jalankan perintah berikut di terminal untuk memastikan tidak ada library yang kurang:
```bash
python logic.py
