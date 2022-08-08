using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;


namespace Library.Controllers
{
  public class BookController : Controller
  {
    private readonly LibraryContext _db;
    public BookController(LibraryContext db)
    {
      _db = db;
    }
    
    public ActionResult Index()
    {
      return View(_db.Books.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.PatronId = new SelectList(_db.Patrons, "PatronId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Book book, int PatronId)
    {
      _db.Books.Add(book);
      _db.SaveChanges();
      if (PatronId != 0)
      {
        _db.BookPatrons.Add(new BookPatron() { PatronId = PatronId, BookId = book.BookId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
  }
}
}