﻿using System.Diagnostics;
using System.Windows;

namespace Nokia
{
    public static class WindowDialogue
    {

        public static void TerminalLog(string message)
        {
            DebugConsole.Instance.Log(message);
        }

        public static void CreateNewInstance(Window window)
        {
            window.Show();
        }

        public static void SwitchTo(this Window current,Window new_window)
        {
            double left = current.Left;
            double top = current.Top;
            new_window.Show();
            current.Hide();
            new_window.Left = left;
            new_window.Top = top;
        }

        public static void DebugWindow()
        {
            DebugConsole.ShowConsole();
        }
    }
}
