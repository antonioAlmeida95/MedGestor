using System.Linq.Expressions;
using MedGestor.Adapter.Driven.Database.UnitOfWork;
using Microsoft.EntityFrameworkCore.Query;

namespace MedGestor.Adapter.Driven.Database.Repository;

public class BaseRepository :  IDisposable, IAsyncDisposable
{
    protected readonly UnitOfWorkContext Context;

    public BaseRepository(UnitOfWorkContext context)
    {
        Context = context;
    }
    
    protected IQueryable<TX> Query<TX>(Expression<Func<TX, bool>>? expression = null, 
        Func<IQueryable<TX>, IIncludableQueryable<TX, object>>? include = null, bool track = false,
        int? skip = null, int? take = null) where TX : class
    {
        var query = Context.GetQuery<TX>(track);

        if (expression != null)
            query = query.Where(expression);
        
        if (include != null)
            query = include(query);

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if (take.HasValue)
            query = query.Take(take.Value);

        return query;
    }

    protected async Task<bool> Commit()
    {
        try
        {
            var linhasAfetadas = await Context.SaveChangesAsync();
            return linhasAfetadas > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Falha: {e.Message}");
            return false;
        }
    }

    public void Dispose() => Context.Dispose();

    public async ValueTask DisposeAsync() => await Context.DisposeAsync();
}