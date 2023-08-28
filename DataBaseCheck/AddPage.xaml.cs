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
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
        }

        WindowShow WindowBox = new WindowShow();
        UtilAdd uadd = new UtilAdd();

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TextBoxPhoneNumber.Text))
                {
                    uadd.AddMethod(TextBoxName,TextBoxSurname, TextBoxPhoneNumber, TextBoxPost);
                    WindowBox.MessageShow("Success");
                    ClosePage();
                }
                else
                {
                    WindowBox.MessageShow("Enter right data");
                }           
            }
            catch (Exception ex)
            {
                WindowBox.MessageShow(ex.ToString());
            }
        } //Добавление

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            ClosePage();
        } //Отмена

        private void ClosePage()
        {
            Uri PageFunctionUri = new Uri("MainPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(PageFunctionUri);
        } //Метод закрытия

        #region Buttons animation
        private void ButtonAdd_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(15);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonAdd.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void ButtonAdd_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(15);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonAdd.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void ButtonCancel_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(15);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonCancel.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void ButtonCancel_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(15);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonCancel.BeginAnimation(Button.MarginProperty, thkanim);
        }
        #endregion //Анимация кнопок

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(200);
            thkanim.To = new Thickness(0);
            thkanim.Duration = TimeSpan.FromMilliseconds(300);
            this.BeginAnimation(Page.MarginProperty, thkanim);
        } //Анимация страницы
    }
}
