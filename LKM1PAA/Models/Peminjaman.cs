using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LKM1PAA.Models
{
    [Table("peminjaman")]
    public class Peminjaman
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("buku_id")]
        public int BukuId { get; set; }

        [Required]
        [Column("nama_peminjam")]
        public string NamaPeminjam { get; set; } = string.Empty;

        [Required]
        [Column("tanggal_pinjam")]
        public DateTime TanggalPinjam { get; set; }

        [Column("status")]
        public string Status { get; set; } = "Dipinjam";

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // Relasi ke Buku
        [ForeignKey("BukuId")]
        [JsonIgnore]
        public Buku? Buku { get; set; }
    }
}