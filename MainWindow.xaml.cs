using Nokia.ApplicationPages;
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

namespace Nokia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Profile.GetUserType() == User.UserType.Programmer)
                WindowDialogue.DebugWindow();
        }

        private void _Monitoring_Click(object sender, RoutedEventArgs e)
        {
            this.SwitchTo(new Monitoring());
        }

        private void _Backlog_Click(object sender, RoutedEventArgs e)
        {
            this.SwitchTo(new BacklogModule());
        }

        private void _Profile_Click(object sender, RoutedEventArgs e)
        {
            this.SwitchTo(new Profile());
        }

        private void _Statistics_Click(object sender, RoutedEventArgs e)
        {
            this.SwitchTo(new Statistics());
        }
    }
}
