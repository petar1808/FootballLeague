using FootballLeague.Api.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace FootballLeague.Api.Services
{
    public class EfCoreTransactionManager : ITransactionManager
    {
        private readonly AppDbContext _context;

        public EfCoreTransactionManager(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Database.BeginTransactionAsync(cancellationToken);
        }
    }

}
