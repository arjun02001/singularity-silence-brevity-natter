using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
namespace BrevityWindowsFormsApplication
{
    public partial class BrevityForm : Form
    {
        public BrevityForm()
        {
            InitializeComponent();
        }
        private void SendMail()
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                MailMessage message = new MailMessage();
                message.Body = bodyTextBox.Text;
                string[] recipients = toTextBox.Text.Split(',');
                foreach (string s in recipients)
                {
                    message.To.Add(s);
                }
                if (ccTextBox.Text != "")
                {
                    string[] cc = ccTextBox.Text.Split(',');
                    foreach (string s in cc)
                    {
                        message.CC.Add(s);
                    }
                }
                if (bccTextBox.Text != "")
                {
                    string[] bcc = bccTextBox.Text.Split(',');
                    foreach (string s in bcc)
                    {
                        message.Bcc.Add(s);
                    }
                }
                if (idTextBox.Text.EndsWith("@gmail.com"))
                    message.From = new MailAddress(idTextBox.Text);
                else
                    message.From = new MailAddress(idTextBox.Text + "@gmail.com");
                message.Subject = subjectTextBox.Text;
                client.Credentials = new NetworkCredential(idTextBox.Text, passwordTtextBox.Text);
                client.Send(message);
                MessageBox.Show("Mail sending successfull!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail not sent!!");
            }
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = true;
                foreach (Control ct in this.Controls)
                {
                    if (ct is TextBox)
                        if (ct != ccTextBox && ct != bccTextBox && ct.Text == string.Empty)
                        {
                            flag = false;
                        }
                }
                if (flag)
                {
                    SendMail();
                }
                else
                {
                    MessageBox.Show("Enter all fields");
                }
            }
            catch (Exception)
            { }
        }
        private void ClearFields()
        {
            try
            {
                foreach (Control ct in this.Controls)
                {
                    if (ct is TextBox)
                    {
                        ct.Text = string.Empty;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void resetButton_Click(object sender, EventArgs e)
        {
            ClearFields();
            meCheckBox.Checked = false;
        }

        private void meCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (meCheckBox.Checked)
                {
                    idTextBox.Text = "anamika02001";
                    idTextBox.Enabled = false;
                }
                else
                {
                    ClearFields();
                    idTextBox.Enabled = true;
                }
            }
            catch (Exception)
            { }
        }

    }
}
