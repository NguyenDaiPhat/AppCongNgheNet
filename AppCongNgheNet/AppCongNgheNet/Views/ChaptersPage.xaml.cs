using AppCongNgheNet.Models;
using AppCongNgheNet.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCongNgheNet.Views
{
    public partial class ChaptersPage : ContentPage
    {
        private ChaptersViewModel _chaptersViewModel;
        public ChaptersPage()
        {
            InitializeComponent();
            _chaptersViewModel = new ChaptersViewModel();
            BindingContext = _chaptersViewModel;
            //NavigationPage.SetHasBackButton(this, false);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetChapterAsync();
        }

        Chapter chapterSelection;
        async void collectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            chapterSelection = e.CurrentSelection[0] as Chapter;
            await Navigation.PushAsync(new ArticlesPage(chapterSelection));
        }

        private async void Button_Edit(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var chapter = button.CommandParameter as Chapter;
            Entry titleEntry = new Entry { Text = chapter.Title };
            Entry decreeEntry = new Entry { Text = chapter.Decree.ToString() };
            string result = await DisplayPromptAsync("Edit Chapter", "", "Save", "Cancel", placeholder: "Title", initialValue: chapter.Title);

            // Gọi Command trong ViewModel
            //if (result != null)
            //{
            //    // Lấy dữ liệu từ trường nhập "Title"
            //    chapter.Title = result;

            //    // Lấy dữ liệu từ trường nhập "Decree" và chuyển đổi sang kiểu int
            //    int updatedDecree;
            //    if (int.TryParse(decreeEntry.Text, out updatedDecree))
            //    {
            //        chapter.Decree = updatedDecree;
            //    }

            //    // Cập nhật trường UpdateTime
            //    chapter.UpdateTime = DateTime.Now;

            //    // Lưu Chapter đã chỉnh sửa vào cơ sở dữ liệu (ví dụ: cập nhật vào SQLite)
            //    await _database.UpdateAsync(chapter);
            //}
        }

        private async void Button_Delete(object sender, EventArgs e)
        {
            // Lấy đối tượng Chapter từ CommandParameter
            var button = (ImageButton)sender;
            var chapter = button.CommandParameter as Chapter;
            bool result = await DisplayAlert("Xác nhận", "Bạn có chắc muốn xóa?", "Đồng ý", "Hủy");
            // Gọi Command trong ViewModel
            if (result)
            {
                _chaptersViewModel.DeleteCommand.Execute(chapter);
                collectionView.ItemsSource = await App.Database.GetChapterAsync();
            }
        }

        private async void AddChapter_Clicked(object sender, EventArgs e)
        {
            // Điều hướng đến layout chỉ định
            await Navigation.PushAsync(new PageAddChapters());
        }

    }
}