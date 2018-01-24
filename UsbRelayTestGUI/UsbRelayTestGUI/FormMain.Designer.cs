namespace UsbRelayTestGUI
{
    partial class FormMain
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
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.numericUpDownRelayNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonStatus = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonOpenAll = new System.Windows.Forms.Button();
            this.buttonCloseAll = new System.Windows.Forms.Button();
            this.comboBoxRelaySerial = new System.Windows.Forms.ComboBox();
            this.buttonGetRelay = new System.Windows.Forms.Button();
            this.buttonDevType = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRelayNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(10, 52);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(91, 52);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // numericUpDownRelayNum
            // 
            this.numericUpDownRelayNum.Location = new System.Drawing.Point(93, 23);
            this.numericUpDownRelayNum.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownRelayNum.Name = "numericUpDownRelayNum";
            this.numericUpDownRelayNum.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownRelayNum.TabIndex = 2;
            this.numericUpDownRelayNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose channel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonStatus);
            this.groupBox1.Controls.Add(this.numericUpDownRelayNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonOpen);
            this.groupBox1.Controls.Add(this.buttonClose);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 111);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Single channel";
            // 
            // buttonStatus
            // 
            this.buttonStatus.Location = new System.Drawing.Point(10, 81);
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.Size = new System.Drawing.Size(156, 23);
            this.buttonStatus.TabIndex = 4;
            this.buttonStatus.Text = "Status";
            this.buttonStatus.UseVisualStyleBackColor = true;
            this.buttonStatus.Click += new System.EventHandler(this.buttonStatus_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonOpenAll);
            this.groupBox2.Controls.Add(this.buttonCloseAll);
            this.groupBox2.Location = new System.Drawing.Point(12, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 88);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Multy channel";
            // 
            // buttonOpenAll
            // 
            this.buttonOpenAll.Location = new System.Drawing.Point(6, 23);
            this.buttonOpenAll.Name = "buttonOpenAll";
            this.buttonOpenAll.Size = new System.Drawing.Size(164, 23);
            this.buttonOpenAll.TabIndex = 0;
            this.buttonOpenAll.Text = "Open All";
            this.buttonOpenAll.UseVisualStyleBackColor = true;
            this.buttonOpenAll.Click += new System.EventHandler(this.buttonOpenAll_Click);
            // 
            // buttonCloseAll
            // 
            this.buttonCloseAll.Location = new System.Drawing.Point(6, 52);
            this.buttonCloseAll.Name = "buttonCloseAll";
            this.buttonCloseAll.Size = new System.Drawing.Size(164, 23);
            this.buttonCloseAll.TabIndex = 1;
            this.buttonCloseAll.Text = "Close All";
            this.buttonCloseAll.UseVisualStyleBackColor = true;
            this.buttonCloseAll.Click += new System.EventHandler(this.buttonCloseAll_Click);
            // 
            // comboBoxRelaySerial
            // 
            this.comboBoxRelaySerial.FormattingEnabled = true;
            this.comboBoxRelaySerial.Location = new System.Drawing.Point(213, 24);
            this.comboBoxRelaySerial.Name = "comboBoxRelaySerial";
            this.comboBoxRelaySerial.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRelaySerial.TabIndex = 6;
            // 
            // buttonGetRelay
            // 
            this.buttonGetRelay.Location = new System.Drawing.Point(213, 51);
            this.buttonGetRelay.Name = "buttonGetRelay";
            this.buttonGetRelay.Size = new System.Drawing.Size(121, 23);
            this.buttonGetRelay.TabIndex = 7;
            this.buttonGetRelay.Text = "Update device serial";
            this.buttonGetRelay.UseVisualStyleBackColor = true;
            this.buttonGetRelay.Click += new System.EventHandler(this.buttonGetRelay_Click);
            // 
            // buttonDevType
            // 
            this.buttonDevType.Location = new System.Drawing.Point(213, 80);
            this.buttonDevType.Name = "buttonDevType";
            this.buttonDevType.Size = new System.Drawing.Size(121, 23);
            this.buttonDevType.TabIndex = 8;
            this.buttonDevType.Text = "Get device type";
            this.buttonDevType.UseVisualStyleBackColor = true;
            this.buttonDevType.Click += new System.EventHandler(this.buttonDevType_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 227);
            this.Controls.Add(this.buttonDevType);
            this.Controls.Add(this.buttonGetRelay);
            this.Controls.Add(this.comboBoxRelaySerial);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "Usb relay test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRelayNum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.NumericUpDown numericUpDownRelayNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonOpenAll;
        private System.Windows.Forms.Button buttonCloseAll;
        private System.Windows.Forms.ComboBox comboBoxRelaySerial;
        private System.Windows.Forms.Button buttonGetRelay;
        private System.Windows.Forms.Button buttonDevType;
    }
}

