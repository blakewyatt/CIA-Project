using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace CIA_Project_Decoder
{
    class Decoder
    {
        //Declaring Global variables
        private string fileType = "";
        private List<string> fileComments = new List<string>();
        private int picWidth = 0;
        private int picHeight = 0;

        public Bitmap ConvertImageFromPPM(string filePath)
        {
            //Declaring variables and Getting header info
            fileComments.Clear();
            StreamReader inFile = new StreamReader(filePath);
            fileType = inFile.ReadLine();
            bool isComment = false;

            do
            {
                string temp = "";
                temp = inFile.ReadLine();
                if (temp.Contains("#"))
                {
                    fileComments.Add(temp);
                    isComment = true;
                }
                else
                {
                    string[] tempLW = temp.Split(' ');
                    picWidth = int.Parse(tempLW[0]);
                    picHeight = int.Parse(tempLW[1]);
                    isComment = false;
                }

            } while (isComment == true);
            inFile.ReadLine();

            Bitmap bmp = new Bitmap(picWidth, picHeight);

            //Loads P3
            if (fileType == "P3")
            {
                //Loop through file and store rgb to a Color then to Bitmap
                for (int y = 0; y < picHeight; y++)
                {
                    for (int x = 0; x < picWidth; x++)
                    {
                        int red = int.Parse(inFile.ReadLine());
                        int green = int.Parse(inFile.ReadLine());
                        int blue = int.Parse(inFile.ReadLine());
                        Color clrCurrent = new Color();
                        clrCurrent = Color.FromArgb(red, green, blue);

                        bmp.SetPixel(x, y, clrCurrent);
                    }

                }
            }
            //Loads P6
            else
            {
                inFile.Close();

                FileStream fileStream = new FileStream(filePath, FileMode.Open);
                char curByte = ' ';

                //Eats through header
                for (int index = 0; index < 3 + fileComments.Count; index++)
                {
                    curByte = (char)fileStream.ReadByte();

                    while (curByte != '\n')
                    {
                        curByte = (char)fileStream.ReadByte();
                    }
                }

                //Loop through file and store rgb to a Color then to Bitmap
                for (int y = 0; y < picHeight; y++)
                {
                    for (int x = 0; x < picWidth; x++)
                    {
                        int red = fileStream.ReadByte();
                        int green = fileStream.ReadByte();
                        int blue = fileStream.ReadByte();

                        Color clrCurrent = new Color();
                        clrCurrent = Color.FromArgb(red, green, blue);

                        bmp.SetPixel(x, y, clrCurrent);

                    }
                }

                fileStream.Close();

            }

            inFile.Close();
            return bmp;
        }

        public string DecodeImage(Bitmap bmp)
        {
            string message = "";

            //Loop through image 
            for (int y = 0; y < picHeight; y++)
            {
                for (int x = 0; x < picWidth; x++)
                {
                    Color clrCurrent = bmp.GetPixel(x, y);

                    //checking for encoded red values and adding them to message
                    if (clrCurrent.R == 32)
                    {
                        message += (char)clrCurrent.R;
                    }
                    else if (clrCurrent.R >= 48 && clrCurrent.R <= 57)
                    {
                        message += (char)clrCurrent.R;
                    }
                    else if (clrCurrent.R >= 65 && clrCurrent.R <= 90)
                    {
                        message += (char)clrCurrent.R;
                    }

                }
            }
            return message;
        }

    }
}
