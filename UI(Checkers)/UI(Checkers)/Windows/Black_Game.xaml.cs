using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using WMPLib;

namespace UI_Checkers_.Windows
{
    /// <summary>
    /// Логика взаимодействия для Black_Game.xaml
    /// </summary>
    public partial class Black_Game : Window
    {
        public MediaPlayer player { get; set; }

        BitmapImage checkblack = new BitmapImage(new Uri(@"\Icon\1.png",UriKind.Relative));
        BitmapImage checkwhite = new BitmapImage(new Uri(@"\Icon\2.png",UriKind.Relative));
        BitmapImage kingblack = new BitmapImage(new Uri(@"\Icon\7.png", UriKind.Relative));
        BitmapImage kingwhite = new BitmapImage(new Uri(@"\Icon\8.png", UriKind.Relative));       

        int currentsong = 0;
        List<string> Songs = new List<string> { "1","2","3","4","5","6","7" };

        bool music = false;
        bool white = false;

        public Black_Game()
        {
            InitializeComponent();
            player = new MediaPlayer();
            this.DataContext = player;
            //if (white == true)
            //{

            //}
            // Music.Source = sound_on;
            Music.Content = (Canvas)this.TryFindResource("sound_mute");

            B8.Source = checkblack;
            D8.Source = checkblack;
            F8.Source = checkblack;
            H8.Source = checkblack;
            A7.Source = checkblack;
            C7.Source = checkblack;
            E7.Source = checkblack;
            G7.Source = checkblack;
            B6.Source = checkblack;
            D6.Source = checkblack;
            F6.Source = checkblack;
            H6.Source = checkblack;

            A1.Source = checkwhite;
            C1.Source = checkwhite;
            E1.Source = checkwhite;
            G1.Source = checkwhite;
            B2.Source = checkwhite;
            D2.Source = checkwhite;
            F2.Source = checkwhite;
            H2.Source = checkwhite;
            A3.Source = checkwhite;
            C3.Source = checkwhite;
            E3.Source = checkwhite;
            G3.Source = checkwhite;
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
                // player.Position = TimeSpan.FromMinutes(3);
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
            if(currentsong==Songs.Count)
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

        }
    }
}
