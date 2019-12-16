using System.Collections.Generic;
using PlugIn;

namespace PostProduct
{
    public class PlugIn : IPlugin
    {

        private string _PluginName = "PostProduct";
        private string _DisplayPluginName = "Второй плагин";
        private string _PluginDescription = "Я и сам не знаю, что он должен делать";
        private string _Author = "Sansiel";
        private int _Version = 100;
        IPluginHost _Host;

        public void Show()
        {
            FormP2Main frm = new FormP2Main(this);
            frm.ShowDialog();
        }

        public string Activate<T>(List<T> input)
        {
            FormP2Main frm = new FormP2Main(this);

            //////
            frm.ShowDialog();
            return frm.Selected;
            //////
        }

        public IPluginHost Host
        {
            get { return _Host; }
            set
            {
                _Host = value;
                _Host.Register(this);
            }
        }

        public string PluginName
        {
            get
            {
                return _PluginName;
            }
        }

        public string DisplayPluginName
        {
            get
            {
                return _DisplayPluginName;
            }
        }

        public string PluginDescription
        {
            get
            {
                return _PluginDescription;
            }
        }

        public string Author
        {
            get
            {
                return _Author;
            }
        }

        public int Version
        {
            get
            {
                return _Version;
            }
        }
    }
}