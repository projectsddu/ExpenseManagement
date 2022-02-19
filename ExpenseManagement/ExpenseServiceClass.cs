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

                SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExpenseManagementDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                using(connection)
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO Expense (ExpenseDescription, ExpenseAmount, ExpenseDate, ExpenseUserId) VALUES (@EDescription, @EAmount, @EDate, @EUserId)";

                    SqlParameter p1 = new SqlParameter("@EDescription", expense.ExpenseDescription);
                    SqlParameter p2 = new SqlParameter("@EAmount", expense.ExpenseAmount);
                    SqlParameter p3 = new SqlParameter("@EDate", DateTime.Now);
                    SqlParameter p4 = new SqlParameter("@EUserId", 1);

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

        public Boolean DeleteExpense(int ExpenseId)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExpenseManagementDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Expense WHERE ExpenseId = " + ExpenseId;

                int row = cmd.ExecuteNonQuery();
                if(row > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine("Error:", err.ToString());
                return false;
            }
        }

        public ExpenseModel UpdateExpense(ExpenseModel expense)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExpenseManagementDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Expense SET ExpenseDescription=@EDescription,ExpenseAmount=@EAmount,ExpenseDate=@EDate WHERE ExpenseId=" + expense.ExpenseId;


                SqlParameter p1 = new SqlParameter("@EDescription", expense.ExpenseDescription);
                SqlParameter p2 = new SqlParameter("@EAmount", expense.ExpenseAmount);
                SqlParameter p3 = new SqlParameter("@EDate", DateTime.Now);

                int rows = cmd.ExecuteNonQuery();
                if(rows!=0)
                {
                    return expense;
                }
                else
                {
                    expense.ExpenseId = -1;
                    return expense; 
                }
            }
            catch(Exception err)
            {
                expense.ExpenseId = -1;
                Debug.WriteLine("Error:", err.ToString());
                return expense;
            }
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
