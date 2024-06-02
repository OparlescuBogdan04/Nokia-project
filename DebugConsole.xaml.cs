using System;
using System.Windows;

namespace Nokia
{
    public partial class DebugConsole : Window
    {
        // This class is a singleton
        private static DebugConsole instance;

        private DebugConsole()
        {
            InitializeComponent();
        }

        public static DebugConsole Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DebugConsole();
                    instance.Closed += (sender, args) => instance = null;
                }
                return instance;
            }
        }

        public void Log(string message)
        {
            _DebugConsole.Text += (log_msg_begin + message + log_msg_end);
        }

        const string log_msg_begin = ">> ";
        const string log_msg_end = "\n";


        public static void ShowConsole()
        {
            if (instance != null)
            {
                instance.Activate();
                return;
            }

            instance = new DebugConsole();
            instance.Show();
            instance.Closed += (sender, args) => instance = null;
        }
    }
}
