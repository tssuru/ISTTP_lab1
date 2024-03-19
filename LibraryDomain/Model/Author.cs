using System;
using System.Collections.Generic;

namespace LibraryDomain.Model;

public partial class Author : Entyty
{
    // public int AuthorId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? BirthDate { get; set; }

    public string? DeathDate { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
