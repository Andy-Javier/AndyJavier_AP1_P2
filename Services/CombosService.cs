using AndyJavier_AP1_P2.DAL;
using AndyJavier_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AndyJavier_AP1_P2.Services
{
    public class CombosService
    {
        private readonly Contexto _contexto;

        public CombosService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Combos>> Listar(Expression<Func<Combos, bool>> criterio)
        {
            return await _contexto.Combos
                .Include(combo => combo.CombosDetalles)
                .ThenInclude(detalle => detalle.Producto)
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Combos?> ObtenerPorId(int comboId)
        {
            return await _contexto.Combos
                .Include(combo => combo.CombosDetalles)
                .ThenInclude(detalle => detalle.Producto)
                .FirstOrDefaultAsync(combo => combo.ComboId == comboId);
        }

        public async Task<Combos> Crear(Combos combo)
        {
            await _contexto.Combos.AddAsync(combo);
            await _contexto.SaveChangesAsync();
            return combo;
        }

        public async Task<Combos> Modificar(Combos combo)
        {
            _contexto.Entry(combo).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return combo;
        }

        public async Task<bool> Eliminar(int comboId)
        {
            var combo = await _contexto.Combos.FindAsync(comboId);
            if (combo == null)
                return false;

            _contexto.Combos.Remove(combo);
            await _contexto.SaveChangesAsync();
            return true;
        }
    }
}
