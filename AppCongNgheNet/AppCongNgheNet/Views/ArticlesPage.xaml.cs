using AppCongNgheNet.Models;
using AppCongNgheNet.ViewModels;
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
	public partial class ArticlesPage : ContentPage
	{
		Chapter _chapter;
        private ArticlesViewModel _articlesViewModel;
        private ToolbarItem addToolbarItem;
        public ArticlesPage (Chapter chapter)
		{
			InitializeComponent ();
            _articlesViewModel = new ArticlesViewModel();
            BindingContext = _articlesViewModel;
            _chapter = chapter;
            addToolbarItem = new ToolbarItem
            {
                IconImageSource = "IconAdd.png",
                //Text = "Add",
                Command = new Command(AddChapter_Clicked)
            };
            if (((App)Application.Current).IsAdmin) ToolbarItems.Add(addToolbarItem);
        }
        private async void AddChapter_Clicked()
        {
            // Điều hướng đến layout chỉ định
            await Navigation.PushAsync(new PageAddArticles(_chapter));
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetArticlesByChapterSelected(_chapter.ID);
        }
        Article articleSelection;
        async void collectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            articleSelection = e.CurrentSelection[0] as Article;
            await Navigation.PushAsync(new SectionsPage(articleSelection));
        }

        private async void Button_Delete(object sender, EventArgs e)
        {
            // Lấy đối tượng Chapter từ CommandParameter
            var button = (ImageButton)sender;
            var article = button.CommandParameter as Article;
            bool result = await DisplayAlert("Xác nhận", "Bạn có chắc muốn xóa?", "Đồng ý", "Hủy");
            // Gọi Command trong ViewModel
            if (result)
            {
                _articlesViewModel.DeleteCommand.Execute(article);
                collectionView.ItemsSource = await App.Database.GetArticlesByChapterSelected(_chapter.ID);
            }
        }
        private async void AddArticleToolbar_Clicked(object sender, EventArgs e)
        {
            // Điều hướng đến layout chỉ định
            await Navigation.PushAsync(new PageAddArticles(_chapter));
        }

        private async void Button_Search(object sender, EventArgs e)
        {
            string x = search.Text;
            await Navigation.PushAsync(new SectionsPage(x));
        }
    }
}