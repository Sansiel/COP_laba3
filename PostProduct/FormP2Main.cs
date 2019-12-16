using PlugIn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostProduct
{
    public partial class FormP2Main : Form
    {
        IPlugin _plug;

        string selected_value;

        public FormP2Main(IPlugin plug)
        {
            InitializeComponent();
            this._plug = plug;
        }

        private void FormP2Main_Load(object sender, EventArgs e)
        {
            this.tbInfo.AppendText("Author: " + this._plug.Author + "\r\n");
            this.tbInfo.AppendText("Name: " + this._plug.DisplayPluginName + "\r\n");
            this.tbInfo.AppendText("Description: " + this._plug.PluginDescription + "\r\n");
            this.tbInfo.AppendText("Name of plagin: " + this._plug.PluginName + "\r\n");
            this.tbInfo.AppendText("Version: " + this._plug.Version + "\r\n");
        }

        private void buttonProduct_Click(object sender, EventArgs e)
        {
            selected_value = tbProduct.Text;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string Selected
        {
            get { return selected_value; }
        }
    }
}
