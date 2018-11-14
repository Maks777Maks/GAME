using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using UI_Checkers_.ServiceReference1;
using UI_Checkers_.Util;
using UI_Checkers_.Windows;

namespace UI_Checkers_.Classes
{
    public class CallBackUI : ServiceReference1.ICallbackCallback
    {
        private Black_Game BG;
        private White_Game WG;
        string game = "";
        BitmapImage checkblack = new BitmapImage(new Uri(@"\Icon\1.png", UriKind.Relative));
        BitmapImage checkwhite = new BitmapImage(new Uri(@"\Icon\2.png", UriKind.Relative));
        BitmapImage kingblack = new BitmapImage(new Uri(@"\Icon\7.png", UriKind.Relative));
        BitmapImage kingwhite = new BitmapImage(new Uri(@"\Icon\8.png", UriKind.Relative));

        public CallBackUI()
        {
           
        }


        public void GetInfo(bool b, PlayerDTO pl)
        {
          
            if (b == true)
            {
                game = "White";
                WG = new White_Game(MapperUI.PlayerFromDTO(pl));
                WG.Show();
            }
            else
            {
                game = "Black";
                BG = new Black_Game(MapperUI.PlayerFromDTO(pl));
                BG.Show();
            }
        }

        public void MakeMoveDuplex(List<Move> moves)
        {
            
            if (game == "Black")
            {
                foreach (var item in moves)
                {
                    foreach (Button b in BG.BtnGrid.Children)
                    {

                        if (b.Name == item.Name)
                        {
                            if (item.Color == "Black")
                                ((b.Content as Border).Child as Image).Source = checkblack;
                            else if(item.Color == "White")
                            {
                                ((b.Content as Border).Child as Image).Source = checkwhite;
                            }
                            else
                            {
                                ((b.Content as Border).Child as Image).Source = null;
                            }
                        }
                    }
                }
            }
            else
            {
               
                foreach (var item in moves)
                {
                    foreach (Button b in WG.BtnGrid.Children)
                    {
                        if (b.Name == item.Name)
                        {
                           
                            if (item.Color == "Black")
                                ((b.Content as Border).Child as Image).Source = checkblack;
                            else if (item.Color == "White")
                            {
                                
                                ((b.Content as Border).Child as Image).Source = checkwhite;
                            }
                            else
                            {
                                
                                ((b.Content as Border).Child as Image).Source = null;
                            }
                        }
                    }
                }
            }         
        }
    }
}
