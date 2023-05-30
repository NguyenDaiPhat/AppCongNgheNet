using AppCongNgheNet.Models;
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
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        public ChaptersPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetUserAsync();
        }

        User lastSelection;
        void collectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            lastSelection = e.CurrentSelection[0] as User;
        }
        async void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            if (lastSelection != null)
            {
                await App.Database.DeletePersonAsync(lastSelection);

                collectionView.ItemsSource = await App.Database.GetUserAsync();
            }
        }
    }
}