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
        public string Role { get; set; }
        private bool _canEdit;
        public bool CanEdit
        {
            get { return _canEdit; }
            set
            {
                _canEdit = value;
                OnPropertyChanged(nameof(CanEdit));
            }
        }

        private bool _canDelete;
        public bool CanDelete
        {
            get { return _canDelete; }
            set
            {
                _canDelete = value;
                OnPropertyChanged(nameof(CanDelete));
            }
        }
        private ObservableCollection<Chapter> _chapterList;

        public ObservableCollection<Chapter> ChapterList
        {
            get { return _chapterList; }
            set
            {
                _chapterList = value;
                OnPropertyChanged(nameof(ChapterList));
            }
        }
        public ICommand EditCommand { get; }
        public ICommand NavigateCommand { get; set; }
        public ICommand DeleteCommand { get; }

        private void SetUIPermissions()
        {
            if (Role == "admin")
            {
                CanEdit = true;
                CanDelete = true;
            }
            else
            {
                CanEdit = false;
                CanDelete = false;
            }
        }
        public ChaptersViewModel() 
        {
            ChapterList = new ObservableCollection< Chapter>()
            {
                new Chapter() { ID = 1, Title = "ÁP DỤNG XỬ PHẠT VI PHẠM HÀNH CHÍNH" },
                new Chapter() { ID = 2, Title = "VI PHẠM QUY ĐỊNH VỀ QUẢN LÝ RỪNG VÀ SỬ DỤNG RỪNG" },
                new Chapter() { ID = 3, Title = "VI PHẠM QUY ĐỊNH VỀ PHÁT TRIỂN RỪNG, BẢO VỆ RỪNG " },
                new Chapter() { ID = 4, Title = "VI PHẠM QUY ĐỊNH QUẢN LÝ LÂM SẢN" },
                new Chapter() { ID = 5, Title = "THẨM QUYỀN XỬ PHẠT VI PHẠM HÀNH CHÍNH" }
            };
            NavigateCommand = new Command<int>(async (chapterId) =>
            {
                SetUIPermissions();
                switch (chapterId)
                {
                    case 1:
                        await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                        break;
                    case 2:
                        await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                        break;
                    case 3:
                        await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                        break;
                    case 4:
                        await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                        break;
                    case 5:
                        await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                        break;
                }
            });
            EditCommand = new Command<Chapter>(async (chapter) => await ExecuteEditCommand(chapter));
            DeleteCommand = new Command<Chapter>(async (chapter) => await ExecuteDeleteCommand(chapter));
        }
        private async Task ExecuteEditCommand(Chapter chapter)
        {
            // Hiển thị một dialog để người dùng nhập vào tên mới
            string newName = await Application.Current.MainPage.DisplayPromptAsync("Chỉnh sửa tên chương", "Nhập tên mới cho chương:", "Lưu", "Hủy", chapter.Title);

            // Nếu người dùng nhập tên mới thì cập nhật tên của chapter
            if (!string.IsNullOrEmpty(newName))
            {
                chapter.Title = newName;
            }
        }
        private async Task ExecuteDeleteCommand(Chapter chapter)
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Xóa nội dung", "Có chắc chắn muốn xóa hay không?", "Có", "Huỷ");
            if (answer)
            {
                //ChapterList.Remove(chapter);
            }
        }

    }
}
