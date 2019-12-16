using PlugIn;
using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();

            Excel.Workbook wb = excelApp.Workbooks.Open(
                @"D:\\cop.xlsx",
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];

            var printers = System.Drawing.Printing.PrinterSettings.InstalledPrinters;

            int printerIndex = 0;

            foreach (String s in printers)
            {
                if (s.Equals("Name of Printer"))
                {
                    break;
                }
                printerIndex++;
            }

            ws.PrintOut(1, 2, 1, false, printers[printerIndex], true, false, Type.Missing);
        }
    }
}