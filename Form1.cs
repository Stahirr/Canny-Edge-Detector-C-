using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Canny
{
    public partial class Form1 : Form
    {        
        private Bitmap _bitmapa,poszarzenie, Gauss, SobelX, 
            SobelY, Gradient, NonMax, Progowanie, Histereza, tHistereza;
        private int progdolny=65, proggorny=200;
        private int[,] tab, SobX, SobY,temp,htemp,
            Sx = {{1,0,-1},
                  {2,0,-2},
                  {1,0,-1}},

            Sy = {{ 1, 2, 1},
                  { 0, 0, 0},
                  {-1,-2,-1}};

        public Form1()
        {
            InitializeComponent();
        }

        public int[,] ProgowaniezHistereza()
        {
            int[,] wynik = new int[tab.GetLength(0), tab.GetLength(1)];
            int [,] krawedzie = new int[tab.GetLength(0), tab.GetLength(1)];
            int slabe = progdolny; int silne = proggorny;
            if (slabe < 25) slabe = 25;if (slabe > 120) slabe = 120;
            if (silne < 130) silne = 130;if (silne > 255) slabe = 255;
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    wynik[i, j] = 0;
                    krawedzie[i, j] = 0;

                    if (temp[i, j] >= silne)
                    {
                        krawedzie[i, j] = 255;
                        wynik[i, j] = 255;
                    }
                    else if (temp[i, j] >= slabe)
                    {
                        krawedzie[i, j] = 127;
                        wynik[i, j] = 127;
                    }
                    else
                    {
                        krawedzie[i, j] = 0;
                        wynik[i, j] = 0;
                    }
                }
            }
            htemp = new int[tab.GetLength(0), tab.GetLength(1)];
            slabe = 127; silne = 255;
            for (int i = 1; i < tab.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < tab.GetLength(1) - 1; j++)
                {
                    htemp[i, j] = krawedzie[i, j];
                    if (krawedzie[i, j] == slabe)
                    {
                        if ((krawedzie[i + 1, j - 1] == silne) || (krawedzie[i + 1, j] == silne)
                         || (krawedzie[i + 1, j + 1] == silne) || (krawedzie[i, j - 1] == silne) || (krawedzie[i, j + 1] == silne)
                         || (krawedzie[i - 1, j - 1] == silne) || (krawedzie[i - 1, j] == silne) || (krawedzie[i - 1, j + 1] == silne))
                        {
                            htemp[i, j] = silne;
                        }
                        else
                            htemp[i, j] = 0;
                    }
                }
            }

            return wynik;
        }
     
        private void InitializeImage()
        {
            poszarzenie = Efekty.Poszarzenie(_bitmapa);
            tab = Efekty.FiltrGaussa(Efekty.NaTab(poszarzenie));
            Gauss = Efekty.NaBitmape(tab);
            SobX = Efekty.Pochodna(tab, Sx);
            SobelX = Efekty.NaBitmape(SobX);
            SobY = Efekty.Pochodna(tab, Sy);
            SobelY = Efekty.NaBitmape(SobY);
            Efekty.Gradient(tab, SobX, SobY);
            Gradient = Efekty.NaBitmape(tab);
            NonMax = Efekty.NaBitmape(
                Efekty.NonMax());
            temp = Efekty.NonMax();
            Progowanie = Efekty.NaBitmape(
                Efekty.Progowanie());
            tHistereza = Histereza = Efekty.NaBitmape(
                Efekty.Histereza());
        }

        private void odblokujPrzyciski()
        {
            efektyToolStripMenuItem.Enabled = true;
            oryginałToolStripMenuItem.Enabled = true;
            zapiszToolStripMenuItem.Enabled = true;
            prógDolny10ToolStripMenuItem.Enabled = true;
            prógDolny10ToolStripMenuItem1.Enabled = true;
            prógGórny10ToolStripMenuItem.Enabled = true;
            prógGórny10ToolStripMenuItem1.Enabled = true;
        }
        private void odb_ZabPrzyciski()
        {
            prógDolny10ToolStripMenuItem.Enabled  = progdolny <= 120;
            prógDolny10ToolStripMenuItem1.Enabled = progdolny >= 25;
            prógGórny10ToolStripMenuItem1.Enabled = proggorny >= 130;
            prógGórny10ToolStripMenuItem.Enabled  = proggorny <= 255;
        }

        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _bitmapa = new Bitmap(this.openFileDialog.FileName);
                this.mainPictureBox.Image = _bitmapa;
                InitializeImage();
                odblokujPrzyciski();
            }
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.mainPictureBox.Image.Save(saveFileDialog.FileName);
            }
        }

        private void negatywToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mainPictureBox.Image = Efekty.Negatyw(_bitmapa);
        }

        private void prógDolny10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progdolny += 10;
            odb_ZabPrzyciski();
            this.mainPictureBox.Image = Efekty.NaBitmape(ProgowaniezHistereza());
            Histereza = Efekty.NaBitmape(htemp);
        }

        private void prógDolny10ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            progdolny -= 10;
            odb_ZabPrzyciski();
            this.mainPictureBox.Image = Efekty.NaBitmape(ProgowaniezHistereza());
            Histereza = Efekty.NaBitmape(htemp);
        }

        private void prógGórny10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proggorny += 10;
            odb_ZabPrzyciski();
            this.mainPictureBox.Image = Efekty.NaBitmape(ProgowaniezHistereza());
            Histereza = Efekty.NaBitmape(htemp);
        }

        private void prógGórny10ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            proggorny -= 10;
            odb_ZabPrzyciski();
            this.mainPictureBox.Image = Efekty.NaBitmape(ProgowaniezHistereza());
            Histereza = Efekty.NaBitmape(htemp);
        }

        private void histerezaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mainPictureBox.Image = Histereza;
        }

        private void progowanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mainPictureBox.Image = Progowanie;
            progdolny = 65; proggorny = 200;
            odb_ZabPrzyciski();
            Histereza = tHistereza;
        }

        private void efektyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_bitmapa == null) efektyToolStripMenuItem.Enabled = false;
        }

        private void mainPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void filtrGaussaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mainPictureBox.Image = Gauss;
        }

        private void oryginałToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_bitmapa == null) oryginałToolStripMenuItem.Enabled = false;
            this.mainPictureBox.Image = _bitmapa;
            
        }

        private void poszarzenieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mainPictureBox.Image = poszarzenie;
            
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mainPictureBox.Image = Gradient;
        }

        private void sobelXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mainPictureBox.Image = SobelX;
        }

        private void sobelYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mainPictureBox.Image = SobelY;
        }

        private void gradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.mainPictureBox.Image = NonMax;
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy chcesz zakończyć działanie programu?", "Zakończ program", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
            else
                this.Activate();
        }
    }
}
