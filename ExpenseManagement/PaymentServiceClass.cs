using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Models;

namespace ExpenseManagement
{
    public class PaymentServiceClass : IPaymentService
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExpenseManagementDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public PaymentModel AddPayment(PaymentModel payment)
        {
            try
            {
                PaymentModel p = new PaymentModel();
                p.PaymentDescription = payment.PaymentDescription;
                p.PaymentDate = payment.PaymentDate.ToString() == "" ? DateTime.Now : payment.PaymentDate;
                p.PaymentFromUser = "Admin";
                p.PaymentToUser = payment.PaymentToUser;
                p.PaymentAmount = payment.PaymentAmount;


                //ExpenseModel e = new ExpenseModel();
                //e.ExpenseDescription = expense.ExpenseDescription;
                //e.ExpenseDate = DateTime.Now;
                //e.ExpenseAmount = expense.ExpenseAmount;
                //// Get user id from cookies.
                //e.ExpenseUserId = 1;

                SqlConnection connection = new SqlConnection(connectionString);

                using (connection)
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO Payment (PaymentDescription, PaymentAmount, PaymentDate, PaymentFromUser,PaymentToUser) VALUES (@EDescription, @EAmount, @EDate, @EFromUser,@EToUser)";

                    SqlParameter p1 = new SqlParameter("@EDescription", p.PaymentDescription);
                    SqlParameter p2 = new SqlParameter("@EAmount", p.PaymentAmount);
                    SqlParameter p3 = new SqlParameter("@EDate", p.PaymentDate);
                    SqlParameter p4 = new SqlParameter("@EFromUser", p.PaymentFromUser);
                    SqlParameter p5 = new SqlParameter("@EToUser", p.PaymentToUser);

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);
                    cmd.Parameters.Add(p5);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows != 0)
                    {
                        return payment;
                    }
                    else
                    {
                        return new PaymentModel() { PaymentId= -1 };
                    }
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine("Error:", err.ToString());
                return new PaymentModel() { PaymentId = -1 };
            }
        }

        public bool DeletePayment(int paymentId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Payment WHERE PaymentId = " + paymentId;

                int row = cmd.ExecuteNonQuery();
                if (row > 0)
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

        public PaymentModel UpdatePayment(PaymentModel payment)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Payment SET PaymentDescription = @EDescription, PaymentAmount = @EAmount, PaymentDate = @EDate,PaymentFromUser = @EFromUser,PaymentToUser=@EToUser WHERE PaymentId = " + payment.PaymentId;

                //PaymentDescription, PaymentAmount, PaymentDate, PaymentFromUser,PaymentToUser
                SqlParameter p1 = new SqlParameter("@EDescription", payment.PaymentDescription);
                SqlParameter p2 = new SqlParameter("@EAmount", payment.PaymentAmount);
                SqlParameter p3 = new SqlParameter("@EDate", DateTime.Now);
                SqlParameter p4 = new SqlParameter("@EFromUser", "Admin");
                SqlParameter p5 = new SqlParameter("@EToUser", payment.PaymentToUser);
                

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);

                int rows = cmd.ExecuteNonQuery();
                if (rows != 0)
                {
                    return payment;
                }
                else
                {
                    payment.PaymentId= -1;
                    return payment;
                }
            }
            catch (Exception err)
            {

                payment.PaymentId = -1;
                Debug.WriteLine("Error:", err.ToString());
                return payment;
            }
        }

        public List<PaymentModel> ViewAllPayment()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Payment";
                SqlDataReader rdr = cmd.ExecuteReader();
                List<PaymentModel> payments = new List<PaymentModel>();

                while (rdr.Read())
                {
                    PaymentModel p = new PaymentModel()
                    {
                        PaymentId = int.Parse(rdr["PaymentId"].ToString()),
                        PaymentDescription = rdr["PaymentDescription"].ToString(),
                        PaymentAmount = float.Parse(rdr["PaymentAmount"].ToString()),
                        PaymentDate = Convert.ToDateTime(rdr["PaymentDate"].ToString()),
                        PaymentFromUser = rdr["PaymentFromUser"].ToString(),
                        PaymentToUser = rdr["PaymentToUser"].ToString(),
                    };

                    payments.Add(p);
                }

                return payments;
            }
            catch(Exception error)
            {
                Console.WriteLine(error.Message);
                return null;
            }
}

        public PaymentModel ViewSinglePayment(int paymentId)
        {
            throw new NotImplementedException();
        }
    }
}
