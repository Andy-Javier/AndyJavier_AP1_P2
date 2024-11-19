using AndyJavier_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace AndyJavier_AP1_P2.DAL;
public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : 
        base(options) { }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<Combos> Combos { get; set; }
    public DbSet<CombosDetalle> CombosDetalle { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Productos>().HasData(
            new Productos { ProductoId = 1, Descripcion = "Procesador Ryzen 5 5600X", Costo = 105m, Precio = 300m, Existencia = 8 },
            new Productos { ProductoId = 2, Descripcion = "RAM Corsair DDR4 2x16 GB", Costo = 82m, Precio = 200m, Existencia = 10 },
            new Productos { ProductoId = 3, Descripcion = "Almacenamiento NVME4.0 1TB Samsung", Costo = 100m, Precio = 200m, Existencia = 15 },
            new Productos { ProductoId = 4, Descripcion = "Grafica NVIDIA RTX 4060", Costo = 305m, Precio = 500m, Existencia = 3 },
            new Productos { ProductoId = 5, Descripcion = "Case Lian Li Black", Costo = 160m, Precio = 280m, Existencia = 4 },
            new Productos { ProductoId = 6, Descripcion = "Mouse Razer", Costo = 60m, Precio = 100m, Existencia = 28 },
            new Productos { ProductoId = 7, Descripcion = "Power Supply Redragon 850W 80+G", Costo = 115m, Precio = 280m, Existencia = 5 },
            new Productos { ProductoId = 8, Descripcion = "Motherboard Asus Strix B550F", Costo = 160m, Precio = 300m, Existencia = 4 },
            new Productos { ProductoId = 9, Descripcion = "Monitor Acer 24p IPS 1080 180hz", Costo =110m, Precio =250m, Existencia = 2 },
            new Productos { ProductoId = 10, Descripcion = "Teclado Redragon RGB 60% Blue Switches", Costo = 60m, Precio = 100m, Existencia = 8 }
        );
    }
}