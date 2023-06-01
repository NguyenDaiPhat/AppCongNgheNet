using AppCongNgheNet.Models;
using AppCongNgheNet.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppCongNgheNet.ViewModels
{
    public class ChaptersViewModel : BaseViewModel
    {
        public ICommand DeleteCommand { get; private set; }
        //public ICommand ShowInfoCommand { get; private set; }

        public ChaptersViewModel()
        {
            DeleteCommand = new Command<Chapter>(OnDeleteCommandExecuted);
            //ShowInfoCommand = new Command<Chapter>(OnShowInfoCommandExecuted);
        }

        private async void OnDeleteCommandExecuted(Chapter chapter)
        {
            if (chapter != null)
            {
                // Thực hiện xóa Chapter và danh sách các Article tương ứng
                int chapterIDToDelete = chapter.ID;
                await App.Database.DeleteChapter(chapterIDToDelete);
            }
        }

    }
}
