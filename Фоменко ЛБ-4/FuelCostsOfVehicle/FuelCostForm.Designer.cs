namespace FuelCostsOfVehicle
{
    partial class FuelCostForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FuelCostForm));
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.textBoxDistance = new System.Windows.Forms.TextBox();
            this.textBoxFuelCost = new System.Windows.Forms.TextBox();
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.labelDistance = new System.Windows.Forms.Label();
            this.labelFuelCost = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(12, 100);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(80, 23);
            this.buttonCalculate.TabIndex = 3;
            this.buttonCalculate.Text = "Расчёт";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(98, 100);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(145, 23);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // textBoxDistance
            // 
            this.textBoxDistance.Location = new System.Drawing.Point(12, 25);
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.Size = new System.Drawing.Size(80, 20);
            this.textBoxDistance.TabIndex = 1;
            // 
            // textBoxFuelCost
            // 
            this.textBoxFuelCost.Location = new System.Drawing.Point(12, 72);
            this.textBoxFuelCost.Name = "textBoxFuelCost";
            this.textBoxFuelCost.ReadOnly = true;
            this.textBoxFuelCost.Size = new System.Drawing.Size(80, 20);
            this.textBoxFuelCost.TabIndex = 2;
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.Enabled = false;
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.Items.AddRange(new object[] {
            "Информация о ТС:"});
            this.listBoxInfo.Location = new System.Drawing.Point(98, 10);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.Size = new System.Drawing.Size(145, 82);
            this.listBoxInfo.TabIndex = 5;
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(9, 9);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(83, 13);
            this.labelDistance.TabIndex = 9;
            this.labelDistance.Text = "Дистанция, км";
            // 
            // labelFuelCost
            // 
            this.labelFuelCost.AutoSize = true;
            this.labelFuelCost.Location = new System.Drawing.Point(12, 56);
            this.labelFuelCost.Name = "labelFuelCost";
            this.labelFuelCost.Size = new System.Drawing.Size(62, 13);
            this.labelFuelCost.TabIndex = 10;
            this.labelFuelCost.Text = "Топливо, л";
            // 
            // FuelCostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 139);
            this.Controls.Add(this.labelFuelCost);
            this.Controls.Add(this.labelDistance);
            this.Controls.Add(this.listBoxInfo);
            this.Controls.Add(this.textBoxFuelCost);
            this.Controls.Add(this.textBoxDistance);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonCalculate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(750, 200);
            this.MaximizeBox = false;
            this.Name = "FuelCostForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Расчёт затрат топлива";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBoxDistance;
        private System.Windows.Forms.TextBox textBoxFuelCost;
        private System.Windows.Forms.ListBox listBoxInfo;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.Label labelFuelCost;
    }
}