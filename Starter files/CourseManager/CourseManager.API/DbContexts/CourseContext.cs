using CourseManager.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.API.DbContexts
{
    public class CourseContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public CourseContext()
        { }
    }
}
