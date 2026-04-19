-- 1. Tabel Kategori
CREATE TABLE kategori (
    id SERIAL PRIMARY KEY,
    nama_kategori VARCHAR(100) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 2. Tabel Buku
CREATE TABLE buku (
    id SERIAL PRIMARY KEY,
    kategori_id INT NOT NULL,
    judul VARCHAR(255) NOT NULL,
    penulis VARCHAR(150) NOT NULL,
    harga DECIMAL(10, 2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    deleted_at TIMESTAMP NULL, -- Penerapan soft delete
    CONSTRAINT fk_kategori FOREIGN KEY (kategori_id) REFERENCES kategori(id) ON DELETE RESTRICT
);

-- Membuat Index untuk kolom yang sering di-filter (pencarian judul buku)
CREATE INDEX idx_judul_buku ON buku(judul);

-- 3. Tabel Peminjaman
CREATE TABLE peminjaman (
    id SERIAL PRIMARY KEY,
    buku_id INT NOT NULL,
    nama_peminjam VARCHAR(150) NOT NULL,
    tanggal_pinjam DATE NOT NULL,
    status VARCHAR(50) DEFAULT 'Dipinjam',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_buku FOREIGN KEY (buku_id) REFERENCES buku(id) ON DELETE CASCADE
);


-- Insert Kategori
INSERT INTO kategori (nama_kategori) VALUES 
('Fiksi'), ('Teknologi'), ('Sejarah'), ('Sains'), ('Bisnis');

-- Insert Buku
INSERT INTO buku (kategori_id, judul, penulis, harga) VALUES 
(1, 'Laskar Pelangi', 'Andrea Hirata', 75000),
(2, 'Belajar C# untuk Pemula', 'Budi Raharjo', 120000),
(2, 'Mastering PostgreSQL', 'John Doe', 150000),
(3, 'Sapiens', 'Yuval Noah Harari', 130000),
(5, 'Atomic Habits', 'James Clear', 110000);

-- Insert Peminjaman
INSERT INTO peminjaman (buku_id, nama_peminjam, tanggal_pinjam, status) VALUES 
(1, 'Andi Suryo', '2023-10-01', 'Dikembalikan'),
(2, 'Budi Santoso', '2023-10-05', 'Dipinjam'),
(3, 'Citra Lestari', '2023-10-10', 'Dipinjam'),
(4, 'Dewi Anggraini', '2023-10-12', 'Dikembalikan'),
(5, 'Eko Prasetyo', '2023-10-15', 'Dipinjam');