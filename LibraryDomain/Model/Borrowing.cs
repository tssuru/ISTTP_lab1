using System;
using System.Collections.Generic;

namespace LibraryDomain.Model;

public partial class Borrowing : Entyty
{
    public string? BorrowDate { get; set; }

    public string? ReturnDate { get; set; }

    public int UserId { get; set; }

    public int BookId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
