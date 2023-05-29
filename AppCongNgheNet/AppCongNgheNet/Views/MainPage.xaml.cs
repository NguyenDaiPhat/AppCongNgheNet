using AppCongNgheNet.Databases;
using AppCongNgheNet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCongNgheNet
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        public MainPage()
        {
            InitializeComponent();

            // TODO Only do this when app first runs
            //var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            //using (Stream stream = assembly.GetManifestResourceStream("AppCongNgheNet.Databases.net03.db"))
            //{
            //    using (MemoryStream memoryStream = new MemoryStream())
            //    {
            //        stream.CopyTo(memoryStream);

            //        File.WriteAllBytes(RuleDatabase.DbPath, memoryStream.ToArray());
            //    }
            //}
        }
        RuleDatabase database = new RuleDatabase();
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await database.GetUserAsync();
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
                await database.DeletePersonAsync(lastSelection);

                collectionView.ItemsSource = await database.GetUserAsync();
            }
        }
    }
}
