using PlugIn;
using System.Collections.Generic;

namespace EditUnit
{
    public class PlugIn : IPlugin
    {

    private string _PluginName = "EditUnit";
    private string _DisplayPluginName = "Первый плагин";
    private string _PluginDescription = "Измененяет единицы измерения поставок";
    private string _Author = "Sansiel";
    private int _Version = 100;
    IPluginHost _Host;

    public void Show()
    {
        FormP1Main frm = new FormP1Main(this);
        frm.ShowDialog();
    }

        public string Activate<T>(List<T> input)
        {
            FormP1Main frm = new FormP1Main(this);
            frm.ShowDialog();
            return frm.Selected;
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
