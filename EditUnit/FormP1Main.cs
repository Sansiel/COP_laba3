using PlugIn;
using System.Windows.Forms;

namespace EditUnit
{
    public partial class FormP1Main : Form
    {
        IPlugin _plug;

        public FormP1Main(IPlugin plug)
        {
            InitializeComponent();
            this._plug = plug;
        }

        private void FormP1Main_Load(object sender, System.EventArgs e)
        {
            this.tbInfo.AppendText("Author: " + this._plug.Author + "\r\n");
            this.tbInfo.AppendText("Name: " + this._plug.DisplayPluginName + "\r\n");
            this.tbInfo.AppendText("Description: " + this._plug.PluginDescription + "\r\n");
            this.tbInfo.AppendText("Name of plagin: " + this._plug.PluginName + "\r\n");
            this.tbInfo.AppendText("Version: " + this._plug.Version + "\r\n");
        }
    }
}
