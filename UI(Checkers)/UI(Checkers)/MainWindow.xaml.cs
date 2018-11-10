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
using UI_Checkers_.Windows;

namespace UI_Checkers_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CallBackUI callbackhandler = new CallBackUI();
        PlayerUI player = new PlayerUI();
        ObservableCollection<PlayerUI> players = new ObservableCollection<PlayerUI>();

        public MainWindow()
        {
            InitializeComponent();
            datagrid.ItemsSource = players;
            Autorization autorization = new Autorization();
            autorization.ShowDialog();


            //player.ID = autorization.player.ID;
            //player.NickName = autorization.player.NickName;
            //player.Password = autorization.player.Password;
            //player.Victory = autorization.player.Victory;
            //player.Losing = autorization.player.Losing;
            //player.Draw = autorization.player.Draw;



            //White_Game white_game = new White_Game();
            //white_game.ShowDialog();
            //Black_Game black_game = new Black_Game();
            //black_game.ShowDialog();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext context = new InstanceContext(callbackhandler);
            ServiceReference1.CallbackClient client = new CallbackClient(context);
            this.Title = "Wait pls";
            await client.StartGameAsync(null);
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
        
    }
}
