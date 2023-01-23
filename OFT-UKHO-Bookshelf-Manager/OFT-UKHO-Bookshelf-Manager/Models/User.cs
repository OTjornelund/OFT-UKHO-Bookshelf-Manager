using System;
using System.Collections.Generic;

namespace OFT_UKHO_Bookshelf_Manager.Models
{
    public partial class User
    {
        public User()
        {
            Rentals = new HashSet<Rental>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Email { get; set; }

        public virtual ICollection<Rental> Rentals { get; private set; }
    }
}
