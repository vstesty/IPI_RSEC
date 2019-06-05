namespace ChargerEmulator
{
    partial class Form1
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
            this.buttonSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBusNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxChargingPower = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelChargingTime = new System.Windows.Forms.Label();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.labelEnergyConsumed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBarChargingTime = new System.Windows.Forms.TrackBar();
            this.richTextBoxLogs = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLocalHost = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarChargingTime)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(12, 318);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bus number:";
            // 
            // textBoxBusNumber
            // 
            this.textBoxBusNumber.Location = new System.Drawing.Point(84, 21);
            this.textBoxBusNumber.Name = "textBoxBusNumber";
            this.textBoxBusNumber.Size = new System.Drawing.Size(100, 20);
            this.textBoxBusNumber.TabIndex = 2;
            this.textBoxBusNumber.Text = "111";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Charging power [kW]:";
            // 
            // comboBoxChargingPower
            // 
            this.comboBoxChargingPower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChargingPower.FormattingEnabled = true;
            this.comboBoxChargingPower.Items.AddRange(new object[] {
            "40",
            "80"});
            this.comboBoxChargingPower.Location = new System.Drawing.Point(128, 52);
            this.comboBoxChargingPower.Name = "comboBoxChargingPower";
            this.comboBoxChargingPower.Size = new System.Drawing.Size(56, 21);
            this.comboBoxChargingPower.TabIndex = 4;
            this.comboBoxChargingPower.SelectedIndexChanged += new System.EventHandler(this.ComboBoxChargingPower_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Charging time [s]:";
            // 
            // labelChargingTime
            // 
            this.labelChargingTime.AutoSize = true;
            this.labelChargingTime.Location = new System.Drawing.Point(106, 90);
            this.labelChargingTime.Name = "labelChargingTime";
            this.labelChargingTime.Size = new System.Drawing.Size(13, 13);
            this.labelChargingTime.TabIndex = 6;
            this.labelChargingTime.Text = "0";
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Location = new System.Drawing.Point(93, 318);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(75, 23);
            this.buttonClearLog.TabIndex = 7;
            this.buttonClearLog.Text = "Clear log";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.ButtonClearLog_Click);
            // 
            // labelEnergyConsumed
            // 
            this.labelEnergyConsumed.AutoSize = true;
            this.labelEnergyConsumed.Location = new System.Drawing.Point(150, 119);
            this.labelEnergyConsumed.Name = "labelEnergyConsumed";
            this.labelEnergyConsumed.Size = new System.Drawing.Size(13, 13);
            this.labelEnergyConsumed.TabIndex = 9;
            this.labelEnergyConsumed.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Energy consumed [kWh]:";
            // 
            // trackBarChargingTime
            // 
            this.trackBarChargingTime.Location = new System.Drawing.Point(12, 144);
            this.trackBarChargingTime.Maximum = 7200;
            this.trackBarChargingTime.Name = "trackBarChargingTime";
            this.trackBarChargingTime.Size = new System.Drawing.Size(172, 45);
            this.trackBarChargingTime.TabIndex = 10;
            this.trackBarChargingTime.ValueChanged += new System.EventHandler(this.TrackBarChargingTime_ValueChanged);
            // 
            // richTextBoxLogs
            // 
            this.richTextBoxLogs.Location = new System.Drawing.Point(15, 168);
            this.richTextBoxLogs.Name = "richTextBoxLogs";
            this.richTextBoxLogs.ReadOnly = true;
            this.richTextBoxLogs.Size = new System.Drawing.Size(169, 120);
            this.richTextBoxLogs.TabIndex = 11;
            this.richTextBoxLogs.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Local host::";
            // 
            // textBoxLocalHost
            // 
            this.textBoxLocalHost.Location = new System.Drawing.Point(84, 294);
            this.textBoxLocalHost.Name = "textBoxLocalHost";
            this.textBoxLocalHost.Size = new System.Drawing.Size(100, 20);
            this.textBoxLocalHost.TabIndex = 2;
            this.textBoxLocalHost.Text = "44340";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 353);
            this.Controls.Add(this.richTextBoxLogs);
            this.Controls.Add(this.trackBarChargingTime);
            this.Controls.Add(this.labelEnergyConsumed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.labelChargingTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxChargingPower);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxLocalHost);
            this.Controls.Add(this.textBoxBusNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Charger emulator";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarChargingTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBusNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxChargingPower;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelChargingTime;
        private System.Windows.Forms.Button buttonClearLog;
        private System.Windows.Forms.Label labelEnergyConsumed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBarChargingTime;
        private System.Windows.Forms.RichTextBox richTextBoxLogs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLocalHost;
    }
}

