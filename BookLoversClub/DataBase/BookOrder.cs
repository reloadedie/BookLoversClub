using System;
using System.Collections.Generic;

namespace BookLoversClub.DataBase
{
    public partial class BookOrder
    {
        public long IdBook { get; set; }
        public long IdOrder { get; set; }
        public int Count { get; set; }

        public virtual Book IdBookNavigation { get; set; } = null!;
        public virtual Order IdOrderNavigation { get; set; } = null!;
    }
}
