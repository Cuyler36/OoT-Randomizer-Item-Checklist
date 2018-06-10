using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OoT_Randomizer_Item_Checklist
{
    public static class Utilities
    {
        public static string GetDirectoryPath(this Assembly assembly)
        {
            string filePath = new Uri(assembly.CodeBase).LocalPath;
            return Path.GetDirectoryName(filePath);
        }

        //From: http://stackoverflow.com/questions/2265910/convert-an-image-to-grayscale
        public static BitmapSource MakeGrayscale(this BitmapSource source)
        {
            if (source == null)
                return null;
            Bitmap original = source.GetBitmap();
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
               });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);

            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            var ReturnSource = newBitmap.GetBitmapSource();

            g.Dispose();
            original.Dispose();
            newBitmap.Dispose();

            return ReturnSource;
        }

        public static BitmapSource MakeGrayscale2(this BitmapSource source)
        {
            Bitmap c = source.GetBitmap();
            Bitmap d = new Bitmap(c.Width, c.Height);

            for (int i = 0; i < c.Width; i++)
            {
                for (int x = 0; x < c.Height; x++)
                {
                    System.Drawing.Color oc = c.GetPixel(i, x);
                    int grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
                    System.Drawing.Color nc = System.Drawing.Color.FromArgb(oc.A, grayScale, grayScale, grayScale);
                    d.SetPixel(i, x, nc);
                }
            }

            var Source = d.GetBitmapSource();
            c.Dispose();
            d.Dispose();

            return Source;
        }

        public static BitmapSource GetBitmapSourceFromResource(string ResourceName)
        {
            if (!ResourceName.Contains(".png"))
            {
                ResourceName += ".png";
            }

            var ResourceDirectory = Assembly.GetExecutingAssembly().GetDirectoryPath() + "\\Resources\\";
            var Bitmap = new BitmapImage();

            if (Directory.Exists(ResourceDirectory))
            {
                using (var Stream = new FileStream(ResourceDirectory + ResourceName, FileMode.Open))
                {
                    Bitmap.BeginInit();
                    Bitmap.StreamSource = Stream;
                    Bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    Bitmap.EndInit();
                }

                return Bitmap;
            }
            else
            {
                return null;
            }
        }

        public static Bitmap GetBitmap(this BitmapSource source)
        {
            Bitmap bmp = new Bitmap(
              source.PixelWidth,
              source.PixelHeight,
              System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            BitmapData data = bmp.LockBits(
              new Rectangle(System.Drawing.Point.Empty, bmp.Size),
              ImageLockMode.WriteOnly,
              System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            source.CopyPixels(
              Int32Rect.Empty,
              data.Scan0,
              data.Height * data.Stride,
              data.Stride);
            bmp.UnlockBits(data);
            return bmp;
        }

        // From: https://stackoverflow.com/questions/26260654/wpf-converting-bitmap-to-imagesource
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        public static BitmapSource GetBitmapSource(this Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally { DeleteObject(handle); }
        }
    }
}
