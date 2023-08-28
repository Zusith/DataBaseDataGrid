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
    class UtilChange
    {
        Client cl;

        public void Load(TextBox textboxName, TextBox textboxSurname, TextBox textboxPhoneNumber, TextBox textboxPost)
        {
            cl = (Client)App.Current.Resources["ClientTest"];
            textboxName.Text = cl.Name;
            textboxSurname.Text = cl.SurName;
            textboxPhoneNumber.Text = cl.PhoneNumber;
            textboxPost.Text = cl.Post;
        }

        public void Changes(TextBox textboxName, TextBox textboxSurname, TextBox textboxPhoneNumber, TextBox textboxPost)
        {
            ClientContext db = new ClientContext((string)App.Current.Resources["ConnectStr"]);
            var chClient = db.Clients.SingleOrDefault(b => b.Name == cl.Name &&
            b.SurName == cl.SurName && b.PhoneNumber == cl.PhoneNumber && b.Post == cl.Post);
            chClient.Name = textboxName.Text.ToString();
            chClient.SurName = textboxSurname.Text.ToString();
            chClient.PhoneNumber = textboxPhoneNumber.Text.ToString();
            chClient.Post = textboxPost.Text.ToString();
            db.SaveChanges();
        }
    }
}
