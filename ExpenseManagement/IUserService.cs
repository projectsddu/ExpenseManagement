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
        UserModel AddUser(UserModel user);

        [OperationContract]
        UserModel GetUser(int userId);
    }
}
