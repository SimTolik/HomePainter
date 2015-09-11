using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HomePainter.Abstract;
using HomePainter.Filters;

namespace HomePainter
{
    public partial class MainForm : Form
    {
        bool drawingProcess = false;

        Bitmap snapshotDrawArea, tempDrawingArea;  //слои рисования
        Color brushColor, fillColor;
        
        int xStartPoint, yStartPoint, xEndPoint, yEndPoint = 0;

        int lineWidth;
        private const int DEFAULT_LINE_WIDTH = 3;

        Pen drawingPen;
        Brush drawigBrush;

        Graphics g;

        GraphicTool selectedTool;

        Thread backgroundWorker;

        public MainForm()
        {
            InitializeComponent();
            
            snapshotDrawArea = new Bitmap(panelDrawArea.ClientRectangle.Width, panelDrawArea.ClientRectangle.Height);   //Creating layer for drawing
            
            g = Graphics.FromImage(snapshotDrawArea);                                        //fill layer with white color for normal saving process
            g.FillRectangle(Brushes.White, 0, 0, panelDrawArea.ClientRectangle.Width, panelDrawArea.ClientRectangle.Height);
            g.Dispose();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            selectedTool = GraphicTool.Pencil;

            brushSizeToolStripComboBox.SelectedIndex = 3;
            
            lineWidth = DEFAULT_LINE_WIDTH;

            //заполняем комбобоксы цветов
            string[] colorNames = Enum.GetNames(typeof(KnownColor));

            for (int i = 0; i < colorNames.Length; i++)
            {
                if (!Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), colorNames[i])).IsSystemColor)
                {
                    //цвета с понятными названиями
                    brushColorToolStripComboBox.Items.Add(colorNames[i]);
                    fillColorToolStripComboBox.Items.Add(colorNames[i]);
                }
                else
                {
                    // сюда попадут системные цвета с "непривычными" названиями. Для их отображения понадобиться переоформить способ отображения элементов.
                    // Секция показана для примера (лишние шаги).
                }
            }

            brushColorToolStripComboBox.SelectedIndex = 8; //value Black
            fillColorToolStripComboBox.SelectedIndex = 0;  //value Transparent

            //присваиваем дефолтные цвета кисти и заливки
            brushColor = Color.FromName(brushColorToolStripComboBox.Text);
            fillColor = Color.FromName(fillColorToolStripComboBox.Text);

            //При старте программы изначально выбран Pencil, поэтому настройку заливки отключаем
            fillColorToolStripComboBox.Enabled = false;
            fillColorToolStripTextBox.Enabled = false;
        }

        private void panelDrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            drawingProcess = true;          //establish the beginning of drawing

            xStartPoint = e.X;
            yStartPoint = e.Y;
        }
        private void panelDrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingProcess)
            {
                xEndPoint = e.X;
                yEndPoint = e.Y;

                panelDrawArea.Invalidate();         
                panelDrawArea.Update();
            }
        }
        private void panelDrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawingProcess)
            {
                snapshotDrawArea = tempDrawingArea;         //all drawing process takes place on a temporary layer therefore at the end of drawing it is necessary to transfer it to the main layer
            }

            drawingProcess = false;         //establish the end of drawing
        }
        

        private void panelDrawArea_Paint(object sender, PaintEventArgs e)
        {
            if(drawingProcess)
            {
                tempDrawingArea = (Bitmap)snapshotDrawArea.Clone();

                g = Graphics.FromImage(tempDrawingArea);

                drawingPen = new Pen(brushColor, lineWidth);
                drawigBrush = new SolidBrush(fillColor);

                switch (selectedTool)
                {
                    case GraphicTool.Dot:

                        drawigBrush = new SolidBrush(brushColor);

                        g.FillRectangle(drawigBrush, xStartPoint, yStartPoint, lineWidth, lineWidth);

                        e.Graphics.DrawImageUnscaled(tempDrawingArea, 0, 0);

                        xStartPoint = xEndPoint;
                        yStartPoint = yEndPoint;

                        snapshotDrawArea = (Bitmap)tempDrawingArea.Clone();

                        break;

                    case GraphicTool.Pencil:

                        g.DrawLine(drawingPen, xStartPoint, yStartPoint, xEndPoint, yEndPoint);

                        e.Graphics.DrawImageUnscaled(tempDrawingArea, 0, 0);

                        xStartPoint = xEndPoint;
                        yStartPoint = yEndPoint;

                        snapshotDrawArea = (Bitmap)tempDrawingArea.Clone();

                        break;

                    case GraphicTool.Line:

                        g.DrawLine(drawingPen, xStartPoint, yStartPoint, xEndPoint, yEndPoint);

                        e.Graphics.DrawImageUnscaled(tempDrawingArea, 0, 0);

                        break;

                    case GraphicTool.Rectangle:

                        //Realization of universal drawing of a rectangle. FillRectangle and DrawRectangle are doesn't understand negative values of the size.
                        if (xStartPoint < xEndPoint && yStartPoint < yEndPoint)
                            {

                                g.FillRectangle(drawigBrush, new Rectangle(xStartPoint, yStartPoint, xEndPoint - xStartPoint, yEndPoint - yStartPoint));
                                g.DrawRectangle(drawingPen, new Rectangle(xStartPoint, yStartPoint, xEndPoint - xStartPoint, yEndPoint - yStartPoint));
                            }
                            else if (xStartPoint > xEndPoint && yStartPoint < yEndPoint)
                            {
                                g.FillRectangle(drawigBrush, new Rectangle(xStartPoint + (xEndPoint - xStartPoint), yStartPoint, Math.Abs(xEndPoint - xStartPoint), Math.Abs(yEndPoint - yStartPoint)));
                                g.DrawRectangle(drawingPen, new Rectangle(xStartPoint + (xEndPoint - xStartPoint), yStartPoint, Math.Abs(xEndPoint - xStartPoint), Math.Abs(yEndPoint - yStartPoint)));
                            }
                            else if (xStartPoint < xEndPoint && yStartPoint > yEndPoint)
                            {
                                g.FillRectangle(drawigBrush, new Rectangle(xStartPoint, yStartPoint + (yEndPoint - yStartPoint), Math.Abs(xEndPoint - xStartPoint), Math.Abs(yEndPoint - yStartPoint)));
                                g.DrawRectangle(drawingPen, new Rectangle(xStartPoint, yStartPoint + (yEndPoint - yStartPoint), Math.Abs(xEndPoint - xStartPoint), Math.Abs(yEndPoint - yStartPoint)));
                            }
                            else
                            {
                                g.FillRectangle(drawigBrush, new Rectangle(xEndPoint, yEndPoint, Math.Abs(xEndPoint - xStartPoint), Math.Abs(yEndPoint - yStartPoint)));
                                g.DrawRectangle(drawingPen, new Rectangle(xEndPoint, yEndPoint, Math.Abs(xEndPoint - xStartPoint), Math.Abs(yEndPoint - yStartPoint)));

                            }

                            
                            e.Graphics.DrawImageUnscaled(tempDrawingArea, 0, 0);
                        
                        break;

                    case GraphicTool.Ellipse:

                            g.DrawEllipse(drawingPen, new Rectangle(xStartPoint, yStartPoint, xEndPoint - xStartPoint, yEndPoint - yStartPoint));
                            
                            g.FillEllipse(drawigBrush, new Rectangle(xStartPoint, yStartPoint, xEndPoint - xStartPoint, yEndPoint - yStartPoint));
                            
                            e.Graphics.DrawImageUnscaled(tempDrawingArea, 0, 0);
                            
                        break;

                    default:
                        break;
                }

                drawingPen.Dispose();
                drawigBrush.Dispose();
                g.Dispose();
            }

        }


        #region Customize drawing tools and standard function
        private void newToolStripButton_Click(object sender, EventArgs e)                           //clear all drawing area
        {
            snapshotDrawArea = new Bitmap(panelDrawArea.ClientRectangle.Width, panelDrawArea.ClientRectangle.Height);

            g = Graphics.FromImage(snapshotDrawArea);
            g.FillRectangle(Brushes.White, 0, 0, panelDrawArea.ClientRectangle.Width, panelDrawArea.ClientRectangle.Height);
            g.Dispose();

            tempDrawingArea = null;

            panelDrawArea.Refresh();
        }

        private void brushSizeToolStripComboBox_TextChanged(object sender, EventArgs e)             //change brush size
        {
            try
            {
                lineWidth = Convert.ToInt32(brushSizeToolStripComboBox.Text.Trim());
                brushSizeToolStripComboBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                brushSizeToolStripComboBox.BackColor = Color.Red;
                MessageBox.Show("Проверьте правильность ввода.");                                   //Similar type of notices already obsolete. I used that, as an example.
            }
        }

        private void brushColorToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)   //change brush color
        {
            brushColor = Color.FromName(brushColorToolStripComboBox.Text);
        }   

        private void fillColorToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)    //change fill color
        {
            fillColor = Color.FromName(fillColorToolStripComboBox.Text);
        }

        private void exitToolStripButton_Click(object sender, EventArgs e)                          //close the program
        {
            this.Close();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)                          //open image
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Jpeg files|*.jpg|Bitmap files|*.bmp";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                snapshotDrawArea = (Bitmap)Image.FromFile(ofd.FileName).Clone();

                g = panelDrawArea.CreateGraphics();
                g.DrawImageUnscaled(snapshotDrawArea, 0, 0);
                g.Dispose();
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)                          //save image
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Jpeg files|*.jpg|Bitmap files|*.bmp";

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FileName.Contains(".jpg"))
                {
                    snapshotDrawArea.Save(sfd.FileName, ImageFormat.Jpeg);
                }
                else
                {
                    snapshotDrawArea.Save(sfd.FileName, ImageFormat.Bmp);
                }
            }
            
        }

        #endregion



        #region Filter background execution

        Invert invertFilter;                                                                        //filter class
        private void toolStripButton1_Click(object sender, EventArgs e)                             //filter use
        {
            //указание параметров ProgressBar
            filterToolStripProgressBar.Minimum = 0;
            filterToolStripProgressBar.Maximum = panelDrawArea.ClientRectangle.Width;

            
                filterToolStripProgressBar.Value = 0;                                               //reset ProgressBar value
                invertToolStripButton.Enabled = false;                                              //disable filter button

            //запуск фильтра
            invertFilter = new Invert();
            invertFilter.OperationComplet += InverFilter_OperationComplet;
            invertFilter.OperationStatus += ProgressBarIncrement;

            invertFilter.Image = snapshotDrawArea;

            backgroundWorker = new Thread(new ThreadStart(invertFilter.Run));
            backgroundWorker.Start();
            
        }

        private delegate void ButtonEnableCallback();                                               //delegate necessary for management of filte button status (Enable/Disable)
        private void InverFilter_OperationComplet()                                                 //method that display inverted image
        {
            if(toolStrip.InvokeRequired)
            {
                var i = new ButtonEnableCallback(InverFilter_OperationComplet);
                Invoke(i);
            }
            else
            {
                snapshotDrawArea = invertFilter.Image;

                g = panelDrawArea.CreateGraphics();
                g.DrawImageUnscaled(snapshotDrawArea, 0, 0);
                g.Dispose();

                invertToolStripButton.Enabled = true;
            }
        }

        private delegate void IncrementProgressBarCallback();                                       //delegate for display inverting progress
        private void ProgressBarIncrement()                                                         //method for display inverting progress
        {
            if (statusStrip.InvokeRequired)
            {
                var d = new IncrementProgressBarCallback(ProgressBarIncrement);
                Invoke(d);
            }
            else
            {
                filterToolStripProgressBar.Increment(1);
            }
        }               

        #endregion
                


        #region Selecting drawing tool
        private void tsbLine_Click(object sender, EventArgs e)
        {
            selectedTool = GraphicTool.Line;
            fillColorToolStripComboBox.Enabled = false;
            fillColorToolStripTextBox.Enabled = false;
        }
        private void tsbRect_Click(object sender, EventArgs e)
        {
            selectedTool = GraphicTool.Rectangle;
            fillColorToolStripComboBox.Enabled = true;
            fillColorToolStripTextBox.Enabled = true;
        }
        private void tsbPencil_Click(object sender, EventArgs e)
        {
            selectedTool = GraphicTool.Pencil;
            fillColorToolStripComboBox.Enabled = false;
            fillColorToolStripTextBox.Enabled = false;
        }
        private void tsbEllipse_Click(object sender, EventArgs e)
        {
            selectedTool = GraphicTool.Ellipse;
            fillColorToolStripComboBox.Enabled = true;
            fillColorToolStripTextBox.Enabled = true;
        }
        private void dotToolStripButton_Click(object sender, EventArgs e)
        {
            selectedTool = GraphicTool.Dot;
            fillColorToolStripComboBox.Enabled = false;
            fillColorToolStripTextBox.Enabled = false;
        }
        #endregion

        
    }
}
