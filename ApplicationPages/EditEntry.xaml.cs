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

namespace Nokia.ApplicationPages
{
    /// <summary>
    /// Interaction logic for EditEntry.xaml
    /// </summary>
    public partial class EditEntry : Window
    {
        //parent backlog
        public BacklogModule BacklogModule;

        public EditEntry()
        {
            InitializeComponent();
        }

        void AddTableEntry(TestCase entry)
        {
            BacklogModule.AddTableEntry(entry);
            BacklogModule.RefreshTable();
        }

        private void _Done_Click(object sender, RoutedEventArgs e)
        {
            AddTableEntry(new TestCase(_Owner.Text, _Status.Text, _Jira.Text, _Defect.Text, _Prio.Text));
        }
    }
}
