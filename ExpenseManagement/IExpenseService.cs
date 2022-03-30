using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Models;

namespace ExpenseManagement
{
    [ServiceContract]
    public interface IExpenseService
    {
        [OperationContract]
        ExpenseModel AddExpense(ExpenseModel expense);

        [OperationContract]
        Boolean DeleteExpense(int ExpenseId);

        [OperationContract]
        ExpenseModel UpdateExpense(ExpenseModel expense);

        [OperationContract]
        ExpenseModel ViewSingleExpense(int ExpenseId);

        [OperationContract]
        List<ExpenseModel> ViewAllExpense(int userId);
    }
}
