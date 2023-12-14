﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace EFCoreCodeFirstApproachTest.Models
{
    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Employees> Employees { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Technology> Technologies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CodeFirstDB;Integrated Security=True;TrustServerCertificate=True;");

    }
}
