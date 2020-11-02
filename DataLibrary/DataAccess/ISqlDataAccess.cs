using System;
using System.Collections.Generic;
using System.Data;

namespace DataLibrary.DataAccess
{
    //public interface ISqlDataAccess : IDisposable
    public interface ISqlDataAccess
    {
        T LoadData<T>(string sql);
        List<T> LoadAllData<T>(string sql);
        //int SaveData<T>(string sql, T data);
        int SaveData<T>(string sql, T data, CommandType commandType);
    }
}