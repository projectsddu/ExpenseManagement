using ExpenseManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ExpenseManagement
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        string AddUser(UserModel user);

        [OperationContract]
        int LoginUser(string username, string password);

        [OperationContract]
        UserModel GetUser(int userId);
    }
}
