using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //exit menu button is hit
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a simple web browser in C#");
        }

        //On click event, rich text box will display the url given
        private void navigateButtn_Click(object sender, EventArgs e)
        {
            NavigateToPage();
        }

        //Core navigation method
        private void NavigateToPage()
        {
            navigateButtn.Enabled = false;
            textBox1.Enabled = false;
            toolStripStatusLabel1.Text = "Navigation in progress!";
            webBrowser1.Navigate(textBox1.Text);
        }

        //event fires everytime key is pressed on the search text box
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //need to check if the key pressed is actually enter key
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                //navigateButtn_Click(null, null); does the same thing since it will simulate the button click functionality
                NavigateToPage();
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            navigateButtn.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Navigation complete!";
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0)
            {
                toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
        }

        private void refreshButtn_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void stopBttn_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void homeBttn_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }
    }
}
