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
using System.Windows.Shapes;

namespace DataBaseCheck
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e) //Закрытие страницы
        {
            this.Close();
        }

        private void textBlockMessage_Loaded(object sender, RoutedEventArgs e) //Загрузка
        {
            //Вывод сообщения
            textBlockMessage.Text = (string)App.Current.Resources["MessageText"];
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) //Анимация страницы
        {
            DoubleAnimation dbanim = new DoubleAnimation();
            dbanim.From = 50;
            dbanim.To = 200;
            dbanim.Duration = TimeSpan.FromMilliseconds(200);
            this.BeginAnimation(Window1.HeightProperty, dbanim);
        }

        #region Button animation //Анимация кнопки
        private void ButtonOK_MouseEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.To = new Thickness(10);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonOK.BeginAnimation(Button.MarginProperty, thkanim);
        }

        private void ButtonOK_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation thkanim = new ThicknessAnimation();
            thkanim.From = new Thickness(10);
            thkanim.To = new Thickness(5);
            thkanim.Duration = TimeSpan.FromMilliseconds(100);
            ButtonOK.BeginAnimation(Button.MarginProperty, thkanim);
        }
        #endregion
    }
}
