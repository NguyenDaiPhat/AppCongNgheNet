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
    public partial class SectionsPage : ContentPage
    {
        private Article _article;
        public SectionsPage(Article article)
        {
            InitializeComponent();
            _article = article;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetSectionsByArticleSelected(_article.ID+5);
        }
        Section sectionSelection;
        async void collectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            sectionSelection = e.CurrentSelection[0] as Section;
            await Navigation.PushAsync(new DetailsPage(sectionSelection));
        }
        private async void AddSection_Clicked(object sender, EventArgs e)
        {
            // Điều hướng đến layout chỉ định
            await Navigation.PushAsync(new PageAddSections());
        }
    }
}