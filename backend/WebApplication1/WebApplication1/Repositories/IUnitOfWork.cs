using System;
using System.Threading.Tasks;
namespace WebApplication1.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBowlerRepository Bowlers { get; }
        ITeamRepository Teams { get; }
        Task<int> CompleteAsync();
    }
}
