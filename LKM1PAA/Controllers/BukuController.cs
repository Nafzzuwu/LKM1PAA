using LKM1PAA.Data;
using LKM1PAA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LKM1PAA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BukuController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BukuController(AppDbContext context)
        {
            _context = context;
        }

        // 1. READ ALL (GET List)
        // Endpoint: GET /api/buku
        [HttpGet]
        public async Task<IActionResult> GetAllBuku()
        {
            try
            {
                // Hanya mengambil data yang belum di-soft delete
                var bukus = await _context.Bukus
                    .Where(b => b.DeletedAt == null)
                    .ToListAsync();

                return Ok(new { status = "success", data = bukus });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Terjadi kesalahan server: {ex.Message}" });
            }
        }

        // 2. READ DETAIL (GET by ID)
        // Endpoint: GET /api/buku/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBukuById(int id)
        {
            try
            {
                var buku = await _context.Bukus
                    .FirstOrDefaultAsync(b => b.Id == id && b.DeletedAt == null);

                if (buku == null)
                {
                    return NotFound(new { status = "error", message = "Data buku tidak ditemukan" });
                }

                return Ok(new { status = "success", data = buku });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Terjadi kesalahan server: {ex.Message}" });
            }
        }

        // 3. CREATE (POST)
        // Endpoint: POST /api/buku
        [HttpPost]
        public async Task<IActionResult> CreateBuku([FromBody] Buku newBuku)
        {
            try
            {
                // Validasi manual sederhana
                if (string.IsNullOrWhiteSpace(newBuku.Judul) || string.IsNullOrWhiteSpace(newBuku.Penulis))
                {
                    return BadRequest(new { status = "error", message = "Judul dan Penulis tidak boleh kosong" });
                }

                newBuku.CreatedAt = DateTime.UtcNow;
                newBuku.UpdatedAt = DateTime.UtcNow;

                _context.Bukus.Add(newBuku);
                await _context.SaveChangesAsync();

                return StatusCode(201, new { status = "success", data = newBuku });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Gagal menambahkan data: {ex.Message}" });
            }
        }

        // 4. UPDATE (PUT)
        // Endpoint: PUT /api/buku/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBuku(int id, [FromBody] Buku updatedBuku)
        {
            try
            {
                var buku = await _context.Bukus.FirstOrDefaultAsync(b => b.Id == id && b.DeletedAt == null);

                if (buku == null)
                {
                    return NotFound(new { status = "error", message = "Data buku tidak ditemukan untuk diupdate" });
                }

                // Update field
                buku.KategoriId = updatedBuku.KategoriId;
                buku.Judul = updatedBuku.Judul;
                buku.Penulis = updatedBuku.Penulis;
                buku.Harga = updatedBuku.Harga;
                buku.UpdatedAt = DateTime.UtcNow; // Update timestamp

                await _context.SaveChangesAsync();

                return Ok(new { status = "success", data = buku });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Gagal mengupdate data: {ex.Message}" });
            }
        }

        // 5. DELETE (Soft Delete)
        // Endpoint: DELETE /api/buku/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuku(int id)
        {
            try
            {
                var buku = await _context.Bukus.FirstOrDefaultAsync(b => b.Id == id && b.DeletedAt == null);

                if (buku == null)
                {
                    return NotFound(new { status = "error", message = "Data buku tidak ditemukan atau sudah dihapus" });
                }

                // Implementasi Soft Delete: Set DeletedAt, bukan menghapus fisik dari DB
                buku.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                return Ok(new { status = "success", message = "Data buku berhasil dihapus (Soft Delete)" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Gagal menghapus data: {ex.Message}" });
            }
        }
    }
}