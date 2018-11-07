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
using UI_Checkers_.Classes;
using UI_Checkers_.Windows;

namespace UI_Checkers_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PlayerUI player = new PlayerUI();

        public MainWindow()
        {
            InitializeComponent();
            //Autorization autorization = new Autorization();
            //autorization.ShowDialog();
            //White_Game white_game = new White_Game();
            //white_game.ShowDialog();
            Black_Game black_game = new Black_Game();
            black_game.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Black_Game game = new Black_Game();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            White_Game game = new White_Game();
        }
    }
}
