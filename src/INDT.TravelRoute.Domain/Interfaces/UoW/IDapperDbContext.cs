using System.Data;

namespace INDT.TravelRoute.Domain.Interfaces.UoW
{
    public interface IDapperDbContext : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; set; }
    }
}
