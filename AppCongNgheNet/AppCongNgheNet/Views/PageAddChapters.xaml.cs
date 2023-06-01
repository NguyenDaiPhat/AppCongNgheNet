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
        private Chapter _chapter;
        public PageAddChapters()
        {
            InitializeComponent();
        }

        public PageAddChapters(Chapter chapter)
        {
            InitializeComponent();
            _chapter = chapter;
            txtTitle.Text = chapter.Title;
            txtDecree.Text = chapter.Decree.ToString();
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
            if(_chapter!=null)
            {
                _chapter.UpdateTime = DateTime.Now.ToString();
                _chapter.Content = txtTitle.Text;  
                _chapter.Title = txtTitle.Text;   
                _chapter.Decree = decree;
                await App.Database.UpdateChapterAsync(_chapter);
                await DisplayAlert("Thành công", "Đã sửa chương thành công.", "OK");
                await Navigation.PushAsync(new ChaptersPage());
            }
            else
            {
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
}