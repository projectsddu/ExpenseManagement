using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ExpenseManagement.Models;

namespace ExpenseManagement
{
    class ExpenseServiceClass : IExpenseService
    {
        public ExpenseModel AddExpense(ExpenseModel expense)
        {
            try
            {
                ExpenseModel e = new ExpenseModel();
                e.ExpenseDescription = expense.ExpenseDescription;
                e.ExpenseDate = DateTime.Now;
                e.ExpenseAmount = expense.ExpenseAmount;
                // Get user id from cookies.
                e.ExpenseUserId = 1;

                SqlConnection connection = new SqlConnection("");
                using(connection)
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO Expense (ExpenseId,ExpenseDescription,ExpenseAmount,ExpenseDate,ExpenseUserId) VALUES (null,@EDescription,@EAmount,@EDate,@EUserId)";

                    SqlParameter p1 = new SqlParameter("EDescription", expense.ExpenseDescription);
                    SqlParameter p2 = new SqlParameter("EAmount", expense.ExpenseAmount);
                    SqlParameter p3 = new SqlParameter("EDate", DateTime.Now);
                    SqlParameter p4 = new SqlParameter("EUserId", 1);

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);

                    int rows = cmd.ExecuteNonQuery();
                    if(rows!=0)
                    {
                        return expense;
                    }
                    else
                    {
                        return new ExpenseModel() { ExpenseId = -1 };
                    }
                }
            }
            catch(Exception err)
            {
                Debug.WriteLine("Error:", err.ToString());
                ExpenseModel e = new ExpenseModel();
                e.ExpenseId = -1;
                return e;
            }
        }

        public ExpenseModel DeleteExpense(int ExpenseId)
        {
            throw new NotImplementedException();
        }

        public ExpenseModel UpdateExpense(ExpenseModel expense)
        {
            throw new NotImplementedException();
        }

        public DataSet ViewAllExpense()
        {
            throw new NotImplementedException();
        }

        public ExpenseModel ViewSingleExpense(int ExpenseId)
        {
            throw new NotImplementedException();
        }
    }
}
