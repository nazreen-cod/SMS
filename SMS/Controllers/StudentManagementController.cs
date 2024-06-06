using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SMS.Models;
using System.Collections;
using StudentManagementSystem.Models;

namespace SMS.Controllers
{
    public class StudentManagementController : Controller
    {
        private readonly IConfiguration configuration;
        public StudentManagementController(IConfiguration config)
        {
            this.configuration = config;
        }
        IList<StudentManagement> GetDbList()
        {
            IList<StudentManagement> dbList = new List<StudentManagement>();
            SqlConnection conn = new SqlConnection(configuration.GetConnectionString("ParcelConnStr"));

            string sql = @"SELECT * FROM course";
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dbList.Add(new StudentManagement()
                    {
                        
                        courseName = reader.GetString(1),
                        
                    });
                }
            }

            catch
            {
                RedirectToAction("Error");
            }

            finally
            {
                conn.Close();
            }
            return dbList;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult addStudent(StudentManagement add)
        {
            SqlConnection conn = new SqlConnection(configuration.GetConnectionString("ParcelConnStr"));
            SqlCommand cmd = new SqlCommand("spInsertStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Add parameters
            cmd.Parameters.AddWithValue("@name", add.Name);
            cmd.Parameters.AddWithValue("@ic", add.IC);
            cmd.Parameters.AddWithValue("@address", add.Address);
            cmd.Parameters.AddWithValue("@intake", add.Intake);
            cmd.Parameters.AddWithValue("@age", add.Age);
            cmd.Parameters.AddWithValue("@phone", add.Phone);
            cmd.Parameters.AddWithValue("@personalemail", add.PersonalEmail);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Log the exception message
                Console.WriteLine("Error: " + ex.Message);
                return View(add);
            }
            finally
            {
                conn.Close();
            }

            return View("addStudent", add);
        }


        public IActionResult addCourse(StudentManagement course)
        {
            SqlConnection conn = new SqlConnection(configuration.GetConnectionString("ParcelConnStr"));
            SqlCommand cmd = new SqlCommand("spInsertCourse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //sender

            cmd.Parameters.AddWithValue("@coursedepartment", course.IndexDept);
            cmd.Parameters.AddWithValue("@coursename", course.courseName);
           

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            catch
            {
                return View(course);
            }

            finally
            {
                conn.Close();
            }


            return View("addCourse", course);
        }

        public IActionResult error()
        {
            return View();
        }

        
    }
}
