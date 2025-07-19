using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using domain.Table;

namespace infrastructure.Data;

public class AppDBContext : DbContext
{
    public virtual DbSet<AServiceLog> AServiceLogs { get; set; }
    public virtual DbSet<AService> AServices { get; set; }
    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public AppDBContext(DbContextOptions<AppDBContext> options)
    : base(options)
    {
    }
}
