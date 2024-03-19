using System;
using System.Collections.Generic;

namespace LibraryDomain.Model;

public partial class Book : Entyty
{
    //public int BookId { get; set; }

    public string? Title { get; set; }

    public string? PublishedYear { get; set; }

    public int? AuthorId { get; set; }

    public int? PublisherId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();

    public virtual Publisher? Publisher { get; set; }

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
