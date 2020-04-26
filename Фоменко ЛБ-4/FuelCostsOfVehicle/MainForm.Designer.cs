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
            this.textBoxWeightVehicle = new System.Windows.Forms.TextBox();
            this.textBoxNameVehicle = new System.Windows.Forms.TextBox();
            this.comboBoxTypesOfVehicles = new System.Windows.Forms.ComboBox();
            this.buttonRandVehicle = new System.Windows.Forms.Button();
            this.buttonAddVehicle = new System.Windows.Forms.Button();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.TypeOfVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightOfVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTypeVehicle = new System.Windows.Forms.Label();
            this.labelNameVehicle = new System.Windows.Forms.Label();
            this.labelWeightVehicle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelWeightVehicle);
            this.groupBox1.Controls.Add(this.labelNameVehicle);
            this.groupBox1.Controls.Add(this.labelTypeVehicle);
            this.groupBox1.Controls.Add(this.textBoxWeightVehicle);
            this.groupBox1.Controls.Add(this.textBoxNameVehicle);
            this.groupBox1.Controls.Add(this.comboBoxTypesOfVehicles);
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
            // textBoxWeightVehicle
            // 
            this.textBoxWeightVehicle.Location = new System.Drawing.Point(344, 31);
            this.textBoxWeightVehicle.Name = "textBoxWeightVehicle";
            this.textBoxWeightVehicle.Size = new System.Drawing.Size(100, 20);
            this.textBoxWeightVehicle.TabIndex = 6;
            // 
            // textBoxNameVehicle
            // 
            this.textBoxNameVehicle.Location = new System.Drawing.Point(221, 31);
            this.textBoxNameVehicle.Name = "textBoxNameVehicle";
            this.textBoxNameVehicle.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameVehicle.TabIndex = 5;
            // 
            // comboBoxTypesOfVehicles
            // 
            this.comboBoxTypesOfVehicles.FormattingEnabled = true;
            this.comboBoxTypesOfVehicles.Location = new System.Drawing.Point(105, 30);
            this.comboBoxTypesOfVehicles.Name = "comboBoxTypesOfVehicles";
            this.comboBoxTypesOfVehicles.Size = new System.Drawing.Size(91, 21);
            this.comboBoxTypesOfVehicles.TabIndex = 4;
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
            this.dataGridViewMain.Location = new System.Drawing.Point(105, 57);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            this.dataGridViewMain.Size = new System.Drawing.Size(339, 252);
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
            // labelTypeVehicle
            // 
            this.labelTypeVehicle.AutoSize = true;
            this.labelTypeVehicle.Location = new System.Drawing.Point(105, 11);
            this.labelTypeVehicle.Name = "labelTypeVehicle";
            this.labelTypeVehicle.Size = new System.Drawing.Size(46, 13);
            this.labelTypeVehicle.TabIndex = 7;
            this.labelTypeVehicle.Text = "Тип ТС:";
            // 
            // labelNameVehicle
            // 
            this.labelNameVehicle.AutoSize = true;
            this.labelNameVehicle.Location = new System.Drawing.Point(218, 11);
            this.labelNameVehicle.Name = "labelNameVehicle";
            this.labelNameVehicle.Size = new System.Drawing.Size(77, 13);
            this.labelNameVehicle.TabIndex = 7;
            this.labelNameVehicle.Text = "Название ТС:";
            // 
            // labelWeightVehicle
            // 
            this.labelWeightVehicle.AutoSize = true;
            this.labelWeightVehicle.Location = new System.Drawing.Point(341, 11);
            this.labelWeightVehicle.Name = "labelWeightVehicle";
            this.labelWeightVehicle.Size = new System.Drawing.Size(74, 13);
            this.labelWeightVehicle.TabIndex = 7;
            this.labelWeightVehicle.Text = "Масса ТС, кг";
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
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.Button buttonAddVehicle;
        private System.Windows.Forms.Button buttonRandVehicle;
        private System.Windows.Forms.ComboBox comboBoxTypesOfVehicles;
        private System.Windows.Forms.TextBox textBoxWeightVehicle;
        private System.Windows.Forms.TextBox textBoxNameVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeOfVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightOfVehicle;
        private System.Windows.Forms.Label labelWeightVehicle;
        private System.Windows.Forms.Label labelNameVehicle;
        private System.Windows.Forms.Label labelTypeVehicle;
    }
}

