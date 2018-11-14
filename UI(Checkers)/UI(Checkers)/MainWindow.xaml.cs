using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
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
using UI_Checkers_.Classes;
using UI_Checkers_.ServiceReference1;
using UI_Checkers_.Util;
using UI_Checkers_.Windows;

namespace UI_Checkers_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CallBackUI callbackhandler = new CallBackUI();
        public PlayerUI player = new PlayerUI();
        ObservableCollection<PlayerUI> players = new ObservableCollection<PlayerUI>();

        public MainWindow()
        {
            InitializeComponent();
            datagrid.ItemsSource = players;
            Autorization autorization = new Autorization();
            autorization.ShowDialog();         
            player.ID = autorization.player.ID;
            player.NickName = autorization.player.NickName;
            player.Password = autorization.player.Password;
            player.Victory = autorization.player.Victory;
            player.Losing = autorization.player.Losing;
            player.Draw = autorization.player.Draw;
            this.DataContext = player;
            ServiceReference1.ContractClient client = new ContractClient();            
            foreach (var item in client.GetPlayers().OrderBy(x=> x.Victory))
            {
                var p = new PlayerUI { ID = item.ID, NickName = item.NickName, Draw = item.Draw, Losing = item.Losing, Password = item.Password, Victory = item.Victory };
                players.Add(p);               
            }
            datagrid.DataContext = players;   
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext context = new InstanceContext(callbackhandler);
            ServiceReference1.CallbackClient client = new CallbackClient(context);
            this.Title = "Wait pls";
            
            await client.StartGameAsync(MapperUI.PlayerForDTO(player));
            this.Title = "Done";
            //if (start == true)
            //{
            //    White_Game white_game = new White_Game();
            //    white_game.ShowDialog();
            //}
            //else
            //{
            //    Black_Game black_game = new Black_Game();
            //    black_game.ShowDialog();
            //}
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void datagrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()+1).ToString();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
