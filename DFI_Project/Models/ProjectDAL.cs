using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace DFI_Project.Models
{
    public class ProjectDAL
    {
        string connectionString = "Data Source=localhost;Initial Catalog=DFI_Database; Persist Security Info=False; User ID=sa; password=reallyStrongPwd123;";

        //Get All Project
        public IEnumerable<Project> GetAllProject()
        {
            List<Project> empList = new List<Project>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllProject", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Project emp = new Project();
                    emp.ProjectID = Convert.ToInt32(dr["ProjectID"].ToString());
                    emp.ProjectTitle = dr["ProjectTitle"].ToString();
                    emp.ProjectTheme = dr["ProjectTheme"].ToString();
                    emp.ProjectRegistStart = Convert.ToDateTime(dr["ProjectRegistStart"].ToString());
                    emp.ProjectRegistEnd = Convert.ToDateTime(dr["ProjectRegistEnd"].ToString());
                    emp.ProjectDeadline = Convert.ToDateTime(dr["ProjectDeadline"].ToString());
                    emp.ProjectPostDate = Convert.ToDateTime(dr["ProjectPostDate"].ToString());
                    emp.ProjectColorPalette = dr["ProjectColorPalette"].ToString();
                    emp.ProjectCanvasSize = dr["ProjectCanvasSize"].ToString();
                    emp.ProjectDescription = dr["ProjectDescription"].ToString();

                    empList.Add(emp);
                }
                con.Close();
            }
            return empList;
        }

        //To Insert User
        public void AddProject(Project emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertProject", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProjectTitle", emp.ProjectTitle);
                cmd.Parameters.AddWithValue("@ProjectTheme", emp.ProjectTheme);
                cmd.Parameters.AddWithValue("@ProjectRegistStart", emp.ProjectRegistStart);
                cmd.Parameters.AddWithValue("@ProjectRegistEnd", emp.ProjectRegistEnd);
                cmd.Parameters.AddWithValue("@ProjectDeadline", emp.ProjectDeadline);
                cmd.Parameters.AddWithValue("@ProjectPostDate", emp.ProjectPostDate);
                cmd.Parameters.AddWithValue("@ProjectColorPalette", emp.ProjectColorPalette);
                cmd.Parameters.AddWithValue("@ProjectCanvasSize", emp.ProjectCanvasSize);
                cmd.Parameters.AddWithValue("@ProjectDescription", emp.ProjectDescription);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update Project
        public void UpdateProject(Project emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateProject", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpProjectID", emp.ProjectID);
                cmd.Parameters.AddWithValue("@ProjectTitle", emp.ProjectTitle);
                cmd.Parameters.AddWithValue("@ProjectTheme", emp.ProjectTheme);
                cmd.Parameters.AddWithValue("@ProjectRegistStart", emp.ProjectRegistStart);
                cmd.Parameters.AddWithValue("@ProjectRegistEnd", emp.ProjectRegistEnd);
                cmd.Parameters.AddWithValue("@ProjectDeadline", emp.ProjectDeadline);
                cmd.Parameters.AddWithValue("@ProjectPostDate", emp.ProjectPostDate);
                cmd.Parameters.AddWithValue("@ProjectColorPalette", emp.ProjectColorPalette);
                cmd.Parameters.AddWithValue("@ProjectCanvasSize", emp.ProjectCanvasSize);
                cmd.Parameters.AddWithValue("@ProjectDescription", emp.ProjectDescription);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Delete Project
        public void DeleteProject(int? empProjectID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteProject", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpProjectID", empProjectID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get User By ID
        public Project GetProjectByID(int empProjectID)
        {
            Project emp = new Project();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetProjectByID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpProjectID", empProjectID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    emp.ProjectID = Convert.ToInt32(dr["ProjectID"].ToString());
                    emp.ProjectTitle = dr["ProjectTitle"].ToString();
                    emp.ProjectTheme = dr["ProjectTheme"].ToString();
                    emp.ProjectRegistStart = Convert.ToDateTime(dr["ProjectRegistStart"].ToString());
                    emp.ProjectRegistEnd = Convert.ToDateTime(dr["ProjectRegistEnd"].ToString());
                    emp.ProjectDeadline = Convert.ToDateTime(dr["ProjectDeadline"].ToString());
                    emp.ProjectPostDate = Convert.ToDateTime(dr["ProjectPostDate"].ToString());
                    emp.ProjectColorPalette = dr["ProjectColorPalette"].ToString();
                    emp.ProjectCanvasSize = dr["ProjectCanvasSize"].ToString();
                    emp.ProjectDescription = dr["ProjectDescription"].ToString();
                }
                con.Close();
            }
            return emp;
        }


    }
}
