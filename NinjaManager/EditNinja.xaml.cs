using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace NinjaManager
{
    /// <summary>
    /// Interaction logic for AddNinja.xaml
    /// </summary>
    public partial class EditNinja : Window
    {
        public EditNinja()
        {
            InitializeComponent();

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
