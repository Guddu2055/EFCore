using AutoMapper;
using EFCoreOperation.Data;
using EFCoreOperation.Data.Model;
using EFCoreOperation.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace EFCoreOperation.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public BookController(AppDbContext appDbContext,IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpPost("upsert")]
        public async Task<IActionResult> Upsert([FromBody] BookDTO bookDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                if (bookDto.Id == 0)
                {
                    // CREATE: Map DTO to a brand new Entity
                    var bookEntity = _mapper.Map<Book>(bookDto);

                    bookEntity.IsActive = true;
                    bookEntity.CreatedOn = DateTime.Now;

                    _appDbContext.Books.Add(bookEntity);
                    await _appDbContext.SaveChangesAsync();

                    return CreatedAtAction(nameof(Upsert), new { id = bookEntity.Id }, bookEntity);
                }
                else
                {
                    // UPDATE: Map DTO values onto an existing tracked Entity
                    var existingBook = await _appDbContext.Books.FindAsync(bookDto.Id);
                    if (existingBook == null) return NotFound();
                    existingBook.Title = bookDto.Title;
                    existingBook.Description = bookDto.Description;
                    existingBook.NoOfPage = bookDto.NoOfPage;
                    existingBook.LanguageId = bookDto.LanguageId > 0 ? bookDto.LanguageId : existingBook.LanguageId;
                    _appDbContext.Books.Update(existingBook);
                    await _appDbContext.SaveChangesAsync();
                    return Ok(existingBook);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal error");
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult>GetAll()
        {
            try
            {
                var books = await _appDbContext.Books.Include(x=>x.Languages).ToListAsync();
                //var result = _mapper.Map<IEnumerable<BookDTO>>(books);
                return Ok(books);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal error");
            }
        }
    }
}
