﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCongNgheNet.Models
{
    [Table("articles")]
    public class Article
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
        public int ChapterID { get; set; }

    }
}
