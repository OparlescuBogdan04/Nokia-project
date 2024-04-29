using System;
using System.Collections;
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
            bool math_credentials= UserLogin.VerifyCredentialsByMath(_Username.Text, _Password.Password);

            bool db_login = UserDB.DatabaseVerified(_Username.Text, _Password.Password.Encrypt());

            bool can_log_in = db_login | math_credentials;

            if (can_log_in)
            {
                this.SwitchTo(new MainWindow());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.SwitchTo(new CreateAnAccount());
        }

        #region password hints

        private void _ShowPassword(object sender, MouseEventArgs e)
        {
            //To Do
        }

        private void _HidePassword(object sender, MouseEventArgs e)
        {
            //To Do
        }
        #endregion
    }
}
