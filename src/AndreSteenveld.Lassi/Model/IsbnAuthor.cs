using System;
using System.Collections.Generic;

#nullable disable

namespace AndreSteenveld.Lassi.Model
{
    public partial class IsbnAuthor
    {
        public string Isbn { get; set; }
        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
