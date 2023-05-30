﻿using AppCongNgheNet.Databases;
using AppCongNgheNet.Views;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCongNgheNet
{
    public partial class App : Application
    {
        public static RuleDatabase Database = new RuleDatabase();
        public App()
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

            MainPage = new ChaptersPage();
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