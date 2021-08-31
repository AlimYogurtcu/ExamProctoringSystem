using System;
using System.Linq;
using System.Web.Mvc;
using ExamProctoring.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoring.Controllers
{
    public class AccountController : Controller
    {
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
            Session.RemoveAll();
            try
            {// to check if the account exist or not
             // DATABASE BAĞLANTISI
             //Account account = accountContext.Accounts.Single(acc => acc.account_username.ToString() == accountUsernameFromForm && acc.account_password.ToString() == accountPasswordFromForm);
             //Session["username"] = accountUsernameFromForm;
             //Session["name"] = account.account_name.ToString();
             //ViewBag.Name = account.account_name.ToString();
             //ViewBag.Username = account.account_username.ToString();
             //String accountRole = account.account_role.ToString();

                //if (accountRole == "Student")
                //{
                //    return View();
                //}
                //if (accountRole == "Teacher")
                //{
                //    return View("Teacher");
                //}

                //return View("Login");

                ViewBag.Name = accountUsernameFromForm;
                ViewBag.Username = accountUsernameFromForm;

                if (accountUsernameFromForm == "student" && accountPasswordFromForm == "student")
                {
                    return View();
                }
                if (accountUsernameFromForm == "proctor" && accountPasswordFromForm == "proctor")
                {
                    return View("Teacher");
                }

                return View("Login");


            }
            catch//if account does not exist
            {
                ViewBag.errorMessage = "There is some problem accured during login! Please try again.";
                return View("Login");
            }
        }

    }
}