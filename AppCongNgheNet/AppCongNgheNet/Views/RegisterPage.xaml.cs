using AppCongNgheNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCongNgheNet.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
            //NavigationPage.SetHasBackButton(this, false);
        }
        private async void Button_Register(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string mobie = txtMobie.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtPasswordConfirm.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(mobie) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                // Kiểm tra nếu có trường nào không được điền, thông báo lỗi
                await DisplayAlert("Lỗi", "Vui lòng điền đầy đủ thông tin", "OK");
                return;
            }
            User existingUser = await App.Database.GetUserByUsername(username);
            if (existingUser != null)
            {
                await DisplayAlert("Lỗi", "Tài khoản đã tồn tại", "OK");
                return;
            }
            int mobieNumber;
            if (!int.TryParse(mobie, out mobieNumber))
            {
                // Kiểm tra nếu mobile không phải là số nguyên, thông báo lỗi
                await DisplayAlert("Lỗi", "Số điện thoại phải là số", "OK");
                return;
            }

            if (password != confirmPassword)
            {
                // Kiểm tra nếu password và confirmPassword không giống nhau, thông báo lỗi
                await DisplayAlert("Lỗi", "Xác nhận mật khẩu không khớp", "OK");
                return;
            }

            // Tiến hành đăng ký tài khoản
            // Gửi thông tin đăng ký lên server hoặc thực hiện các xử lý cần thiết

            // Hiển thị thông báo thành công
            User user = new User
            {
                UserName = username,
                Email = email,
                Mobie = mobieNumber,
                PassWord = password,
                Role = "user"
            };
            await App.Database.InsertUserAsync(user);
            await DisplayAlert("Thành công", "Đăng ký tài khoản thành công", "OK");
            await Navigation.PushAsync(new LoginPage());
            //if (txtPassword.Text != txtPasswordConfirm.Text)
            //{
            //    DisplayAlert("Lỗi", "Mật khẩu xác nhận không khớp", "OK");
            //}
            //else
            //{ 
            //    DisplayAlert("Thông báo", "Đăng ký thành công", "OK");

            //    Navigation.PushAsync(new LoginPage());
            //}

        }

    }
}