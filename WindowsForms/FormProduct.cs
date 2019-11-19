﻿using ProdDAL.BindingModels;
using ProdDAL.Interfaces;
using ProdDAL.ViewModels;
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

        public FormProduct(IProductService service)
        {
            InitializeComponent();
            controlListBox.SetList(typeof(x));
            this.service = service;
        }

        private void controlListBox_SelectedIndexChanged(int index, object selected)
        {

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

            try
            {
                service.AddElement(new ProductBindingModel
                {
                    ProductName = textBoxName.Text,
                    ProductUnit = controlListBox.Selected.ToString(),
                    ProductAmount = Int32.Parse(textBoxAmount.Text),
                    ProductData = DateTime.ParseExact(enterFieldControlDate.TemplateText, "dd.MM.yyyy", null)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                LoadData(); ;
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
            List<ProductViewModel> list = service.GetList();
            List<string> titles = new List<string> { "Название", "Юнит", "Кол-во", "Дата" };
            List<string> fields = new List<string> { "ProductName", "ProductUnit", "ProductAmount", "ProductData" };
            diagrammaExcelComponent.CreateDiagram("D:/test", list.Select(x => (object)x).ToList(), titles, fields);
        }

        private void buttonDeserialization_Click(object sender, EventArgs e)
        {

        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {

        }
    }
}