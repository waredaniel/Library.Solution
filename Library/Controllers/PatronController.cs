using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace Library.Controllers
{
  [Authorize(Roles = "Librarian")]
  public class PatronController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public PatronController(UserManager<ApplicationUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      List<Patron> model = _db.Patrons.ToList();
      return View(model);
    }

     public ActionResult Create()
    {
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
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

    public ActionResult Details(int id)
    {
      var thisPatron = _db.Patrons
        .Include(patron => patron.JoinEntities)
        .ThenInclude(join => join.Book)
        .FirstOrDefault(patron => patron.PatronId == id);
      return View(thisPatron);
    }

    public ActionResult Edit(int id)
    {
      var thisPatron = _db.Patrons.FirstOrDefault(patron => patron.PatronId == id);
      return View(thisPatron);
    }

    [HttpPost]
    public ActionResult Edit(Patron patron)
    {
      _db.Entry(patron).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

      public ActionResult Delete(int id)
    {
      var thisPatron = _db.Patrons.FirstOrDefault(patron => patron.PatronId == id);
      return View(thisPatron);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisPatron = _db.Patrons.FirstOrDefault(patron => patron.PatronId == id);
      _db.Patrons.Remove(thisPatron);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

     [HttpPost]
    public ActionResult DeleteBook(int joinId)
    {
      var joinEntry = _db.BookPatrons.FirstOrDefault(entry => entry.BookPatronId == joinId);
      _db.BookPatrons.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

      public ActionResult AddBook(int id)
    {
      var thisPatron = _db.Patrons.FirstOrDefault(patron => patron.PatronId == id);
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
      return View(thisPatron);
    }

    [HttpPost]
    public ActionResult AddBook(Patron patron, int BookId)
    {
      if (BookId != 0)
      {
        _db.BookPatrons.Add(new BookPatron() { BookId = BookId, PatronId = patron.PatronId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  }
}
