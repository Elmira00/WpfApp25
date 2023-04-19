using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesignPatterns_Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CacheProxy cacheProxy = new CacheProxy();

        List<string> Words = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            cacheProxy.SetWords();
            string text = File.ReadAllText(@"~/../../..\Words.txt");
            var splitted = text.Split('\n');
            foreach (var item in splitted)
            {
                Words.Add(item.Trim());
            }
        }


        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string text = TextTB.Text;
            SubmittedWordsLB.Items.Add(text);
            cacheProxy.AddWord(text);
        }

        private void TextTB_KeyUp(object sender, KeyEventArgs e)
        {
            var tb = sender as TextBox;
            var text = tb.Text.ToLower();
            if (text == String.Empty)
            {
                Hints.Items.Clear();
            }

            List<string> hints = cacheProxy.GetValues(text);

            if (hints.Count > 0)
            {
                Hints.Items.Clear();
                foreach (var item in hints)
                {
                    Hints.Items.Add(item);
                }
            }
            else
            {
                Hints.Items.Clear();
                // from words file
                foreach (var item in Words)
                {
                    if (item.StartsWith(text))
                    {
                        Hints.Items.Add(item);
                    }
                }
            }
        }

        private void Hints_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = (ListBox)sender;
            TextTB.Text = listbox.SelectedItem.ToString();
        }

        private void TextTB_GotFocus(object sender, RoutedEventArgs e)
        {
            TextTB.Text = string.Empty;
        }
    }
}
