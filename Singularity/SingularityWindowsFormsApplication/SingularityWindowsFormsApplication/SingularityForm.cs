using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SingularityWindowsFormsApplication
{
    public partial class SingularityForm : Form
    {
        public SingularityForm()
        {
            InitializeComponent();
        }

        private void SingularityForm_Load(object sender, EventArgs e)
        {

        }

        private void brevityButton_Click(object sender, EventArgs e)
        {
            BrevityWindowsFormsApplication.BrevityForm brevity = new BrevityWindowsFormsApplication.BrevityForm();
            brevity.Show();
        }

        private void silenceButton_Click(object sender, EventArgs e)
        {
            SilenceWindowsFormsApplication.SilenceForm silence = new SilenceWindowsFormsApplication.SilenceForm();
            silence.Show();
        }

        private void natterButton_Click(object sender, EventArgs e)
        {
            NatterCWindowsFormsApplication.NatterForm natter = new NatterCWindowsFormsApplication.NatterForm();
            natter.Show();
        }

    }
}
