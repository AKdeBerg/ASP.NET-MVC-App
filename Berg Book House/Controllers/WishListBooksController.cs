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
    public class WishListBooksController : Controller
    {
        private ApplicationDbContext _context;

        public WishListBooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: WishListBooks
        public ActionResult Index()
        {
            //fetch data from database with eager loading
            var wishListBooks = _context.WishListBooks.Include(wb => wb.Category).ToList();

            return View("ListOfWishListBooks", wishListBooks);
        }

        //add new book to the wish list
        public ActionResult New()
        {
            var categories = _context.Categories.ToList();

            var viewModel = new WishListBookViewModel
            {
                Categories = categories
            };

            return View("WishListForm", viewModel);
        }

        //save the wishlist book info from the form
        [HttpPost]
        public ActionResult Save(WishListBookViewModel viewModel, HttpPostedFileBase bookCover)
        {
            //save the data from viewModel to model
            var wishListModel = new WishListBook
            {
                Name = viewModel.Name,
                Author = viewModel.Author,
                CategoryId = viewModel.CategoryId,
                Purpose = viewModel.Purpose
                
            };


            if (viewModel.Id == 0)
            {
                //for image by the Jon Skeet
                MemoryStream target = new MemoryStream();
                viewModel.BookCover.InputStream.CopyTo(target);
                byte[] data = target.ToArray();
                wishListModel.BookCover = data;

                //add the model data to database table(WishListBooks)
                _context.WishListBooks.Add(wishListModel);
            }

            else
            {
                var wishListBookInDb = _context.WishListBooks.Single(wb => wb.Id == viewModel.Id);

                wishListBookInDb.Name = wishListModel.Name;
                wishListBookInDb.Author = wishListModel.Author;
                wishListBookInDb.CategoryId = wishListModel.CategoryId;
                wishListBookInDb.Purpose = wishListModel.Purpose;


                if (bookCover != null && bookCover.ContentLength > 0)
                {
                    //for image by the Jon Skeet
                    MemoryStream target = new MemoryStream();
                    viewModel.BookCover.InputStream.CopyTo(target);
                    byte[] data = target.ToArray();

                    wishListModel.BookCover = data;
                    wishListBookInDb.BookCover = wishListModel.BookCover;

                }
            }
            

            
            

            
            _context.SaveChanges();


            return RedirectToAction("Index", "WishListBooks");
        }


        public ActionResult Edit(int id)
        {
            //fetch the corresponding data from database using id
            var wishListBook = _context.WishListBooks.Single(wb => wb.Id == id);

            var viewModel = new WishListBookViewModel
            {

                Name = wishListBook.Name,
                Author = wishListBook.Author,
                Purpose = wishListBook.Purpose,
                CategoryId = wishListBook.CategoryId,

                Categories = _context.Categories.ToList()
            };


            return View("WishListForm", viewModel);
        }

        public ActionResult DeleteWish(int id)
        {
            if (id != 0)
            {
                var wishListBook = _context.WishListBooks.Where(wb => wb.Id == id).FirstOrDefault();

                if (wishListBook != null)
                {
                    _context.Entry(wishListBook).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}