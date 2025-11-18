using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.SqlClient;
using RegalLogoIntegration.Services.Interfaces;

namespace RegalLogoIntegration.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RegalLogoIntegrationController : ControllerBase
    {
        private readonly ICLCARDService _service;

        public RegalLogoIntegrationController(ICLCARDService service)
        {
            _service = service;
        }

        [HttpGet("connectiontest")]
        public async Task<IActionResult> ConnectionTest()
        {
            string connectionString = "Server=****;Database=***;User Id=***;Password=*****;TrustServerCertificate=true;Connect Timeout=30;";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    return Ok("✅ Bağlantı başarılı!");
                }
            }
            catch (Exception ex)
            {
                
                return Ok("❌ Bağlantı başarısız!" + ex);
            }
        }

        
        [HttpGet("currents")]
        public async Task<IActionResult> Currents()
        {
            try
            {
                var currents = await _service.GetAllAsync();

                var firstItem = currents.FirstOrDefault();
                if (firstItem != null)
                {
                    var testObject = new
                    {
                        firstItem.LOGICALREF,
                        firstItem.CODE
                    };
                    return Ok(new { success = true, data = currents });
                }

                return Ok(new { success = true, data = currents });
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new
                {
                    success = false,
                    message = ex.Message,
                    innerException = ex.InnerException?.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }

    }
}

