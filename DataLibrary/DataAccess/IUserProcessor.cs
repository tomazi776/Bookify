using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.DataAccess
{
    public interface IUserProcessor
    {
        UserModel GetUser(int id);
        int CreateUser(int id, string firstName, string lastName, string emailAddress);
    }
}