using System.Collections.Generic;

namespace Library.Models
{
  public class Patron
  {
    public Patron()
    {
      this.JoinEntities = new HashSet<BookPatron>();
    }

    public int PatronId { get; set; }
    public string FirstName { get; set; }
    public string LastName {get; set;}
    public string StreetAddress {get;set;}
    public string CityState {get; set;}
    public string PhoneNumber {get; set;}
    public string DateJoined {get;set;}
    public virtual ICollection<BookPatron> JoinEntities { get;}
  }
}