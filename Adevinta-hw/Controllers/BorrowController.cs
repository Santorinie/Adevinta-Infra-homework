using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using Adevinta_hw.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Adevinta_hw.Helpers;
using Adevinta_hw.Data;
using System.Linq;

namespace Adevinta_hw.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BorrowController : ControllerBase
    {

        // This Class instance gets wiped out on every call.
        // Storing data in this class is not possible

        // Manages File Write and Read operations
        private FileTaskHelper _helper { get; set; } = new(@"notSoSecureDB.json");

        // DBContext dependency injection
        private readonly KonyvtarDbContext _context;

        public BorrowController(KonyvtarDbContext Context)
        {
            _context = Context;
        }

        //Get method that returns a record matching the Id
        // I know Task 1 solution is extremely unefficient, it's for the task I was given.
        [HttpGet]
        [Route("{borrowId}")]
        public Borrow Get(int borrowId)
        {


            // TASK 1 VERSION

            //var Content = GetJSON();
            //// Try to find a record with the corresponding id
            //try
            //{
            //    return Content.First(x => x.BorrowId == borrowId);
            //}
            //catch (Exception)
            //{
            //    return null;
            //}

            // TASK 2 VERSION

            try
            {
                var result = _context.Borrows.First(x => x.BorrowId == borrowId);

                return result;

            }
            catch (Exception)
            {
                return null;
            }

        }


        // Post method that lets you add data
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Post(Borrow borrow)
        {

            // TASK 1 VERSION

            //var Content = GetJSON();

            //if (Content.Contains(borrow))
            //{
            //    return BadRequest("Object already exists");
            //}
            //else
            //{

            //    int lastId = Content.MaxBy(x => x.BorrowId).BorrowId;
            //    borrow.BorrowDate = DateTime.UtcNow;
            //    borrow.BorrowId = lastId + 1;
            //    Content.Add(borrow);

            //    _helper.Write(GenerateJSON(Content));

            //    return Ok("Record saved");
            //}

            // TASK 2 VERSION

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

        //JSON Serialize and Deserializers

        private List<Borrow> GetJSON()
        {
            return JsonSerializer.Deserialize<List<Borrow>>(_helper.Read());
        }

        private string GenerateJSON(IEnumerable<Borrow> content)
        {
            return JsonSerializer.Serialize(content);
        }
    }
}

