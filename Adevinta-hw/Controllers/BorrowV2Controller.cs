using System;
using Adevinta_hw.Data;
using Adevinta_hw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Adevinta_hw.Controllers
{
    [ApiController]
    [Route("v2")]
    public class BorrowV2Controller : ControllerBase
    {
        // 14 day expiration
        private readonly TimeSpan _expiration = new(14,0,0,0);

        // DBContext dependency injection
        private readonly KonyvtarDbContext _context;

        public BorrowV2Controller(KonyvtarDbContext Context)
        {
            _context = Context;
        }

        //Get method that returns a record matching the Id
        [HttpGet]
        [Route("book/{borrowId}")]
        public Borrow Get(int borrowId)
        {
            try
            {
                var result = _context.Borrows.Include(x => x.BorrowedBook).First(x => x.BorrowId == borrowId);


                return result;

            }
            catch (Exception)
            {
                return null;
            }

        }


        // Post method that lets you add data
        [HttpPost]
        [Route("book/add")]
        public async Task<IActionResult> Post(Borrow borrow)
        {

            if (!_context.Borrows.Any(x => x.BorrowerName == borrow.BorrowerName && x.BorrowedBook.Title == borrow.BorrowedBook.Title))
            {
                borrow.BorrowDate = DateTime.UtcNow;
                borrow.Expiration = borrow.BorrowDate + _expiration;
                _context.Borrows.Add(borrow);
                await _context.SaveChangesAsync();

                return Ok("Success!");

            }
            else
            {
                return Conflict("Already exists");
            }

        }


    }
}

