using System.Windows.Forms;

namespace PlugIn
{
    public partial class FormMain : Form, IPluginHost
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public bool Register(IPlugin plug)
        {
            return true;
        }
    }
}
