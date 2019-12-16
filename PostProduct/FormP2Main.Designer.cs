namespace PostProduct
{
    partial class FormP2Main
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
            this.tbProduct = new System.Windows.Forms.TextBox();
            this.buttonProduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbInfo
            // 
            this.tbInfo.Location = new System.Drawing.Point(27, 31);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(230, 187);
            this.tbInfo.TabIndex = 0;
            // 
            // tbProduct
            // 
            this.tbProduct.Location = new System.Drawing.Point(281, 31);
            this.tbProduct.Name = "tbProduct";
            this.tbProduct.Size = new System.Drawing.Size(172, 22);
            this.tbProduct.TabIndex = 1;
            // 
            // buttonProduct
            // 
            this.buttonProduct.Location = new System.Drawing.Point(281, 59);
            this.buttonProduct.Name = "buttonProduct";
            this.buttonProduct.Size = new System.Drawing.Size(172, 23);
            this.buttonProduct.TabIndex = 2;
            this.buttonProduct.Text = "Этот продукт поступил";
            this.buttonProduct.UseVisualStyleBackColor = true;
            this.buttonProduct.Click += new System.EventHandler(this.buttonProduct_Click);
            // 
            // FormP2Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 253);
            this.Controls.Add(this.buttonProduct);
            this.Controls.Add(this.tbProduct);
            this.Controls.Add(this.tbInfo);
            this.Name = "FormP2Main";
            this.Text = "FormP2Main";
            this.Load += new System.EventHandler(this.FormP2Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.TextBox tbProduct;
        private System.Windows.Forms.Button buttonProduct;
    }
}