﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Adevinta_hw.Models
{
    public class Borrow
    {

        public int BorrowId { get; set; }

        [MaxLength(255)]
        public string BorrowerName { get; set; }

        public Book BorrowedBook { get; set; }

        public DateTime BorrowDate { get; set; }
    }
}

