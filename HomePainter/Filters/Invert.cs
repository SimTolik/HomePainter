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
        public void Run()
        {
            int x, y;   //image axis

            for (x = 0; x <= Image.Width - 1; x++)      //processing width
            {
                Thread.Sleep(1);    

                OperationStatus();

                for (y = 0; y <= Image.Height - 1; y += 1)      //processing height
                {
                    Color oldColor = Image.GetPixel(x, y);      //the Old Color to replace  
                    
                    Color newColor;                             //the New Color to replace the Old Color
                    
                    newColor = Color.FromArgb(oldColor.A, 255 - oldColor.R, 255 - oldColor.G, 255 - oldColor.B);    //set the Color for newColor
                    
                    Image.SetPixel(x, y, newColor);             //replace the Old Color with the New Color
                }
            }

            OperationComplet();
        }
    }
}
