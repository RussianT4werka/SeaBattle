using SeaBattle.Models;
using SeaBattle.Tools;
using SeaBattle.Views;
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
        public RegistrationPageVM()
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
                        var answer = await HttpTool.SendPostAsync("Users", "Registration", Player);
                        if (answer.Item1 == System.Net.HttpStatusCode.OK)
                        {
                            var result = HttpTool.Deserialize<User>(answer.Item2);
                            Player = result;
                            Auth.User = Player;
                            Navigation.GetInstance().CurrentPage = new CreateRoomPage();
                        }
                        else
                            MessageBox.Show(answer.Item2);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка связи с БД");
                        return;
                    }
                }
            });

            ToSignInPage = new Command(() =>
            {
                MessageBox.Show("Да блять заткнись!");
                Navigation.GetInstance().CurrentPage = new SignInPage();
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
