using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace CIA_Project_Encoder
{
    class Encoder
    {
        //Declaring Variables
        private List<string> fileComments = new List<string>();
        private string filePixelMax = "";
        private string fileType = "";
        private int picWidth = 0;
        private int picHeight = 0;

        public Bitmap SetupImage(Bitmap readyImage)
        {
            //Loops through image
            for (int y = 0; y < picHeight; y++)
            {
                for (int x = 0; x < picWidth; x++)
                {
                    Color colorChange = new Color();

                    colorChange = readyImage.GetPixel(x, y);

                    //Checks pixel's R value and change value if it is used by
                    //encoding method
                    if (colorChange.R == 32)
                    {
                        colorChange = Color.FromArgb(31, colorChange.G, colorChange.B);
                        readyImage.SetPixel(x, y, colorChange);
                    }
                    else if (colorChange.R >= 48 && colorChange.R <= 57)
                    {
                        colorChange = Color.FromArgb(47, colorChange.G, colorChange.B);
                        readyImage.SetPixel(x, y, colorChange);
                    }
                    else if (colorChange.R >= 65 && colorChange.R <= 79)
                    {
                        colorChange = Color.FromArgb(64, colorChange.G, colorChange.B);
                        readyImage.SetPixel(x, y, colorChange);
                    }
                    else if (colorChange.R >= 80 && colorChange.R <= 90)
                    {
                        colorChange = Color.FromArgb(91, colorChange.G, colorChange.B);
                        readyImage.SetPixel(x, y, colorChange);
                    }
                }
            }

            //return the prepared image
            return readyImage;
        }

        public Bitmap EncodeImage(Bitmap bmp, string message)
        {
            //initializing at 1
            int messageStartX = 0;
            int messageStartY = 0;

            //Checks to see if the length is smaller than half of the picture
            if (message.Length < (picHeight - 1) * (picWidth / 2))
            {
                //Starts in the middle of the picture
                messageStartY = picWidth / 2;
            }

            //loop through message and change red values in picture
            for (int index = 0; index < message.Length; index++)
            {
                //makes sure the message isnt going off the pic boundaries
                if (messageStartX == bmp.Width)
                {
                    messageStartY += 1;
                    messageStartX = 0;
                }

                //Gets the pixel at the current location
                Color clrCurrent = new Color();
                clrCurrent = bmp.GetPixel(messageStartX, messageStartY);

                //Encodes character
                int currentRed = message[index];
                clrCurrent = Color.FromArgb(currentRed, clrCurrent.G, clrCurrent.B);

                //Sets the pixel back with encoded character
                bmp.SetPixel(messageStartX, messageStartY, clrCurrent);
                messageStartX++;
            }

            //return encoded image
            return bmp;

        }

        public Bitmap ConvertImageFromPPM(string filePath)
        {
            fileComments.Clear();
            //Declaring variables and saving header
            StreamReader inFile = new StreamReader(filePath);
            fileType = inFile.ReadLine();
            bool isComment = false;

            //loop for multiple comment lines
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
                    //getting length and width
                    string[] tempLW = temp.Split(' ');
                    picWidth = int.Parse(tempLW[0]);
                    picHeight = int.Parse(tempLW[1]);
                    isComment = false;
                }

            } while (isComment == true);

            filePixelMax = inFile.ReadLine();

            Bitmap bmp = new Bitmap(picWidth, picHeight);

            //Converts P3 PPM to Bitmap
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

            //Converts P6 PPM into Bitmap
            else
            {
                //closes StreamReader to open FileStream
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

            //Return the image
            return bmp;
        }

        public void ConvertImageToPPM(string filePath, Bitmap endPic)
        {
            StreamWriter outFile = new StreamWriter(filePath);

            //Writing Header to file
            outFile.WriteLine(fileType);
            for(int index = 0; index < fileComments.Count; index++)
            {
                outFile.WriteLine(fileComments[index]);
            }
            outFile.WriteLine(picWidth.ToString() + " " + picHeight.ToString());
            outFile.WriteLine(filePixelMax);

            //Converts to P3
            if (fileType == "P3")
            {
                //Loops through image getting rgb and writing it to file
                for (int y = 0; y < picHeight; y++)
                {
                    for (int x = 0; x < picWidth; x++)
                    {
                        Color current = new Color();
                        current = endPic.GetPixel(x, y);

                        outFile.WriteLine(current.R.ToString());
                        outFile.WriteLine(current.G.ToString());

                        //Makes sure not to add an extra line at the end of the file
                        if (x == picWidth - 1 && y == picHeight - 1)
                        {
                            outFile.Write(current.B.ToString());
                        }
                        else
                        {
                            outFile.WriteLine(current.B.ToString());
                        }

                    }
                }
            }
            //Converts to P6
            else
            {
                //Closes StreamWriter to open in FileStream
                outFile.Close();
                FileStream fileStream = new FileStream(filePath, FileMode.Append);

                //Loops through image getting rgb and writing to file
                for (int y = 0; y < picHeight; y++)
                {
                    for (int x = 0; x < picWidth; x++)
                    {
                        Color current = new Color();
                        current = endPic.GetPixel(x, y);

                        fileStream.WriteByte(current.R);
                        fileStream.WriteByte(current.G);

                        //Makes sure not to add an extra line at the end of the file
                        if (x == picWidth - 1 && y == picHeight - 1)
                        {
                            fileStream.WriteByte(current.B);
                        }
                        else
                        {
                            fileStream.WriteByte(current.B);
                        }

                    }
                }

                fileStream.Close();
            }


            outFile.Close();
        }
    }
}
