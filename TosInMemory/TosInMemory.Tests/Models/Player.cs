using System;
using System.Collections.Generic;

namespace TosInMemory.Tests.Models
{
    public partial class Player
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public int? Number { get; set; }

        public virtual Club Club { get; set; } = null!;
    }
}
