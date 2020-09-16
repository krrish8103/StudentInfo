using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentInfo.Entity
{
    public partial class StudentInfoDbContext : DbContext
    {
        public StudentInfoDbContext()
        {
        }

        public StudentInfoDbContext(DbContextOptions<StudentInfoDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
