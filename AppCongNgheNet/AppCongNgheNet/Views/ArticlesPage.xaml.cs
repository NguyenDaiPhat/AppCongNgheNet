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
	public partial class ArticlesPage : ContentPage
	{
		Chapter _chapter;
		public ArticlesPage (Chapter chapter)
		{
			InitializeComponent ();
			_chapter = chapter;
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
        private async void AddArticleToolbar_Clicked(object sender, EventArgs e)
        {
            // Điều hướng đến layout chỉ định
            await Navigation.PushAsync(new PageAddArticles());
        }
    }
}