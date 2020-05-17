using System;
using System.Collections.Generic;
using System.Text;
using AppCovid.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppCovid.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Covid> Covids { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
