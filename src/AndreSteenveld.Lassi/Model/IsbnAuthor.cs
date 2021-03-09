using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AndreSteenveld.Lassi.Model
{
    [Keyless]
    [Table("isbn_author")]
    [Index(nameof(Isbn), nameof(AuthorId), Name = "isbn_author_isbn_author_id_key", IsUnique = true)]
    public partial class IsbnAuthor
    {
        [Column("isbn")]
        public string Isbn { get; set; }
        [Column("author_id")]
        public int? AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public virtual Author Author { get; set; }
    }
}
