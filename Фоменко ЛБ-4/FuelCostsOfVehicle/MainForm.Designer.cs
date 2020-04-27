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
            this.groupBoxDataBase = new System.Windows.Forms.GroupBox();
            this.buttonPullFullList = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonDeleteVehicle = new System.Windows.Forms.Button();
            this.buttonRandVehicle = new System.Windows.Forms.Button();
            this.buttonAddVehicle = new System.Windows.Forms.Button();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.TypeOfVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightOfVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.groupBoxDataBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxDataBase
            // 
            this.groupBoxDataBase.Controls.Add(this.buttonHelp);
            this.groupBoxDataBase.Controls.Add(this.buttonPullFullList);
            this.groupBoxDataBase.Controls.Add(this.buttonFind);
            this.groupBoxDataBase.Controls.Add(this.buttonDeleteVehicle);
            this.groupBoxDataBase.Controls.Add(this.buttonRandVehicle);
            this.groupBoxDataBase.Controls.Add(this.buttonAddVehicle);
            this.groupBoxDataBase.Controls.Add(this.dataGridViewMain);
            this.groupBoxDataBase.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDataBase.Name = "groupBoxDataBase";
            this.groupBoxDataBase.Size = new System.Drawing.Size(450, 325);
            this.groupBoxDataBase.TabIndex = 0;
            this.groupBoxDataBase.TabStop = false;
            this.groupBoxDataBase.Text = "База данных ТС";
            this.groupBoxDataBase.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonPullFullList
            // 
            this.buttonPullFullList.Location = new System.Drawing.Point(6, 106);
            this.buttonPullFullList.Name = "buttonPullFullList";
            this.buttonPullFullList.Size = new System.Drawing.Size(75, 38);
            this.buttonPullFullList.TabIndex = 6;
            this.buttonPullFullList.Text = "Полный список";
            this.buttonPullFullList.UseVisualStyleBackColor = true;
            this.buttonPullFullList.Click += new System.EventHandler(this.buttonPullFullList_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(6, 150);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(75, 23);
            this.buttonFind.TabIndex = 5;
            this.buttonFind.Text = "Поиск";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonDeleteVehicle
            // 
            this.buttonDeleteVehicle.Location = new System.Drawing.Point(6, 48);
            this.buttonDeleteVehicle.Name = "buttonDeleteVehicle";
            this.buttonDeleteVehicle.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteVehicle.TabIndex = 4;
            this.buttonDeleteVehicle.Text = "Удалить";
            this.buttonDeleteVehicle.UseVisualStyleBackColor = true;
            this.buttonDeleteVehicle.Click += new System.EventHandler(this.buttonDeleteVehicle_Click);
            // 
            // buttonRandVehicle
            // 
            this.buttonRandVehicle.Location = new System.Drawing.Point(6, 77);
            this.buttonRandVehicle.Name = "buttonRandVehicle";
            this.buttonRandVehicle.Size = new System.Drawing.Size(75, 23);
            this.buttonRandVehicle.TabIndex = 3;
            this.buttonRandVehicle.Text = "R";
            this.buttonRandVehicle.UseVisualStyleBackColor = true;
            this.buttonRandVehicle.Click += new System.EventHandler(this.buttonRandVehicle_Click);
            // 
            // buttonAddVehicle
            // 
            this.buttonAddVehicle.Location = new System.Drawing.Point(6, 19);
            this.buttonAddVehicle.Name = "buttonAddVehicle";
            this.buttonAddVehicle.Size = new System.Drawing.Size(75, 23);
            this.buttonAddVehicle.TabIndex = 2;
            this.buttonAddVehicle.Text = "Добавить";
            this.buttonAddVehicle.UseVisualStyleBackColor = true;
            this.buttonAddVehicle.Click += new System.EventHandler(this.buttonAddVehicle_Click);
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToDeleteRows = false;
            this.dataGridViewMain.AllowUserToResizeColumns = false;
            this.dataGridViewMain.AllowUserToResizeRows = false;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeOfVehicle,
            this.NameOfVehicle,
            this.WeightOfVehicle});
            this.dataGridViewMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridViewMain.Location = new System.Drawing.Point(101, 19);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            this.dataGridViewMain.Size = new System.Drawing.Size(315, 252);
            this.dataGridViewMain.TabIndex = 1;
            this.dataGridViewMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMain_CellClick);
            this.dataGridViewMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMain_CellDoubleClick);
            this.dataGridViewMain.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewMain_RowHeaderMouseDoubleClick);
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
            // buttonHelp
            // 
            this.buttonHelp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonHelp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonHelp.Location = new System.Drawing.Point(6, 179);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(75, 23);
            this.buttonHelp.TabIndex = 7;
            this.buttonHelp.Text = "Помощь";
            this.buttonHelp.UseVisualStyleBackColor = false;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 340);
            this.Controls.Add(this.groupBoxDataBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBoxDataBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDataBase;
        private System.Windows.Forms.Button buttonAddVehicle;
        private System.Windows.Forms.Button buttonRandVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeOfVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightOfVehicle;
        public System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.Button buttonDeleteVehicle;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Button buttonPullFullList;
        private System.Windows.Forms.Button buttonHelp;
    }
}

