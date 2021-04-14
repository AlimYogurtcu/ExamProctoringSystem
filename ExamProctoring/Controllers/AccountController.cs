using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamProctoring.Models;

namespace ExamProctoring.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        string connectionString = "Data Source=tcp:examproctoringdatabase.database.windows.net,1433;Initial Catalog=ExamProctoring_db;User Id=examproctoring@examproctoringdatabase;Password=Exam1907";
        
        SqlConnection cnnct;
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {

            DateTime date = DateTime.Now;

            bool isProctor = false;
            cnnct = new SqlConnection(connectionString); 
            string query = "SELECT * FROM account_information WHERE account_username = '"+acc.accountUsername+"' and account_password = '"+acc.accountPassword+"';";
            /*string queryTwo = "INSERT INTO `account_info` (`id`, `account_username`, `account_password`, `account_role`) VALUES (NULL, '21704737', 'pass123', 'Student')";

            MySqlCommand cmmndTwo = new MySqlCommand(queryTwo, cnnct);*/
            SqlCommand cmmnd = new SqlCommand(query,cnnct);
            SqlDataReader reader;
            
            cnnct.Open();

            /*cmmndTwo.ExecuteNonQuery();*/

            reader = cmmnd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetString(3) == "Student")
                {
                    isProctor = false;
                }
                else if(reader.GetString(3) == "Teacher")
                {
                    isProctor = true;
                }
            }
            else
            {
                return View("test");
            }

            cnnct.Close();
            if (isProctor)
            {
                return View("Teacher");
            }
            else
            {
                return View("ExamPage");
            }
        }
    }
}