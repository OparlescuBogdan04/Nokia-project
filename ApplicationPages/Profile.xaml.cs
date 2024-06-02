using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Nokia.ApplicationPages
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        static User user;
        public Profile()
        {
            InitializeComponent();

            if (user == null)
                return;
            try
            {
                InitializeFields();
            }
            catch { }
        }

        void InitializeFields()
        {
            _Name.Text += user.name;
            _Email.Text += user.email;
        }

        public static void SetCurrentUser(User user)
        {
            Profile.user = user;
        }

        public static User.UserType GetUserType()
        {
            return user.user_type;
        }

        public static void LogOut()
        {
            SetCurrentUser(null);
            Window current_window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            current_window.SwitchTo(new Login(false));
        }

        private void _Logout_Click(object sender, RoutedEventArgs e)
        {
            LogOut();
        }

        private void _RecurringUser_Click(object sender, RoutedEventArgs e)
        {
            RecurringUser.WriteFile(user);
        }
    }
}
