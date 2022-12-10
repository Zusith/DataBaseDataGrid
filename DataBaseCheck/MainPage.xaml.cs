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
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        //ClientContext db;
        UtilMain utilita = new UtilMain();

        public MainPage()
        {
            InitializeComponent();
            utilita.MainInitialize();
        }

        private void MainTable_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                #region Animation //анимация окна
                TextBoxConnect.Text = (string)App.Current.Resources["ConnectStr"];
                ThicknessAnimation thkanim = new ThicknessAnimation();
                thkanim.From = new Thickness(200);
                thkanim.To = new Thickness(0);
                thkanim.Duration = TimeSpan.FromMilliseconds(300);
                this.BeginAnimation(Page.MarginProperty, thkanim);
                #endregion
                utilita.MainLoad(TextBoxConnect, MainTable); //вызов метода загрузки          
            }
            catch (Exception)
            {
                //Отображение сообщения
                App.Current.Resources["MessageText"] = "Connection failed";
                utilita.MessageShow();
            }
        } //Загрузка

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // открытие страницы добавления
            Uri PageFunctionUri = new Uri("AddPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(PageFunctionUri);
        } //Кнопка добавления

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            PageChoose("DeletePage.xaml");
        } //Кнопка удаления

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            PageChoose("ChangePage.xaml");
        } //Кнопка изменения

        private void PageChoose(string page)
        {
            if (MainTable.SelectedItem != null)
            {
                Client cl = (Client)MainTable.SelectedItem;
                App.Current.Resources["ClientTest"] = cl;
                Uri PageFunctionUri = new Uri(page, UriKind.Relative);
                this.NavigationService.Navigate(PageFunctionUri);
            }
            else 
            {
                App.Current.Resources["MessageText"] = "Choose a client";
                Window1 win = new Window1();
                win.Show();
            }
        } //Выбор страницы

        #region Buttons Animation
        private void AddButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(15);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            AddButton.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void AddButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(15);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            AddButton.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void ChangeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(15);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ChangeButton.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void ChangeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(15);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ChangeButton.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void DeleteButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(15);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            DeleteButton.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void DeleteButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(15);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            DeleteButton.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void FindButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(15);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            FindButton.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void FindButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(15);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            FindButton.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void ButtonConnect_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(10);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonConnect.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void ButtonConnect_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(6);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonConnect.BeginAnimation(Button.MarginProperty, thkanim);
        }
        #endregion

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Resources["MessageText"] = "Enter name and surname or phone number";
            utilita.MessageShow();
            Uri PageFunctionUri = new Uri("FindPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(PageFunctionUri);
        } //Кнопка поиска

        private void ButtonConnect_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Resources["ConnectStr"] = TextBoxConnect.Text;
            MainTable_Loaded(sender, e);
        } //Кнопка подключения

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            utilita.MainPageLoad(TextBoxConnect);        
        } //Загрузка страницы

        
    }
}
