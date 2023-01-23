using System;
using System.Collections.Generic;

namespace OFT_UKHO_Bookshelf_Manager.Models
{
    public partial class Rental
    {
        public Rental(int id, int copyId, int userId, DateTime startDateTime, DateTime? endDateTime)
        {
            Id = id;
            CopyId = copyId;
            UserId = userId;
            StartDateTime = startDateTime; 
            EndDateTime = endDateTime;
        }

        public int Id { get; set; }
        public int CopyId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public virtual Copy Copy { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
