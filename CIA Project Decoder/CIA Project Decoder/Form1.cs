using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CIA_Project_Decoder
{
    public partial class Form1 : Form
    {
        //Declaring class instance
        Decoder decoder = new Decoder();

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dgrTemp = fileBrowse.ShowDialog();

            //Open File, Convert Bitmap, and store to picBox
            if (dgrTemp == DialogResult.OK)
            {
                txtBoxMessage.Text = "";
                picBoxStart.Image = decoder.ConvertImageFromPPM(fileBrowse.FileName);
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            if(picBoxStart.Image != null)
            {
                Bitmap bmp = new Bitmap(picBoxStart.Image);
                txtBoxMessage.Text = decoder.DecodeImage(bmp);
            }
            else
            {
                //Popup Error message for file has not been loaded
                MessageBox.Show("File has not been loaded.", "File Decode Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
