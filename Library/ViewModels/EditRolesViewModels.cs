using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels{
  public class EditRoleViewModel
  {
    public EditRoleViewModel()
    {
      Users = new List<string>();
    }
    public string Id { get; set; }
    [Required(ErrorMessage = "Role Name is Requried")]
    public string RoleName { get; set; }

    public List<string> Users { get; set; }
  }
}