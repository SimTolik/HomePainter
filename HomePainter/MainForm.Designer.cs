namespace HomePainter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dotToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pencilToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.lineToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rectangleToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ellipseToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.invertToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.filterToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.panelDrawArea = new HomePainter.DoubleBufferedPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.brushSizeToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.brushSizeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.brushColorToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.brushColorToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.fillColorToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillColorToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panelDrawArea.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.dotToolStripButton,
            this.pencilToolStripButton,
            this.lineToolStripButton,
            this.rectangleToolStripButton,
            this.ellipseToolStripButton,
            this.toolStripSeparator2,
            this.invertToolStripButton,
            this.toolStripSeparator5,
            this.exitToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1030, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // dotToolStripButton
            // 
            this.dotToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dotToolStripButton.Image = global::HomePainter.Properties.Resources.Dot;
            this.dotToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dotToolStripButton.Name = "dotToolStripButton";
            this.dotToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.dotToolStripButton.Text = "Dot";
            this.dotToolStripButton.Click += new System.EventHandler(this.dotToolStripButton_Click);
            // 
            // pencilToolStripButton
            // 
            this.pencilToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pencilToolStripButton.Image = global::HomePainter.Properties.Resources.Pencil;
            this.pencilToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pencilToolStripButton.Name = "pencilToolStripButton";
            this.pencilToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pencilToolStripButton.Text = "Pencil";
            this.pencilToolStripButton.Click += new System.EventHandler(this.tsbPencil_Click);
            // 
            // lineToolStripButton
            // 
            this.lineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineToolStripButton.Image = global::HomePainter.Properties.Resources.Line;
            this.lineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineToolStripButton.Name = "lineToolStripButton";
            this.lineToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.lineToolStripButton.Text = "Line";
            this.lineToolStripButton.Click += new System.EventHandler(this.tsbLine_Click);
            // 
            // rectangleToolStripButton
            // 
            this.rectangleToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rectangleToolStripButton.Image = global::HomePainter.Properties.Resources.Rectange;
            this.rectangleToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangleToolStripButton.Name = "rectangleToolStripButton";
            this.rectangleToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.rectangleToolStripButton.Text = "Rectangle";
            this.rectangleToolStripButton.Click += new System.EventHandler(this.tsbRect_Click);
            // 
            // ellipseToolStripButton
            // 
            this.ellipseToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ellipseToolStripButton.Image = global::HomePainter.Properties.Resources.Ellipse;
            this.ellipseToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ellipseToolStripButton.Name = "ellipseToolStripButton";
            this.ellipseToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ellipseToolStripButton.Text = "Ellipse";
            this.ellipseToolStripButton.Click += new System.EventHandler(this.tsbEllipse_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // invertToolStripButton
            // 
            this.invertToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.invertToolStripButton.Image = global::HomePainter.Properties.Resources.Invert;
            this.invertToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.invertToolStripButton.Name = "invertToolStripButton";
            this.invertToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.invertToolStripButton.Text = "toolStripButton1";
            this.invertToolStripButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // exitToolStripButton
            // 
            this.exitToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitToolStripButton.Image = global::HomePainter.Properties.Resources.Exit;
            this.exitToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitToolStripButton.Name = "exitToolStripButton";
            this.exitToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.exitToolStripButton.Text = "toolStripButton1";
            this.exitToolStripButton.Click += new System.EventHandler(this.exitToolStripButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterToolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 524);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1030, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // filterToolStripProgressBar
            // 
            this.filterToolStripProgressBar.Name = "filterToolStripProgressBar";
            this.filterToolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // panelDrawArea
            // 
            this.panelDrawArea.BackColor = System.Drawing.Color.White;
            this.panelDrawArea.Controls.Add(this.toolStrip1);
            this.panelDrawArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDrawArea.Location = new System.Drawing.Point(0, 25);
            this.panelDrawArea.Name = "panelDrawArea";
            this.panelDrawArea.Size = new System.Drawing.Size(1030, 499);
            this.panelDrawArea.TabIndex = 3;
            this.panelDrawArea.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDrawArea_Paint);
            this.panelDrawArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelDrawArea_MouseDown);
            this.panelDrawArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelDrawArea_MouseMove);
            this.panelDrawArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelDrawArea_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brushSizeToolStripTextBox,
            this.brushSizeToolStripComboBox,
            this.toolStripSeparator3,
            this.brushColorToolStripTextBox,
            this.brushColorToolStripComboBox,
            this.toolStripSeparator4,
            this.fillColorToolStripTextBox,
            this.fillColorToolStripComboBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1030, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // brushSizeToolStripTextBox
            // 
            this.brushSizeToolStripTextBox.Name = "brushSizeToolStripTextBox";
            this.brushSizeToolStripTextBox.Size = new System.Drawing.Size(60, 25);
            this.brushSizeToolStripTextBox.Text = "Brush size:";
            // 
            // brushSizeToolStripComboBox
            // 
            this.brushSizeToolStripComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.brushSizeToolStripComboBox.Name = "brushSizeToolStripComboBox";
            this.brushSizeToolStripComboBox.Size = new System.Drawing.Size(75, 25);
            this.brushSizeToolStripComboBox.TextChanged += new System.EventHandler(this.brushSizeToolStripComboBox_TextChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // brushColorToolStripTextBox
            // 
            this.brushColorToolStripTextBox.Name = "brushColorToolStripTextBox";
            this.brushColorToolStripTextBox.Size = new System.Drawing.Size(70, 25);
            this.brushColorToolStripTextBox.Text = "Brush color:";
            // 
            // brushColorToolStripComboBox
            // 
            this.brushColorToolStripComboBox.Name = "brushColorToolStripComboBox";
            this.brushColorToolStripComboBox.Size = new System.Drawing.Size(120, 25);
            this.brushColorToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.brushColorToolStripComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // fillColorToolStripTextBox
            // 
            this.fillColorToolStripTextBox.Name = "fillColorToolStripTextBox";
            this.fillColorToolStripTextBox.Size = new System.Drawing.Size(60, 25);
            this.fillColorToolStripTextBox.Text = "Fill color:";
            // 
            // fillColorToolStripComboBox
            // 
            this.fillColorToolStripComboBox.Name = "fillColorToolStripComboBox";
            this.fillColorToolStripComboBox.Size = new System.Drawing.Size(120, 25);
            this.fillColorToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.fillColorToolStripComboBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 546);
            this.Controls.Add(this.panelDrawArea);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Name = "MainForm";
            this.Text = "Home Paint";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelDrawArea.ResumeLayout(false);
            this.panelDrawArea.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar filterToolStripProgressBar;
        private System.Windows.Forms.ToolStripButton lineToolStripButton;
        private System.Windows.Forms.ToolStripButton rectangleToolStripButton;
        private System.Windows.Forms.ToolStripButton pencilToolStripButton;
        private System.Windows.Forms.ToolStripButton ellipseToolStripButton;
        private DoubleBufferedPanel panelDrawArea;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton exitToolStripButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox brushSizeToolStripTextBox;
        private System.Windows.Forms.ToolStripComboBox brushSizeToolStripComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox brushColorToolStripTextBox;
        private System.Windows.Forms.ToolStripComboBox brushColorToolStripComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox fillColorToolStripTextBox;
        private System.Windows.Forms.ToolStripComboBox fillColorToolStripComboBox;
        private System.Windows.Forms.ToolStripButton invertToolStripButton;
        private System.Windows.Forms.ToolStripButton dotToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}

