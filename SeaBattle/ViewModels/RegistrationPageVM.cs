using SeaBattle.Tools;
using SeaBattle.Views;
using SeaBattleAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SeaBattle.ViewModels
{
    public class RegistrationPageVM:BaseVM
    {
        public User Player { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public Command Registration { get; set; }
        public Command ToSignInPage { get; set; }
        public Command SeaComplex { get; set; }
        public RegistrationPageVM(MainWindowVM mainVM)
        {
            Registration = new Command(async() =>
            {
                if(string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                {
                    MessageBox.Show("Не все поля заполнены");
                    return;
                }
                else
                {
                    try
                    {
                        Player = new User();
                        Player.Email = Email;
                        Player.Login = "Login";
                        Player.Password = Password;
                        string json = await HttpTool.SendPostAsync("Users", "Registration", Player);
                        var result = HttpTool.Deserialize<User>(json);
                        Player = result;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка связи с БД");
                        return;
                    }
                    if(Player.Id == 0)
                    {
                        MessageBox.Show("Ошибка регистрации");
                    }
                    else
                    {
                        mainVM.CurrentPage = new StabbingPage(mainVM);
                    }
                }
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
