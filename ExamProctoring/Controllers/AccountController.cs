using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamProctoring.Models;
using MySqlConnector;

namespace ExamProctoring.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        string connectionString = "SERVER=localhost;DATABASE=schooldb; UID=root; Password=mysql123;"; // connection string for my sql
        MySqlConnection cnnct;
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            bool isProctor = false;
            cnnct = new MySqlConnection(connectionString); 
            string query = "SELECT * FROM account_info WHERE account_username = '"+acc.accountUsername+"' and account_password = '"+acc.accountPassword+"';";
            /*string queryTwo = "INSERT INTO `account_info` (`id`, `account_username`, `account_password`, `account_role`) VALUES (NULL, '21704737', 'pass123', 'Student')";

            MySqlCommand cmmndTwo = new MySqlCommand(queryTwo, cnnct);*/
            MySqlCommand cmmnd = new MySqlCommand(query,cnnct);
            MySqlDataReader reader;
            
            cnnct.Open();

            /*cmmndTwo.ExecuteNonQuery();*/

            reader = cmmnd.ExecuteReader();

            if (reader.Read())
            {
                if(reader.GetString("account_role") == "Student")
                {
                    isProctor = false;
                }
                else if(reader.GetString("account_role") == "Teacher")
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