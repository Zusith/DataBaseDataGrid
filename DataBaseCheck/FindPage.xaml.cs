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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        UtilFind ufind = new UtilFind();
        WindowShow WindowBox = new WindowShow();

        #region Buttons animation //Анимация кнопок
        private void FindButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(15);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonFind.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void FindButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(15);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonFind.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void CancelButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(15);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonCancel.BeginAnimation(Button.MarginProperty, thkanim);
        }
    
        private void CancelButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(15);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonCancel.BeginAnimation(Button.MarginProperty, thkanim);
        }
        #endregion

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textboxName.Text) && string.IsNullOrEmpty(textboxSurname.Text) && string.IsNullOrEmpty(textboxPhoneNumber.Text))
            {
                WindowBox.MessageShow("Enter name and wurname or phone number");
            }
            else
            {
                ufind.Find(textboxName, textboxSurname, textboxPhoneNumber);
                ClosePage();
            }         
        } //Кнопка Поиска

        private void CancelButton_Click(object sender, RoutedEventArgs e) //Кнопка отмена
        {
            ClosePage();
        }

        private void ClosePage() //Закрытие страницы
        {
            Uri PageFunctionUri = new Uri("MainPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(PageFunctionUri);
        }

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
