using IronXL;
using PlugIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FormWaybill
{
    public partial class FormP3Main : Form
    {
        IPlugin _plug;

        public FormP3Main(IPlugin plug)
        {
            InitializeComponent();
            this._plug = plug;
        }

        private void FormP3Main_Load(object sender, EventArgs e)
        {
            this.tbInfo.AppendText("Author: " + this._plug.Author + "\r\n");
            this.tbInfo.AppendText("Name: " + this._plug.DisplayPluginName + "\r\n");
            this.tbInfo.AppendText("Description: " + this._plug.PluginDescription + "\r\n");
            this.tbInfo.AppendText("Name of plagin: " + this._plug.PluginName + "\r\n");
            this.tbInfo.AppendText("Version: " + this._plug.Version + "\r\n");
        }

        private void buttonFormWaybill_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}