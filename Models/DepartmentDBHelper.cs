using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace _3_CRUD.Models
{
    public class DepartmentDBHelper
    {
        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            string CS = ConfigurationManager.ConnectionStrings["EmpDeptCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Department", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Department d = new Department();
                    d.Id = (int)reader["Id"];
                    d.Name = reader["Name"].ToString();
                    d.Location = reader["Location"].ToString();

                    departments.Add(d);


                }
            }


            return departments;
        }

        public void InsertDepartment(Department dept)
        {
            string cs = ConfigurationManager.ConnectionStrings["EmpDeptCS"].ConnectionString;
            using (SqlConnection con=new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", dept.Name);
                cmd.Parameters.AddWithValue("@Location", dept.Location);

                con.Open();
                cmd.ExecuteNonQuery();
                
            }
        }

        public void UpdateDepartment(Department dept)
        {
            string cs = ConfigurationManager.ConnectionStrings["EmpDeptCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Usp_UpdateDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", dept.Id);
                cmd.Parameters.AddWithValue("@Name", dept.Name);
                cmd.Parameters.AddWithValue("@Location", dept.Location);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void DeleteDepartment(int? id)
        {
            string cs = ConfigurationManager.ConnectionStrings["EmpDeptCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Usp_UpdateDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id",id);
               

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
    } 
}