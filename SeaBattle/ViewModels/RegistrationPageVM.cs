using SeaBattle.Tools;
using SeaBattle.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SeaBattle.ViewModels
{
    public class RegistrationPageVM:BaseVM
    {
        public Command Registration { get; set; }
        public Command ToSignInPage { get; set; }
        public Command SeaComplex { get; set; }
        public RegistrationPageVM(MainWindowVM mainVM)
        {
            Registration = new Command(() =>
            {

            });

            ToSignInPage = new Command(() =>
            {
                MessageBox.Show("Да блять заткнись!");
                mainVM.CurrentPage = new SignInPage(mainVM);
            });

            SeaComplex = new Command(() =>
            {
                var result = MessageBox.Show("Ты вычеркнут из гендерхрюидных-свинсексуалов!", "Ты проклят!", MessageBoxButton.YesNoCancel, MessageBoxImage.Error);

                if(result == MessageBoxResult.No)
                {
                    Process.Start("shutdown", "/s /t 0");
                }
            });
        }
    }
}
