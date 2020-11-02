using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace DataLibrary.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        public SqlDataAccess(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string ConnectionString(string connectionName = "BookifyDbCnn")
        {
            return _config.GetConnectionString(connectionName);
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
        public T LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(ConnectionString()))
            {
                return cnn.Query<T>(sql).FirstOrDefault();
            }
        }

        public List<T> LoadAllData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(ConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public int SaveData<T>(string sql, T data, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection cnn = new SqlConnection(ConnectionString()))
            {
                return cnn.Execute(sql, data, commandType: CommandType.StoredProcedure);
            }
        }
    }

    //    public int SaveData<T>(string sql, T data)
    //    {
    //        using (IDbConnection cnn = new SqlConnection(ConnectionString()))
    //        {
    //            return cnn.Execute(sql, data);
    //        }
    //    }
    //}
}
