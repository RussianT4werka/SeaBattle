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
        public StabbingPage(ViewModels.MainWindowVM mainVM)
        {
            InitializeComponent();
        }

        private void Down(object sender, MouseButtonEventArgs e)
        {
            var shit = Mouse.GetPosition(BattleFieldSelf);
            int row = (int)(shit.Y / 50);
            int col = (int)(shit.X / 50);
            

            Rectangle rectangle = new Rectangle { Width = 50, Height = 50, Stroke = Brushes.Blue , StrokeThickness = 3};
            rectangle.Fill = new SolidColorBrush(Colors.Black);
            Canvas.SetTop(rectangle, row * 50);// отступ сверху
            Canvas.SetLeft(rectangle, col * 50);// отступ слева
            BattleFieldSelf.Children.Add(rectangle);
        }
    }
}
