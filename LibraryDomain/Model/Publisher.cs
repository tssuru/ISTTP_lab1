using System;
using System.Collections.Generic;

namespace LibraryDomain.Model;

public partial class Publisher : Entyty
{
    //public int PublisherId { get; set; }

    public string? Name { get; set; }

    public string? Adress { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
