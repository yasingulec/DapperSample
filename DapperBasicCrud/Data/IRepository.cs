using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperBasicCrud.Data
{
   public interface IRepository<T> where  T:class, new()
   {
       SqlConnection GetSqlConnection();
       List<T> GetList();
       T Get(int id);
       void Add(T Entity);
       void Update(T Entity);
       void Delete(T Entity);

   }
}
