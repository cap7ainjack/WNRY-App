using System;
using System.Collections.Generic;
using System.Text;
using WNRY.Models.CommonModels;

namespace WNRY.Core.Data
{
    public class OrdersRepository : BaseRepository<Order>
    {
        public OrdersRepository(WnryDbContext context) : base(context)
        {
        }
    }
}
