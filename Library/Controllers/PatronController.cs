using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
  public class PatronController : Controller
  {
    private readonly LibraryContext _db;

    public PatronController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Patron> model = _db.Patrons.ToList();
      return View(model);
    }

     public ActionResult Create()
    {
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Patron patron, int BookId)
    {
      _db.Patrons.Add(patron);
      _db.SaveChanges();
       if (BookId != 0)
      {
        _db.BookPatrons.Add(new BookPatron() { BookId = BookId, PatronId = patron.PatronId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

  }
}
