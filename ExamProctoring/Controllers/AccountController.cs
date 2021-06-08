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
        /*string connectionString = "Data Source=tcp:examproctoringdatabase.database.windows.net,1433;Initial Catalog=ExamProctoring_db;User Id=examproctoring@examproctoringdatabase;Password=Exam1907";
        
        SqlConnection cnnct;*/
        //[HttpGet]
        public ActionResult AccountDetails()// a test action to show account details 
        {
            AccountContext accountContext = new AccountContext();
            Account account = accountContext.Accounts.Single(acc => acc.account_username.ToString() == "CHANGE HERE TO MAKE IT WORK");// gets the data table and finds the matching username to show on accountdetail view
            return View(account);

        }
        public ActionResult Login()// action to return login view
        {
            return View();   
        }

        [HttpPost]
        public String FormValuesTest(FormCollection formCollection)//action to test formcollection values
        {
            return formCollection["account_username"];
        }

        public ActionResult ExamPageSessionNotNull() // Action to use when the session is not full. With this action user cannot login 2 accounts at the same time
        {
            return View("ExamPage");
        }

        [HttpPost]
        public ActionResult ExamPage(FormCollection formCollection) // the post request of the form to get the login info from form, check it and return the view to the user corresponding to the account.
        {
            AccountContext accountContext = new AccountContext();
            String accountUsernameFromForm = formCollection["account_username"];
            String accountPasswordFromForm = formCollection["account_password"];
            try{// to check if the account exist or not
                if(Session["username"] == null)// if statement to check if the Session "user" is empty or not
                {
                    Account account = accountContext.Accounts.Single(acc => acc.account_username.ToString() == accountUsernameFromForm && acc.account_password.ToString() == accountPasswordFromForm);
                    Session["username"] = accountUsernameFromForm;
                    Session["name"] = account.account_name.ToString();
                    ViewBag.Name = account.account_name.ToString();
                    ViewBag.Username = account.account_username.ToString();
                    String accountRole = account.account_role.ToString();
                    

                    if (accountRole == "Student")
                    {
                        return View();
                    }
                    if (accountRole == "Teacher")
                    {
                        return View("Teacher");
                    }

                    return View("Login");
                }
                else
                {
                    return View();
                }
            }
            catch//if account does not exist
            {
                return View("Login");
            }
        }

        [HttpPost]
        public String Test() //test to see if the post request of forn works or not
        {
            return "Post  action _Test_ is working.";
        }

        /*[HttpPost]
        public ActionResult Verify(Account acc)
        {

            bool isProctor = false;
            cnnct = new SqlConnection(connectionString); 
            string query = "SELECT * FROM account_information WHERE account_username = '"+acc.accountUsername+"' and account_password = '"+acc.accountPassword+"';";

            SqlCommand cmmnd = new SqlCommand(query,cnnct);
            SqlDataReader reader;

            cnnct.Open();
            List<Account> model = new List<Account>();

            reader = cmmnd.ExecuteReader();

            if (reader.Read())
            {
                var user = new Account();
                string queryTwo = "UPDATE account_information SET account_status = 'Online' WHERE account_id = " + reader["account_id"].ToString() + ";";
                SqlCommand cmmndTwo = new SqlCommand(queryTwo,cnnct);
                user.accountUsername = reader["account_username"].ToString();
                model.Add(user);

                if (reader.GetString(3) == "Student")
                {

                    isProctor = false;
                }
                else if(reader.GetString(3) == "Teacher")
                {
                    isProctor = true;
                }
                reader.Close();
                cmmndTwo.ExecuteNonQuery();
                Session["loggedUser"] = user.accountUsername.ToString();
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
                return View("ExamPage", model);
            }
        }*/
    }
}