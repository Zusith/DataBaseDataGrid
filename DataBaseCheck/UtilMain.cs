using DataBaseCheck.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
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
        ClientContext db; //контекст подключения бд

        #region MainPage

        //Инициализация главной страницы MainPage.xaml
        public void MainInitialize(TextBox connectionstring)
        {
            //Чтение файла со строкой подключения
            string[] optionlines = File.ReadAllLines("option.ini");
            for (int option = 0; option < optionlines.Length; option++)
            {
                if (optionlines[option] == "DataSource")
                {
                    connectionstring.Text = optionlines[option + 1];
                }                
            }
            App.Current.Resources["ConnectStr"] = connectionstring.Text; 
        }

        //Подсчет общего количества строк DataGrid
        public int NumbersOfRowsInDataGrid(DataGrid table) => table.Items.Count;

        #region Add methods for load // доп методы для загрузки

        //Заполнение фильтра по должности
        public void PostFilterFilling(ComboBox box, List<Client> clients)
        {
            List<string> posts = new List<string>();
            box.Items.Add("All");
            foreach (var client in clients)
            {
                if (!posts.Contains(client.Post))
                {
                    posts.Add(client.Post);
                    box.Items.Add(client.Post);
                }
            }
            box.SelectedItem = "All";
        }

        //Дополнительная проверка базы данных и DataGrid на соответствие
        public void DataBaseDataGridEquals(DataGrid MainTable, List<Client> clients)
        {
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

        #endregion

        #region Load // загрузка

        //Загрузка страницы MainPage.xaml
        public void MainLoad(TextBox TextBoxConnect, DataGrid MainTable, ComboBox box)
        {
            //Подключение к бд через строку подключения
            db = new ClientContext((string)App.Current.Resources["ConnectStr"]);
            var clients = db.Clients.ToList();
            MainTable.ItemsSource = clients;
            //Вызов метода проверка соответствия бд и DataGrid
            DataBaseDataGridEquals(MainTable, clients);
            //Вызов метода заполния фильтра по должности
            PostFilterFilling(box, clients);
        }

        //Загрузка таблицы
        public void MainPageLoad(TextBox TextBoxConnect)
        {
            //Доп проверка на наличие строки подключения
            if (!string.IsNullOrEmpty((string)App.Current.Resources["ConnectStr"]))
            {
                TextBoxConnect.Text = (string)App.Current.Resources["ConnectStr"];
            }
        }

        #endregion

        #endregion

    }
}
