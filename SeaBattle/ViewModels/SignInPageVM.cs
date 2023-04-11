using SeaBattle.Tools;
using SeaBattle.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.ViewModels
{
    public class SignInPageVM: BaseVM
    {
        public Command ToRegistrationPage { get; set; }
        public SignInPageVM(MainWindowVM mainVM)
        {
            ToRegistrationPage = new Command(() =>
            {
                mainVM.CurrentPage = new RegistrationPage(mainVM);
            });
        }
    }
}
