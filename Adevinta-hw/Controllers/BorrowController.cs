using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using Adevinta_hw.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Adevinta_hw.Helpers;

namespace Adevinta_hw.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BorrowController : ControllerBase
    {

        // This Class instance gets wiped out on every call.
        // Storing data in this class is not possible

        // Dependency Injection for managing File Write and Read operations
        private FileTaskHelper _helper { get; set; } = new(@"notSoSecureDB.json");


        //Get method that returns a record matching the Id
        // I know it is extremely unefficient, it's for the task I was given.
        [HttpGet]
        [Route("{borrowId}")]
        public Borrow Get(int borrowId)
        {

            var Content = GetJSON();
            
            // Try to find a record with the corresponding id
            try
            {
                return Content.First(x => x.BorrowId == borrowId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Post method that lets you add data
        [HttpPost]
        [Route("add")]
        public IActionResult Post(Borrow borrow)
        {
            var Content = GetJSON();

            if (Content.Contains(borrow))
            {
                return BadRequest("Object already exists");
            }
            else
            {
                
                int lastId = Content.MaxBy(x => x.BorrowId).BorrowId;
                borrow.BorrowDate = DateTime.Now;
                borrow.BorrowId = lastId + 1;
                Content.Add(borrow);

                _helper.Write(GenerateJSON(Content));

                return Ok("Record saved");
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

