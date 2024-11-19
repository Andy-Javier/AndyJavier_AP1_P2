using AndyJavier_AP1_P2.DAL;
using AndyJavier_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AndyJavier_AP1_P2.Service;

public class ComboService
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public ComboService(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    // Metodo Existe
    public async Task<bool> Existe(int ComboId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.combos.AnyAsync(r => r.ComboId == ComboId);
    }

    // Metodo Insertar
    private async Task<bool> Insertar(Combos combos)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.combos.Add(combos);
        return await contexto.SaveChangesAsync() > 0;
    }

    // Metodo Modificar
    private async Task<bool> Modificar(Combos combos)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Update(combos);
        return await contexto.SaveChangesAsync() > 0;
    }

    // Metodo Guardar
    public async Task<bool> Guardar(Combos combos)
    {
        if (!await Existe(combos.ComboId))
        {
            return await Insertar(combos);
        }
        else
        {
            return await Modificar(combos);
        }
    }

    // Metodo Eliminar
    public async Task<bool> Eliminar(Combos Combo)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.combos
            .AsNoTracking()
            .Where(r => r.ComboId == Combo.ComboId)
            .ExecuteDeleteAsync() > 0;
    }

    // Metodo Buscar
    public async Task<Combos?> Buscar(int ComboId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.combos
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.ComboId == ComboId);
    }

    // Metodo Listar
    public async Task<List<Combos>> Listar(Expression<Func<Combos, bool>> criterio)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.combos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}