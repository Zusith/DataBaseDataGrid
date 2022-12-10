using DataBaseCheck.Models;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBaseCheck
{
    class UtilDelete
    {
        public void Delete()
        {
            Client cl = (Client)App.Current.Resources["ClientTest"];
            ClientContext db = new ClientContext((string)App.Current.Resources["ConnectStr"]);
            db.Clients.Attach(cl);
            db.Clients.Remove(cl);
            db.SaveChanges();
        }

        public void Load(TextBox TextBoxName, TextBox TextBoxSurname, TextBox TextBoxPhoneNumber)
        {
            Client cl = (Client)App.Current.Resources["ClientTest"];
            TextBoxName.Text = cl.Name;
            TextBoxSurname.Text = cl.SurName;
            TextBoxPhoneNumber.Text = cl.PhoneNumber;
        }
    }
}
