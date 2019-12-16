using IronXL;
using PlugIn;
using System.Collections.Generic;
using System.Linq;

namespace FormWaybill
{
    public class PlugIn : IPlugin
    {
        private string FieldType = "ProductName ProductData ProductUnit";
        private string _PluginName = "FormWaybill";
        private string _DisplayPluginName = "Третий плагин";
        private string _PluginDescription = "Делает накладную";
        private string _Author = "Sansiel";
        private int _Version = 100;
        IPluginHost _Host;

        public void Show()
        {
            FormP3Main frm = new FormP3Main(this);
            frm.ShowDialog();
        }

        public string Activate<T>(List<T> input)
        {
            string path = "D://cop";
            CreateExcelReport(input, path);
            return "";
        }

        public void CreateExcelReport<T>(List<T> toReport, string path)
        {
            WorkBook xlsxWorkbook = WorkBook.Create(ExcelFileFormat.XLSX);
            WorkSheet xlsSheet = xlsxWorkbook.CreateWorkSheet("main_sheet");

            var props = typeof(T).GetProperties().Where((x) => FieldType.Split(' ').Contains(x.Name)).ToList();

            int propsLength = props.Capacity;
            string[] cells = { "A", "B", "C", "D", "E", "F", "G" };
            int j = 0;
            string cell;
            foreach (var p in toReport)
            {
                for (int i = 1; i < propsLength; i++)
                {
                    cell = cells[i - 1];
                    cell += j + 1;
                    xlsSheet[cell].Value = props[i - 1].GetValue(p).ToString();
                }
                j++;
            }
            xlsxWorkbook.SaveAs(path + ".xlsx");
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