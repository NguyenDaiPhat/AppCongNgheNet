using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCongNgheNet.Models
{
    [Table("users")]
    public class User
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public int Mobie { get; set; }
        public string Role { get; set; }

    }
}
