using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCheck
{
    class WindowShow
    {
        public void MessageShow(string messagetext)
        {
            App.Current.Resources["MessageText"] = messagetext;
            Window1 win = new Window1();
            win.Show();
        }
    }
}
