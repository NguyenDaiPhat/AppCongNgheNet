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
    public partial class PageAddArticles : ContentPage
    {
        Chapter _chapter;
        public PageAddArticles(Chapter chapter)
        {
            InitializeComponent();
            _chapter = chapter;
        }
        private async void Button_Add(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtContent.Text))
            {
                // Hiển thị thông báo lỗi nếu tiêu đề hoặc nội dung trống
                await DisplayAlert("Error", "Please enter a title and content.", "OK");
                return; // Dừng xử lý tiếp theo nếu có lỗi
            }

                // Tạo một đối tượng Chapter mới và thực hiện các thao tác cần thiết
                Article newArticle = new Article
                {
                    Title = txtTitle.Text,
                    Content = txtContent.Text,
                    CreateTime = DateTime.Now.ToString(),
                    UpdateTime = DateTime.Now.ToString(),
                    ChapterID = _chapter.ID
                };

                await App.Database.InsertArticleAsync(newArticle);
                // Hiển thị thông báo thành công
                await DisplayAlert("Thành công", "Đã thêm điều thành công.", "OK");
                await Navigation.PushAsync(new ArticlesPage(_chapter));
        }
    }
}