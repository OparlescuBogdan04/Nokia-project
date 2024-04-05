using System;
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
            new_window.Show();
            current.Hide();
        }
    }
}
