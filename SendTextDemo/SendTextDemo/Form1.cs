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

        //Tylee Number: 3523628441
        private void Form1_Load(object sender, EventArgs e)
        {
            tbCharacterCount.Text = tbPhoneNumber.TextLength.ToString();
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            //Create the Recipient variable to Grab the recipients phone number
            string recipient = "";
            //string recipient = "3524549993" + Settings.Default.serverVZ;
            SmtpClient smtpClient = new SmtpClient(Settings.Default.GmailServer, 587);

            try
            {

                if (tbPhoneNumber.TextLength < 10) //Fist determine if the phone number is proper length
                {
                    statusStrip1.BackColor = Color.Red;
                    statusStrip1.ForeColor = Color.White;
                    toolStripStatusLabel1.Text = "Check Recipient phone number";
                    errorProvider1.SetError(tbPhoneNumber, "Invalid Length");
                }
                else if(cbServiceProvider.Text == "Verizon") //Check to see if VZ was selected by user
                {
                    recipient = tbPhoneNumber.Text + Settings.Default.serverVZ;
                }
                else if(cbServiceProvider.Text == "ATT") //Check to see if ATT was selected by the user
                {
                    recipient = tbPhoneNumber.Text + Settings.Default.serverATT;
                }
                else if (cbServiceProvider.Text == "T-Mobile") //Check to see if T-Mobile was selected by the user
                {
                    recipient = tbPhoneNumber.Text + Settings.Default.serverTMobile;
                }
                else if (cbServiceProvider.Text == "Sprint") //Check to see if Sprint was selected by the user
                {
                    recipient = tbPhoneNumber.Text + Settings.Default.serverSprint;
                }

                MailMessage SMS = new MailMessage(Settings.Default.FromEmail, recipient);
                SMS.Body = rtbSMSmessage.Text;
                SMS.IsBodyHtml = true;
                smtpClient.Credentials = new NetworkCredential(Settings.Default.FromEmail, Settings.Default.EmailPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Send(SMS);
                toolStripStatusLabel1.ForeColor = Color.Black;
                statusStrip1.BackColor = Color.Lime;
                toolStripStatusLabel1.Text = "SMS Sent Successfully";

            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.ForeColor = Color.White;
                statusStrip1.BackColor = Color.Red;
                toolStripStatusLabel1.Text = ex.Message.ToString();
            }
        }

        private void rtbSMSmessage_TextChanged(object sender, EventArgs e)
        {
            tbCharacterCount.Text = rtbSMSmessage.TextLength.ToString();
        }

        private void verizonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbServiceProvider.Text = "Verizon";
        }

        private void aTTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbServiceProvider.Text = "ATT";
        }

        private void tMobileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbServiceProvider.Text = "T-Mobile";
        }

        private void sprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbServiceProvider.Text = "Sprint";
        }

        private void clearSMSBodyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rtbSMSmessage.Text = "";
            statusStrip1.BackColor = Color.FromName("Control");
            toolStripStatusLabel1.ForeColor = Color.Black;
            toolStripStatusLabel1.Text = "Reset complete.";
        }

        private void clearALLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbPhoneNumber.Text = "";
            rtbSMSmessage.Text = "";
            tbCharacterCount.Text = tbPhoneNumber.TextLength.ToString();

            statusStrip1.BackColor = Color.FromName("Control");
            toolStripStatusLabel1.ForeColor = Color.Black;
            toolStripStatusLabel1.Text = "Reset complete.";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rtbSMSmessage_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    errorProvider1.Clear();

                    //Create the Recipient variable to Grab the recipients phone number
                    string recipient = "";
                    //string recipient = "3524549993" + Settings.Default.serverVZ;
                    SmtpClient smtpClient = new SmtpClient(Settings.Default.GmailServer, 587);


                    if (tbPhoneNumber.TextLength < 10) //Fist determine if the phone number is proper length
                    {
                        statusStrip1.BackColor = Color.Red;
                        statusStrip1.ForeColor = Color.White;
                        toolStripStatusLabel1.Text = "Check Recipient phone number";
                        errorProvider1.SetError(tbPhoneNumber, "Invalid Length");
                    }
                    else if (cbServiceProvider.Text == "Verizon") //Check to see if VZ was selected by user
                    {
                        recipient = tbPhoneNumber.Text + Settings.Default.serverVZ;
                    }
                    else if (cbServiceProvider.Text == "ATT") //Check to see if ATT was selected by the user
                    {
                        recipient = tbPhoneNumber.Text + Settings.Default.serverATT;
                    }
                    else if (cbServiceProvider.Text == "T-Mobile") //Check to see if T-Mobile was selected by the user
                    {
                        recipient = tbPhoneNumber.Text + Settings.Default.serverTMobile;
                    }
                    else if (cbServiceProvider.Text == "Sprint") //Check to see if Sprint was selected by the user
                    {
                        recipient = tbPhoneNumber.Text + Settings.Default.serverSprint;
                    }

                    MailMessage SMS = new MailMessage(Settings.Default.FromEmail, recipient);
                    SMS.Body = rtbSMSmessage.Text;
                    SMS.IsBodyHtml = true;
                    smtpClient.Credentials = new NetworkCredential(Settings.Default.FromEmail, Settings.Default.EmailPassword);
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(SMS);
                    toolStripStatusLabel1.ForeColor = Color.Black;
                    statusStrip1.BackColor = Color.Lime;
                    toolStripStatusLabel1.Text = "SMS Sent Successfully";

                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.ForeColor = Color.White;
                statusStrip1.BackColor = Color.Red;
                toolStripStatusLabel1.Text = ex.Message.ToString();
            }
        }

        private void tyleeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbServiceProvider.Text = "Verizon";
            tbPhoneNumber.Text = "3523628441";
        }
    }
}
