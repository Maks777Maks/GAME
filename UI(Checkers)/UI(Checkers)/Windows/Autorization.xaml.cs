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
        public PlayerUI player;

        public Autorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.ContractClient client = new ContractClient();
            player=MapperUI.PlayerFromDTO(client.AddPlayer(Nickname.Text, Password.Password));
            MessageBox.Show(player.ID.ToString());
            MessageBox.Show(player.NickName);
            //client.
        }
    }
}
