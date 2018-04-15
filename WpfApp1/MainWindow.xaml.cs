using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginButton.IsEnabled = false;
            var task = Task.Run(() => {
                Thread.Sleep(2000);
                return "Login Successfull";
            });


            task.ConfigureAwait(true).GetAwaiter().OnCompleted(() =>
            {
                LoginButton.Content = task.Result;
                LoginButton.IsEnabled = true;
            });


            //
         /*   task.ContinueWith((t) =>
            {
                if (t.IsFaulted)
                {
                    Dispatcher.Invoke(() =>
                    {
                        LoginButton.Content = "Login Unsuccessful";
                        LoginButton.IsEnabled = true;

                    });
                }
                else
                {
                    Dispatcher.Invoke(() =>
                    {
                        LoginButton.Content = t.Result;
                        LoginButton.IsEnabled = true;

                    });
                }
            });*/
        }
    }
}
