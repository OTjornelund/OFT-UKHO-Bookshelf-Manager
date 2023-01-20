using System;
using System.Collections.Generic;

namespace OFT_UKHO_Bookshelf_Manager.Models
{
    public partial class Copy
    {
        public Copy()
        {
            Rentals = new HashSet<Rental>();
        }

        public Copy(int validBookId)
        {
            BookId = validBookId;
            Rentals = new HashSet<Rental>();
        }

        public int Id { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
