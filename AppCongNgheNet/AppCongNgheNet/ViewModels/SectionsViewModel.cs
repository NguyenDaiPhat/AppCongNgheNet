using AppCongNgheNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static System.Collections.Specialized.BitVector32;
using Section = AppCongNgheNet.Models.Section;

namespace AppCongNgheNet.ViewModels
{
    public class SectionsViewModel
    {
        public ICommand DeleteCommand { get; private set; }

        public SectionsViewModel()
        {
            DeleteCommand = new Command<Section>(OnDeleteCommandExecuted);
        }

        private async void OnDeleteCommandExecuted(Section section)
        {
            if (section != null)
            {
                // Thực hiện xóa Chapter và danh sách các Article tương ứng
                int sectionIDToDelete = section.ID;
                await App.Database.DeleteSection(sectionIDToDelete);
            }
        }
    }
}
