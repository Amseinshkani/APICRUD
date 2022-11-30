
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.DBContext
{
    public class DataConnection : DbContext
    {
        public DataConnection(DbContextOptions<DataConnection> Options) : base(Options) { }

        public DbSet<TPerson> People { get; set; }
    }
}
