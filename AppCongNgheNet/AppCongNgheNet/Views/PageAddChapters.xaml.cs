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
    public partial class PageAddChapters : ContentPage
    {
        public PageAddChapters()
        {
            InitializeComponent();
        }

        private async void Buton_Add(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtDecree.Text))
            {
                // Hiển thị thông báo lỗi nếu tiêu đề hoặc nội dung trống
                await DisplayAlert("Error", "Please enter a title or decree.", "OK");
                return; // Dừng xử lý tiếp theo nếu có lỗi
            }

            // Kiểm tra Decree
            int decree;
            if (!int.TryParse(txtDecree.Text, out decree))
            {
                // Hiển thị thông báo lỗi nếu Decree không phải số nguyên
                await DisplayAlert("Error", "Please enter a valid decree.", "OK");
                return; // Dừng xử lý tiếp theo nếu có lỗi
            }

            // Tạo một đối tượng Chapter mới và thực hiện các thao tác cần thiết
            Chapter newChapter = new Chapter
            {
                Title = txtTitle.Text,
                Content = txtTitle.Text,
                CreateTime = DateTime.Now.ToString(),
                UpdateTime = DateTime.Now.ToString(),
                Decree = decree
            };

            // Lưu newChapter vào SQLite
            await App.Database.InsertChapterAsync(newChapter);
            // Hiển thị thông báo thành công
            await DisplayAlert("Thành công", "Đã thêm chương thành công.", "OK");
            await Navigation.PushAsync(new ChaptersPage());
        }
    }
}