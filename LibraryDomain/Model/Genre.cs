using System;
using System.Collections.Generic;

namespace LibraryDomain.Model;

public partial class Genre : Entyty
{
    //public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
