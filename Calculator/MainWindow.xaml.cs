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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data; 
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement el in MainRoot.Children) // перебирает полностью элементы в сетке 
            {
                if (el is Button) // является ли этот объект классом Button 
                {
                    ((Button)el).Click += Button_Click; // обработчик события к каждой кнопке, указывает тот метод, который будет вызываться при нажатии на кнопку
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content; // переменная; устанавливает тот текст, который был на кнопке , который нажал пользователь
            // e - объект на который нажали
            // (Button)e.OriginalSource-преобразовать  объект "е" к классу Button
            // (string)((Button)e.OriginalSource)- нужно преобразовать к типу данных строка "string"; объект который идет к RoutedEventsArgs преобразует к классу Button , OriginalSource-берет этот объект
            // Content-получаем ту надпись которая находится на этом объекте и это все преобразуется к строке
            if (str == "AC") // если текст на кнопке равен значению AC, то значит пользователь нажал на кнопку
                textLabel.Text = ""; // текстовая надпись; при нажатии AC поле будет очищено 
            else if (str == "=") // проверить что написано на кнопке, если будет = то будет производить математическое действие (чтоб ее подключить нужно ввести где using - это 
            // using.System.Data
            {
                string value = new DataTable().Compute(textLabel.Text, null).ToString(); // переменная; создается объект Data Table(), метод Сompute будет вычислять математическую операцию
                // в Compute() обращается к текстовой строке,  ToString - преобразует к формату строки
                textLabel.Text = value; // обращение к текстовой строке 
            }

            else
                textLabel.Text += str; // добавляет значение к текстовой строке 

        }
    }
}
