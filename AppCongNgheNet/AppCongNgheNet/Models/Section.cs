using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCongNgheNet.Models
{
    [Table("sections")]
    public class Sections
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Avg { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
        public int ArticleID { get; set; }
        public int DecreeID { get; set; }

    }
}
