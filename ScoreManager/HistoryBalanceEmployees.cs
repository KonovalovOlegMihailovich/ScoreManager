﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoreManager
{
    class HistoryBalanceEmployees: IHistoryBalanceDbSet<Employees>
    {
        private DbSet<Employees> Entities { get; set; }
        private DbSet<History<Employees>> Histories { get; set; }
        public HistoryBalanceEmployees(in DbSet<Employees> entities, in DbSet<History<Employees>> histories)
        {
            Entities = entities;
            Histories = histories;
        }
        public void Add(Employees entity) 
        {
            Entities.Add(entity);
            Histories.Add(new History<Employees> 
            { 
                Date = DateTime.Now, 
                Time = TimeSpan.Parse(DateTime.Now.ToLongTimeString()),
                Entity = entity,
                Sum = entity.Balance, // В форме не будет поля для указания баланса, все начисления, через начисления идут.
                Type = "Added"
            });
        }
        
        public void Update(Employees entity) 
        {
            Entities.Update(entity);
            Histories.Add(new History<Employees>
            {
                Date = DateTime.Now,
                Time = TimeSpan.Parse(DateTime.Now.ToLongTimeString()),
                Entity = entity,
                Sum = entity.Balance,
                Type = "Update"
            });
        }
        public void Remove(Employees entity)
        {
            Histories.RemoveRange(Histories.Where(s => s.Entity == entity)); // Удаляем всю историю связаную с данной записью
            Entities.Remove(entity);
        }
       

        public void Enrollment(Employees entity, uint sum) 
        {
            // Тяжело будет такое регистрировать, но другого решения не вижу.
            if (entity.Department.Balance < sum) throw new Exception("To many Balance Departament");
            entity.Department.Balance -= sum;
            entity.Department.Spent += sum; 
            entity.Balance += sum;
            Entities.Update(entity);
            Histories.Add(new History<Employees>
            {
                Date = DateTime.Now,
                Time = TimeSpan.Parse(DateTime.Now.ToLongTimeString()),
                Entity = entity,
                Sum = entity.Balance,
                Type = "Enrollment"
            });
        }
        
        public void Writeoff(Employees entity, uint sum) 
        {
            if (entity.Balance < sum) throw new Exception("To many Balance");
            entity.Balance -= sum;
            Entities.Update(entity);
            Histories.Add(new History<Employees>
            {
                Date = DateTime.Now,
                Time = TimeSpan.Parse(DateTime.Now.ToLongTimeString()),
                Entity = entity,
                Sum = entity.Balance,
                Type = "Write-off"
            });
        }
        
        public void Buy(Employees entity, Tovar tovar) 
        {
            if (entity.Balance < tovar.Price)
                throw new Exception("To many balance");
            if (tovar.Quantity == 0)
                throw new Exception("Tovar not found");
            entity.Balance -= tovar.Price;
            tovar.Quantity--;
        }
        public List<Employees> Get() => Entities.ToList();
        public List<History<Employees>> GetHistories() => Histories.ToList();
        // перегрузки, для удобства
        public void Remove(uint id) => Remove(Entities.Where(s => s.Id == id).First());
        public void Enrollment(uint id, uint sum) => Enrollment(Entities.Where(s => s.Id == id).First(), sum);
        public void Writeoff(uint id, uint sum) => Writeoff(Entities.Where(s => s.Id == id).First(), sum);
        public void Buy(uint idEmp, Tovar tovar) => Buy(Entities.Where(s => s.Id == idEmp).First(), tovar); 
    }
}