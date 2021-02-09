using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Database
{
  public abstract class RepositoryBase<TEntity>: RepositoryBase<TEntity, int>
    where TEntity : EntityBase
  {
    protected RepositoryBase(DatabaseContext context, IMapper mapper)
      : base(context, mapper) { }
  }

  public abstract class RepositoryBase<TEntity, T>: RepositoryBase
    where TEntity : EntityBase<T>
  {
    protected DbSet<TEntity> DbSet => fContext.Set<TEntity>();

    protected RepositoryBase(DatabaseContext context, IMapper mapper)
      : base(context, mapper) { }
  }

  public abstract class RepositoryBase
  {
    protected readonly DatabaseContext fContext;
    protected readonly IMapper fMapper;

    protected RepositoryBase(DatabaseContext context, IMapper mapper)
    {
      fContext = context;
      fMapper = mapper;
    }

    protected async Task InTrasactionAsync(Func<Task> operation, CancellationToken cancellationToken)
    {
      var trasaction = await fContext.Database.BeginTransactionAsync(cancellationToken);
      try
      {
        await operation();
        await trasaction.CommitAsync(cancellationToken);
      }
      catch
      {
        await trasaction.RollbackAsync(cancellationToken);
        throw;
      }
    }

    protected async Task<TResult> InTrasactionAsync<TResult>(Func<Task<TResult>> operation, CancellationToken cancellationToken)
    {
      var trasaction = await fContext.Database.BeginTransactionAsync(cancellationToken);
      try
      {
        var result = await operation();
        await trasaction.CommitAsync(cancellationToken);
        return result;
      }
      catch
      {
        await trasaction.RollbackAsync(cancellationToken);
        throw;
      }
    }
  }
}
