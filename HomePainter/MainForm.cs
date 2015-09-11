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
        int lineWidth;
        int xStartPoint, yStartPoint, xEndPoint, yEndPoint = 0;

        Pen drawingPen;
        Brush drawigBrush;

        Graphics g;

        GraphicTool selectedTool;

        Thread backgroundWorker;

        public MainForm()
        {
            InitializeComponent();
            
            snapshotDrawArea = new Bitmap(panelDrawArea.ClientRectangle.Width, panelDrawArea.ClientRectangle.Height);   // Создание слоя для рисования
            
            g = Graphics.FromImage(snapshotDrawArea);   //заполнение слоя белым цветом
            g.FillRectangle(Brushes.White, 0, 0, panelDrawArea.ClientRectangle.Width, panelDrawArea.ClientRectangle.Height);
            g.Dispose();

            lineWidth = 5;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            selectedTool = GraphicTool.Dot;

            brushSizeToolStripComboBox.SelectedIndex = 4; //Подход не самый лучший, но без ТЗ... :-)
            lineWidth = 4;

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

            brushColorToolStripComboBox.SelectedIndex = 8; //значение Black
            fillColorToolStripComboBox.SelectedIndex = 0;  //значение Transparent


            //присваиваем дефолтные цвета кисти и заливки
            brushColor = Color.FromName(brushColorToolStripComboBox.Text);
            fillColor = Color.FromName(fillColorToolStripComboBox.Text);

            //При старте программы изначально выбран Pencil, поэтому настройку заливки отключаем
            fillColorToolStripComboBox.Enabled = false;
            fillColorToolStripTextBox.Enabled = false;
        }

        private void panelDrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            drawingProcess = true;
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
                    snapshotDrawArea = tempDrawingArea;
            }

            drawingProcess = false;
        }
        

        private void panelDrawArea_Paint(object sender, PaintEventArgs e)
        {
            if(drawingProcess)
            {
                switch (selectedTool)
                {
                    case GraphicTool.Dot:
                        tempDrawingArea = (Bitmap)snapshotDrawArea.Clone();
                        g = Graphics.FromImage(tempDrawingArea);
                        drawigBrush = new SolidBrush(brushColor);
                        g.FillRectangle(drawigBrush, xStartPoint, yStartPoint, lineWidth, lineWidth);
                        drawigBrush.Dispose();
                        e.Graphics.DrawImageUnscaled(tempDrawingArea, 0, 0);
                        g.Dispose();
                        xStartPoint = xEndPoint;
                        yStartPoint = yEndPoint;
                        snapshotDrawArea = (Bitmap)tempDrawingArea.Clone();
                        break;

                    case GraphicTool.Pencil:

                        tempDrawingArea = (Bitmap)snapshotDrawArea.Clone();
                        g = Graphics.FromImage(tempDrawingArea);
                        drawingPen = new Pen(brushColor, lineWidth);
                        g.DrawLine(drawingPen, xStartPoint, yStartPoint, xEndPoint, yEndPoint);
                        drawingPen.Dispose();
                        e.Graphics.DrawImageUnscaled(tempDrawingArea, 0, 0);
                        g.Dispose();
                        xStartPoint = xEndPoint;
                        yStartPoint = yEndPoint;
                        snapshotDrawArea = (Bitmap)tempDrawingArea.Clone();
                        break;

                    case GraphicTool.Line:
                            tempDrawingArea = (Bitmap)snapshotDrawArea.Clone();
                            g = Graphics.FromImage(tempDrawingArea);
                            drawingPen = new Pen(brushColor, lineWidth);
                            g.DrawLine(drawingPen, xStartPoint, yStartPoint, xEndPoint, yEndPoint);
                            drawingPen.Dispose();
                            e.Graphics.DrawImageUnscaled(tempDrawingArea, 0, 0);
                            g.Dispose();

                        break;

                    case GraphicTool.Rectangle:

                            tempDrawingArea = (Bitmap)snapshotDrawArea.Clone();
                            g = Graphics.FromImage(tempDrawingArea);
                            drawingPen = new Pen(brushColor, lineWidth);
                            drawigBrush = new SolidBrush(fillColor);

                            //Реализация универсального рисования прямоугольника.
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
                        
                            drawingPen.Dispose();
                            drawigBrush.Dispose();
                            g.Dispose();
                        
                        break;

                    case GraphicTool.Ellipse:
                            tempDrawingArea = (Bitmap)snapshotDrawArea.Clone();
                            g = Graphics.FromImage(tempDrawingArea);
                            drawingPen = new Pen(brushColor, lineWidth);
                            g.DrawEllipse(drawingPen, new Rectangle(xStartPoint, yStartPoint, xEndPoint - xStartPoint, yEndPoint - yStartPoint));
                            drawigBrush = new SolidBrush(fillColor);
                            g.FillEllipse(drawigBrush, new Rectangle(xStartPoint, yStartPoint, xEndPoint - xStartPoint, yEndPoint - yStartPoint)); //(myPen, xStartPoint, yStartPoint, xEndPoint - xStartPoint, yEndPoint - yStartPoint);
                            drawingPen.Dispose();
                            drawigBrush.Dispose();
                            e.Graphics.DrawImageUnscaled(tempDrawingArea, 0, 0);
                            g.Dispose();
                        break;

                    default:
                        break;
                }
            }

        }



        #region Customize drawing tools and standard function  ----------------- Можно не смотреть 
        private void newToolStripButton_Click(object sender, EventArgs e)   //создание нового документа
        {
            snapshotDrawArea = new Bitmap(panelDrawArea.ClientRectangle.Width, panelDrawArea.ClientRectangle.Height);

            g = Graphics.FromImage(snapshotDrawArea);
            g.FillRectangle(Brushes.White, 0, 0, panelDrawArea.ClientRectangle.Width, panelDrawArea.ClientRectangle.Height);
            g.Dispose();

            tempDrawingArea = null;
            panelDrawArea.Refresh();
        }

        private void brushSizeToolStripComboBox_TextChanged(object sender, EventArgs e) //изменение размера кисти
        {
            try
            {
                lineWidth = Convert.ToInt32(brushSizeToolStripComboBox.Text.Trim());
                brushSizeToolStripComboBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                brushSizeToolStripComboBox.BackColor = Color.Red;
                MessageBox.Show("Проверьте правильность ввода."); //Подобный вид уведомлений уже устарел. Использовал, как пример.
            }
            
        }

        private void brushColorToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            brushColor = Color.FromName(brushColorToolStripComboBox.Text);
        }   //цвет кисти

        private void fillColorToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillColor = Color.FromName(fillColorToolStripComboBox.Text);
        }   //цвет залики

        private void exitToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }   //закрытие программы

        private void openToolStripButton_Click(object sender, EventArgs e)
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
        }   //открытие изображения

        private void saveToolStripButton_Click(object sender, EventArgs e)
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
            
        }   //сохранение изображения

        #endregion

        #region Filter background execution

        Invert invertFilter;    //объявление класса фильтра
        private void toolStripButton1_Click(object sender, EventArgs e)     //применение фильтра
        {
            //указание параметров ProgressBar
            filterToolStripProgressBar.Minimum = 0;
            filterToolStripProgressBar.Maximum = panelDrawArea.ClientRectangle.Width;

            
            filterToolStripProgressBar.Value = 0;   //сброс значения ProgressBar
            invertToolStripButton.Enabled = false;  //блокировка кнопки фильтра

            //запуск фильтра
            invertFilter = new Invert();
            invertFilter.OperationComplet += InverFilter_OperationComplet;
            invertFilter.OperationStatus += ProgressBarIncrement;

            invertFilter.Image = snapshotDrawArea;

            backgroundWorker = new Thread(new ThreadStart(invertFilter.Run));
            backgroundWorker.Start();
            
        }

        private delegate void ButtonEnableCallback();       //делегат необходимый для управления активностью кнопки фильтра
        private void InverFilter_OperationComplet()         //метод отображающий инвертированное изображение
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

        private delegate void IncrementProgressBarCallback();   //делегат для отображения прогресса применения фильтра
        private void ProgressBarIncrement()
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
        }               //метод отображения состояния процесса наложения

        #endregion
                
        #region Selecting drawing tool ----------------- Можно не смотреть
        private void tsbLine_Click(object sender, EventArgs e)      //Кнопка рисования линии
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
