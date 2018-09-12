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
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.rtbSMSmessage = new System.Windows.Forms.RichTextBox();
            this.btnSendSMS = new System.Windows.Forms.Button();
            this.ServiceProviders = new System.Windows.Forms.GroupBox();
            this.rbATT = new System.Windows.Forms.RadioButton();
            this.rbTMobile = new System.Windows.Forms.RadioButton();
            this.rbSprint = new System.Windows.Forms.RadioButton();
            this.rbVerizon = new System.Windows.Forms.RadioButton();
            this.ServiceProviders.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Location = new System.Drawing.Point(86, 177);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(156, 20);
            this.tbPhoneNumber.TabIndex = 0;
            // 
            // rtbSMSmessage
            // 
            this.rtbSMSmessage.Location = new System.Drawing.Point(86, 75);
            this.rtbSMSmessage.Name = "rtbSMSmessage";
            this.rtbSMSmessage.Size = new System.Drawing.Size(156, 96);
            this.rtbSMSmessage.TabIndex = 1;
            this.rtbSMSmessage.Text = "";
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendSMS.Location = new System.Drawing.Point(123, 203);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(88, 23);
            this.btnSendSMS.TabIndex = 2;
            this.btnSendSMS.Text = "Send SMS";
            this.btnSendSMS.UseVisualStyleBackColor = true;
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // ServiceProviders
            // 
            this.ServiceProviders.Controls.Add(this.rbVerizon);
            this.ServiceProviders.Controls.Add(this.rbSprint);
            this.ServiceProviders.Controls.Add(this.rbTMobile);
            this.ServiceProviders.Controls.Add(this.rbATT);
            this.ServiceProviders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServiceProviders.Location = new System.Drawing.Point(12, 12);
            this.ServiceProviders.Name = "ServiceProviders";
            this.ServiceProviders.Size = new System.Drawing.Size(312, 57);
            this.ServiceProviders.TabIndex = 3;
            this.ServiceProviders.TabStop = false;
            this.ServiceProviders.Text = "Service Provider :";
            // 
            // rbATT
            // 
            this.rbATT.AutoSize = true;
            this.rbATT.Location = new System.Drawing.Point(92, 21);
            this.rbATT.Name = "rbATT";
            this.rbATT.Size = new System.Drawing.Size(53, 20);
            this.rbATT.TabIndex = 0;
            this.rbATT.TabStop = true;
            this.rbATT.Text = "AT&T";
            this.rbATT.UseVisualStyleBackColor = true;
            // 
            // rbTMobile
            // 
            this.rbTMobile.AutoSize = true;
            this.rbTMobile.Location = new System.Drawing.Point(151, 21);
            this.rbTMobile.Name = "rbTMobile";
            this.rbTMobile.Size = new System.Drawing.Size(80, 20);
            this.rbTMobile.TabIndex = 1;
            this.rbTMobile.TabStop = true;
            this.rbTMobile.Text = "T-Mobile";
            this.rbTMobile.UseVisualStyleBackColor = true;
            // 
            // rbSprint
            // 
            this.rbSprint.AutoSize = true;
            this.rbSprint.Location = new System.Drawing.Point(237, 21);
            this.rbSprint.Name = "rbSprint";
            this.rbSprint.Size = new System.Drawing.Size(60, 20);
            this.rbSprint.TabIndex = 2;
            this.rbSprint.TabStop = true;
            this.rbSprint.Text = "Sprint";
            this.rbSprint.UseVisualStyleBackColor = true;
            // 
            // rbVerizon
            // 
            this.rbVerizon.AutoSize = true;
            this.rbVerizon.Location = new System.Drawing.Point(15, 21);
            this.rbVerizon.Name = "rbVerizon";
            this.rbVerizon.Size = new System.Drawing.Size(71, 20);
            this.rbVerizon.TabIndex = 3;
            this.rbVerizon.TabStop = true;
            this.rbVerizon.Text = "Verizon";
            this.rbVerizon.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 269);
            this.Controls.Add(this.ServiceProviders);
            this.Controls.Add(this.btnSendSMS);
            this.Controls.Add(this.rtbSMSmessage);
            this.Controls.Add(this.tbPhoneNumber);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ServiceProviders.ResumeLayout(false);
            this.ServiceProviders.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPhoneNumber;
        private System.Windows.Forms.RichTextBox rtbSMSmessage;
        private System.Windows.Forms.Button btnSendSMS;
        private System.Windows.Forms.GroupBox ServiceProviders;
        private System.Windows.Forms.RadioButton rbVerizon;
        private System.Windows.Forms.RadioButton rbSprint;
        private System.Windows.Forms.RadioButton rbTMobile;
        private System.Windows.Forms.RadioButton rbATT;
    }
}

