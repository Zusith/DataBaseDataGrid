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
    /// Логика взаимодействия для ChangePage.xaml
    /// </summary>
    public partial class ChangePage : Page
    {
        public ChangePage()
        {
            InitializeComponent();
        }

        UtilChange uchange = new UtilChange();
        WindowShow WindowBox = new WindowShow();

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            uchange.Load(textboxName, textboxSurname, textboxPhoneNumber, TextBoxPost);
        } //Загрузка

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textboxPhoneNumber.Text))
            {
                uchange.Changes(textboxName, textboxSurname, textboxPhoneNumber, TextBoxPost);
                WindowBox.MessageShow("Success");
                ClosePage();
            }
            else
            {
                WindowBox.MessageShow("Phone cannot be empty");
            }
        } //Кнопка изменение

        private void ButtonCancel_Click(object sender, RoutedEventArgs e) //Кнопка отмена
        {
            ClosePage();
        }

        private void ClosePage() //Закрытие страницы
        {
            Uri PageFunctionUri = new Uri("MainPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(PageFunctionUri);
        }

        #region Buttons animations //анимация кнопок
        private void ButtonChange_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(15);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonChange.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void ButtonChange_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(15);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonChange.BeginAnimation(Button.MarginProperty, thkanim);
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
        #endregion

        private void Page_Loaded(object sender, RoutedEventArgs e) //Анимация страницы
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(200);
            thkanim.To = new Thickness(0);
            thkanim.Duration = TimeSpan.FromMilliseconds(300);
            this.BeginAnimation(Page.MarginProperty, thkanim);
        }
    }
}
