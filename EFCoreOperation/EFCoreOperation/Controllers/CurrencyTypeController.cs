using EFCoreOperation.Data;
using EFCoreOperation.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreOperation.Controllers
{
    [Route("api/currencytype")]
    [ApiController]
    public class CurrencyTypeController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CurrencyTypeController(AppDbContext appDbContext)
        {
           _appDbContext = appDbContext;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _appDbContext.CurrencyTypes.AsNoTracking().ToListAsync();
            return Ok(result);
                        
        }
       

    }
}
