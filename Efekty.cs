using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using System.Linq;
using System.Text;


namespace Canny
{
    public struct Rgb
    {
        #region pola
        public byte b, g, r;
        #endregion pola
        public Rgb Szarosc()
        {
            byte srednia = (byte)((this.r + this.g + this.b) / 3);
            Rgb rob = new Rgb() { r = srednia, g = srednia, b = srednia };
            return rob;
        }
        public Rgb Negatyw()
        {
            Rgb rob;
            rob.r = (byte)(255 - this.r);
            rob.g = (byte)(255 - this.g);
            rob.b = (byte)(255 - this.b);
            return rob;
        }
    }
    class Efekty
    {
        private static double[,] gradient, Fi, krawedzie;
        private static int[,] jadroGaussa = 
           {{ 2, 4, 5, 4, 2 },
            { 4, 9,12, 9, 4 },
            { 5,12,15,12, 5 },
            { 4, 9,12, 9, 4 },
            { 2, 4, 5, 4, 2 }}, nM;
        private static int szerokosc, wysokosc, slabe, silne;
        public static Bitmap Poszarzenie(Bitmap bitmapaWe)
        {
            szerokosc = bitmapaWe.Width; wysokosc = bitmapaWe.Height;
            Bitmap bitmapaWy = new Bitmap(szerokosc, wysokosc, PixelFormat.Format24bppRgb);

            BitmapData bmWeData = bitmapaWe.LockBits(new Rectangle(0, 0, szerokosc, wysokosc),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmWyData = bitmapaWy.LockBits(new Rectangle(0, 0, szerokosc, wysokosc),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                for (int y = 0; y < wysokosc; y++)
                {
                    byte* pWe = (byte*)(void*)bmWeData.Scan0 + y * bmWeData.Stride;
                    byte* pWy = (byte*)(void*)bmWyData.Scan0 + y * bmWyData.Stride;
                        for (int x = 0; x < szerokosc; x++)
                        {
                            ((Rgb*)pWy)[x] = ((Rgb*)pWe)[x].Szarosc();
                        }
                }
            }
            bitmapaWy.UnlockBits(bmWyData);
            bitmapaWe.UnlockBits(bmWeData);

            return bitmapaWy;
        }
        public static int[,] NaTab(Bitmap bitmapaWe)
        {
            int[,] tab = new int[szerokosc, wysokosc];

            BitmapData bmWeData = bitmapaWe.LockBits(new Rectangle(0, 0, szerokosc, wysokosc),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            
            unsafe
            {
                for (int y = 0; y < wysokosc; y++)
                {
                    byte* pWe = (byte*)(void*)bmWeData.Scan0 + y * bmWeData.Stride;
                        for (int x = 0; x < szerokosc; x++)
                        {
                            tab[x, y] = ((Rgb*)pWe)[x].r;
                        }
                }
            }
            bitmapaWe.UnlockBits(bmWeData);
            return tab;
        }
        public static Bitmap NaBitmape(int[,] tab)
        {
            Bitmap bitmapaWy = new Bitmap(szerokosc, wysokosc, PixelFormat.Format24bppRgb);

            BitmapData bmWyData = bitmapaWy.LockBits(new Rectangle(0, 0, szerokosc, wysokosc), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                for (int y = 0; y < wysokosc; y++)
                {
                    byte* pWy = (byte*)(void*)bmWyData.Scan0 + y * bmWyData.Stride;

                    for (int x = 0; x < szerokosc; x++)
                    {
                        byte z;
                            if (tab[x, y] < 0) z = 0;
                                else
                            if (tab[x, y] > 255) z = 255;
                                else z = (byte)tab[x, y];
                        ((Rgb*)pWy)[x] = new Rgb() { r = z, g = z, b = z };
                    }
                }
            }
            bitmapaWy.UnlockBits(bmWyData);
            return bitmapaWy;
        }
        public static int[,] FiltrGaussa(int[,] tab)
        {
            int[,] wynik;
            wynik = tab;
            for (int i = 2; i < szerokosc - 2; i++)
            {
                for (int j = 2; j < wysokosc - 2; j++)
                {
                    float sum = 0;
                    for (int k = -2; k <= 2; k++)
                    {
                        for (int l = -2; l <= 2; l++)
                        {
                            sum += (float)tab[i + k, j + l] * jadroGaussa[2 + k, 2 + l];
                        }
                    }
                    wynik[i, j] = (int)Math.Round(sum / 159);
                }
            }
            return wynik;
        }
        public static int[,] Pochodna(int[,] tab, int[,] maska)
        {
            int[,] wynik = new int[szerokosc, wysokosc];

            for (int i = 1; i < szerokosc - 1 ; i++)
            {
                for (int j = 1; j < wysokosc - 1; j++)
                {
                    int sum = 0;
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            sum += tab[i + k, j + l] * maska[1 + k, 1 + l];
                        }
                    }
                    wynik[i, j] = sum;
                }
            }
            return wynik;
        }
        public static void Gradient(int[,] tab, int[,] SobX, int[,] SobY)
        {
            gradient = new double[szerokosc, wysokosc];
            Fi = new double[szerokosc, wysokosc];
            for (int i = 0; i < szerokosc; i++)
            {
                for (int j = 0; j < wysokosc; j++)
                {
                    gradient[i, j] = Math.Sqrt(Math.Pow(SobX[i, j], 2.0) + Math.Pow(SobY[i, j], 2.0));
                    Fi[i, j] = Math.Atan2(SobY[i, j], SobX[i, j]) * 180 / Math.PI;
                    tab[i, j] = (int)gradient[i, j];
                }
            }
        }
        public static int[,] NonMax()
        {
            int[,] wynik = new int[szerokosc, wysokosc];
            nM = new int[szerokosc, wysokosc];
            for (int i = 1; i < szerokosc-1; i++)
            {
                for (int j = 1; j < wysokosc-1; j++)
                {
                    wynik[i, j] = 0;
                    if (Fi[i, j] < 0) Fi[i, j] += 360;

                    if ((Fi[i, j] >= 337.5 || Fi[i, j] < 22.5) || (Fi[i, j] >= 157.5 || Fi[i, j] < 202.5))
                        if (gradient[i, j] >= gradient[i, j + 1] && gradient[i, j] >= gradient[i, j - 1])
                            wynik[i, j] = nM[i,j] = (int)gradient[i, j];

                    if ((Fi[i, j] >= 22.5 && Fi[i, j] < 67.5) || (Fi[i, j] >= 202.5 || Fi[i, j] < 247.5))
                        if (gradient[i, j] >= gradient[i - 1, j + 1] && gradient[i, j] >= gradient[i + 1, j - 1])
                            wynik[i, j] = nM[i, j] = (int)gradient[i, j];

                    if ((Fi[i, j] >= 67.5 && Fi[i, j] < 112.5) || (Fi[i, j] >= 247.5 || Fi[i, j] < 292.5))
                        if (gradient[i, j] >= gradient[i - 1, j] && gradient[i, j] >= gradient[i + 1, j])
                            wynik[i, j] = nM[i, j] = (int)gradient[i, j];

                    if ((Fi[i, j] >= 112.5 || Fi[i, j] < 157.5) || (Fi[i, j] >= 292.5 || Fi[i, j] < 337.5))
                        if (gradient[i, j] >= gradient[i - 1, j - 1] && gradient[i, j] >= gradient[i + 1, j + 1])
                            wynik[i, j] = nM[i, j] = (int)gradient[i, j];
                }
            }
            
            return wynik;
        }
        public static int[,] Progowanie()
        {
            int[,] wynik = new int[szerokosc, wysokosc];
            krawedzie = new double[szerokosc, wysokosc];
            slabe = 95; silne=200;
            for (int i = 0; i < szerokosc; i++)
            {
                for (int j = 0; j < wysokosc; j++)
                {
                    wynik[i, j] = 0;
                    krawedzie[i, j] = 0;

                    if (nM[i, j] >= silne)
                    {
                        krawedzie[i, j] = 255;
                        wynik[i, j] = 255;
                    }
                    else if (nM[i, j] >= slabe)
                    {
                        krawedzie[i, j]  = 127;
                        wynik[i, j] = 127;
                    }
                    else
                    {
                        krawedzie[i, j] = 0;
                        wynik[i, j] = 0;
                    }
                }
            }
            return wynik;
        }
        public static int[,] Histereza()
        {
            int[,] wynik = new int[szerokosc, wysokosc];
            slabe = 127; silne = 255;
            for (int i = 1; i < szerokosc - 1; i++)
            {
                for (int j = 1; j < wysokosc - 1; j++)
                {
                    wynik[i, j] = (int)krawedzie[i, j];
                    if (krawedzie[i, j] == 127)
                    {
                        if ((krawedzie[i + 1, j - 1] == silne) || (krawedzie[i + 1, j] == silne) 
                         || (krawedzie[i + 1, j + 1] == silne) || (krawedzie[i, j - 1] == silne) || (krawedzie[i, j + 1] == silne)
                         || (krawedzie[i - 1, j - 1] == silne) || (krawedzie[i - 1, j] == silne) || (krawedzie[i - 1, j + 1] == silne))
                        {
                            wynik[i, j] = silne;
                        }
                        else
                            wynik[i, j] = 0;
                    }
                }
            }

            return wynik;
        }
        public static Bitmap Negatyw(Bitmap bitmapaWe)
        {
            Bitmap bitmapaWy = new Bitmap(szerokosc, wysokosc, PixelFormat.Format24bppRgb);

            BitmapData bmWeData = bitmapaWe.LockBits(new Rectangle(0, 0, szerokosc, wysokosc), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmWyData = bitmapaWy.LockBits(new Rectangle(0, 0, szerokosc, wysokosc), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int strideWe = bmWeData.Stride;
            int strideWy = bmWyData.Stride;

            IntPtr scanWe = bmWeData.Scan0;
            IntPtr scanWy = bmWyData.Scan0;

            unsafe
            {
                for (int y = 0; y < wysokosc; y++)
                {
                    byte* pWe = (byte*)(void*)scanWe + y * strideWe;
                    byte* pWy = (byte*)(void*)scanWy + y * strideWy;

                    for (int x = 0; x < szerokosc; x++)
                    {

                        Rgb pikselWejsciowy = ((Rgb*)pWe)[x];
                        Rgb pikselWynikowy = pikselWejsciowy.Negatyw();
                        ((Rgb*)pWy)[x] = pikselWynikowy;

                    }
                }
            }
            bitmapaWy.UnlockBits(bmWyData);
            bitmapaWe.UnlockBits(bmWeData);

            return bitmapaWy;
        }

    }


}

