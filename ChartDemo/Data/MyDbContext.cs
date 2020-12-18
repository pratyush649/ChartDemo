using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChartDemo.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext (DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<SaleOrder> SaleOrder { get; set; }
    }
}
