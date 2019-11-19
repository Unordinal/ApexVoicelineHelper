using System;
using System.Collections.Generic;
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

namespace ApexVoicelineHelper
{
    /// <summary>
    /// Interaction logic for VoicelineDialog.xaml
    /// </summary>
    public partial class VoicelineDialog : Window
    {
        public VoicelineDialog(List<string> validIDs, Voiceline toEdit = null)
        {
            InitializeComponent();
            cbName.DataContext = validIDs;
            if (toEdit != null)
            {
                Title = "Edit Voiceline";
                btnDialogAdd.Content = "Edit";
                tbKey.Text = toEdit.Keybind;
                cbName.SelectedItem = toEdit.Name;
            }
        }

        private void BtnDialogAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbKey.Text.Contains(" "))
            {
                e.Handled = true;
                MessageBox.Show("The keybind cannot contain spaces!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (string.IsNullOrWhiteSpace(tbKey.Text) || string.IsNullOrWhiteSpace(cbName.Text))
            {
                e.Handled = true;
                MessageBox.Show("Both fields must be filled!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
                DialogResult = true;
        }

        public string Key { get => tbKey.Text; }
        public new string Name { get => cbName.Text; }
    }
}
