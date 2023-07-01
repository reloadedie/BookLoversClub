using System;
using System.Collections.Generic;

namespace BookLoversClub.DataBase
{
    public partial class Production
    {
        public Production()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
