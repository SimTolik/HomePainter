using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace HomePainter.Filters
{
    public sealed class Invert
    {
        public delegate void worker();
        public delegate void workerStatus();

        public event worker OperationComplet;
        public event workerStatus OperationStatus;
        public Bitmap Image { get; set; }
        public int Percentage { get; set; }
        public void Run()
        {
            //X Axis
            int x;
            //Y Axis
            int y;
            //For the Width
            for (x = 0; x <= Image.Width - 1; x++)
            {
                Thread.Sleep(1);
                //Percentage = x / ((Image.Width - 1) / 100) ;
                //Percentage = x;
                OperationStatus();
                //For the Height
                for (y = 0; y <= Image.Height - 1; y += 1)
                {
                    //The Old Color to Replace
                    Color oldColor = Image.GetPixel(x, y);
                    //The New Color to Replace the Old Color
                    Color newColor;
                    //Set the Color for newColor
                    newColor = Color.FromArgb(oldColor.A, 255 - oldColor.R, 255 - oldColor.G, 255 - oldColor.B);
                    //Replace the Old Color with the New Color
                    Image.SetPixel(x, y, newColor);
                }
            }

            OperationComplet();
            

            //return snapshotDrawArea;
            //Return the Inverted Bitmap
            //return bitmap;
        }
    }
}
