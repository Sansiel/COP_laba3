using PlugIn;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EditUnit
{
    public partial class FormP1Main : Form
    {
        IPlugin _plug;

        string selected_value;

        object[] elems = {"KG", "Funt", "Gramm"};

        public FormP1Main(IPlugin plug)
        {
            InitializeComponent();
            this._plug = plug;
            listBox.Items.AddRange(elems);
        }

        private void FormP1Main_Load(object sender, System.EventArgs e)
        {
            this.tbInfo.AppendText("Author: " + this._plug.Author + "\r\n");
            this.tbInfo.AppendText("Name: " + this._plug.DisplayPluginName + "\r\n");
            this.tbInfo.AppendText("Description: " + this._plug.PluginDescription + "\r\n");
            this.tbInfo.AppendText("Name of plagin: " + this._plug.PluginName + "\r\n");
            this.tbInfo.AppendText("Version: " + this._plug.Version + "\r\n");
        }

        private void listBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            selected_value = listBox.SelectedItem.ToString();
        }

        public string Selected
        {
            get { return selected_value; }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
