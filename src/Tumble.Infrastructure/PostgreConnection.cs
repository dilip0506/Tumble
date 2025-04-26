using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace Tumble.User.Infrastructure
{
    abstract class PostgreConnection
    {
        private readonly Settings _settings;
        public PostgreConnection(IOptions<Settings> settings)
        {
            _settings = settings.Value;
        }
        public IDbConnection GetConnection()
        {
            var conn = new NpgsqlConnection(_settings.ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
