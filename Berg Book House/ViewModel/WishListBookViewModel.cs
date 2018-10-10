using Berg_Book_House.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Berg_Book_House.ViewModel
{
    public class WishListBookViewModel
    {
        public byte Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        [Display(Name = "Book Cover")]
        public HttpPostedFileBase BookCover { get; set; }

        [Display(Name = "Why are you considering this book?")]
        public string Purpose { get; set; }


        public IEnumerable<Category> Categories { get; set; } //this will populate the dropdownlist
        [Display(Name = "Category")]
        public byte CategoryId { get; set; } //each item in dropdownlist will corrospond to the id

        public string Title
        {
            get {
                if (Name == null)
                {
                    return "Add a New Book To Your Wishlist";
                }

                return "Edit This Book Info";
            }
        }
    }
}