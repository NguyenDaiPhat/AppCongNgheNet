using AppCongNgheNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Collections.Specialized.BitVector32;

namespace AppCongNgheNet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticlesShowInfoPage : ContentPage
    {
        public static Chapter _Chapter;
        public ArticlesShowInfoPage(Article article, Chapter chapter)
        {
            InitializeComponent();
            _Chapter = chapter;
            txtChapter.Text = chapter.Title;
            txtTitle.Text = article.Title;
            txtDecree.Text = "Nghị định số " + chapter.Decree.ToString();
            txtCreateTime.Text = "Thời gian tạo: " + article.CreateTime;
            txtUpdateTime.Text = "Thời gian cập nhật: " + article.UpdateTime;
        }
    }
}