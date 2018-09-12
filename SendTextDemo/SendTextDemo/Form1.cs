using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using SendTextDemo.Properties;

namespace SendTextDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            MailMessage SMS = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            try
            {
                if(rbVerizon.Checked)
                {
                    SMS.To.Add(tbPhoneNumber.Text + Settings.Default.serverVZ);
                }
                else if(rbATT.Checked)
                {
                    SMS.To.Add(tbPhoneNumber.Text + Settings.Default.serverATT);
                }
                else if (rbTMobile.Checked)
                {
                    SMS.To.Add(tbPhoneNumber.Text + Settings.Default.serverTMobile);
                }
                else if (rbSprint.Checked)
                {
                    SMS.To.Add(tbPhoneNumber.Text + Settings.Default.serverSprint);
                }

                SMS.Body = rtbSMSmessage.Text;
                SMS.IsBodyHtml = true;
                smtpClient.Credentials = new NetworkCredential(Settings.Default.FromEmail, Settings.Default.EmailPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Send(SMS);
                MessageBox.Show("SMS Sent Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
