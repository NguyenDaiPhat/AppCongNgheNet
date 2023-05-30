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
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            //NavigationPage.SetHasBackButton(this, false);
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "123")
            {


                // Lưu thông tin đăng nhập
                App.IsUserLoggedIn = true;

                // Chuyển hướng đến trang chủ
                await Navigation.PushAsync(new MyFlyoutPage());
            }
            else
            {
                DisplayAlert("Thông báo", "Tài khoản hoặc mật khẩu sai", "OK");
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}