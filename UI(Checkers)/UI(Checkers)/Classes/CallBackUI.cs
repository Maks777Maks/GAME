using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI_Checkers_.ServiceReference1;
using UI_Checkers_.Windows;

namespace UI_Checkers_.Classes
{
    public class CallBackUI : ServiceReference1.ICallbackCallback
    {
        public CallBackUI()
        {

        }

        public void GetInfo(bool b)
        {
           // MessageBox.Show("Hello");
           
            if (b == true)
            {
                White_Game wnd = new White_Game();
                wnd.Show();
            }
            else
            {
               Black_Game wnd = new Black_Game();
                wnd.Show();
            }
        }
    }
}
