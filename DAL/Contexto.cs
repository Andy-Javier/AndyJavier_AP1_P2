using Microsoft.EntityFrameworkCore;
using AndyJavier_AP1_P2.Models;
using Microsoft.Win32;

namespace AndyJavier_AP1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Combos> combos { get; set; }
    public DbSet<Articulos> articulos { get; set; }
    public DbSet<CombosDetalle> combosDetalles { get; set; }
}