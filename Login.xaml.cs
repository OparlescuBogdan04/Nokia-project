﻿using Nokia.ApplicationPages;
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
        public Login() : this(true) { }
        public Login(bool recurring)
        {
            InitializeComponent();
            if(recurring)
                RecurringUserLogin();
        }

        private void RecurringUserLogin()
        {
            try
            {
                if (RecurringUser.ExistingCredentialsFile())
                {
                    User user = RecurringUser.ReadFile();
                    _Username.Text = user.name;
                    _Password.Password = user.password;
                    _Login_Click(null, new RoutedEventArgs());
                }
            }
            catch { return; }
        }

        private void _Login_Click(object sender, RoutedEventArgs e)
        {
            //special login sequence
            LocalUserDB.LoadUsers();
            bool local_user_credentials = LocalUserDB.VerifyCredentials(_Username.Text, _Password.Password);
            if (local_user_credentials)
            {
                User user = LocalUserDB.retreiveUser(_Username.Text, _Password.Password);
                LocalUserDB.Kill();
                Profile.SetCurrentUser(user);
                this.SwitchTo(new MainWindow());
                return;
            }
            LocalUserDB.Kill();

            //math credentials or DB user
            bool math_credentials= UserLogin.VerifyCredentialsByMath(_Username.Text, _Password.Password);
            bool db_login = UserDB.DatabaseVerified(_Username.Text, _Password.Password.Encrypt()); 
            //change this to only accept the user ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

            bool can_log_in = db_login | math_credentials;
            if (can_log_in)
                Profile.SetCurrentUser(new User(_Username.Text,_Password.Password));


            if(can_log_in)
                this.SwitchTo(new MainWindow());
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
