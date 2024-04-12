using System.Windows.Controls;
using System.Windows;

namespace Nokia
{
        public partial class UserInputField : UserControl
        {
            public static readonly DependencyProperty LabelTextProperty =
                DependencyProperty.Register("LabelText", typeof(string), typeof(UserInputField));

            public string LabelText
            {
                get { return (string)GetValue(LabelTextProperty); }
                set { SetValue(LabelTextProperty, value); }
            }

            public static readonly DependencyProperty TextBoxNameProperty =
                DependencyProperty.Register("TextBoxName", typeof(string), typeof(UserInputField));

            public string TextBoxName
            {
                get { return (string)GetValue(TextBoxNameProperty); }
                set { SetValue(TextBoxNameProperty, value); }
            }

            //public UserInputField()
            //{
            //    InitializeComponent();
            //    DataContext = this;
            //}
        }
}
