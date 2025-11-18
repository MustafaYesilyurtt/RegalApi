using Dapper;
using RegalLogoIntegration.Helper;
using Microsoft.Data.SqlClient;
using RegalLogoIntegration.Models;
using RegalLogoIntegration.Repositories.Interfaces;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace RegalLogoIntegration.Repositories
{
    public class CLCARDRepository : ICLCARDRepository
    {
        private readonly string _connectionString;

        public CLCARDRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(_connectionString))
                throw new Exception("Connection string boş geldi! appsettings.json kontrol et.");
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);
        
        public async Task<IEnumerable<CLCARD>> GetAllAsync()
        {
            bool canConnect = await ConnectionTest.ConnectionControl(_connectionString);
            if (!canConnect)
                throw new Exception("❌ DB bağlantısı sağlanamadı!");

            using (var db = Connection)
            {
                string sql = "SELECT LOGICALREF,ACTIVE,CARDTYPE,CODE,DEFINITION_,ADDR1,ADDR2,CITY,COUNTRY,POSTCODE,TELNRS1,TELNRS2,FAXNR,TAXNR,TAXOFFICE,INCHARGE FROM LG_002_CLCARD";

                return await db.QueryAsync<CLCARD>(sql);
            }
        }

        public async Task<CLCARD> GetByIdAsync(int id)
        {
            bool canConnect = await ConnectionTest.ConnectionControl(_connectionString);
            if (!canConnect)
                throw new Exception("❌ DB bağlantısı sağlanamadı!");

            using (var db = Connection)
            {
                string sql = "SELECT **FROM LG_002_CLCARD WHERE LOGICALREF = @Id";
                return await db.QueryFirstOrDefaultAsync<CLCARD>(sql, new { Id = id });
            }
        }
    }
}
