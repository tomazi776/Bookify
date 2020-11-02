using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.DataAccess
{
    public class UserProcessor : IUserProcessor
    {
        private readonly ISqlDataAccess _dataAccess;
        public UserProcessor(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public UserModel GetUser(int userId)
        {
            string query = $@"SELECT Id, UserId, FirstName, LastName, EmailAddress 
                             FROM dbo.User
                             WHERE UserId = '{userId}';";
            return _dataAccess.LoadData<UserModel>(query);
        }

        public int CreateUser(int userId, string firstName, string lastName, string emailAddress)
        {
            string sp = $@"dbo.spInsert_User";
            int rowsAffected = _dataAccess.SaveData(sp, new { 
                UserId = userId, 
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress}, System.Data.CommandType.StoredProcedure);
            return rowsAffected;
        }
    }
}
