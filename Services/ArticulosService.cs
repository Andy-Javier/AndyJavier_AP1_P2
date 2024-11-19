using AndyJavier_AP1_P2.DAL;
using AndyJavier_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AndyJavier_AP1_P2.Service;

public class ArticulosService
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public ArticulosService(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    // Metodo Existe
    public async Task<bool> Existe(int ArticuloId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.articulos.AnyAsync(r => r.ArticuloId == ArticuloId);
    }

    // Metodo Insertar
    private async Task<bool> Insertar(Articulos articulos)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.articulos.Add(articulos);
        return await contexto.SaveChangesAsync() > 0;
    }

    // Metodo Modificar
    private async Task<bool> Modificar(Articulos articulos)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Update(articulos);
        return await contexto.SaveChangesAsync() > 0;
    }

    // Metodo Guardar
    public async Task<bool> Guardar(Articulos articulos)
    {
        if (!await Existe(articulos.ArticuloId))
        {
            return await Insertar(articulos);
        }
        else
        {
            return await Modificar(articulos);
        }
    }

    // Metodo Eliminar
    public async Task<bool> Eliminar(Articulos articulos)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.articulos
            .AsNoTracking()
            .Where(r => r.ArticuloId == articulos.ArticuloId)
            .ExecuteDeleteAsync() > 0;
    }

    // Metodo Buscar
    public async Task<Articulos?> Buscar(int ArticuloId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.articulos
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.ArticuloId == ArticuloId);
    }

    // Metodo Listar
    public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.articulos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}