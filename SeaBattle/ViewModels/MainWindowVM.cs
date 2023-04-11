using SeaBattle.Tools;
using SeaBattle.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SeaBattle.ViewModels
{
    public class MainWindowVM: BaseVM
    {
        public Page CurrentPage { get; set; }
        public MainWindowVM()
        {
            CurrentPage = new RegistrationPage(this);
        }
    }
}
