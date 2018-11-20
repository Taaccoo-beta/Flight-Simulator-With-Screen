using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightSimulator
{
    public partial class ResultBrowser : Form
    {
        public ResultBrowser()
        {
            InitializeComponent();
        }

        private void btnWebpageOpen_Click(object sender, EventArgs e)
        {
            
            webBrowser1.Navigate(new Uri("http://www.baidu.com"));
        }

        private void ResultBrowser_Load(object sender, EventArgs e)
        {

        }
    }
}
