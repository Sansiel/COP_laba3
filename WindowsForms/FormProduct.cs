using PlugIn;
using ProdDAL.BindingModels;
using ProdDAL.Interfaces;
using ProdDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Unity;

namespace WindowsForms
{
    public enum x
    {
        KG,
        Funt,
        Gramm,
    }

    public partial class FormProduct : Form, IPluginHost
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IProductService service;

        ProductFactory factory;

        List<IPlugin> _plugins;
        private string PName;

        public List<ProductViewModel> waybill_list;

        public FormProduct(IProductService service)
        {
            InitializeComponent();
            controlListBox.SetList(typeof(x));
            this.service = service;
            waybill_list = service.GetList();
        }

        private void controlListBox_SelectedIndexChanged(int index, object selected)
        {
            if (controlListBox.Selected.ToString().Equals("KG")) factory = new KgFactory();
            if (controlListBox.Selected.ToString().Equals("Funt")) factory = new FuntFactory();
            if (controlListBox.Selected.ToString().Equals("Gramm")) factory = new GrammFactory();
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            LoadData();
            this.LoadPlugins("C:\\Users\\User\\source\\repos\\COP_laba3\\plugins\\");
            this.AddPluginsItems();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PName))
            {
                MessageBox.Show("Заполните Name", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PaternDemonstration prod = new PaternDemonstration(factory);

            try
            {
                service.AddElement(new ProductBindingModel
                {
                    ProductName = PName,
                    ProductUnit = prod.Run(),
                    ProductAmount = Int32.Parse(textBoxAmount.Text),
                    ProductData = DateTime.ParseExact(enterFieldControlDate.TemplateText, "dd.MM.yyyy", null)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                List<ProductViewModel> list = service.GetList();
                List<string> titles = new List<string> { "Название", "Юнит", "Кол-во", "Дата" };
                List<string> fields = new List<string> { "ProductName", "ProductUnit", "ProductAmount", "ProductData" };
                vivodTableComponent.LoadEnumerationName(list.Select(x => (object)x).ToList(), titles, fields);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDiagram_Click(object sender, EventArgs e)
        {
            SaveFileDialog path = new SaveFileDialog { };
            if (path.ShowDialog() == DialogResult.OK)
            {
                List<ProductViewModel> list = service.GetList();
                List<string> titles = new List<string> { "Количество каждого Unit", "Unit", "Кол-во" };
                List<string> fields = new List<string> { "ProductUnit", "ProductAmount" };
                diagrammaExcelComponent.CreateDiagram(@path.FileName, list.Select(x => (object)x).ToList(), fields, titles);
            }
        }

        private void buttonDeserialization_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog path = new OpenFileDialog { };
                if (path.ShowDialog() == DialogResult.OK)
                {
                    var list1 = deserialization.Deserialize<ProductViewModel>(@path.FileName);
                    List<string> titles = new List<string> { "Название", "Юнит", "Кол-во", "Дата" };
                    List<string> fields = new List<string> { "ProductName", "ProductUnit", "ProductAmount", "ProductData" };
                    vivodTableComponent1.LoadEnumerationName(list1.Select(x => (object)x).ToList(), titles, fields);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog path = new SaveFileDialog { };
            if (path.ShowDialog() == DialogResult.OK)
            {
                List<ProductViewModel> list = service.GetList();
                excelReporterComponent.CreateExcelReport(list, @path.FileName, false);
            }
        }

        private void buttonBackUp_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            List<ProductViewModel> list = service.GetList();
            createBackUpComponent1.BackUp(list, @path);
        }

        private void LoadPlugins(string path)
        {
            string[] pluginFiles = Directory.GetFiles(path, "*.dll");
            this._plugins = new List<IPlugin>();

            foreach (string pluginPath in pluginFiles)
            {
                Type objType = null;
                try
                {
                    // пытаемся загрузить библиотеку
                    Assembly assembly = Assembly.LoadFrom(pluginPath);
                    if (assembly != null)
                    {
                        objType = assembly.GetType(Path.GetFileNameWithoutExtension(pluginPath) + ".PlugIn");
                    }
                }
                catch
                {
                    continue;
                }
                try
                {
                    if (objType != null)
                    {
                        this._plugins.Add((IPlugin)Activator.CreateInstance(objType));
                        this._plugins[this._plugins.Count - 1].Host = this;
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        private void AddPluginsItems()
        {
            this.lvPlugins.Items.Clear();
            foreach (IPlugin plugin in this._plugins)
            {
                if (plugin == null)
                {
                    continue;
                }
                this.lvPlugins.Items.Add(plugin.DisplayPluginName);
                this.lvPlugins.Items[this.lvPlugins.Items.Count - 1].SubItems.Add(plugin.Version.ToString());
                this.lvPlugins.Items[this.lvPlugins.Items.Count - 1].SubItems.Add(plugin.Author);
            }
        }

        public bool Register(IPlugin plug)
        {
            return true;
        }

        private void lvPlugins_DoubleClick(object sender, EventArgs e)
        {
            if (this.lvPlugins.SelectedItems.Count > 0)
            {
                int selectedIndex = this.lvPlugins.SelectedItems[0].Index;
                this._plugins[selectedIndex].Show();
            }
        }

        private void Waybill_Click(object sender, EventArgs e)
        {
            List<ProductViewModel> list = service.GetList();
            //int selectedIndex = this.lvPlugins.SelectedItems[0].Index;
            string fp = this._plugins[0].Activate(list);
            string sp = this._plugins[2].Activate(list);
            string thp = this._plugins[1].Activate(list);

            if (fp.Equals("KG")) factory = new KgFactory();
            if (fp.Equals("Funt")) factory = new FuntFactory();
            if (fp.Equals("Gramm")) factory = new GrammFactory();

            PName = sp;



        }
    }
}
