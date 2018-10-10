using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Berg_Book_House.Models
{
    public class WishListBook
    {
        //without it BookId going to assign to database primary key and creates exception
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public byte Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public byte CategoryId { get; set; }
        public Category Category { get; set; }

        [Display(Name = "Book Cover")]
        public byte[] BookCover { get; set; }


        [Display(Name= "Why are you considering this book?")]
        public string Purpose { get; set; }

    }
}