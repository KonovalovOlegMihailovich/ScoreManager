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
    public class Limits
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public uint Year { get; set; } = (uint) DateTime.Now.Year; 
        public uint January { get; set; }
        public uint February { get; set; }
        public uint March { get; set; }
        public uint April { get; set; }
        public uint May { get; set; }
        public uint June { get; set; }
        public uint July { get; set; }
        public uint August { get; set; }
        public uint September { get; set; }
        public uint October { get; set; }
        public uint November { get; set; }
        public uint December { get; set; }
        public List<Department> departments { get; set; }
    }
    public class Tovar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; } 
        public string Name { get; set; }
        public uint Price { get; set; }
        public uint Quantity { get; set; }
    }

    public class History<TEntity> where TEntity : class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Type { get; set; }
        public uint Sum { get; set; }
        public TEntity Entity { get; set; }
    }
    
    public class Reason
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public uint Score { get; set; }
        public string Name { get; set; }
        public List<Department> departments { get; set; } = new List<Department>();
        public override string ToString() => Name;
    }
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public string DepartmentName { get; set; }
        public List<Reason> Reasons { get; set; } = new List<Reason>();
        public List<Employees> Employees { get; set; } = new List<Employees>();
        public List<Limits> Limits { get; set; } = new List<Limits>();
        public uint Balance { get; set; } = 0;
        public uint Spent { get; set; } = 0;
        public override string ToString() => DepartmentName;
    }
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public string FullName { get; set; }
        public uint Balance { get; set; } = 0;
        public Department Department { get; set; }
        public override string ToString() => FullName;
    }

    internal class ApplicationContext: DbContext
    {
        private DbSet<Employees> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        private DbSet<History<Employees>> HistoriesEmp { get; set; }
        public DbSet<Tovar> Tovars { get; set; }
        public HistoryBalanceEmployees historyBalanceEmployees { get; private set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
            historyBalanceEmployees = new HistoryBalanceEmployees(Employees, HistoriesEmp);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Здесь надо строчку подключения поменять, при желании можно реализовать чтобы 
            optionsBuilder.UseSqlServer("Data Source=.\\MSSQLSERVER1;Database=1c-galex;User ID=ARM_RP2;Password=12345678;");
        }
    }
}
