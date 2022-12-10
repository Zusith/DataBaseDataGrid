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
    class UtilFind
    {
        public void Find(TextBox textboxName, TextBox textboxSurname, TextBox textboxPhoneNumber)
        {
            Client cl = new Client();
            cl.Name = textboxName.Text;
            cl.SurName = textboxSurname.Text;
            cl.PhoneNumber = textboxPhoneNumber.Text;
            App.Current.Resources["ClientTest"] = cl;
            App.Current.Resources["Check"] = "true";
        }
    }
}
