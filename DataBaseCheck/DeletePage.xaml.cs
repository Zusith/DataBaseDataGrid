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
    /// Логика взаимодействия для DeletePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        public DeletePage()
        {
            InitializeComponent();
        }

        UtilDelete udelete = new UtilDelete();
        WindowShow WindowBox = new WindowShow();

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            udelete.Delete();
            WindowBox.MessageShow("Success");
            ClosePage();
        } //Кнопка удалить

        private void ButtonCancel_Click(object sender, RoutedEventArgs e) //Кнопка отмена
        {
            ClosePage();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e) //Загрузка
        {
            udelete.Load(TextBoxName, TextBoxSurname, TextBoxPhoneNumber, TextBoxPost);
        }

        private void ClosePage()
        {
            Uri PageFunctionUri = new Uri("MainPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(PageFunctionUri);
        } //Закрытие страницы

        #region Buttons animation //анимация кнопок
        private void ButtonDelete_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(15);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonDelete.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void ButtonDelete_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(15);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonDelete.BeginAnimation(Button.MarginProperty, thkanim);
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

        private void ButtonDelete_DragEnter(object sender, DragEventArgs e)
        {

        }
    }
}
