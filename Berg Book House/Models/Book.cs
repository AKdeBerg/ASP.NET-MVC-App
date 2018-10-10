
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Berg_Book_House.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //without it BookId going to assign to database primary key and creates exception
        public byte BookId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Category Category { get; set; }
        [Display(Name = "Category")]
        public byte CategoryId { get; set; }

        public string Author { get; set; }
        

        //for cover photo
        public byte[] CoverPhoto { get; set; }

        
    }
}