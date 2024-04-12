using System;
using System.Windows;

namespace Nokia
{
    public partial class DebugConsole : Window
    {
        //this class is a singleton
        private static DebugConsole instance;

        public DebugConsole()
        {
            InitializeComponent();
        }

        public static DebugConsole Instance
        {
            get
            {
                if (instance == null)
                    instance = new DebugConsole();
                return instance;
            }
        }

        public void log(string message)
        {
            _DebugConsole.Text += (log_msg_begin + message + log_msg_end);
        }

        const string log_msg_begin = ">> ";
        const string log_msg_end = "\n";
    }
}
