using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LKM1PAA.Models
{
    [Table("buku")]
    public class Buku
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("kategori_id")]
        public int KategoriId { get; set; }

        [Required]
        [Column("judul")]
        public string Judul { get; set; } = string.Empty;

        [Required]
        [Column("penulis")]
        public string Penulis { get; set; } = string.Empty;

        [Required]
        [Column("harga")]
        public decimal Harga { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        // Relasi ke Kategori
        [ForeignKey("KategoriId")]
        [JsonIgnore] // Agar tidak looping saat response JSON
        public Kategori? Kategori { get; set; }
    }
}