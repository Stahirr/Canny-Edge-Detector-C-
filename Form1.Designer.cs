namespace Canny
{
    partial class Form1
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otworzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.zakończToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.efektyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negatywToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poszarzenieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtrGaussaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progowanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histerezaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oryginałToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prógDolny10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prógDolny10ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.prógGórny10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prógGórny10ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.efektyToolStripMenuItem,
            this.oryginałToolStripMenuItem,
            this.prógDolny10ToolStripMenuItem,
            this.prógDolny10ToolStripMenuItem1,
            this.prógGórny10ToolStripMenuItem,
            this.prógGórny10ToolStripMenuItem1});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(724, 30);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otworzToolStripMenuItem,
            this.zapiszToolStripMenuItem,
            this.toolStripSeparator1,
            this.zakończToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // otworzToolStripMenuItem
            // 
            this.otworzToolStripMenuItem.Name = "otworzToolStripMenuItem";
            this.otworzToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.otworzToolStripMenuItem.Text = "Otwórz";
            this.otworzToolStripMenuItem.Click += new System.EventHandler(this.otworzToolStripMenuItem_Click);
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Enabled = false;
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.zapiszToolStripMenuItem.Text = "Zapisz";
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // zakończToolStripMenuItem
            // 
            this.zakończToolStripMenuItem.Name = "zakończToolStripMenuItem";
            this.zakończToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.zakończToolStripMenuItem.Text = "Zakończ";
            this.zakończToolStripMenuItem.Click += new System.EventHandler(this.zakończToolStripMenuItem_Click);
            // 
            // efektyToolStripMenuItem
            // 
            this.efektyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.negatywToolStripMenuItem,
            this.poszarzenieToolStripMenuItem,
            this.filtrGaussaToolStripMenuItem,
            this.sobelToolStripMenuItem,
            this.gradientToolStripMenuItem,
            this.progowanieToolStripMenuItem,
            this.histerezaToolStripMenuItem});
            this.efektyToolStripMenuItem.Enabled = false;
            this.efektyToolStripMenuItem.Name = "efektyToolStripMenuItem";
            this.efektyToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.efektyToolStripMenuItem.Text = "Efekty";
            this.efektyToolStripMenuItem.Click += new System.EventHandler(this.efektyToolStripMenuItem_Click);
            // 
            // negatywToolStripMenuItem
            // 
            this.negatywToolStripMenuItem.Name = "negatywToolStripMenuItem";
            this.negatywToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.negatywToolStripMenuItem.Text = "Negatyw";
            this.negatywToolStripMenuItem.Click += new System.EventHandler(this.negatywToolStripMenuItem_Click);
            // 
            // poszarzenieToolStripMenuItem
            // 
            this.poszarzenieToolStripMenuItem.Name = "poszarzenieToolStripMenuItem";
            this.poszarzenieToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.poszarzenieToolStripMenuItem.Text = "Poszarzenie";
            this.poszarzenieToolStripMenuItem.Click += new System.EventHandler(this.poszarzenieToolStripMenuItem_Click);
            // 
            // filtrGaussaToolStripMenuItem
            // 
            this.filtrGaussaToolStripMenuItem.Name = "filtrGaussaToolStripMenuItem";
            this.filtrGaussaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.filtrGaussaToolStripMenuItem.Text = "Filtr Gaussa";
            this.filtrGaussaToolStripMenuItem.Click += new System.EventHandler(this.filtrGaussaToolStripMenuItem_Click);
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobelXToolStripMenuItem,
            this.sobelYToolStripMenuItem});
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sobelToolStripMenuItem.Text = "Gradient";
            this.sobelToolStripMenuItem.Click += new System.EventHandler(this.sobelToolStripMenuItem_Click);
            // 
            // sobelXToolStripMenuItem
            // 
            this.sobelXToolStripMenuItem.Name = "sobelXToolStripMenuItem";
            this.sobelXToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.sobelXToolStripMenuItem.Text = "SobelX";
            this.sobelXToolStripMenuItem.Click += new System.EventHandler(this.sobelXToolStripMenuItem_Click);
            // 
            // sobelYToolStripMenuItem
            // 
            this.sobelYToolStripMenuItem.Name = "sobelYToolStripMenuItem";
            this.sobelYToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.sobelYToolStripMenuItem.Text = "SobelY";
            this.sobelYToolStripMenuItem.Click += new System.EventHandler(this.sobelYToolStripMenuItem_Click);
            // 
            // gradientToolStripMenuItem
            // 
            this.gradientToolStripMenuItem.Name = "gradientToolStripMenuItem";
            this.gradientToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gradientToolStripMenuItem.Text = "Nie-maksymalne";
            this.gradientToolStripMenuItem.Click += new System.EventHandler(this.gradientToolStripMenuItem_Click);
            // 
            // progowanieToolStripMenuItem
            // 
            this.progowanieToolStripMenuItem.Name = "progowanieToolStripMenuItem";
            this.progowanieToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.progowanieToolStripMenuItem.Text = "Progowanie";
            this.progowanieToolStripMenuItem.Click += new System.EventHandler(this.progowanieToolStripMenuItem_Click);
            // 
            // histerezaToolStripMenuItem
            // 
            this.histerezaToolStripMenuItem.Name = "histerezaToolStripMenuItem";
            this.histerezaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.histerezaToolStripMenuItem.Text = "Histereza";
            this.histerezaToolStripMenuItem.Click += new System.EventHandler(this.histerezaToolStripMenuItem_Click);
            // 
            // oryginałToolStripMenuItem
            // 
            this.oryginałToolStripMenuItem.Enabled = false;
            this.oryginałToolStripMenuItem.Name = "oryginałToolStripMenuItem";
            this.oryginałToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.oryginałToolStripMenuItem.Text = "Oryginał";
            this.oryginałToolStripMenuItem.Click += new System.EventHandler(this.oryginałToolStripMenuItem_Click);
            // 
            // prógDolny10ToolStripMenuItem
            // 
            this.prógDolny10ToolStripMenuItem.Enabled = false;
            this.prógDolny10ToolStripMenuItem.Name = "prógDolny10ToolStripMenuItem";
            this.prógDolny10ToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.prógDolny10ToolStripMenuItem.Text = "próg dolny +10";
            this.prógDolny10ToolStripMenuItem.Click += new System.EventHandler(this.prógDolny10ToolStripMenuItem_Click);
            // 
            // prógDolny10ToolStripMenuItem1
            // 
            this.prógDolny10ToolStripMenuItem1.Enabled = false;
            this.prógDolny10ToolStripMenuItem1.Name = "prógDolny10ToolStripMenuItem1";
            this.prógDolny10ToolStripMenuItem1.Size = new System.Drawing.Size(49, 24);
            this.prógDolny10ToolStripMenuItem1.Text = " -10";
            this.prógDolny10ToolStripMenuItem1.Click += new System.EventHandler(this.prógDolny10ToolStripMenuItem1_Click);
            // 
            // prógGórny10ToolStripMenuItem
            // 
            this.prógGórny10ToolStripMenuItem.Enabled = false;
            this.prógGórny10ToolStripMenuItem.Name = "prógGórny10ToolStripMenuItem";
            this.prógGórny10ToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.prógGórny10ToolStripMenuItem.Text = "próg górny +10";
            this.prógGórny10ToolStripMenuItem.Click += new System.EventHandler(this.prógGórny10ToolStripMenuItem_Click);
            // 
            // prógGórny10ToolStripMenuItem1
            // 
            this.prógGórny10ToolStripMenuItem1.Enabled = false;
            this.prógGórny10ToolStripMenuItem1.Name = "prógGórny10ToolStripMenuItem1";
            this.prógGórny10ToolStripMenuItem1.Size = new System.Drawing.Size(49, 26);
            this.prógGórny10ToolStripMenuItem1.Text = " -10";
            this.prógGórny10ToolStripMenuItem1.Click += new System.EventHandler(this.prógGórny10ToolStripMenuItem1_Click);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPictureBox.Location = new System.Drawing.Point(0, 30);
            this.mainPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(724, 557);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mainPictureBox.TabIndex = 1;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Click += new System.EventHandler(this.mainPictureBox_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Wszystkie pliki (*.*)|*.*|Bitmap (*.bmp)|*.bmp";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Wszystkie pliki(*.*)| *.*| Bitmap(*.bmp) | *.bmp";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 587);
            this.Controls.Add(this.mainPictureBox);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Canny";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otworzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem zakończToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem efektyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negatywToolStripMenuItem;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem filtrGaussaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oryginałToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poszarzenieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem progowanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histerezaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prógDolny10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prógDolny10ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem prógGórny10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prógGórny10ToolStripMenuItem1;
    }
}

