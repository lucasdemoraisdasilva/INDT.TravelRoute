using INDT.TravelRoute.Domain.Interfaces.UoW;
using System.Data;

namespace INDT.TravelRoute.Infrastructure.SqlServer.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IDapperDbContext _context;

        public UnitOfWork(IDapperDbContext context) => _context = context;

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _context.Transaction = _context.Connection.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            _context.Transaction.Commit();
            Dispose();
        }

        public void Dispose()
        {
            _context.Transaction?.Dispose();
        }

        public void Rollback()
        {
            _context.Transaction.Rollback();
            Dispose();
        }
    }
}
