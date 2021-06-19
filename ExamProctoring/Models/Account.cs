using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }


}