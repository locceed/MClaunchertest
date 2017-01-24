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
using System.Net;
using System.IO;
using System.Xml;
using System.Collections;
namespace mclauncher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// http://bmclapi.bangbang93.com/mc/game/version_manifest.json
        /// http://bmclapi.bangbang93.com/doc/#api-_
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            vers();
        }
        public ArrayList mcver()
        {
            WebClient w1 = new WebClient();
            byte[] b1 = w1.DownloadData("http://bmclapi.bangbang93.com/mc/game/version_manifest.json");
            ASCIIEncoding ASCII = new ASCIIEncoding();
            string s1 = ASCII.GetString(b1);
            s1 = s1.Substring(s1.IndexOf("[") + 1);
            s1 = s1.Remove(s1.LastIndexOf("]"));
            ArrayList a1 = new ArrayList();
            while (true)
            {
                try
                {
                    a1.Add(s1.Substring(0, s1.IndexOf("}") + 1));
                    s1 = s1.Substring(s1.IndexOf("}") + 2);
                }
                catch
                {
                    break;
                }
            }
            return a1;
        }
        public ArrayList vers()
        {
            ArrayList a1 =new ArrayList();
            foreach(object each in mcver())
            {
                string s1 = each.ToString().Substring(each.ToString().IndexOf("id") + 5);
                s1 = s1.Substring(0, s1.IndexOf(",") - 1);
                a1.Add(s1);
                listBox.Items.Add(s1);
            }
            return a1;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            WebClient w1 = new WebClient();
            w1.DownloadFile("http://bmclapi2.bangbang93.com/version/" + "/" + listBox.SelectedItems[0] + "/cilent", Environment.CurrentDirectory + "\\" + listBox.SelectedItems[0].ToString() + ".json");
        }
    }
}
