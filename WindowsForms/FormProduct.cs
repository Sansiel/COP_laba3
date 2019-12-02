using ControlLibrary;
using ProdDAL.BindingModels;
using ProdDAL.Interfaces;
using ProdDAL.ViewModels;
using ProdModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace WindowsForms
{
    public enum x {
        KG,
        Funt,
        Gramm,
    }

    public partial class FormProduct : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IProductService service;

        ProductFactory factory;

        public FormProduct(IProductService service)
        {
            InitializeComponent();
            controlListBox.SetList(typeof(x));
            this.service = service;
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
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните Name", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PaternDemonstration prod = new PaternDemonstration(factory);

            try
            {
                service.AddElement(new ProductBindingModel
                {
                    ProductName = textBoxName.Text,
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
    }
}
