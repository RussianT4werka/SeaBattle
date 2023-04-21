using SeaBattle.Models;
using SeaBattle.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SeaBattle.ViewModels
{
    public class CreateRoomPageVM:BaseVM
    {
        public Command CreateRoom { get; set; }
        public Command Join { get; set; }
        public List<Room> Rooms { get; set; }
        public User User { get; set; }
        public Room SelectedRoom { get; set; }
        public CreateRoomPageVM()
        {
            Task.Run(async () =>
            {
                var answer = await HttpTool.SendPostAsync("Rooms", "GetRooms", null);
                if (answer.Item1 == System.Net.HttpStatusCode.OK)
                {
                    var result = HttpTool.Deserialize<List<Room>>(answer.Item2);
                    Rooms = result;
                }
                else
                    MessageBox.Show(answer.Item2);
            });

            User = Auth.User;

            CreateRoom = new Command(async() =>
            {
                
            });

            Join = new Command(() =>
            {

            });
        }
    }
}
