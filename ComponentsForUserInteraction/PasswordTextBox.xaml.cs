using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace ComponentsForUserInteraction
{
    /// <summary>
    /// Interaction logic for PasswordTextBox.xaml
    /// </summary>
    public partial class PasswordTextBox : UserControl
    {
        public PasswordTextBox()
        {
            InitializeComponent();
        }

        public TextBox TextBoxMaint { get
        {
            return textBox;
        }
        }

        private Complexity _complexity { get; set; }
        private Complexity Complexity
        {
            get
            {
                return _complexity;
            }
            set
            {
                _complexity = value;
                this.rectangle4.Fill = this._complexity <= Complexity.Hard ? Brushes.LightCyan : Brushes.ForestGreen;
                this.rectangle3.Fill = this._complexity <= Complexity.Good ? Brushes.LightCyan : Brushes.ForestGreen;
                this.rectangle2.Fill = this._complexity <= Complexity.Normal ? Brushes.LightCyan : Brushes.ForestGreen;
                this.rectangle1.Fill = this._complexity <= Complexity.Lite ? Brushes.LightCyan : Brushes.ForestGreen;
                
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Complexity = 0;
            if (this.textBox.Text.Any(c => char.IsLetter(c) && char.IsLower(c)))
            {
                this.Complexity++;
            }
            if (this.textBox.Text.Any(char.IsDigit))
            {
                this.Complexity++;
            }

            if (this.textBox.Text.Any(c => char.IsLetter(c) && !char.IsLower(c)))
            {
                this.Complexity++;
            }

            if (this.textBox.Text.Any(char.IsPunctuation))
            {
                this.Complexity++;
            }
        }

    }
}
