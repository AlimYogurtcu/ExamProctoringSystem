using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamProctoring.Models
{
    [Table("account_information")]
    public class Account //model to get values from dataserver
    {
        [Key]
        public int account_id { get; set; }
        public string account_name { get; set; }
        public string account_username { get; set; }
        public string account_password { get; set; }
        public string account_role { get; set; }
        public string account_status { get; set; }

        /*public void setAccountUsername(String fAccountUsername)
        {
            this.accountUsername = fAccountUsername;
        }
        public void setAccountPassword(String fAccountPassword)
        {
            this.accountPassword = fAccountPassword;
        }
        public void setAccountRole(String fAccountRole)
        {
            this.accountRole = fAccountRole;
        }
        public void setAccountStatus(String fAccountStatus)
        {
            this.accountStatus = fAccountStatus;
        }
        public String getAccountUsername()
        {
            return this.accountUsername;
        }
        public String getAccountPassword()
        {
            return this.accountPassword;
        }
        public String getAccountRole()
        {
            return this.accountRole;
        }
        public String getAccountStatus()
        {
            return this.accountStatus;
        }

        //this variables are for check account ---
        string connectionString = "Data Source=tcp:examproctoringdatabase.database.windows.net,1433;Initial Catalog=ExamProctoring_db;User Id=examproctoring@examproctoringdatabase;Password=Exam1907"; // string for connect database
        SqlConnection cnnct;// variable for handle connection 
        //----

        public Account checkAccountFromDatabase(Account acc)// function for check if the username and password are correct
        {
            bool isAccountValid = false, isProctor = false;
            cnnct = new SqlConnection(connectionString);
            string query = "SELECT * FROM account_information WHERE account_username = '" + acc.accountUsername + "' and account_password = '" + acc.accountPassword + "';"; //jquery for check if the account valid or not

            SqlCommand cmmnd = new SqlCommand(query, cnnct); // to handle with jquery
            SqlDataReader reader;// reader to read from database and check if the user input valid or not

            cnnct.Open();// opens connection with database

            //List<Account> model = new List<Account>();

            reader = cmmnd.ExecuteReader();

            if (reader.Read())
            {
                var user = new Account();
                user.setAccountUsername(reader["account_username"].ToString());
                user.setAccountRole(reader["account_role"].ToString());
                //user.setAccountStatus(reader["account_status"].ToString());

                string queryTwo = "UPDATE account_information SET account_status = 'Online' WHERE account_id = " + reader["account_id"].ToString() + ";"; //jquey for change account status from offline to online
                SqlCommand cmmndTwo = new SqlCommand(queryTwo, cnnct);// to handle with second jquery
                //model.Add(user);
                reader.Close();//closing the reader for checking user account in database
                cmmndTwo.ExecuteNonQuery();// executing jquary for change account status

                cnnct.Close();

                return user;
            }
            else
            {
                return null;
            }
        }*/
    }


}