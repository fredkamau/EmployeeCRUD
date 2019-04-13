namespace EmployeeCRUD
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeeDataModel : DbContext
    {
        public EmployeeDataModel()
            : base("name=EmployeeDataModel")
        {
        }

        public virtual DbSet<employees_tbl> employees_tbl { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
