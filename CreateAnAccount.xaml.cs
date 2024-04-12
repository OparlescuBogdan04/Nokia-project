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
using System.Windows.Shapes;

namespace Nokia
{
    /// <summary>
    /// Interaction logic for CreateAnAccount.xaml
    /// </summary>
    public partial class CreateAnAccount : Window
    {
        public CreateAnAccount()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = _Username.Text;
            string email=_Email.Text;
            string password = _Password.Text;
            //create a new account using the credentials
            //To Do
            this.SwitchTo(new MainWindow());
        }
    }
}
