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

        public int getIdByUsername(string username)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM UserTable WHERE UserName = '" + username + "'" ;

                SqlDataReader rdr = cmd.ExecuteReader();
                int userId = -1;
                while(rdr.Read())
                {
                    userId = int.Parse(rdr["UserId"].ToString());
                }

                return userId;
            }
        }

        public string getUserNameById(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM UserTable WHERE UserId = " + id;

                SqlDataReader rdr = cmd.ExecuteReader();
                string username = "";
                while (rdr.Read())
                {
                    username = rdr["UserName"].ToString();
                }

                return username;
            }
        }

        public UserModel getUserObj(int userId)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM UserTable WHERE UserId = " + userId;

                SqlDataReader rdr = cmd.ExecuteReader();

                UserModel user = new UserModel();

                while(rdr.Read())
                {
                    user.UserId = userId;
                    user.UserName = rdr["UserName"].ToString();
                    user.UserCredit = float.Parse(rdr["UserCredit"].ToString());
                    user.UserDebit = float.Parse(rdr["UserDebit"].ToString());
                }

                return user;

            }
        }

        public bool updateUser(UserModel user)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE UserTable SET UserCredit = @credit, UserDebit = @debit WHERE UserId = @userid";

                SqlParameter p1 = new SqlParameter("@credit", user.UserCredit);
                SqlParameter p2 = new SqlParameter("@debit", user.UserDebit);
                SqlParameter p3 = new SqlParameter("@userid", user.UserId);

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);

                int rows = cmd.ExecuteNonQuery();

                if(rows <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
       
        public PaymentModel AddPayment(PaymentModel payment)
        {
            try
            {
                PaymentModel p = new PaymentModel();
                p.PaymentDescription = payment.PaymentDescription;
                p.PaymentDate = payment.PaymentDate.ToString() == "" ? DateTime.Now : payment.PaymentDate;
                p.PaymentFromUser = payment.PaymentFromUser;
                p.PaymentToUser = getIdByUsername(payment.PaymentToUser).ToString();
                p.PaymentAmount = payment.PaymentAmount;


                UserModel sender_user = getUserObj(int.Parse(payment.PaymentFromUser));
                UserModel receiver_user = getUserObj(int.Parse(p.PaymentToUser));

                Debug.WriteLine(sender_user.UserCredit);
                Debug.WriteLine(sender_user.UserDebit);

                float netAmt = sender_user.UserCredit - sender_user.UserDebit;

                if(netAmt < payment.PaymentAmount)
                {
                    return new PaymentModel() { PaymentId = -1 };
                }
                else
                {
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
                            Debug.WriteLine(payment.PaymentAmount);
                            sender_user.UserDebit += payment.PaymentAmount;
                            receiver_user.UserCredit += payment.PaymentAmount;
                            Debug.WriteLine(sender_user.UserDebit);
                            Debug.WriteLine(receiver_user.UserCredit);
                            updateUser(sender_user);
                            updateUser(receiver_user);

                            return payment;
                        }
                        else
                        {
                            return new PaymentModel() { PaymentId= -1 };
                        }
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
                cmd.CommandText = "UPDATE Payment SET PaymentDescription = @EDescription WHERE PaymentId = " + payment.PaymentId;

                //PaymentDescription, PaymentAmount, PaymentDate, PaymentFromUser,PaymentToUser
                SqlParameter p1 = new SqlParameter("@EDescription", payment.PaymentDescription);
                //SqlParameter p2 = new SqlParameter("@EAmount", payment.PaymentAmount);
                //SqlParameter p3 = new SqlParameter("@EDate", DateTime.Now);
                //SqlParameter p4 = new SqlParameter("@EFromUser", payment.PaymentFromUser);
                //SqlParameter p5 = new SqlParameter("@EToUser", getIdByUsername(payment.PaymentToUser).ToString());
                

                cmd.Parameters.Add(p1);
                //cmd.Parameters.Add(p2);
                //cmd.Parameters.Add(p3);
                //cmd.Parameters.Add(p4);
                //cmd.Parameters.Add(p5);

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

        public List<PaymentModel> ViewAllPayment(int userId)
        {
            string id = userId.ToString();
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Payment WHERE PaymentFromUser = '" + id + "'";
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
                        PaymentFromUser = getUserNameById(int.Parse(rdr["PaymentFromUser"].ToString())),
                        PaymentToUser = getUserNameById(int.Parse(rdr["PaymentToUser"].ToString())),
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
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Payment WHERE PaymentId = " + paymentId;

                SqlDataReader rdr = cmd.ExecuteReader();

                PaymentModel payment = new PaymentModel();
                while (rdr.Read())
                {
                    payment.PaymentId = int.Parse(rdr["PaymentId"].ToString());
                    payment.PaymentDescription = rdr["PaymentDescription"].ToString();
                    payment.PaymentDate = Convert.ToDateTime(rdr["PaymentDate"].ToString());
                    payment.PaymentAmount = float.Parse(rdr["PaymentAmount"].ToString());
                    payment.PaymentFromUser = getUserNameById(int.Parse(rdr["PaymentFromUser"].ToString()));
                    payment.PaymentToUser = getUserNameById(int.Parse(rdr["PaymentToUser"].ToString()));
                }

                return payment;

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return new PaymentModel()
                {
                    PaymentId = -1
                };
            }
        }
    }
}
