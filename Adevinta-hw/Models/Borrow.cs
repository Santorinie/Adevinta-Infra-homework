using System;
namespace Adevinta_hw.Models
{
    public class Borrow
    {
        public string BorrowerName { get; set; }
        public Book BorrowedBook { get; set; }
        public DateTime BorrowDate { get; set; }
    }
}

