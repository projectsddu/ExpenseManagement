using ExpenseManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Diagnostics;

using System.Web;


namespace ExpenseManagement
{
    
    public class UserServiceClass : IUserService
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExpenseManagementDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public UserModel AddUser(UserModel user)
        {
            UserModel newUser = new UserModel();
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO UserTable (UserName, UserEmail, UserCredit, UserDebit, UserPassword) VALUES (@username, @useremail, @usercredit, @userdebit, @userpassword)";

                
                newUser.UserName = user.UserName;
                newUser.UserEmail = user.UserEmail;
                newUser.UserCredit = user.UserCredit;
                newUser.UserDebit = user.UserDebit;
                newUser.UserPassword = user.UserPassword;

                SqlParameter p1 = new SqlParameter("@username", user.UserName);
                SqlParameter p2 = new SqlParameter("@useremail", user.UserEmail);
                SqlParameter p3 = new SqlParameter("@usercredit", user.UserCredit);
                SqlParameter p4 = new SqlParameter("@userdebit", user.UserDebit);
                SqlParameter p5 = new SqlParameter("@userpassword", user.UserPassword);

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);

                int row = cmd.ExecuteNonQuery();
                Debug.WriteLine("Number of rows: " + row);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return new UserModel() { 
                    UserName = error.Message
                };
            }

            return newUser;
        }
       
        public UserModel GetUser(int userId)
        {

            UserModel user = new UserModel();
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM UserTable WHERE UserId = " + userId;

                SqlDataReader rdr = cmd.ExecuteReader();
                
                while(rdr.Read())
                {
                    user.UserId = int.Parse(rdr["Userid"].ToString());
                    user.UserName = rdr["UserName"].ToString();
                    user.UserEmail = rdr["UserEmail"].ToString();
                    user.UserCredit = float.Parse(rdr["UserCredit"].ToString());
                    user.UserDebit = float.Parse(rdr["UserDebit"].ToString());
                    user.UserPassword = rdr["UserEmail"].ToString();
                }
                rdr.Close();
                con.Close();
            }
            catch(Exception error)
            {
                Console.WriteLine(error.Message);
                return new UserModel()
                {
                    UserName = error.Message
                };
            }
            return user;
        }
    }
}
