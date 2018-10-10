using Berg_Book_House.Models;
using Berg_Book_House.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Berg_Book_House.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Books
        public ActionResult Index()
        {
            //var books = _context.Books.ToList();

            var books = _context.Books.Include(b => b.Category).ToList(); //eager loading

            return View("ListOfBooks", books);
        }

        //add new Book

        public ActionResult New()
        {
            var categories = _context.Categories.ToList();  //fetch data from database

            var viewModel = new BookFormViewModel   //assign the fetched data in the ViewModel prop
            {
                Categories = categories
            };
            return View("BookForm", viewModel);
        }


        [HttpPost]
        public ActionResult Save(BookFormViewModel viewModel, HttpPostedFileBase uploadCoverPhoto)
        {
            //For updating the data we'll use this action
            //if the form has id value then this is edit form
            //that means the book is existing one and we need to update it
            //otherwise, this is a new form and we need to save it


            //But before it we need to assign the viewModel data to Domain Model
            Book book = new Book
            {
                Name = viewModel.Name,
                Author = viewModel.Author,
                CategoryId = viewModel.CategoryId,

            };



            //If the id is zero then this is a new book
            //so add this to database        
            if (viewModel.Id == 0)
            {
                //for image by the Jon Skeet
                MemoryStream target = new MemoryStream();
                viewModel.UploadCoverPhoto.InputStream.CopyTo(target);
                byte[] data = target.ToArray();



                book.CoverPhoto = data; //assign the data to cover photo


                _context.Books.Add(book);

            }

            //otherwise if the id is not zero
            //then the book is existing one
            //so we need to update it
            else
            {
                //To update the data, we need to compare
                //To compare we need to have two sources data
                //one from database and another from viewModel data


                //so first load the database data using the id
                var bookInDb = _context.Books.Single(b => b.BookId == viewModel.Id);

                //so now compare and update
                bookInDb.Name = book.Name;
                bookInDb.Author = book.Author;
                bookInDb.CategoryId = book.CategoryId;

                //Now for the image file
                //if the file is not empty
                //then replace the existing one in database
                if (uploadCoverPhoto != null && uploadCoverPhoto.ContentLength > 0)   //problem here
                {
                    MemoryStream target = new MemoryStream();
                    viewModel.UploadCoverPhoto.InputStream.CopyTo(target);
                    byte[] data = target.ToArray();

                    book.CoverPhoto = data; //assign photo from viewModel to Domain Model prop

                    //Now assign this photo to database
                    bookInDb.CoverPhoto = book.CoverPhoto;
                }

            }


            _context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }


        public ActionResult Edit(int id)
        {
            //fetch data from database using that id
            var book = _context.Books.SingleOrDefault(b => b.BookId == id);

            //use this book to render the bookform view
            //but bookForm view works with a viewModel
            //so you have to use a viewModel here 
            var viewModel = new BookFormViewModel
            {
                //we don't assign Id value to viewModel
                //as our viewModel already has the Id value from the form

                Name = book.Name,
                Author = book.Author,
                CategoryId = book.CategoryId, //this is must to display the selected category


                Categories = _context.Categories.ToList() //load values for categories 
            };

            return View("BookForm", viewModel);
        }
    }
}