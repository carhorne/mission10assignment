using System;
using System.Threading.Tasks;
using WebApplication1.Data;
namespace WebApplication1.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BowlingLeagueContext _context;
        private IBowlerRepository _bowlerRepository;
        private ITeamRepository _teamRepository;
        private bool _disposed = false;

        public UnitOfWork(BowlingLeagueContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IBowlerRepository Bowlers => _bowlerRepository ??= new BowlerRepository(_context);

        public ITeamRepository Teams => _teamRepository ??= new TeamRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
