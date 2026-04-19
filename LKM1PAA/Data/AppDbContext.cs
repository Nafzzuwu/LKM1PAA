using LKM1PAA.Models;
using Microsoft.EntityFrameworkCore;

namespace LKM1PAA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Mendaftarkan tabel-tabel ke EF Core
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Buku> Bukus { get; set; }
        public DbSet<Peminjaman> Peminjamans { get; set; }
    }
}