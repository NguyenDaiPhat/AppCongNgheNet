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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
            //NavigationPage.SetHasBackButton(this, false);
        }
        private void Button_Register(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                DisplayAlert("Lỗi", "Mật khẩu xác nhận không khớp", "OK");
            }
            else
            {

                DisplayAlert("Thông báo", "Đăng ký thành công", "OK");
                Navigation.PushAsync(new LoginPage());
            }
        }
    }
}