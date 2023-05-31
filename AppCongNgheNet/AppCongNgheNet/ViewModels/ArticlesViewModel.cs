using AppCongNgheNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppCongNgheNet.ViewModels
{
    public class ArticlesViewModel
    {
        public ICommand DeleteCommand { get; private set; }

        public ArticlesViewModel()
        {
            DeleteCommand = new Command<Article>(OnDeleteCommandExecuted);
        }

        private async void OnDeleteCommandExecuted(Article article)
        {
            if (article != null)
            {
                // Thực hiện xóa Article và danh sách các Section tương ứng
                int articleIDToDelete = article.ID;
                await App.Database.DeleteArticle(articleIDToDelete);
            }
        }
    }
}
