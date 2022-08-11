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

