using Microsoft.Win32;
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

namespace _10lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Students student;
        public MainWindow()
        {
            InitializeComponent();
            student = new Students();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == false) return;
            ReadAsync(openFileDialog.FileName);
        }
        private async void ReadAsync(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                int i = 1;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    switch (i)
                    {
                        case 1: student.Name = line; break;
                        case 2: student.Surname = line; break;
                        case 3: student.Patronymic = line; break;
                        case 4: student.Gender = line; break;
                        case 5: student.BornDate = int.Parse(line); break;
                        case 6: student.Address = line; break;
                        case 7: student.Marks = int.Parse(line); break;
                        case 8: student.Passmark = int.Parse(line); break;
                    }
                    i++;
                }
                TextInput.Text = student.ToString();
            }
        }

        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files(*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == false) return;
            SaveAsync(saveFileDialog.FileName);
        }
        private async void SaveAsync(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                await writer.WriteLineAsync(TextInput.Text);
            }
        }
    }
}
