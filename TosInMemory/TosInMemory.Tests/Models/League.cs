using System;
using System.Collections.Generic;

namespace TosInMemory.Tests.Models
{
    public partial class League
    {
        public League()
        {
            Clubs = new HashSet<Club>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Club> Clubs { get; set; }
    }
}
