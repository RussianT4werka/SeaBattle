
using Microsoft.AspNetCore.SignalR.Client;
using SeaBattle.Tools;
using SeaBattle.Views;
using SeaBattleAPI.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SeaBattle.ViewModels
{
    public class CreateRoomPageVM : BaseVM
    {
        public Command CreateRoom { get; set; }
        public Command Join { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }
        public User User { get; set; }
        public Room SelectedRoom { get; set; }

        private HubConnection _hub;

        public Page CurrentPage { get; set; }

        public CreateRoomPageVM()
        {
            Task.Run(async () =>
            {
                var id = SelectedRoom?.Id;
                var answer = await HttpTool.SendPostAsync("Rooms", "GetRooms", null);
                if (answer.Item1 == System.Net.HttpStatusCode.OK)
                {
                    var result = HttpTool.Deserialize<List<Room>>(answer.Item2);
                    Rooms = new ObservableCollection<Room>(result);
                    SelectedRoom = Rooms.FirstOrDefault(s => s.Id == id);
                }
                else
                    MessageBox.Show(answer.Item2);

                _hub = new HubConnectionBuilder().WithUrl("https://localhost:7041/Hub")
                                          .WithAutomaticReconnect()
                                          .Build();


                _hub.On<object>("UpdateRoom", room =>
                {
                    MessageBox.Show($"Принял комнату");
                });

                _hub.On<object>("AddRoom", room =>
                {
                    if (Rooms is not null)
                    {
                        CurrentPage.Dispatcher.Invoke(() =>
                        {
                            Rooms.Add(HttpTool.Deserialize<Room>(room.ToString()));
                        });
                    }
                });
               
                await _hub.StartAsync();
            });

            User = Auth.User;

            CreateRoom = new Command(async () =>
            {
                var answer = await HttpTool.SendPostAsync("Rooms", "CreateRoom", User);
                if (answer.Item1 == System.Net.HttpStatusCode.OK)
                {
                    Auth.Room = HttpTool.Deserialize<Room>(answer.Item2);
                    Navigation.GetInstance().CurrentPage = new StabbingPage();
                }
                else
                    MessageBox.Show(answer.Item2);

            });

            Join = new Command(async () =>
            {
                if (SelectedRoom?.StatusId != 1)
                {
                    MessageBox.Show("Идиотсюда");
                    return;
                }

                var answer = await HttpTool.SendPostAsync("Rooms", $"JoinRoom/{User.Id}/{SelectedRoom.Id}", null);
                if (answer.Item1 == System.Net.HttpStatusCode.OK)
                {
                    Auth.Room = HttpTool.Deserialize<Room>(answer.Item2);
                    Navigation.GetInstance().CurrentPage = new StabbingPage();
                }
                else
                    MessageBox.Show(answer.Item2);
            });
        }
    }
}