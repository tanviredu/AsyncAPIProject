using AutoMapper;
using Books.Application.DTO;
using Books.Application.Services;
using Books.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController:ControllerBase
    {
        private IBookRepository _bookRepository;
        private IMapper _mapper;
        public BookController(IBookRepository repository,IMapper mapper)
        {
            _bookRepository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReadDTO>>> GetBooks()
        {
            try
            {
                var bookEntities = await _bookRepository.GetBooksAsync();
                return Ok(_mapper.Map<IEnumerable<BookReadDTO>>(bookEntities));
            }
            catch {
                return NotFound();
            }
            
        }


        [HttpGet]
        [Route("{id}",Name ="GetBookById")]
        public async Task<ActionResult> GetBookById(int id) {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null) {
                //RedirectToAction(nameof(GetBooks));
                return NotFound();
            }
            return Ok(book);

        }

        [HttpPost]
        public async Task<ActionResult> CreateBook(BookCreateDTO bookCreateDTO) 
        {
            var bookEntity = _mapper.Map<Book>(bookCreateDTO);
            _bookRepository.AddBook(bookEntity);
            await _bookRepository.SaveChangeAsync();

            // now generate new url for the newly created post
            // to do that use CreatedAtRouteMethod
            return CreatedAtRoute("GetBookById", new { id = bookEntity.Id }, bookEntity);

        
        }




    }
}
