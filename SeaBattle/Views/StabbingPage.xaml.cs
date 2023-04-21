using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SeaBattle.Views
{
    /// <summary>
    /// Логика взаимодействия для StabbingPage.xaml
    /// </summary>
    public partial class StabbingPage : Page
    {
        public StabbingPage()
        {
            InitializeComponent();
        }

        private void Down(object sender, MouseButtonEventArgs e)
        {
            var shit = Mouse.GetPosition(BattleFieldSelf);
            int row = (int)(shit.Y / 50);
            int col = (int)(shit.X / 50);


            Rectangle rectangle = new Rectangle { Width = 50, Height = 50, Fill = new ImageBrush { ImageSource = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\Images\bulk.png", UriKind.Absolute)) } };
            Canvas.SetTop(rectangle, row * 50);// отступ сверху
            Canvas.SetLeft(rectangle, col * 50);// отступ слева
            BattleFieldSelf.Children.Add(rectangle);
        }

        private void Down1(object sender, MouseButtonEventArgs e)
        {
            var shit = Mouse.GetPosition(BattleFieldEnemy);
            int row = (int)(shit.Y / 50);
            int col = (int)(shit.X / 50);
            Rectangle rectangle = new Rectangle { Width = 50, Height = 50, Fill = new ImageBrush { ImageSource = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\Images\bulk.png", UriKind.Absolute)) } };
            Canvas.SetTop(rectangle, row * 50);// отступ сверху
            Canvas.SetLeft(rectangle, col * 50);// отступ слева
            BattleFieldEnemy.Children.Add(rectangle);
        }
    }
}
