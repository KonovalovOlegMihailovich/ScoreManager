using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ScoreManager
{
    public class History
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public string Type { get; set; }
        public Employees? Employees { get; set; }
        public Department? Department { get; set; }

    }
    public class Reason
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
    }
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public List<Reason> Reasons { get; set; }
        public List<Employees> Employees { get; set; }
        public int Balance { get; set; }
        //public int LimitMountScore { get; set; }  //
        //public int LimitSectorScore { get; set; } // Будем считать из истории.
        //public int LimitYearScore { get; set; }   //
        public int Spent { get; set;  }
    }
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName { get; set; }
        public int TotalScore { get; set; }
        public Department Department { get; set; }
    }
    internal class ApplicationContext: DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<History> Histories { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\MSSQLSERVER1;Database=1c-galex;User ID=ARM_RP2;Password=12345678;");
        }
    }
}
