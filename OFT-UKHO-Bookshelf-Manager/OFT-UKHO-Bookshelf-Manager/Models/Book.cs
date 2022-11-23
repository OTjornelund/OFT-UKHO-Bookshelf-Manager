using System;
using System.Collections.Generic;

namespace OFT_UKHO_Bookshelf_Manager.Models
{
    public partial class Book
    {
        public Book()
        {
            Copies = new HashSet<Copy>();
        }

        public int Id { get; set; }
        public string Isbn10 { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Publisher { get; set; }
        public byte? Edition { get; set; }
        public string? Author { get; set; }

        public virtual ICollection<Copy> Copies { get; set; }
    }
}
