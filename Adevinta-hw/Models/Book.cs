using System;
using System.ComponentModel.DataAnnotations;

namespace Adevinta_hw.Models
{
    public class Book
    {
        // Book Model for Entity Framework ORM

        public int BookId { get; private set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Author { get; set; }

        //Just to make distinction between books with the same title
        public Guid guid { get; private set; }

        public Book()
        {
            guid = Guid.NewGuid();
        }
    }
}

