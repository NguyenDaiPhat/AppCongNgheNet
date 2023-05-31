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
        private ChaptersViewModel chaptersViewModel;
        public ChaptersPage()
        {
            InitializeComponent();
            chaptersViewModel = new ChaptersViewModel();
            BindingContext = chaptersViewModel;
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

        private void Button_Edit(object sender, EventArgs e)
        {

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
                chaptersViewModel.DeleteCommand.Execute(chapter);
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