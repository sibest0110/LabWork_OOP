namespace FuelCostsOfVehicle
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRandVehicle = new System.Windows.Forms.Button();
            this.buttonAddVehicle = new System.Windows.Forms.Button();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.TypeOfVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightOfVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonRandVehicle);
            this.groupBox1.Controls.Add(this.buttonAddVehicle);
            this.groupBox1.Controls.Add(this.dataGridViewMain);
            this.groupBox1.Location = new System.Drawing.Point(183, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 347);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonRandVehicle
            // 
            this.buttonRandVehicle.Location = new System.Drawing.Point(6, 125);
            this.buttonRandVehicle.Name = "buttonRandVehicle";
            this.buttonRandVehicle.Size = new System.Drawing.Size(75, 23);
            this.buttonRandVehicle.TabIndex = 3;
            this.buttonRandVehicle.Text = "R";
            this.buttonRandVehicle.UseVisualStyleBackColor = true;
            this.buttonRandVehicle.Click += new System.EventHandler(this.buttonRandVehicle_Click);
            // 
            // buttonAddVehicle
            // 
            this.buttonAddVehicle.Location = new System.Drawing.Point(6, 57);
            this.buttonAddVehicle.Name = "buttonAddVehicle";
            this.buttonAddVehicle.Size = new System.Drawing.Size(75, 23);
            this.buttonAddVehicle.TabIndex = 2;
            this.buttonAddVehicle.Text = "AddVehicle";
            this.buttonAddVehicle.UseVisualStyleBackColor = true;
            this.buttonAddVehicle.Click += new System.EventHandler(this.buttonAddVehicle_Click);
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeOfVehicle,
            this.NameOfVehicle,
            this.WeightOfVehicle});
            this.dataGridViewMain.Location = new System.Drawing.Point(101, 19);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            this.dataGridViewMain.Size = new System.Drawing.Size(315, 252);
            this.dataGridViewMain.TabIndex = 1;
            // 
            // TypeOfVehicle
            // 
            this.TypeOfVehicle.HeaderText = "Тип";
            this.TypeOfVehicle.Name = "TypeOfVehicle";
            this.TypeOfVehicle.ReadOnly = true;
            this.TypeOfVehicle.Width = 60;
            // 
            // NameOfVehicle
            // 
            this.NameOfVehicle.HeaderText = "Название";
            this.NameOfVehicle.Name = "NameOfVehicle";
            this.NameOfVehicle.ReadOnly = true;
            this.NameOfVehicle.Width = 160;
            // 
            // WeightOfVehicle
            // 
            this.WeightOfVehicle.HeaderText = "Масса, кг";
            this.WeightOfVehicle.Name = "WeightOfVehicle";
            this.WeightOfVehicle.ReadOnly = true;
            this.WeightOfVehicle.Width = 50;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 450);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAddVehicle;
        private System.Windows.Forms.Button buttonRandVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeOfVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightOfVehicle;
        public System.Windows.Forms.DataGridView dataGridViewMain;
    }
}

