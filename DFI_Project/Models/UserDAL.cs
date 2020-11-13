using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace DFI_Project.Models
{
    public class UserDAL
    {
        string connectionString = "Data Source=localhost;Initial Catalog=DFI_Database; Persist Security Info=False; User ID=sa; password=reallyStrongPwd123;";

        //Get All User
        public IEnumerable<User> GetAllUser()
        {
            List<User> empList = new List<User>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    User emp = new User();
                    emp.UserID = Convert.ToInt32(dr["UserID"].ToString());
                    emp.UserUsername = dr["UserUsername"].ToString();
                    emp.UserEmail = dr["UserEmail"].ToString();
                    emp.UserPassword = dr["UserPassword"].ToString();
                    emp.UserName = dr["UserName"].ToString();
                    emp.UserHometown = dr["UserHometown"].ToString();
                    emp.UserBirthDate = Convert.ToDateTime(dr["UserBirthDate"].ToString());
                    emp.UserTwitter = dr["UserTwitter"].ToString();
                    emp.UserInstagram = dr["UserInstagram"].ToString();

                    empList.Add(emp);
                }
                con.Close();
            }
            return empList;
        }

        //To Insert User
        public void AddUser(User emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@UserID", emp.UserID);
                cmd.Parameters.AddWithValue("@UserUsername", emp.UserUsername);
                cmd.Parameters.AddWithValue("@UserEmail", emp.UserEmail);
                cmd.Parameters.AddWithValue("@UserPassword", emp.UserPassword);
                cmd.Parameters.AddWithValue("@UserName", emp.UserName);
                cmd.Parameters.AddWithValue("@UserHometown", emp.UserHometown);
                cmd.Parameters.AddWithValue("@UserBirthDate", emp.UserBirthDate);
                cmd.Parameters.AddWithValue("@UserTwitter", emp.UserTwitter);
                cmd.Parameters.AddWithValue("@UserInstagram", emp.UserInstagram);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update User
        public void UpdateUser(User emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpUserID", emp.UserID);
                cmd.Parameters.AddWithValue("@UserUsername", emp.UserUsername);
                cmd.Parameters.AddWithValue("@UserEmail", emp.UserEmail);
                cmd.Parameters.AddWithValue("@UserPassword", emp.UserPassword);
                cmd.Parameters.AddWithValue("@UserName", emp.UserName);
                cmd.Parameters.AddWithValue("@UserHometown", emp.UserHometown);
                cmd.Parameters.AddWithValue("@UserBirthDate", emp.UserBirthDate);
                cmd.Parameters.AddWithValue("@UserTwitter", emp.UserTwitter);
                cmd.Parameters.AddWithValue("@UserInstagram", emp.UserInstagram);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }  
        }

        //To Delete User
        public void DeleteUser(int? empUserID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpUserID", empUserID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get User By ID
        public User GetUserByID(int empUserID)
        {
            User emp = new User();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetUserById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpUserID", empUserID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                 
                    emp.UserID = Convert.ToInt32(dr["UserID"].ToString());
                    emp.UserUsername = dr["UserUsername"].ToString();
                    emp.UserEmail = dr["UserEmail"].ToString();
                    emp.UserPassword = dr["UserPassword"].ToString();
                    emp.UserName = dr["UserName"].ToString();
                    emp.UserHometown = dr["UserHometown"].ToString();
                    emp.UserBirthDate = Convert.ToDateTime(dr["UserBirthDate"].ToString());
                    emp.UserTwitter = dr["UserTwitter"].ToString();
                    emp.UserInstagram = dr["UserInstagram"].ToString();


                }
                con.Close();
            }
            return emp;
        }


    }
}
