using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TSIApiWebApp.Core;

namespace TSIApiWebApp.Data
{
    public class TSIApiWebAppDbContext : DbContext
    {
        public TSIApiWebAppDbContext(DbContextOptions<TSIApiWebAppDbContext> options) : base(options)
        {

        }
        public DbSet<UploadedImage> UploadedImage { get; set; }
    }
}
