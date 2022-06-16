using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace labb3Api.Models
{
    public partial class UserInterest
    {
        public int UserId { get; set; }
        public int InterestId { get; set; }

        public virtual Interest Interest { get; set; }
        public virtual User User { get; set; }
    }
}
