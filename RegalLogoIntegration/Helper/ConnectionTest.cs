using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace RegalLogoIntegration.Helper
{
    public class ConnectionTest
    {
        public static async Task<bool> ConnectionControl(string connectionString)
        {   
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    return (true);
                }
            }
            catch
            {
                return (false);
            }
        }
    }
}
