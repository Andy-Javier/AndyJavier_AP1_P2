using AndyJavier_AP1_P2.DAL;
using AndyJavier_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AndyJavier_AP1_P2.Services
{
    public class CombosDetalleService
    {
        private readonly Contexto _contexto;

        public CombosDetalleService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<CombosDetalle>> ObtenerDetallesDeCombo(int comboId)
        {
            return await _contexto.CombosDetalle
                .Include(cd => cd.Combo)
                .Include(cd => cd.Producto)
                .Where(cd => cd.ComboId == comboId)
                .ToListAsync();
        }


        public async Task<CombosDetalle?> ObtenerPorId(int detalleId)
        {
            return await _contexto.CombosDetalle
                .Include(detalle => detalle.Producto)
                .FirstOrDefaultAsync(detalle => detalle.DetalleId == detalleId);
        }

        public async Task<CombosDetalle> Crear(CombosDetalle comboDetalle)
        {
            await _contexto.CombosDetalle.AddAsync(comboDetalle);
            await _contexto.SaveChangesAsync();
            return comboDetalle;
        }

        public async Task<CombosDetalle> Modificar(CombosDetalle comboDetalle)
        {
            _contexto.Entry(comboDetalle).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return comboDetalle;
        }

        public async Task<bool> Eliminar(int detalleId)
        {
            var comboDetalle = await _contexto.CombosDetalle.FindAsync(detalleId);
            if (comboDetalle == null)
                return false;

            _contexto.CombosDetalle.Remove(comboDetalle);
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task<List<Productos>> ListaProductos(Expression<Func<Productos, bool>>? criterio = null)
        {
            return criterio == null
                ? await _contexto.Productos.AsNoTracking().ToListAsync()
                : await _contexto.Productos.Where(criterio).AsNoTracking().ToListAsync();
        }

    }
}
