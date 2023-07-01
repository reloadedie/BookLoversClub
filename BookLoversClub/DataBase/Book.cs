using System;
using System.Collections.Generic;

namespace BookLoversClub.DataBase
{
    public partial class Book
    {
        public Book()
        {
            BookOrders = new HashSet<BookOrder>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Cost { get; set; }
        public string PhotoImage { get; set; } = null!;
        public string Description { get; set; } = null!;
        public long IdProduction { get; set; }
        public decimal? SaleCost { get; set; }

        public virtual Production IdProductionNavigation { get; set; } = null!;
        public virtual ICollection<BookOrder> BookOrders { get; set; }
    }
}
