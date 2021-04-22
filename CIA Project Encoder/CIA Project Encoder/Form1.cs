using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CIA_Project_Encoder
{
    public partial class Form1 : Form
    {
        //Declaring class instance
        Encoder encoder = new Encoder();

        public Form1()
        {
            InitializeComponent();
            lblSave.Visible = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dgrTemp = fileBrowse.ShowDialog();

            //After file is opened convert to Bitmap
            if (dgrTemp == DialogResult.OK)
            {
                lblSave.Visible = false;
                picBoxEnd.Image = null;
                txtBoxMessage.Text = "";
                picBoxStart.Image = encoder.ConvertImageFromPPM(fileBrowse.FileName);
            }
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            //Makes sure a pic has been loaded
            if(picBoxStart.Image != null)
            {
                //Makes sure the message is not empty
                if(txtBoxMessage.Text == "")
                {
                    MessageBox.Show("Message is empty.", "Message Length Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Bitmap bmp = new Bitmap(picBoxStart.Image);
                    string message = "";

                    //Sets up Image
                    bmp = encoder.SetupImage(bmp);

                    //Ensures the message isn't larger than the image
                    if (txtBoxMessage.Text.Length > (bmp.Width) * (bmp.Height))
                    {
                        MessageBox.Show("Message is larger than image.", "Message Length Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        message = txtBoxMessage.Text.ToUpper();

                        //Encodes msg
                        Bitmap endImage = encoder.EncodeImage(bmp, message);

                        //Sets picBox with encoded message
                        picBoxEnd.Image = endImage;
                    }
                }
              
            }
            else
            {
                MessageBox.Show("File has not been loaded.", "Encode Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //If the file has been encoded
            if (picBoxEnd.Image != null)
            {
                //if the file is ok to be saved
                if (fileSave.ShowDialog() == DialogResult.OK)
                {
                    //Convert to ppm and save
                    Bitmap endPic = new Bitmap(picBoxEnd.Image);
                    encoder.ConvertImageToPPM(fileSave.FileName, endPic);
                    lblSave.Visible = true;
                }

            }
            else
            {
                //Popup Error message for file has not been encoded
                MessageBox.Show("File has not been encoded.", "File Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBoxMessage_TextChanged(object sender, EventArgs e)
        {
            int count = txtBoxMessage.Text.Length;

            //Updates the character count for the text box
            if(((picBoxStart.Image.Width) * (picBoxStart.Image.Height)) < 256)
            {
                lblCharCount.Text = count + "/" + ((picBoxStart.Image.Width) * (picBoxStart.Image.Height));
                txtBoxMessage.MaxLength = ((picBoxStart.Image.Width) * (picBoxStart.Image.Height));
            }
            else
            {
                lblCharCount.Text = count + "/256";
            }
        }
    }
}
