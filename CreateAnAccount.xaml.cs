using System;
using System.Collections.Generic;
using System.Data.Common;
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

        #region user input validation checks
        private bool CheckUsername()
        {
            //return uniqueness of username in raport to the UserDB
            return (UserDB.ExistsInDB(_Username.Text) == false) && (_Username.Text.Length>UserLogin.min_username_length);
        }

        private bool CheckEmail()
        {
            return UserLogin.IsValidEmailFormat(_Email.Text);
        }

        private bool CheckPasswords()
        {
            return (_Password == _ConfirmPsw)&&(_Password.Password.Length>UserLogin.min_password_length);
        }

        #endregion

        private void InvalidEmailCheck()
        {
            if (CheckEmail() == false)
                _ErrorMsg.Text = "Invalid email address!";
            else
                _ErrorMsg.Text = "";
        }
        private void _Email_LostFocus(object sender, RoutedEventArgs e)
        {
            InvalidEmailCheck();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = _Username.Text;
            string email= _Email.Text;
            string password = _Password.Password;

            if(UserDB.ExistsInDB(username))
            {
                string message = "User already exists in our Database Resources!";
                MessageBox.Show(message); 
                _ErrorMsg.Text = message;
                return;
            }

            DbCon.InsertUser(username, email, password.Encrypt());
            this.SwitchTo(new MainWindow());
        }
    }
}
