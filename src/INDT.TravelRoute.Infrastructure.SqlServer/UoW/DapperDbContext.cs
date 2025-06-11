using INDT.TravelRoute.Domain.Interfaces.UoW;
using INDT.TravelRoute.Infrastructure.SqlServer.DependencyInjection.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace INDT.TravelRoute.Infrastructure.SqlServer.UoW
{
    public sealed class DapperDbContext : IDapperDbContext
    {
        public IDbConnection Connection => GetConnection();

        public IDbTransaction Transaction { get; set; }

        private readonly IDbConnection _connection;

        public DapperDbContext(IOptions<ConnectionStrings> options)
        {
            _connection = new SqlConnection(options.Value.SqlServerDbContext);
            _connection.Open();
        }

        private IDbConnection GetConnection()
        {
            EnsureConnectionIsOpen();
            return _connection;
        }

        private void EnsureConnectionIsOpen()
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

        public void Dispose() => _connection?.Close();
    }
}
