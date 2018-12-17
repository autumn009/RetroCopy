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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RetroCopy
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //TextStatus.Text = "jf;;awejfwjfgoqemgeoimwqeo\r\njiwof;ioqwfiqjh;qigore\r\nfnwefiqowjifo;o";
            load();
        }

        private void addLog(string s)
        {
            TextStatus.Text += "\r\n" + s;
        }

        private void load()
        {
            try
            {
                SrcCombo.Text = Properties.Settings.Default.SrcDir;
                DstCombo.Text = Properties.Settings.Default.DstDir;
            }
            catch (Exception e)
            {
                addLog(e.ToString());
            }
        }
        private void save()
        {
            try
            {
                Properties.Settings.Default.SrcDir = SrcCombo.Text;
                Properties.Settings.Default.DstDir = DstCombo.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception e)
            {
                addLog(e.ToString());
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            save();
        }

        // Start button Handler
        private string createNewString()
        {
            return DateTimeOffset.Now.ToString("000$$$yyyyMMddHHmmss");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var dst = System.IO.Path.Combine(DstCombo.Text, createNewString());
            var p = System.Diagnostics.Process.Start("xcopy", "/v/e/i/h/k/y/z \"" + SrcCombo.Text + "\" \"" + dst + "\"");
            p.WaitForExit();
            this.IsEnabled = true;
            Console.Beep();
        }

        // Cancel button Handler
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
