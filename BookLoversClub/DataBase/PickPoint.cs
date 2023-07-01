using System;
using System.Collections.Generic;

namespace BookLoversClub.DataBase
{
    public partial class PickPoint
    {
        public PickPoint()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
