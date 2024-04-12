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
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void _Login_Click(object sender, RoutedEventArgs e)
        {
            bool can_log_in = true;// UserLogin.VerifyCredentialsByMath(_Username.Text, _Password.Text);
            if (can_log_in)
                this.SwitchTo(new MainWindow());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.SwitchTo(new CreateAnAccount());
        }
    }
}
