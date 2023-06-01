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
    public partial class PageAddSections : ContentPage
    {
        Article _article;
        public PageAddSections(Article article)
        {
            InitializeComponent();
            _article = article;
        }
        private async void Button_Add(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContent.Text) || string.IsNullOrEmpty(txtMin.Text) 
                || string.IsNullOrEmpty(txtMax.Text) || string.IsNullOrEmpty(txtDecree.Text))
            {
                // Hiển thị thông báo lỗi nếu tiêu đề hoặc nội dung trống
                await DisplayAlert("Error", "Bạn chưa nhập đủ thông tin.", "OK");
                return; // Dừng xử lý tiếp theo nếu có lỗi
            }
            double min;
            if (!double.TryParse(txtDecree.Text, out min))
            {
                await DisplayAlert("Error", "Please enter a valid price min.", "OK");
                return; // Dừng xử lý tiếp theo nếu có lỗi
            }
            double max;
            if (!double.TryParse(txtDecree.Text, out max))
            {
                await DisplayAlert("Error", "Please enter a valid price max.", "OK");
                return; // Dừng xử lý tiếp theo nếu có lỗi
            }
            int decree;
            if (!int.TryParse(txtDecree.Text, out decree))
            {
                // Hiển thị thông báo lỗi nếu Decree không phải số nguyên
                await DisplayAlert("Error", "Please enter a valid decree.", "OK");
                return; // Dừng xử lý tiếp theo nếu có lỗi
            }
            double avg = (min + max) / 2;
            // Tạo một đối tượng Chapter mới và thực hiện các thao tác cần thiết
            Section newSection = new Section
            {
                Title = _article.Title,
                Content = txtContent.Text,
                Min = min,
                Max = max,
                Avg = avg,
                CreateTime = DateTime.Now.ToString(),
                UpdateTime = DateTime.Now.ToString(),
                ArticleID = _article.ID + 5,
                DecreeID = decree
            };

            await App.Database.InsertSectionAsync(newSection);
            // Hiển thị thông báo thành công
            await DisplayAlert("Thành công", "Đã thêm điều thành công.", "OK");
            await Navigation.PushAsync(new SectionsPage(_article));
        }

    }
}