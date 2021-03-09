using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AndreSteenveld.Lassi.Model
{
    [Table("author")]
    public partial class Author
    {
        [Key]
        [Column("author_id")]
        public int AuthorId { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}
