using AppCongNgheNet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AppCongNgheNet.ViewModels
{
    public class ChaptersViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set { SetProperty(ref _selectedUser, value); }
        }

        public ChaptersViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            //Users = await App.Database.GetUserAsync();
        }

        private async void DeleteUser()
        {
            if (SelectedUser != null)
            {
                await App.Database.DeletePersonAsync(SelectedUser);
                //Users = await App.Database.GetUserAsync();
            }
        }

        public Command DeleteCommand => new Command(DeleteUser);
    }
}
