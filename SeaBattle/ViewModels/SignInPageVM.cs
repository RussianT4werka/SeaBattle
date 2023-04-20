﻿using SeaBattle.Tools;
using SeaBattle.Views;
using SeaBattleAPI.Models;
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
        public SignInPageVM(MainWindowVM mainVM)
        {
            ToRegistrationPage = new Command(() =>
            {
                mainVM.CurrentPage = new RegistrationPage(mainVM);
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
                        string json = await HttpTool.SendPostAsync("Users", "SignIn", Player);
                        var result = HttpTool.Deserialize<User>(json);
                        Player = result;
                        if (Player.Id == 0)
                        {
                            MessageBox.Show("Неверный логин или пароль");
                            return;
                        }
                        else
                        {
                            mainVM.CurrentPage = new StabbingPage(mainVM);
                        }
                           
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка связи с БД");
                        return;
                    }
                   
                }
            });
        }
    }
}
