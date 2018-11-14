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
using System.Windows.Shapes;
using UI_Checkers_.Classes;
using UI_Checkers_.ServiceReference1;
using UI_Checkers_.Util;

namespace UI_Checkers_.Windows
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        //BitmapImage image = new BitmapImage(new Uri(@"\Icon\Background.jpg", UriKind.Relative));
        //Brush image = @"\Icon\Background.jpg" as Brush;
        public PlayerUI player;

        public Autorization()
        {
            InitializeComponent();
           // grid.Background = image;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            ServiceReference1.ContractClient client = new ContractClient();
            player = MapperUI.PlayerFromDTO(client.AddPlayer(Nickname.Text, Password.Password));
            
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
