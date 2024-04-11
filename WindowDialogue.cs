﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nokia
{
    public static class WindowDialogue
    {
        public static void SwitchTo(this Window current,Window new_window)
        {
            double left = current.Left;
            double top = current.Top;

            new_window.Show();
            current.Hide();

            new_window.Left = left;
            new_window.Top = top;
        }
    }
}
