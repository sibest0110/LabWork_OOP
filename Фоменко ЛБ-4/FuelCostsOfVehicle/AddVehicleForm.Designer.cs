namespace FuelCostsOfVehicle
{
    partial class AddVehicleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVehicleForm));
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelWeightVehicle = new System.Windows.Forms.Label();
            this.labelNameVehicle = new System.Windows.Forms.Label();
            this.labelTypeVehicle = new System.Windows.Forms.Label();
            this.textBoxWeightVehicle = new System.Windows.Forms.TextBox();
            this.textBoxNameVehicle = new System.Windows.Forms.TextBox();
            this.comboBoxTypesOfVehicles = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(177, 65);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(59, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(177, 95);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(59, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelWeightVehicle
            // 
            this.labelWeightVehicle.AutoSize = true;
            this.labelWeightVehicle.Location = new System.Drawing.Point(136, 22);
            this.labelWeightVehicle.Name = "labelWeightVehicle";
            this.labelWeightVehicle.Size = new System.Drawing.Size(74, 13);
            this.labelWeightVehicle.TabIndex = 11;
            this.labelWeightVehicle.Text = "Масса ТС, кг";
            // 
            // labelNameVehicle
            // 
            this.labelNameVehicle.AutoSize = true;
            this.labelNameVehicle.Location = new System.Drawing.Point(24, 75);
            this.labelNameVehicle.Name = "labelNameVehicle";
            this.labelNameVehicle.Size = new System.Drawing.Size(77, 13);
            this.labelNameVehicle.TabIndex = 12;
            this.labelNameVehicle.Text = "Название ТС:";
            // 
            // labelTypeVehicle
            // 
            this.labelTypeVehicle.AutoSize = true;
            this.labelTypeVehicle.Location = new System.Drawing.Point(27, 19);
            this.labelTypeVehicle.Name = "labelTypeVehicle";
            this.labelTypeVehicle.Size = new System.Drawing.Size(46, 13);
            this.labelTypeVehicle.TabIndex = 13;
            this.labelTypeVehicle.Text = "Тип ТС:";
            // 
            // textBoxWeightVehicle
            // 
            this.textBoxWeightVehicle.Location = new System.Drawing.Point(136, 38);
            this.textBoxWeightVehicle.Name = "textBoxWeightVehicle";
            this.textBoxWeightVehicle.Size = new System.Drawing.Size(100, 20);
            this.textBoxWeightVehicle.TabIndex = 2;
            // 
            // textBoxNameVehicle
            // 
            this.textBoxNameVehicle.Location = new System.Drawing.Point(27, 95);
            this.textBoxNameVehicle.Name = "textBoxNameVehicle";
            this.textBoxNameVehicle.Size = new System.Drawing.Size(131, 20);
            this.textBoxNameVehicle.TabIndex = 3;
            // 
            // comboBoxTypesOfVehicles
            // 
            this.comboBoxTypesOfVehicles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypesOfVehicles.FormattingEnabled = true;
            this.comboBoxTypesOfVehicles.Items.AddRange(new object[] {
            "Car",
            "HybridCar",
            "Helicopter"});
            this.comboBoxTypesOfVehicles.Location = new System.Drawing.Point(27, 38);
            this.comboBoxTypesOfVehicles.Name = "comboBoxTypesOfVehicles";
            this.comboBoxTypesOfVehicles.Size = new System.Drawing.Size(91, 21);
            this.comboBoxTypesOfVehicles.TabIndex = 1;
            // 
            // AddVehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 135);
            this.Controls.Add(this.labelWeightVehicle);
            this.Controls.Add(this.labelNameVehicle);
            this.Controls.Add(this.labelTypeVehicle);
            this.Controls.Add(this.textBoxWeightVehicle);
            this.Controls.Add(this.textBoxNameVehicle);
            this.Controls.Add(this.comboBoxTypesOfVehicles);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(750, 200);
            this.MaximizeBox = false;
            this.Name = "AddVehicleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Добавление ТС";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelWeightVehicle;
        private System.Windows.Forms.Label labelNameVehicle;
        private System.Windows.Forms.Label labelTypeVehicle;
        private System.Windows.Forms.TextBox textBoxWeightVehicle;
        private System.Windows.Forms.TextBox textBoxNameVehicle;
        private System.Windows.Forms.ComboBox comboBoxTypesOfVehicles;
    }
}