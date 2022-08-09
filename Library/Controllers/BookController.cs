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

  public ActionResult Details(int id)
  {
    var thisBook = _db.Books
      .Include(book => book.JoinEntities)
      .ThenInclude(join => join.Patron)
      .FirstOrDefault(book => book.BookId == id);
    return View(thisBook);
  }

   public ActionResult Edit(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      ViewBag.PatronId = new SelectList(_db.Patrons, "PatronId", "Name");
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult Edit(Book book, int PatronId)
    {
      if (PatronId != 0)
      {
        _db.BookPatrons.Add(new BookPatron() { PatronId = PatronId, BookId = book.BookId });
      }
      _db.Entry(book).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

     public ActionResult Delete(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      _db.Books.Remove(thisBook);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
}
}