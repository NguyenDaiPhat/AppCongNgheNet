using AppCongNgheNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCongNgheNet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChaptersShowInfoPage : ContentPage
    {
        public ChaptersShowInfoPage(Chapter chapter)
        {
            InitializeComponent();
            txtTitle.Text = chapter.Title;
            txtDecree.Text ="Nghị định số "+ chapter.Decree.ToString();
            txtCreateTime.Text ="Thời gian tạo: "+ chapter.CreateTime;
            txtUpdateTime.Text ="Thời gian cập nhật: " + chapter.UpdateTime;
        }
        
    }
}