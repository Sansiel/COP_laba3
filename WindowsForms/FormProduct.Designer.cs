﻿namespace WindowsForms
{
    partial class FormProduct
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.enterFieldControlDate = new WindowsFormsControlLibraryComponentSansiel.EnterFieldControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.controlListBox = new ControlLibrary.ControlListBox();
            this.vivodTableComponent = new Lab1ComponentKate.VivodTableComponent();
            this.diagrammaExcelComponent = new Lab1ComponentKate.DiagrammaExcelComponent(this.components);
            this.deserialization = new ControlLibrary.Deserialization(this.components);
            this.excelReporterComponent = new WindowsFormsControlLibraryComponentSansiel.ExcelReporterComponent(this.components);
            this.buttonDiagram = new System.Windows.Forms.Button();
            this.buttonDeserialization = new System.Windows.Forms.Button();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enterFieldControlDate
            // 
            this.enterFieldControlDate.AcceptColor = System.Drawing.Color.Green;
            this.enterFieldControlDate.DangerColor = System.Drawing.Color.Red;
            this.enterFieldControlDate.Location = new System.Drawing.Point(74, 257);
            this.enterFieldControlDate.Name = "enterFieldControlDate";
            this.enterFieldControlDate.Size = new System.Drawing.Size(201, 30);
            this.enterFieldControlDate.TabIndex = 0;
            this.enterFieldControlDate.TemplateData = "";
            this.enterFieldControlDate.TemplateRegex = "\\d\\d\\.\\d\\d\\.\\d\\d\\d\\d";
            this.enterFieldControlDate.TemplateText = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Unit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Date";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(75, 229);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(200, 22);
            this.textBoxAmount.TabIndex = 5;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(74, 9);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(201, 22);
            this.textBoxName.TabIndex = 6;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(75, 293);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // controlListBox
            // 
            this.controlListBox.Location = new System.Drawing.Point(75, 37);
            this.controlListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.controlListBox.Name = "controlListBox";
            this.controlListBox.Size = new System.Drawing.Size(200, 185);
            this.controlListBox.TabIndex = 8;
            this.controlListBox.SelectedIndexChanged += new ControlLibrary.ControlListBox.ListBoxEventHandler(this.controlListBox_SelectedIndexChanged);
            // 
            // vivodTableComponent
            // 
            this.vivodTableComponent.Location = new System.Drawing.Point(292, -6);
            this.vivodTableComponent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vivodTableComponent.Name = "vivodTableComponent";
            this.vivodTableComponent.Size = new System.Drawing.Size(517, 293);
            this.vivodTableComponent.TabIndex = 9;
            // 
            // excelReporterComponent
            // 
            this.excelReporterComponent.FieldType = null;
            // 
            // buttonDiagram
            // 
            this.buttonDiagram.Location = new System.Drawing.Point(315, 308);
            this.buttonDiagram.Name = "buttonDiagram";
            this.buttonDiagram.Size = new System.Drawing.Size(75, 23);
            this.buttonDiagram.TabIndex = 10;
            this.buttonDiagram.Text = "Diagram";
            this.buttonDiagram.UseVisualStyleBackColor = true;
            this.buttonDiagram.Click += new System.EventHandler(this.buttonDiagram_Click);
            // 
            // buttonDeserialization
            // 
            this.buttonDeserialization.Location = new System.Drawing.Point(413, 308);
            this.buttonDeserialization.Name = "buttonDeserialization";
            this.buttonDeserialization.Size = new System.Drawing.Size(114, 23);
            this.buttonDeserialization.TabIndex = 11;
            this.buttonDeserialization.Text = "Deserialization";
            this.buttonDeserialization.UseVisualStyleBackColor = true;
            this.buttonDeserialization.Click += new System.EventHandler(this.buttonDeserialization_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.Location = new System.Drawing.Point(553, 308);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(75, 23);
            this.buttonExcel.TabIndex = 12;
            this.buttonExcel.Text = "Excel";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // FormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 359);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.buttonDeserialization);
            this.Controls.Add(this.buttonDiagram);
            this.Controls.Add(this.vivodTableComponent);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enterFieldControlDate);
            this.Controls.Add(this.controlListBox);
            this.Name = "FormProduct";
            this.Text = "FormProduct";
            this.Load += new System.EventHandler(this.FormProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsControlLibraryComponentSansiel.EnterFieldControl enterFieldControlDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonAdd;
        private ControlLibrary.ControlListBox controlListBox;
        private Lab1ComponentKate.VivodTableComponent vivodTableComponent;
        private Lab1ComponentKate.DiagrammaExcelComponent diagrammaExcelComponent;
        private ControlLibrary.Deserialization deserialization;
        private WindowsFormsControlLibraryComponentSansiel.ExcelReporterComponent excelReporterComponent;
        private System.Windows.Forms.Button buttonDiagram;
        private System.Windows.Forms.Button buttonDeserialization;
        private System.Windows.Forms.Button buttonExcel;
    }
}
