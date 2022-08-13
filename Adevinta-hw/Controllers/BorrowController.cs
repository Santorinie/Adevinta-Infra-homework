using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using Adevinta_hw.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Adevinta_hw.Helpers;
using Adevinta_hw.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Adevinta_hw.Controllers
{
    [ApiController]
    [Route("v1")]
    public class BorrowController : ControllerBase
    {


        // DBContext dependency injection
        private readonly KonyvtarDbContext _context;

        public BorrowController(KonyvtarDbContext Context)
        {
            _context = Context;
        }

        //Get method that returns a record matching the Id
        [HttpGet]
        [Route("book/{borrowId}")]
        public IActionResult Get(int borrowId)
        {
            try
            {
                var result = _context.Borrows.Include(x => x.BorrowedBook).First(x => x.BorrowId == borrowId);


                return Ok(result);

            }
            catch (Exception)
            {
                return NoContent();
            }

        }

        //Get method that returns a record matching the name
        [HttpGet]
        [Route("book/name/{borrowerName}")]
        public IActionResult Get(string borrowerName)
        {
            try
            {
                var result = _context.Borrows.Include(x => x.BorrowedBook).First(x => x.BorrowerName == borrowerName);


                return Ok(result);

            }
            catch (Exception)
            {
                return NoContent();
            }

        }

        //Get method that returns all of the borrows
        [HttpGet]
        [Route("book/all")]
        public IActionResult Get()
        {
            try
            {
                var result = _context.Borrows.Include(x => x.BorrowedBook);


                return Ok(result);

            }
            catch (Exception)
            {
                return NoContent();
            }

        }



        [HttpPut]
        [Route("book/change/{borrowId}")]
        public async Task<IActionResult> Put(int borrowId, [FromBody]Borrow borrow)
        {
            var entity = _context.Borrows.Include(x => x.BorrowedBook).First(x => x.BorrowId == borrowId);

            entity.BorrowerName = borrow.BorrowerName;
            entity.BorrowedBook.Title = borrow.BorrowedBook.Title;
            entity.BorrowedBook.Author = borrow.BorrowedBook.Author;

           await _context.SaveChangesAsync();

            return Ok("record changed!");
            
            
        }


        // Post method that lets you add data
        [HttpPost]
        [Route("book/add")]
        public async Task<IActionResult> Post(Borrow borrow)
        {

            if (!_context.Borrows.Any(x => x.BorrowerName == borrow.BorrowerName && x.BorrowedBook.Title == borrow.BorrowedBook.Title))
            {
                borrow.BorrowDate = DateTime.UtcNow;
                _context.Borrows.Add(borrow);
                await _context.SaveChangesAsync();

                return Ok("Success!");

            }
            else
            {
                return Conflict("Already exists");
            }

        }

        [HttpDelete]
        [Route("book/delete/{borrowId}")]
        public async Task<IActionResult> Delete(int borrowId)
        {
            try
            {
                var entity = _context.Borrows.Include(x => x.BorrowedBook).First(x => x.BorrowId == borrowId);

                _context.Borrows.Remove(entity);

                await _context.SaveChangesAsync();

                return Ok("Deleted");
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

    }
}

