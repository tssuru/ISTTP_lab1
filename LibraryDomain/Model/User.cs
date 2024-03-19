using System;
using System.Collections.Generic;

namespace LibraryDomain.Model;

public partial class User : Entyty
{
    //public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
}
