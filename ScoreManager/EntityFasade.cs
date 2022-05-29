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
    public class Tovar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; } 
        public string Name { get; set; }
        public uint Price { get; set; }
        public uint Quantity { get; set; }
    }

    public class History
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public DateTime Date { get; set; } 
        public string Type { get; set; }
        public Employees? Employees { get; set; }
        public Department? Department { get; set; }
    }
    public class Reason
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public uint Score { get; set; }
        public string Name { get; set; }
    }
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public string DepartmentName { get; set; }
        public List<Reason> Reasons { get; set; }
        public List<Employees> Employees { get; set; }
        public uint Balance { get; set; }
        public int Spent { get; set; }
    }
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public string FullName { get; set; }
        public uint TotalScore { get; set; }
        public Department Department { get; set; }
    }
    internal class ApplicationContext: DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Tovar> Tovars { get; set; }
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
