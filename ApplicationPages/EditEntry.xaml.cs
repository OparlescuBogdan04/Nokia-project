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
        public struct Entry
        {
            public string Owner { get; set; }
            public string Status { get; set; }
            public string Jira { get; set; }
            public string Defect { get; set; }
            public string Priority { get; set; }

            public Entry(string Owner, string Status, string Jira, string Defect, string Priority)
            {
                this.Owner = Owner;
                this.Status = Status;
                this.Jira = Jira;
                this.Defect = Defect;
                this.Priority = Priority;
            }
        }

        public EditEntry()
        {
            InitializeComponent();
        }

        void AddTableEntry(Entry entry)
        {
            BacklogModule.AddTableEntry(entry);
            BacklogModule.RefreshTable();
        }

        private void _Done_Click(object sender, RoutedEventArgs e)
        {
            AddTableEntry(new Entry(_Owner.Text, _Status.Text, _Jira.Text, _Defect.Text, _Prio.Text));
        }
    }
}
