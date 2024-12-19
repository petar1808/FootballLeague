using Microsoft.EntityFrameworkCore.Storage;

namespace FootballLeague.Api.Services
{
    public interface ITransactionManager
    {
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    }
}
