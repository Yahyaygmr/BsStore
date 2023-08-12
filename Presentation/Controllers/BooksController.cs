using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {

            var books = _manager.BookService.GetAllBooks(false);
            return Ok(books);


        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {

            var book = _manager.BookService.GetOneBookById(id, false);
            return Ok(book);

        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] BookDtoForInsertion book)
        {
            if (book == null)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            _manager.BookService.CreateOneBook(book);
            return StatusCode(201, book);

        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
        {
            if (bookDto == null)
                return BadRequest(); //400

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState); //422
            }

            _manager.BookService.UpdateOneBook(id, bookDto, false);

            return NoContent(); //204

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            _manager.BookService.DeletOneBook(id, false);

            return NoContent();

        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateBook([FromRoute(Name = "id")] int id,
           [FromBody] JsonPatchDocument<BookDtoForUpdate> bookPatch)
        {
            if (bookPatch is null)
                return BadRequest(); //400

            var result = _manager.BookService.GetOneBookForPatch(id, false);

            bookPatch.ApplyTo(result.bookDtoForUpdate, ModelState);

            TryValidateModel(result.bookDtoForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _manager.BookService.SaveChangesForPatch(result.bookDtoForUpdate, result.book);


            return NoContent();

        }

    }
}

