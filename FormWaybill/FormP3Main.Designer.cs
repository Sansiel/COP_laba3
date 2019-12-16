namespace FormWaybill
{
    partial class FormP3Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.buttonFormWaybill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbInfo
            // 
            this.tbInfo.Location = new System.Drawing.Point(33, 22);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(215, 196);
            this.tbInfo.TabIndex = 0;
            // 
            // buttonFormWaybill
            // 
            this.buttonFormWaybill.Location = new System.Drawing.Point(33, 224);
            this.buttonFormWaybill.Name = "buttonFormWaybill";
            this.buttonFormWaybill.Size = new System.Drawing.Size(212, 23);
            this.buttonFormWaybill.TabIndex = 1;
            this.buttonFormWaybill.Text = "Cancel";
            this.buttonFormWaybill.UseVisualStyleBackColor = true;
            this.buttonFormWaybill.Click += new System.EventHandler(this.buttonFormWaybill_Click);
            // 
            // FormP3Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 253);
            this.Controls.Add(this.buttonFormWaybill);
            this.Controls.Add(this.tbInfo);
            this.Name = "FormP3Main";
            this.Text = "FormP3Main";
            this.Load += new System.EventHandler(this.FormP3Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Button buttonFormWaybill;
    }
}