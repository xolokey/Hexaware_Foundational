using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Models;

namespace BookStoreApp.Controllers
{
    public class BooksController : Controller
    {
        public static List<Book> book= new List<Book>()
        {
            new Book(){BookID=100,BookName="Game Of Thrones",BookType="Fantasy",BookPrice=120.00m},
            new Book(){BookID=101,BookName="Bad Dad Good Dad",BookType="Documentry",BookPrice=150.00m},
            new Book(){BookID=102,BookName="Cindrella",BookType="Fantasy",BookPrice=20.00m},
            new Book(){BookID=103,BookName="Love Like Fantasy",BookType="Romance",BookPrice=120.00m},
            new Book(){BookID=104,BookName="Biopic of APJ Abdhul Kalam",BookType="BioPic",BookPrice=140.00m},

        };
        public IActionResult Index()
        {
            return View(book);
        }
        //Creating a Book entry
        public IActionResult NewBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewBook(Book newbook)
        {
            book.Add(newbook);
            return RedirectToAction("Index");
        }
        //To Find The Book
        public IActionResult MoreInfo(int BookID)
        {
            var BookInffo = book.FirstOrDefault(b=> b.BookID==BookID);

            return PartialView("_MoreInfo",BookInffo);
        }
    }
}
