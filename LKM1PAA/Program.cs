using LKM1PAA.Data; // Tambahkan using ini di paling atas
using Microsoft.EntityFrameworkCore; // Tambahkan using ini juga

var builder = WebApplication.CreateBuilder(args);

// === TAMBAHKAN BARIS INI UNTUK KONEKSI DATABASE ===
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// ===================================================

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();