using System;
using System.Collections.ObjectModel;
using Adevinta_hw.Models;
using Microsoft.AspNetCore.Mvc;

namespace Adevinta_hw.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BorrowController : ControllerBase
    {
        


      
        //Get method that returns all borrows
        [HttpGet]
        public string Get()
        {
            return "hey";
        }

        // Post method that lets you add data
        [HttpPost]
        [Route("add")]
        public void Post(Borrow borrow)
        {
            borrow.BorrowDate = DateTime.Now;
            //todo: Store data
        }
    }
}

