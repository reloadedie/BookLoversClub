using System;
using System.Collections.Generic;

namespace BookLoversClub.DataBase
{
    public partial class Order
    {
        public Order()
        {
            BookOrders = new HashSet<BookOrder>();
        }

        public long Number { get; set; }
        public long IdStatus { get; set; }
        public long IdPickPoint { get; set; }
        public decimal? SummSaleCost { get; set; }
        public decimal OrderCost { get; set; }
        public DateTime OrderDate { get; set; }
        public string? OrderCode { get; set; }

        public virtual PickPoint IdPickPointNavigation { get; set; } = null!;
        public virtual Status IdStatusNavigation { get; set; } = null!;
        public virtual ICollection<BookOrder> BookOrders { get; set; }
    }
}
