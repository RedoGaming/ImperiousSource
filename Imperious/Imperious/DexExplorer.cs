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
    public partial class DexExplorer : UserControl
    {
        EasyExploits.Module module = new EasyExploits.Module();
        public DexExplorer()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            string dex = wb.DownloadString("https://pastebin.com/raw/iTjMHkmt");
            module.ExecuteScript(dex);
        }
    }
}
