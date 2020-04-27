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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBoxDataBase = new System.Windows.Forms.GroupBox();
            this.buttonDownLoadDB = new System.Windows.Forms.Button();
            this.buttonUpLoadDB = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonPullFullList = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonDeleteVehicle = new System.Windows.Forms.Button();
            this.buttonRandVehicle = new System.Windows.Forms.Button();
            this.buttonAddVehicle = new System.Windows.Forms.Button();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.TypeOfVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightOfVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonHelp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddVehicle = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveVehicle = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRandom = new System.Windows.Forms.ToolStripButton();
            this.groupBoxDataBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDataBase
            // 
            this.groupBoxDataBase.Controls.Add(this.buttonDownLoadDB);
            this.groupBoxDataBase.Controls.Add(this.buttonUpLoadDB);
            this.groupBoxDataBase.Controls.Add(this.buttonHelp);
            this.groupBoxDataBase.Controls.Add(this.buttonPullFullList);
            this.groupBoxDataBase.Controls.Add(this.buttonFind);
            this.groupBoxDataBase.Controls.Add(this.buttonDeleteVehicle);
            this.groupBoxDataBase.Controls.Add(this.buttonRandVehicle);
            this.groupBoxDataBase.Controls.Add(this.buttonAddVehicle);
            this.groupBoxDataBase.Controls.Add(this.dataGridViewMain);
            this.groupBoxDataBase.Location = new System.Drawing.Point(6, 28);
            this.groupBoxDataBase.Name = "groupBoxDataBase";
            this.groupBoxDataBase.Size = new System.Drawing.Size(426, 281);
            this.groupBoxDataBase.TabIndex = 0;
            this.groupBoxDataBase.TabStop = false;
            this.groupBoxDataBase.Text = "База данных ТС";
            this.groupBoxDataBase.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonDownLoadDB
            // 
            this.buttonDownLoadDB.Location = new System.Drawing.Point(6, 248);
            this.buttonDownLoadDB.Name = "buttonDownLoadDB";
            this.buttonDownLoadDB.Size = new System.Drawing.Size(90, 23);
            this.buttonDownLoadDB.TabIndex = 9;
            this.buttonDownLoadDB.Text = "Загрузка БД";
            this.buttonDownLoadDB.UseVisualStyleBackColor = true;
            this.buttonDownLoadDB.Click += new System.EventHandler(this.buttonDownLoadDB_Click);
            // 
            // buttonUpLoadDB
            // 
            this.buttonUpLoadDB.Location = new System.Drawing.Point(6, 219);
            this.buttonUpLoadDB.Name = "buttonUpLoadDB";
            this.buttonUpLoadDB.Size = new System.Drawing.Size(90, 23);
            this.buttonUpLoadDB.TabIndex = 8;
            this.buttonUpLoadDB.Text = "Выгрузка БД";
            this.buttonUpLoadDB.UseVisualStyleBackColor = true;
            this.buttonUpLoadDB.Click += new System.EventHandler(this.buttonUpLoadDB_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonHelp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonHelp.Location = new System.Drawing.Point(6, 179);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(89, 23);
            this.buttonHelp.TabIndex = 7;
            this.buttonHelp.Text = "Справка";
            this.buttonHelp.UseVisualStyleBackColor = false;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonPullFullList
            // 
            this.buttonPullFullList.Location = new System.Drawing.Point(6, 106);
            this.buttonPullFullList.Name = "buttonPullFullList";
            this.buttonPullFullList.Size = new System.Drawing.Size(89, 38);
            this.buttonPullFullList.TabIndex = 6;
            this.buttonPullFullList.Text = "Полный список";
            this.buttonPullFullList.UseVisualStyleBackColor = true;
            this.buttonPullFullList.Click += new System.EventHandler(this.buttonPullFullList_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(6, 150);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(89, 23);
            this.buttonFind.TabIndex = 5;
            this.buttonFind.Text = "Поиск";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonDeleteVehicle
            // 
            this.buttonDeleteVehicle.Location = new System.Drawing.Point(6, 48);
            this.buttonDeleteVehicle.Name = "buttonDeleteVehicle";
            this.buttonDeleteVehicle.Size = new System.Drawing.Size(89, 23);
            this.buttonDeleteVehicle.TabIndex = 4;
            this.buttonDeleteVehicle.Text = "Удалить";
            this.buttonDeleteVehicle.UseVisualStyleBackColor = true;
            this.buttonDeleteVehicle.Click += new System.EventHandler(this.buttonDeleteVehicle_Click);
            // 
            // buttonRandVehicle
            // 
            this.buttonRandVehicle.Location = new System.Drawing.Point(6, 77);
            this.buttonRandVehicle.Name = "buttonRandVehicle";
            this.buttonRandVehicle.Size = new System.Drawing.Size(89, 23);
            this.buttonRandVehicle.TabIndex = 3;
            this.buttonRandVehicle.Text = "!__RND__!";
            this.buttonRandVehicle.UseVisualStyleBackColor = true;
            this.buttonRandVehicle.Click += new System.EventHandler(this.buttonRandVehicle_Click);
            // 
            // buttonAddVehicle
            // 
            this.buttonAddVehicle.Location = new System.Drawing.Point(6, 19);
            this.buttonAddVehicle.Name = "buttonAddVehicle";
            this.buttonAddVehicle.Size = new System.Drawing.Size(89, 23);
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
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonHelp,
            this.toolStripButtonAddVehicle,
            this.toolStripButtonRemoveVehicle,
            this.toolStripButtonUpdate,
            this.toolStripButtonSearch,
            this.toolStripButtonExport,
            this.toolStripButtonImport,
            this.toolStripButtonRandom});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(438, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonHelp
            // 
            this.toolStripButtonHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHelp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHelp.Image")));
            this.toolStripButtonHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHelp.Name = "toolStripButtonHelp";
            this.toolStripButtonHelp.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonHelp.Text = "Справка";
            this.toolStripButtonHelp.Click += new System.EventHandler(this.toolStripButtonHelp_Click);
            // 
            // toolStripButtonAddVehicle
            // 
            this.toolStripButtonAddVehicle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddVehicle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddVehicle.Image")));
            this.toolStripButtonAddVehicle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddVehicle.Name = "toolStripButtonAddVehicle";
            this.toolStripButtonAddVehicle.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddVehicle.Text = "Добавить ТС";
            this.toolStripButtonAddVehicle.Click += new System.EventHandler(this.toolStripButtonAddVehicle_Click);
            // 
            // toolStripButtonRemoveVehicle
            // 
            this.toolStripButtonRemoveVehicle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemoveVehicle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemoveVehicle.Image")));
            this.toolStripButtonRemoveVehicle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemoveVehicle.Name = "toolStripButtonRemoveVehicle";
            this.toolStripButtonRemoveVehicle.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRemoveVehicle.Text = "Удалить выделенное ТС";
            this.toolStripButtonRemoveVehicle.Click += new System.EventHandler(this.toolStripButtonRemoveVehicle_Click);
            // 
            // toolStripButtonUpdate
            // 
            this.toolStripButtonUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUpdate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUpdate.Image")));
            this.toolStripButtonUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUpdate.Name = "toolStripButtonUpdate";
            this.toolStripButtonUpdate.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUpdate.Text = "Обновить список";
            this.toolStripButtonUpdate.Click += new System.EventHandler(this.toolStripButtonUpdate_Click);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSearch.Image")));
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearch.Text = "Поиск ТС";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // toolStripButtonExport
            // 
            this.toolStripButtonExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExport.Image")));
            this.toolStripButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExport.Name = "toolStripButtonExport";
            this.toolStripButtonExport.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExport.Text = "Выгрузка базы данных во внешний файл";
            this.toolStripButtonExport.Click += new System.EventHandler(this.toolStripButtonExport_Click);
            // 
            // toolStripButtonImport
            // 
            this.toolStripButtonImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonImport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonImport.Image")));
            this.toolStripButtonImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonImport.Name = "toolStripButtonImport";
            this.toolStripButtonImport.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonImport.Text = "Загрузка базы данных из внешнего файла";
            this.toolStripButtonImport.Click += new System.EventHandler(this.toolStripButtonImport_Click);
            // 
            // toolStripButtonRandom
            // 
            this.toolStripButtonRandom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRandom.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRandom.Image")));
            this.toolStripButtonRandom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRandom.Name = "toolStripButtonRandom";
            this.toolStripButtonRandom.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRandom.Text = "Генерация случайного ТС";
            this.toolStripButtonRandom.Click += new System.EventHandler(this.toolStripButtonRandom_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 438);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBoxDataBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBoxDataBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button buttonDownLoadDB;
        private System.Windows.Forms.Button buttonUpLoadDB;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonHelp;
        private System.Windows.Forms.ToolStripButton toolStripButtonExport;
        private System.Windows.Forms.ToolStripButton toolStripButtonImport;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddVehicle;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveVehicle;
        private System.Windows.Forms.ToolStripButton toolStripButtonUpdate;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonRandom;
    }
}

