using DataBaseCheck.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBaseCheck
{
    class UtilMain
    {
        ClientContext db;

        #region MainPage

        public void MainInitialize(TextBox connectionstring)
        { 
            App.Current.Resources["ConnectStr"] = connectionstring.Text; 
        }

        public void MainLoad(TextBox TextBoxConnect, DataGrid MainTable)
        {
            db = new ClientContext((string)App.Current.Resources["ConnectStr"]);
            var clients = db.Clients.ToList();
            MainTable.ItemsSource = clients;
            if ((string)App.Current.Resources["Check"] == "true")
            {
                App.Current.Resources["Check"] = "false";
                Client cl = new Client();
                cl = (Client)App.Current.Resources["ClientTest"];
                bool chk = false;
                for (int i = 0; i < clients.Count; i++)
                {
                    if (clients.Contains(cl))
                    {
                        MainTable.SelectedItem = cl;
                        chk = true;
                        break;
                    }
                    else if ((cl.Name == clients[i].Name && cl.SurName == clients[i].SurName) || cl.PhoneNumber == clients[i].PhoneNumber)
                    {
                        MainTable.SelectedItem = clients[i];
                        chk = true;
                        break;
                    }
                }
                if (!chk)
                {
                    App.Current.Resources["MessageText"] = "Not Find";
                    Window1 win = new Window1();
                    win.Show();
                }
            }
        }

        public void MainPageLoad(TextBox TextBoxConnect)
        {
            if (!string.IsNullOrEmpty((string)App.Current.Resources["ConnectStr"]))
            {
                TextBoxConnect.Text = (string)App.Current.Resources["ConnectStr"];
            }
        }

        public void MessageShow()
        {
            Window1 win = new Window1();
            win.Show();
        }

        #endregion

    }
}
