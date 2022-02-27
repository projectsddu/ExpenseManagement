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
    public class ExpenseServiceClass : IExpenseService
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
                cmd.CommandText = "UPDATE Expense SET ExpenseDescription = @EDescription, ExpenseAmount = @EAmount, ExpenseDate = @EDate WHERE ExpenseId = " + expense.ExpenseId;


                SqlParameter p1 = new SqlParameter("@EDescription", expense.ExpenseDescription);
                SqlParameter p2 = new SqlParameter("@EAmount", expense.ExpenseAmount);
                SqlParameter p3 = new SqlParameter("@EDate", DateTime.Now);

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);

                int rows = cmd.ExecuteNonQuery();
                if(rows != 0)
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

        public List<ExpenseModel> ViewAllExpense()
        {
            try
            {
                //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Expense", @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExpenseManagementDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //DataSet ds = new DataSet();
                //da.Fill(ds, "Expense");
                //return ds;

                SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExpenseManagementDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Expense";
                SqlDataReader rdr = cmd.ExecuteReader();
                List<ExpenseModel> expenses = new List<ExpenseModel>();

                while (rdr.Read())
                {
                    ExpenseModel e = new ExpenseModel()
                    {
                        ExpenseId = int.Parse(rdr["ExpenseId"].ToString()),
                        ExpenseDescription = rdr["ExpenseDescription"].ToString(),
                        ExpenseAmount = int.Parse(rdr["ExpenseAmount"].ToString()),
                        ExpenseDate = Convert.ToDateTime(rdr["ExpenseDate"].ToString()),
                        ExpenseUserId = int.Parse(rdr["ExpenseUserId"].ToString())

                    };

                    expenses.Add(e);
                }

                return expenses;
            }
            catch(Exception error)
            {
                Console.WriteLine(error.Message);
                return null;
            }
        }

        public ExpenseModel ViewSingleExpense(int ExpenseId)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExpenseManagementDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Expense WHERE ExpenseId = " + ExpenseId;

                SqlDataReader rdr = cmd.ExecuteReader();

                ExpenseModel expense = new ExpenseModel();
                while(rdr.Read())
                {
                    expense.ExpenseId = int.Parse(rdr["ExpenseId"].ToString());
                    expense.ExpenseDescription = rdr["ExpenseDescription"].ToString();
                    expense.ExpenseDate = Convert.ToDateTime(rdr["ExpenseDate"].ToString());
                    expense.ExpenseAmount = float.Parse(rdr["ExpenseAmount"].ToString());
                    expense.ExpenseUserId = int.Parse(rdr["ExpenseUserId"].ToString());
                }

                return expense;

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return new ExpenseModel() { 
                    ExpenseId = -1
                };
            }
        }
    }
}
