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
        private ToolbarItem logoutToolbarItem;
        private ToolbarItem addToolbarItem;
        public ChaptersPage()
        {
            InitializeComponent();
            _chaptersViewModel = new ChaptersViewModel();
            BindingContext = _chaptersViewModel;
            //NavigationPage.SetHasBackButton(this, false);
            logoutToolbarItem = new ToolbarItem
            {
                IconImageSource = "IconLogout.png",
                //Text = "Add",
                Command = new Command(LogoutButton_Clicked)
            };
            addToolbarItem = new ToolbarItem
            {
                IconImageSource = "IconAdd.png",
                //Text = "Add",
                Command = new Command(AddChapter_Clicked)
            };
            if (((App)Application.Current).IsAdmin) ToolbarItems.Add(addToolbarItem);
            if (App.User != null) ToolbarItems.Add(logoutToolbarItem);
            
        }
        private void LogoutButton_Clicked()
        {
            // Xử lý logic khi nhấp vào nút Add
            if (((App)Application.Current).IsAdmin) ToolbarItems.Remove(addToolbarItem);
            App.User = null;
            ((App)Application.Current).IsAdmin = false;
            ToolbarItems.Remove(logoutToolbarItem);
        }
        private async void AddChapter_Clicked()
        {
            // Điều hướng đến layout chỉ định
            await Navigation.PushAsync(new PageAddChapters());
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
            await Navigation.PushAsync(new PageAddChapters(chapter));
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

        private async void Button_Search(object sender, EventArgs e)
        {
            string x = search.Text;
            await Navigation.PushAsync(new SectionsPage(x));
        }

        private async void Button_ShowInfo(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var chapter = button.CommandParameter as Chapter;
            await Navigation.PushAsync(new ChaptersShowInfoPage(chapter));
        }
    }
}