using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for BacklogModule.xaml
    /// </summary>
    public partial class BacklogModule : Window
    {
        public BacklogModule()
        {
            InitializeComponent();
        }

        ///<summary>
        ///Backlog Module function for adding a new table entry
        ///</summary>
        public void AddTableEntry(EditEntry.Entry entry)
        {
            _DataTable.Items.Add(entry);
        }

        ///<summary>
        ///Backlog Module function for refreshing the data table
        ///</summary>
        public void RefreshTable()
        {
            _DataTable.Items.Refresh();
        }

        private void _EditEntry_Click(object sender, RoutedEventArgs e)
        {
            //Communication between this window and the instance window
            EditEntry instance = new EditEntry();
            instance.BacklogModule = this;
            WindowDialogue.CreateNewInstance(instance);
        }
    }
}
