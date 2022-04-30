using System;
using System.Collections.Generic;

namespace TosInMemory.Tests.Models
{
    public partial class Club
    {
        public Club()
        {
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public int LeagueId { get; set; }
        public string? Name { get; set; }
        public int? Score { get; set; }

        public virtual League League { get; set; } = null!;
        public virtual ICollection<Player> Players { get; set; }
    }
}
