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
        //public override string ToString() => $"{January}, {February}, {March}, {April}, {May}, {June}, {July}, {August}, {September}, {October}, {November}, {December}";
        public override string ToString() => string.Join(",", ToArray());
        public uint[] ToArray() => new uint[12] { January, February, March, April, May, June, July, August, September, October, November, December }; // 
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
        //public TimeSpan Time { get; set; }
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
        public Limits? Limits { get; set; }
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
        public Department? Department { get; set; } // Для того чтобы сотрудники не удалялись при удалении их из отдела
        public override string ToString() => FullName;
    }

    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; private set; }
        public DateTime Date { get; private set; } = DateTime.Now;
    }

    public class Company // Будет только одна запись в ней, много компаний не надо.
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; private set; }
        public uint Balance { get; set; } = 20000;
        private uint _balance { get; set; } = 0;
        private uint _addsiter { get; set; } = 0;
        internal void SetBalance(uint sum) => Balance = sum;
        internal void Add(uint sum)
        {
            _addsiter++;
            _balance += sum;
            if (_addsiter == 4)
                QueareAdd();
        }
        private void QueareAdd() 
        {
            Balance += _balance;
            _balance = 0;
            _addsiter = 0;
        }
    }

    internal class ApplicationContext : DbContext
    {
        private DbSet<Employees> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        private DbSet<History<Employees>> HistoriesEmp { get; set; }
        public DbSet<Tovar> Tovars { get; set; }
        public DbSet<Limits> Limits { get; set; }
        public HistoryBalanceEmployees historyBalanceEmployees { get; private set; }
        public DbSet<Login> Logins { get; set; } // Для расчёта лимитов и баланса.
        private DbSet<Company> Company { get; set; }

        public Company GetCompany()
        {
            if (Company.Count() == 0)
            { 
                Company.Add(new Company());
                this.SaveChanges();
            }
            return Company.First();
        }
        
        public void UpBalance(uint sum)
        {
            Company c = GetCompany();
            c.Add(sum);
            Company.Update(c);
            this.SaveChanges();
        }
        public void DownBalance(uint sum)
        {
            Company c = GetCompany();
            c.Balance -= sum;
            Company.Update(c);
            this.SaveChanges();
        }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            historyBalanceEmployees = new HistoryBalanceEmployees(Employees, HistoriesEmp);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Здесь надо строчку подключения поменять, при желании можно реализовать чтобы выдавалось окно
            optionsBuilder.UseSqlServer("Data Source=.\\MSSQLSERVER1;Database=1c-galex;User ID=ARM_RP2;Password=12345678;");
        }
    }
}
