using SeaBattle.Tools;
using SeaBattle.Views;
using SeaBattle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SeaBattle.ViewModels
{
    public class SignInPageVM: BaseVM
    {
        public User Player { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Command ToRegistrationPage { get; set; }
        public Command SignIn { get; set; }
        public SignInPageVM()
        {
            ToRegistrationPage = new Command(() =>
            {
                Navigation.GetInstance().CurrentPage = new RegistrationPage();
            });

            SignIn = new Command(async () =>
            {
                if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
                {
                    MessageBox.Show("Не все поля заполнены");
                    return;
                }
                else
                {
                    try
                    {
                        Player = new User();
                        Player.Login = Login;
                        Player.Password = Password;
                        Player.Email = "shit@gavno.ru";
                        var answer = await HttpTool.SendPostAsync("Users", "SignIn", Player);
                        if (answer.Item1 == System.Net.HttpStatusCode.OK)
                        {
                            var result = HttpTool.Deserialize<User>(answer.Item2);
                            Player = result;
                            Auth.User = Player;
                            Navigation.GetInstance().CurrentPage = new CreateRoomPage();
                        }
                        else
                        {
                            MessageBox.Show(answer.Item2);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка связи с БД");
                    }
                   
                }
            });
        }
    }
}
