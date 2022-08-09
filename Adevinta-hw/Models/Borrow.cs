using System;
namespace Adevinta_hw.Models
{
    public class Borrow
    {

        public int BorrowId { get; set; }
        public string BorrowerName { get; set; }
        public Book BorrowedBook { get; set; }
        public DateTime BorrowDate { get; set; }
    }
}

