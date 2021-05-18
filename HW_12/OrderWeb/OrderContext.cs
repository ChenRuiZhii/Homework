using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T8;
using T6;
using Microsoft.EntityFrameworkCore;

namespace OrderWeb
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
           : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
