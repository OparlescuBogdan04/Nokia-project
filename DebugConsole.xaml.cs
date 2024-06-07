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
            _DebugConsole.Text += '\n';
        }

        public static DebugConsole Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DebugConsole();
                    instance.Closed += (sender, args) => CloseDebugWindow();
                }
                return instance;
            }
        }

        const string log_msg_begin = ">> ";
        const string log_msg_end = "\n";

        public void Log(string message)
        {
            _DebugConsole.Text += (log_msg_begin + message + log_msg_end);
        }

        public static void ShowConsole()
        {
            if (instance != null)
                return;

            instance = new DebugConsole();
            instance.Show();
            instance.Closed += (sender, args) =>CloseDebugWindow();
        }

        public static void CloseDebugWindow()
        {
            instance.Close();
            instance = null;
        }
    }
}
