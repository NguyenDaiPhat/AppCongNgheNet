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
    public partial class SectionsPage : ContentPage
    {
        private SectionsViewModel _sectionsViewModel;
        private ToolbarItem addToolbarItem;
        private Article _article;
        public SectionsPage(Article article)
        {
            InitializeComponent();
            _sectionsViewModel = new SectionsViewModel();
            BindingContext = _sectionsViewModel;
            _article = article;
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
            await Navigation.PushAsync(new PageAddSections());
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
        private async void Button_Delete(object sender, EventArgs e)
        {
            // Lấy đối tượng Chapter từ CommandParameter
            var button = (ImageButton)sender;
            var section = button.CommandParameter as Section;
            bool result = await DisplayAlert("Xác nhận", "Bạn có chắc muốn xóa?", "Đồng ý", "Hủy");
            // Gọi Command trong ViewModel
            if (result)
            {
                _sectionsViewModel.DeleteCommand.Execute(section);
                collectionView.ItemsSource = await App.Database.GetSectionsByArticleSelected(_article.ID + 5);
            }
        }
        private async void AddSection_Clicked(object sender, EventArgs e)
        {
            // Điều hướng đến layout chỉ định
            await Navigation.PushAsync(new PageAddSections());
        }
    }
}