using System;
using System.Collections.Generic;

namespace OFT_UKHO_Bookshelf_Manager.Models
{
    public partial class Rental
    {
        public int Id { get; set; }
        public int CopyId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public virtual Copy Copy { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
