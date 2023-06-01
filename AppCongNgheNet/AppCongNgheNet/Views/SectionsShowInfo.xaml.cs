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
    public partial class SectionsShowInfo : ContentPage
    {
        //bool isVisible = (ArticlesShowInfoPage._Chapter.Content != "NA");
        public SectionsShowInfo(Section section)
        {
            InitializeComponent();
            //txtChapter.Text = ArticlesShowInfoPage._Chapter.Title;
            //txtContent.IsVisible = isVisible;
            //txtContent.Text = ArticlesShowInfoPage._Chapter.Content;
            txtTitle.Text = section.Title;
            txtContent1.Text = section.Content;
            //txtMinMax.IsVisible = (section.Min.ToString() != "NA");
            txtMinMax.Text = "Mức xử phạt từ " + section.Min.ToString() + " tr đến " + section.Max.ToString()+ " tr";
            //txtAvg.IsVisible = (section.Avg.ToString() != "NA");
            txtAvg.Text = "Mức xử phạt trung bình: " + section.Avg.ToString() + " tr";
            txtDecree.Text = "Nghị định số " + section.DecreeID.ToString();
            txtCreateTime.Text = "Thời gian tạo: " + section.CreateTime;
            txtUpdateTime.Text = "Thời gian cập nhật: " + section.UpdateTime;
        }
    }
}