using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Berg_Book_House.Models
{
    public class Author
    {
        public byte AuthorId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}