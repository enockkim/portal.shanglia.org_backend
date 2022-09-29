using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using groups_backend.Models;

namespace groups_backend.Service
{
    public class ServiceDbContext : DbContext
    {
        public DbSet<users> users { set; get; }
        public DbSet<login_history> login_history { set; get; }
        public DbSet<members> members { set; get; }
        public DbSet<projects> projects { set; get; }
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {
        }
    }
}

