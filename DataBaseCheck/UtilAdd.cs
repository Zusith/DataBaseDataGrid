using DataBaseCheck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataBaseCheck
{
    class UtilAdd
    {

        public void AddMethod(TextBox TextBoxName, TextBox TextBoxSurname, TextBox TextBoxPhoneNumber)
        {
            string name = TextBoxName.Text;
            string surname = TextBoxSurname.Text;
            string phoneNumber = TextBoxPhoneNumber.Text;
            Client newclient = new Client { Name = name, SurName = surname, PhoneNumber = phoneNumber };
            ClientContext db = new ClientContext((string)App.Current.Resources["ConnectStr"]);
            db.Clients.Add(newclient);
            db.SaveChanges();
        }
    }
}
