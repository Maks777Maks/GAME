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
    /// Логика взаимодействия для White_Game.xaml
    /// </summary>
    public partial class White_Game : Window
    {
        public MediaPlayer player { get; set; }

        BitmapImage checkblack = new BitmapImage(new Uri(@"\Icon\1.png", UriKind.Relative));
        BitmapImage checkwhite = new BitmapImage(new Uri(@"\Icon\2.png", UriKind.Relative));
        BitmapImage kingblack = new BitmapImage(new Uri(@"\Icon\7.png", UriKind.Relative));
        BitmapImage kingwhite = new BitmapImage(new Uri(@"\Icon\8.png", UriKind.Relative));
        

        int currentsong = 0;
        List<string> Songs = new List<string> { "1", "2", "3", "4", "5", "6", "7" };
        MoveUI movetmp = new MoveUI();
        List<Move> list = new List<Move>();
        bool music = false;
        
        bool first = true;

        public White_Game(PlayerUI pl)
        {
            InitializeComponent();
            player = new MediaPlayer();
            this.DataContext = player;

            Music.Content = (Canvas)this.TryFindResource("sound_mute");

            label.Content = "You turn";

            b8i.Source = checkblack;
            d8i.Source = checkblack;
            f8i.Source = checkblack;
            h8i.Source = checkblack;
            a7i.Source = checkblack;
            c7i.Source = checkblack;
            e7i.Source = checkblack;
            g7i.Source = checkblack;
            b6i.Source = checkblack;
            d6i.Source = checkblack;
            f6i.Source = checkblack;
            h6i.Source = checkblack;

            a1i.Source = checkwhite;
            c1i.Source = checkwhite;
            e1i.Source = checkwhite;
            g1i.Source = checkwhite;
            b2i.Source = checkwhite;
            d2i.Source = checkwhite;
            f2i.Source = checkwhite;
            h2i.Source = checkwhite;
            a3i.Source = checkwhite;
            c3i.Source = checkwhite;
            e3i.Source = checkwhite;
            g3i.Source = checkwhite;
        }

        private void Music_on_of(object sender, RoutedEventArgs e)
        {
            if (music == false)
            {
                Music.Content = (Canvas)this.TryFindResource("sound_3");
                player.Open(new Uri($@"Music/{Songs[currentsong]}.mp3", UriKind.Relative));
                currentsong++;
                player.MediaEnded += Player_MediaEnded;
                player.Play();
                music = true;
            }
            else
            {
                Music.Content = (Canvas)this.TryFindResource("sound_mute");
                player.Pause();
                music = false;
            }
        }

        private void Player_MediaEnded(object sender, EventArgs e)
        {
            player.Open(new Uri($@"Music/{Songs[currentsong]}.mp3", UriKind.Relative));
            currentsong++;
            if (currentsong == Songs.Count)
            {
                currentsong = 0;
            }
            player.Play();
        }

        private void Value_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Volume = slider.Value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;          
            if (first == true)
            {
                if ((string)label.Content == "Turn of opponent" || ((button.Content as Border).Child as Image).Source != checkwhite) { return; }
                button.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                button.VerticalContentAlignment = VerticalAlignment.Stretch;
                (button.Content as Border).BorderBrush = new SolidColorBrush(Colors.Yellow);

                MoveUI move = new MoveUI();
                ServiceReference1.MoveClient contr = new ServiceReference1.MoveClient();                
                move.Name = button.Name;
                list = contr.ChekMove(MapperUI.MoveUIToMove(move));
                if (list.Count == 0)
                {
                    MessageBox.Show("NULL");
                    button.HorizontalContentAlignment = HorizontalAlignment.Center;
                    button.VerticalContentAlignment = VerticalAlignment.Center;
                    (button.Content as Border).BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF612E1C"));
                   
                    return;
                }
                movetmp.Name = button.Name;
                foreach (var item in list)
                {
                    foreach (Button b in BtnGrid.Children)
                    {

                        if (b.Content is Border && (b.Content as Border).Name == item.Name + "b")
                        {
                            b.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                            b.VerticalContentAlignment = VerticalAlignment.Stretch;
                            (b.Content as Border).BorderBrush = new SolidColorBrush(Colors.Green);
                        }
                    }
                }
                first = false;
            }
            else
            {
                MoveUI move = new MoveUI();
                
                ServiceReference1.MoveClient contr = new ServiceReference1.MoveClient();
                
                foreach(var item in list)
                {
                    if (button.Name == item.Name)
                    {
                        
                        foreach (Button b in BtnGrid.Children)
                        {

                            foreach(var i in list)
                            {
                                if (b.Content is Border && (b.Content as Border).Name == i.Name + "b" || b.Content is Border && (b.Content as Border).Name == movetmp.Name + "b")
                                {
                                    b.HorizontalContentAlignment = HorizontalAlignment.Center;
                                    b.VerticalContentAlignment = VerticalAlignment.Center;
                                    (b.Content as Border).BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF612E1C"));
                                }
                            }
                            
                        }
                        move.Name = button.Name;
                        if (movetmp != null && move != null)
                        {
                            
                            contr.MakeMove(MapperUI.MoveUIToMove(movetmp), MapperUI.MoveUIToMove(move));
                            
                            first = true;
                        }
                        
                       
                    }
                }
                movetmp.Name = "";
                list.Clear();
                return;
            }

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
