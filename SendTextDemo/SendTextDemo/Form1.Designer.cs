namespace SendTextDemo
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
            this.components = new System.ComponentModel.Container();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.rtbSMSmessage = new System.Windows.Forms.RichTextBox();
            this.btnSendSMS = new System.Windows.Forms.Button();
            this.ServiceProviders = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbServiceProvider = new System.Windows.Forms.ComboBox();
            this.tbCharacterCount = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.serviceProviderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verizonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aTTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tMobileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSMSBodyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSMSBodyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastSentTxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tyleeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ServiceProviders.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Location = new System.Drawing.Point(125, 55);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(120, 22);
            this.tbPhoneNumber.TabIndex = 0;
            this.tbPhoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rtbSMSmessage
            // 
            this.rtbSMSmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSMSmessage.Location = new System.Drawing.Point(9, 21);
            this.rtbSMSmessage.MaxLength = 150;
            this.rtbSMSmessage.Name = "rtbSMSmessage";
            this.rtbSMSmessage.Size = new System.Drawing.Size(251, 96);
            this.rtbSMSmessage.TabIndex = 1;
            this.rtbSMSmessage.Text = "";
            this.rtbSMSmessage.TextChanged += new System.EventHandler(this.rtbSMSmessage_TextChanged);
            this.rtbSMSmessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbSMSmessage_KeyDown);
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendSMS.Location = new System.Drawing.Point(194, 370);
            this.btnSendSMS.MaximumSize = new System.Drawing.Size(88, 23);
            this.btnSendSMS.MinimumSize = new System.Drawing.Size(88, 23);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(88, 23);
            this.btnSendSMS.TabIndex = 2;
            this.btnSendSMS.Text = "Send SMS";
            this.btnSendSMS.UseVisualStyleBackColor = true;
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // ServiceProviders
            // 
            this.ServiceProviders.Controls.Add(this.label1);
            this.ServiceProviders.Controls.Add(this.label2);
            this.ServiceProviders.Controls.Add(this.cbServiceProvider);
            this.ServiceProviders.Controls.Add(this.tbPhoneNumber);
            this.ServiceProviders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServiceProviders.Location = new System.Drawing.Point(10, 27);
            this.ServiceProviders.Name = "ServiceProviders";
            this.ServiceProviders.Size = new System.Drawing.Size(272, 92);
            this.ServiceProviders.TabIndex = 3;
            this.ServiceProviders.TabStop = false;
            this.ServiceProviders.Text = "Recipient Information :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Phone Number :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Service Provider :";
            // 
            // cbServiceProvider
            // 
            this.cbServiceProvider.FormattingEnabled = true;
            this.cbServiceProvider.Items.AddRange(new object[] {
            "Verizon",
            "ATT",
            "T-Mobile",
            "Sprint"});
            this.cbServiceProvider.Location = new System.Drawing.Point(125, 25);
            this.cbServiceProvider.Name = "cbServiceProvider";
            this.cbServiceProvider.Size = new System.Drawing.Size(120, 24);
            this.cbServiceProvider.TabIndex = 6;
            // 
            // tbCharacterCount
            // 
            this.tbCharacterCount.Location = new System.Drawing.Point(166, 123);
            this.tbCharacterCount.Name = "tbCharacterCount";
            this.tbCharacterCount.Size = new System.Drawing.Size(66, 22);
            this.tbCharacterCount.TabIndex = 4;
            this.tbCharacterCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 400);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(292, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbCharacterCount);
            this.groupBox1.Controls.Add(this.rtbSMSmessage);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 152);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SMS Body :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "SMS Character Count :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serviceProviderToolStripMenuItem,
            this.clearSMSBodyToolStripMenuItem,
            this.tyleeToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(292, 24);
            this.mainMenu.TabIndex = 7;
            this.mainMenu.Text = "menuStrip1";
            // 
            // serviceProviderToolStripMenuItem
            // 
            this.serviceProviderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verizonToolStripMenuItem,
            this.aTTToolStripMenuItem,
            this.tMobileToolStripMenuItem,
            this.sprintToolStripMenuItem});
            this.serviceProviderToolStripMenuItem.Name = "serviceProviderToolStripMenuItem";
            this.serviceProviderToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.serviceProviderToolStripMenuItem.Text = "&Service Provider";
            // 
            // verizonToolStripMenuItem
            // 
            this.verizonToolStripMenuItem.Name = "verizonToolStripMenuItem";
            this.verizonToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.verizonToolStripMenuItem.Text = "Verizon";
            this.verizonToolStripMenuItem.Click += new System.EventHandler(this.verizonToolStripMenuItem_Click);
            // 
            // aTTToolStripMenuItem
            // 
            this.aTTToolStripMenuItem.Name = "aTTToolStripMenuItem";
            this.aTTToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.aTTToolStripMenuItem.Text = "ATT";
            this.aTTToolStripMenuItem.Click += new System.EventHandler(this.aTTToolStripMenuItem_Click);
            // 
            // tMobileToolStripMenuItem
            // 
            this.tMobileToolStripMenuItem.Name = "tMobileToolStripMenuItem";
            this.tMobileToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.tMobileToolStripMenuItem.Text = "T-Mobile";
            this.tMobileToolStripMenuItem.Click += new System.EventHandler(this.tMobileToolStripMenuItem_Click);
            // 
            // sprintToolStripMenuItem
            // 
            this.sprintToolStripMenuItem.Name = "sprintToolStripMenuItem";
            this.sprintToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.sprintToolStripMenuItem.Text = "Sprint";
            this.sprintToolStripMenuItem.Click += new System.EventHandler(this.sprintToolStripMenuItem_Click);
            // 
            // clearSMSBodyToolStripMenuItem
            // 
            this.clearSMSBodyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearSMSBodyToolStripMenuItem1,
            this.clearALLToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.lastSentTxtToolStripMenuItem});
            this.clearSMSBodyToolStripMenuItem.Name = "clearSMSBodyToolStripMenuItem";
            this.clearSMSBodyToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.clearSMSBodyToolStripMenuItem.Text = "&Application";
            // 
            // clearSMSBodyToolStripMenuItem1
            // 
            this.clearSMSBodyToolStripMenuItem1.Name = "clearSMSBodyToolStripMenuItem1";
            this.clearSMSBodyToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.clearSMSBodyToolStripMenuItem1.Text = "&Clear SMS Body";
            this.clearSMSBodyToolStripMenuItem1.Click += new System.EventHandler(this.clearSMSBodyToolStripMenuItem1_Click);
            // 
            // clearALLToolStripMenuItem
            // 
            this.clearALLToolStripMenuItem.Name = "clearALLToolStripMenuItem";
            this.clearALLToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.clearALLToolStripMenuItem.Text = "&Clear ALL";
            this.clearALLToolStripMenuItem.Click += new System.EventHandler(this.clearALLToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // lastSentTxtToolStripMenuItem
            // 
            this.lastSentTxtToolStripMenuItem.Name = "lastSentTxtToolStripMenuItem";
            this.lastSentTxtToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.lastSentTxtToolStripMenuItem.Text = "&LastSentTxt";
            this.lastSentTxtToolStripMenuItem.Click += new System.EventHandler(this.lastSentTxtToolStripMenuItem_Click);
            // 
            // tyleeToolStripMenuItem
            // 
            this.tyleeToolStripMenuItem.Name = "tyleeToolStripMenuItem";
            this.tyleeToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.tyleeToolStripMenuItem.Text = "&Tylee";
            this.tyleeToolStripMenuItem.Click += new System.EventHandler(this.tyleeToolStripMenuItem_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(12, 137);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(270, 69);
            this.listBox1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(99, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sent History :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 422);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.ServiceProviders);
            this.Controls.Add(this.btnSendSMS);
            this.MainMenuStrip = this.mainMenu;
            this.MaximumSize = new System.Drawing.Size(308, 460);
            this.MinimumSize = new System.Drawing.Size(308, 460);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ServiceProviders.ResumeLayout(false);
            this.ServiceProviders.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPhoneNumber;
        private System.Windows.Forms.RichTextBox rtbSMSmessage;
        private System.Windows.Forms.Button btnSendSMS;
        private System.Windows.Forms.GroupBox ServiceProviders;
        private System.Windows.Forms.TextBox tbCharacterCount;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbServiceProvider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem serviceProviderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verizonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aTTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tMobileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearSMSBodyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearSMSBodyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearALLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tyleeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastSentTxtToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
    }
}

