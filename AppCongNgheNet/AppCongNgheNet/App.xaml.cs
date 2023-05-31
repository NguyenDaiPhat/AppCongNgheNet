using AppCongNgheNet.Databases;
using AppCongNgheNet.Models;
using AppCongNgheNet.Views;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("MaterialIcons.ttf", Alias = "Material")]
[assembly: ExportFont("MaterialIconsTwoTone.otf", Alias = "TwoToneMaterial")]
namespace AppCongNgheNet
{
    public partial class App : Application, INotifyPropertyChanged
    {
        public static RuleDatabase Database = new RuleDatabase();
        public static User User;
        private bool isAdmin;

        public bool IsAdmin
        {
            get { return isAdmin; }
            set
            {
                if (isAdmin != value)
                {
                    isAdmin = value;
                    OnPropertyChanged(nameof(IsAdmin));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public App()
        {
            InitializeComponent();

            // TODO Only do this when app first runs
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("AppCongNgheNet.Databases.net03.db"))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    File.WriteAllBytes(RuleDatabase.DbPath, memoryStream.ToArray());
                }
            }

            //MainPage = new ChaptersPage();
            MainPage = new NavigationPage(new MyFlyoutPage());
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
