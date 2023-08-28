using DataBaseCheck.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        #region variables create // создание переменных

        //Создание переменной для взаимодействия с управляющим классом страницей Main
        UtilMain utilita = new UtilMain();
        //Создание переменной для отображения измененных Messagebox под дизайн
        WindowShow WindowBox = new WindowShow();

        #endregion

        public MainPage()
        {
            InitializeComponent();

            //подключение к базе данных по строке подключения расположенной в файле option.ini
            utilita.MainInitialize(TextBoxConnect); 
        }


        #region Load // загрузка

        //Загрузка таблицы
        private void MainTable_Loaded(object sender, RoutedEventArgs e) 
        {
            try
            {
                #region Animation //анимация открытия окна

                TextBoxConnect.Text = (string)App.Current.Resources["ConnectStr"];
                ThicknessAnimation thkanim = new ThicknessAnimation();
                thkanim.From = new Thickness(200);
                thkanim.To = new Thickness(0);
                thkanim.Duration = TimeSpan.FromMilliseconds(300);
                this.BeginAnimation(Page.MarginProperty, thkanim);

                #endregion

                utilita.MainLoad(TextBoxConnect, MainTable, ComboBoxFilter); //вызов метода загрузки вывод данных в DataGrid
                ComboBoxFilter.SelectedIndex = 0; //Установка значения фильтра
            }
            catch (Exception)
            {
                //Отображение сообщения о потере подключения
                WindowBox.MessageShow("Connection failed");
            }
            NumbersOfPostPrint();
        }

        //Загрузка данной страницы
        private void Page_Loaded(object sender, RoutedEventArgs e) 
        {
            utilita.MainPageLoad(TextBoxConnect);        
        }

        #endregion

        #region Additional methods // дополнительные методы

        //доп метод выбора страницы для DeletePage.xml и ChangePage.xml
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
                WindowBox.MessageShow("Choose a client");
            }
        }

        //доп метод вывода значения в Label для подсчет кол-ва сотрудников в должности
        private void NumbersOfPostPrint() => LabelNumbersOfPost.Content = utilita.NumbersOfRowsInDataGrid(MainTable);

        #endregion

        #region All Buttons Click // нажатие всех кнопок

        //Нажатие на кнопку поиска
        private void FindButton_Click(object sender, RoutedEventArgs e) 
        {
            WindowBox.MessageShow("Enter name and surname or phone number");
            //Открытие нужной страницы FindPage.xaml
            Uri PageFunctionUri = new Uri("FindPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(PageFunctionUri);
        }

        //Нажатие на кнопку подключения для подключения к бд через строку
        private void ButtonConnect_Click(object sender, RoutedEventArgs e) 
        {
            App.Current.Resources["ConnectStr"] = TextBoxConnect.Text;
            MainTable_Loaded(sender, e);
        }

        //Нажатие на кнопку добавления
        private void AddButton_Click(object sender, RoutedEventArgs e) 
        {
            // открытие нужной страницы AddPage.xaml
            Uri PageFunctionUri = new Uri("AddPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(PageFunctionUri);
        }

        //Нажатие на кнопку удаления
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // открытие нужной страницы DeletePage.xaml
            PageChoose("DeletePage.xaml");
        }

        //Нажатие на кнопку изменения
        private void ChangeButton_Click(object sender, RoutedEventArgs e) 
        {
            // открытие нужной страницы ChangePage.xaml
            PageChoose("ChangePage.xaml");
        }

        #endregion

        #region Font size option // настройка размера шрифта

        //Ввод цифр, изменения шрифта
        //Динамическое изменение размера шрифта
        private void TextBoxFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MainTable.FontSize = int.Parse(TextBoxFontSize.Text);
            }
            catch (Exception)
            {
                MainTable.FontSize = 24;
            }
        } 

        //Ввод только цифр в TextBox для изменения шрифта 
        private void TextBoxFontSize_PreviewTextInput(object sender, TextCompositionEventArgs e) 
        {
            try
            {
                if (!Char.IsDigit(e.Text, 0))
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
                WindowBox.MessageShow("Check font size");
            }
        }

        #endregion

        #region Filter option // настройка фильтра

        //Логика фильтра 
        public bool Contains(object de) 
        {
            try
            {
                if (ComboBoxFilter.SelectedItem == null || ComboBoxFilter.SelectedItem.ToString() == "All")
                {
                    return true;
                }
                Client client = de as Client;
                return (client.Post == ComboBoxFilter.SelectedItem.ToString());
            }
            catch (Exception)
            { return true; }
        }

        //включение фильтра при взаимодействии с ComboBox
        private void ComboBoxFilter_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {
            if (ComboBoxFilter.SelectedItem != null)
            {
                MainTable.Items.Filter = new Predicate<object>(Contains);
            }
            NumbersOfPostPrint();
        }

        #endregion

        #region Buttons Animation // анимации кнопок

        private void AddButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(10);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            AddButton.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void AddButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(10);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            AddButton.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void ChangeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(10);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ChangeButton.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void ChangeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(10);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ChangeButton.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void DeleteButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(10);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            DeleteButton.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void DeleteButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(10);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            DeleteButton.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void FindButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(10);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            FindButton.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void FindButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(10);
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
            thkanim.From = new Thickness(10);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonConnect.BeginAnimation(Button.MarginProperty, thkanim);
        }

        #endregion
    }
}
