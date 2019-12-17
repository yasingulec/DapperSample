using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperBasicCrud.Entities;

namespace DapperBasicCrud.Data
{
   public class Repository:IRepository<Contact>
   {
        public void Add(Contact Entity)
        {
            string sp = "insert_contact";
            using (var conn = GetSqlConnection())
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("FirstName",Entity.FirstName);
                parameter.Add("LastName", Entity.LastName);
                parameter.Add("ProfilePicture", Entity.ProfilePicture);
                parameter.Add("City", Entity.City);
                parameter.Add("Country", Entity.Country);
                var addedEntity = conn.Execute(sp, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(Contact Entity)
        {
            using (var conn=GetSqlConnection())
            {
                string sp = "delete_contact";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("ContactId", Entity.ContactId);
                var deletedEntity = conn.Execute(sp, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public Contact Get(int id)
        {
            using (var conn = GetSqlConnection())
            { 
                return conn.QueryFirstOrDefault<Contact>($"select * from Contact where ContactId={id}");
            }
        }

        public List<Contact> GetList()
        {
            using (var conn = GetSqlConnection())
            {
                return conn.Query<Contact>($"select * from Contact").ToList();
            }
        }

        public SqlConnection GetSqlConnection()
        {
            var connection=new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            connection.Open();
            return connection;
        }

        public void Update(Contact Entity)
        {
            throw new NotImplementedException();
        }
    }
}
