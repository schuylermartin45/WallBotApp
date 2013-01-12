using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WallBotApp
{
    [Serializable]
    /// <summary>
    /// Represents a color combination as specified by the YCbCr color system
    /// Y: Luminosity (brightness) of image; Y is between 0 and 1 (black to white)
    /// Cb, Cr represent the Blue and Red component of the image
    /// 
    /// Reasoning: 
    /// This color system is less effected by lighting conditions and other factors than RGB is,
    /// Therefore it should be easier to find 
    /// </summary>
    public class YCbCr
    {
        //Static constants that represent the 'ideal' max/mins for a human face
        //http://www.m-hikari.com/ams/ams-2012/ams-85-88-2012/chitraAMS85-88-2012.pdf
        //http://www.eurojournals.com/AJSR_21_13.pdf
        //current values derived from my tests using photoshop
        /*public static int MINY = 50; //60
        public static int MAXY = 90;
        
        public static int MINCb = 124; //127
        public static int MAXCb = 140; 

        public static int MINCr = 130;
        public static int MAXCr = 140;*/
        /// <summary>
        /// Y component Range: 16 to 235
        /// </summary>
        public int Y
        { get; set; }
        /// <summary>
        /// Cb component Range: 16 to 235
        /// </summary>
        public int Cb
        { get; set; }
        /// <summary>
        /// Cr component Range: 16 to 235
        /// </summary>
        public int Cr
        { get; set; }
        /// <summary>
        /// stores a visual of what has been processed and a mathematical equivalent
        /// </summary>
        public struct VisualPercent
        {
            public Bitmap MAP;
            public float PERCENT;
        }
        public YCbCr()
        {
        }
        /// <summary>
        /// Construct a YCbCr object; collection of three values
        /// </summary>
        /// <param name="color"></param>
        public YCbCr(Color color)
        {
            //calculate the YCbCr component from RGB values 
            //using conversion factors from the official YCbCr standard (see wikipedia: http://en.wikipedia.org/wiki/YCbCr)
            this.Y = (int)Math.Round(16 + (((65.481f * (float)color.R) + (128.553f * (float)color.G) + (24.966f * (float)color.B)) / 256f));
            this.Cb = (int)Math.Round(128f + (((-37.797f * (float)color.R) - (74.203f * (float)color.G) + (112.0f * (float)color.B)) / 256f));
            this.Cr = (int)Math.Round(128f + (((112.0f * (float)color.R) - (93.786f * (float)color.G) - (18.214f * (float)color.B)) / 256f));
            /*
            Console.WriteLine("RGB");
            Console.WriteLine((float)color.R);
            Console.WriteLine((float)color.G);
            Console.WriteLine((float)color.B);
            Console.WriteLine("YCbCr");
            Console.WriteLine(this.Y);
            Console.WriteLine(this.Cb);
            Console.WriteLine(this.Cr);
            */
        }
        /// <summary>
        /// Constructs based on given YCbCr values
        /// </summary>
        /// <param name="Y"></param>
        /// <param name="Cb"></param>
        /// <param name="Cr"></param>
        public YCbCr(int Y, int Cb, int Cr)
        {
            this.Y = Y;
            this.Cb = Cb;
            this.Cr = Cr;
        }

        /// <summary>
        /// Converts a bitmap image to an matrix of YCbCr values
        /// </summary>
        public static YCbCr[,] BitmapToYCbCr(Bitmap bmp)
        {
            YCbCr[,] ColorMatrix = new YCbCr[bmp.Height,bmp.Width];
            //fill dat matrix!
            for (int col = 0; col < bmp.Height; col++)
            {
                for (int row = 0; row < bmp.Width; row++)
                {
                    ColorMatrix[row, col] = new YCbCr(bmp.GetPixel(row, col));
                }
            }
            return(ColorMatrix);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static float PercentFace(Bitmap bmp, YCbCr minYCbCr, YCbCr maxYCbCr)
        {
            float facePixels = 0f;
            float totalPixels = ((float)bmp.Height * (float)bmp.Width);
            //search through each pixel in the bit map
            for (int col = 0; col < bmp.Height; col++)
            {
                for (int row = 0; row < bmp.Width; row++)
                {
                    //construct a YCbCr value set for each pixel (THIS MAY BE SLOW)
                    YCbCr temp = new YCbCr(bmp.GetPixel(row, col));
                    if ((temp.Cr >= minYCbCr.Cr) && (temp.Cr <= maxYCbCr.Cr))
                    {
                        if ((temp.Cb >= minYCbCr.Cb) && (temp.Cb <= maxYCbCr.Cb))
                        {
                            if ((temp.Y >= minYCbCr.Y) && (temp.Y <= maxYCbCr.Y))
                            {
                                //Keepin' that precesion
                                facePixels += 1f;
                            }
                        }
                    }
                }
            }
            return (facePixels / totalPixels);
        }
        /// <summary>
        /// Takes a bitmap image and produces a "PercentFace" visualization of the image
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap PercentFaceBmp(Bitmap bmp, YCbCr minYCbCr, YCbCr maxYCbCr)
        {
            //copies over from the original
            Bitmap newMap = new Bitmap(bmp);
            //search through each pixel in the bit map
            for (int col = 0; col < bmp.Height; col++)
            {
                for (int row = 0; row < bmp.Width; row++)
                {
                    //Console.WriteLine(bmp.Width + " " + bmp.Height);
                    //Console.WriteLine("Row: " + row + " Col: " + col);
                    //construct a YCbCr value set for each pixel (THIS MAY BE SLOW)
                    YCbCr temp = new YCbCr(bmp.GetPixel(row,col));
                    //pixels that pass both tests are white
                    if (((temp.Cr >= minYCbCr.Cr) && (temp.Cr <= maxYCbCr.Cr)) && ((temp.Cb >= minYCbCr.Cb) && (temp.Cb <= maxYCbCr.Cb)) && ((temp.Y >= minYCbCr.Y) && (temp.Y <= maxYCbCr.Y)))
                        newMap.SetPixel(row, col, bmp.GetPixel(row,col)); //Color.White
                    /*
                    //pixels that pass just the red test are red
                    else if ((temp.Cr >= MINCr) && (temp.Cr <= MAXCr))
                        newMap.SetPixel(row, col, Color.Red);
                    //pixels that pass just the blue test are blue
                    else if ((temp.Cb >= MINCb) && (temp.Cb <= MAXCb))
                        newMap.SetPixel(row, col, Color.Blue);
                    */
                    else
                        //pixels that fail both tests are black
                        newMap.SetPixel(row, col, Color.Black);
                }
            }
            return(newMap);
        }

        /// <summary>
        /// Takes a bitmap image and produces a "PercentFace" visualization of the image and the percentage value
        /// Cuts calculations down significantly when trying to detect the face and visualize it to the user
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static VisualPercent PercentFaceBoth(Bitmap bmp, YCbCr minYCbCr, YCbCr maxYCbCr)
        {
            float facePixels = 0f;
            float totalPixels = ((float)bmp.Height * (float)bmp.Width);
            //copies over from the original
            Bitmap newMap = new Bitmap(bmp);
            //search through each pixel in the bit map
            for (int col = 0; col < bmp.Height; col++)
            {
                for (int row = 0; row < bmp.Width; row++)
                {
                    //Console.WriteLine(bmp.Width + " " + bmp.Height);
                    //Console.WriteLine("Row: " + row + " Col: " + col);
                    //construct a YCbCr value set for each pixel (THIS MAY BE SLOW)
                    YCbCr temp = new YCbCr(bmp.GetPixel(row, col));
                    //pixels that pass both tests are white
                    if (((temp.Cr >= minYCbCr.Cr) && (temp.Cr <= maxYCbCr.Cr)) && ((temp.Cb >= minYCbCr.Cb) && (temp.Cb <= maxYCbCr.Cb)) && ((temp.Y >= minYCbCr.Y) && (temp.Y <= maxYCbCr.Y)))
                    {
                        newMap.SetPixel(row, col, bmp.GetPixel(row, col));
                        //Keepin' that precesion
                        facePixels += 1f;
                    }
                    else
                        //pixels that fail both tests are black
                        newMap.SetPixel(row, col, Color.Black);
                }
            }
            //return both a bitmap and a percentage value
            VisualPercent newVisualPercent = new VisualPercent();
            newVisualPercent.MAP = newMap;
            newVisualPercent.PERCENT = facePixels / totalPixels;
            return(newVisualPercent);
        }

    }
}
