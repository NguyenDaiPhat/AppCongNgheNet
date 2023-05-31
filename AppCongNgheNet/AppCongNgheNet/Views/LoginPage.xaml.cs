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
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            //NavigationPage.SetHasBackButton(this, false);
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            //if (txtUsername.Text == "admin" && txtPassword.Text == "123")
            //{


            //    // Lưu thông tin đăng nhập
            //    App.IsUserLoggedIn = true;

            //    // Chuyển hướng đến trang chủ
            //    await Navigation.PushAsync(new MyFlyoutPage());
            //}
            //else
            //{
            //    DisplayAlert("Thông báo", "Tài khoản hoặc mật khẩu sai", "OK");
            //}

            // Lấy thông tin đăng nhập từ các trường nhập liệu
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Kiểm tra các trường nhập liệu và thông báo lỗi nếu cần
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Lỗi", "Vui lòng điền đầy đủ thông tin", "OK");
                return;
            }
            User user = await App.Database.GetUserByUsername(username);
            if (user == null)
            {
                await DisplayAlert("Lỗi", "Người dùng không tồn tại", "OK");
                return;
            }
            if (user.PassWord != password)
            {
                await DisplayAlert("Lỗi", "Sai mật khẩu", "OK");
                return;
            }
            // Đăng nhập thành công
            await Navigation.PushAsync(new MyFlyoutPage());
            App.User = user;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}