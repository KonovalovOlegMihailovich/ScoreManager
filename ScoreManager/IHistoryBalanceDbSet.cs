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
    interface IHistoryBalanceDbSet<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        List<TEntity> Get();
        List<History<TEntity>> GetHistories();
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Enrollment(TEntity entity, uint sum);
        void Writeoff(TEntity entity, uint sum);
    }
}
