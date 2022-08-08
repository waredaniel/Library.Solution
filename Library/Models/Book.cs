using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      this.JoinEntities = new HashSet<BookPatron>();
    }

    public int BookId { get; set; }
    public string Title { get; set; }
    public virtual ApplicationUser User { get; set; }

    public virtual ICollection<BookPatron> JoinEntities { get;set;}
  }
}