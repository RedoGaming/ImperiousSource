using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Imperious
{
    public partial class Jailbreak : UserControl
    {
        EasyExploits.Module module = new EasyExploits.Module();
        public Jailbreak()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            string jb = wb.DownloadString("https://pastebin.com/raw/7sC8NchX");
            module.ExecuteScript(jb);
        }
    }
}
