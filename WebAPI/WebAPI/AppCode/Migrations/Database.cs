using Dapper;
using Data;

namespace WebAPI.AppCode.Migrations
{
    public class Database
    {
        private readonly IRepository _context;
        public Database(IRepository context) => _context = context;
        public void CreateDatabase(string dbName)
        {
            var query = "SELECT * FROM sys.databases WHERE name = @name";
            var parameters = new DynamicParameters();
            parameters.Add("name", dbName);
            using (var connection = _context.GetMasterConnection())
            {
                var records = connection.Query(query, parameters);
                if (!records.Any())
                    connection.Execute($"CREATE DATABASE {dbName}");
            }
        }
    }
}
