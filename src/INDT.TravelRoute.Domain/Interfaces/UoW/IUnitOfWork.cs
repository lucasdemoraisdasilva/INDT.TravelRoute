using System.Data;

namespace INDT.TravelRoute.Domain.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        void Commit();

        void Rollback();
    }
}
