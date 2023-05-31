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
    public partial class DetailsPage : ContentPage
    {
        private Section _section;
        public DetailsPage(Section section)
        {
            InitializeComponent();
            _section = section;
        }
        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    collectionView.ItemsSource = await App.Database.GetSectionsByArticleSelected(_article.ID);
        //}
        //Article articleSelection;
        //async void collectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        //{
        //    articleSelection = e.CurrentSelection[0] as Article;
        //    await Navigation.PushAsync(new DetailsPage(articleSelection));
        //}
    }
}