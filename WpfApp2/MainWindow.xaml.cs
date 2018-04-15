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

namespace WpfApp2
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

        private async void Login_Click(object sender, RoutedEventArgs e)
        {

            // dead locking
    /*      var task =  Task.Delay(1).ContinueWith((t) =>
            {
                Dispatcher.Invoke(() => { });
            });

            task.Wait();*/

            // deadlocking


            try
            {
                LoginButt.IsEnabled = false;
                var result = await LoginAsync();
                //continuation of await
                LoginButt.Content = result;
                LoginButt.IsEnabled = true;

            }
            catch (Exception)
            {

                LoginButt.Content = "Login Failed";
            }


        }
        //task is the same as void
        private/*async*/ Task<string> LoginAsync()
        {
            try
            {
                // await means wait for this them everything else is a continuation.
               // string result = await Task.Run(()=>
               //Three tasks running at the same time
               //async calls each state machine.
                var loginTask = Task.Run(async () =>
                {
                    //  Thread.Sleep(2000);
                    await Task.Delay(2000); 
                    //method is returning something from the async task.
                    return "Login Successful";

                });
                //UI
                //   var logTask = Task.Delay(2000);//log the login
                //UI
                //    var purchaseTask = Task.Delay(1000); //Fetch proccesses
                //UI
                // this will now wait for all tasks to be completed.
                //    await Task.WhenAll(loginTask, loginTask, purchaseTask);
                return loginTask;
            }
            catch (Exception)
            {
                return Task.FromResult("Login unsuccessful");
            }
        }
    }
}
