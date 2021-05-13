using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace OneFileManager.Common.Utils
{
    internal class ImageUtil
    {
        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)

        {
            // BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

            using (MemoryStream outStream = new MemoryStream())

            {
                BitmapEncoder enc = new BmpBitmapEncoder();

                enc.Frames.Add(BitmapFrame.Create(bitmapImage));

                enc.Save(outStream);

                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        private BitmapImage Bitmap2BitmapImage(Bitmap bitmap)

        {
            IntPtr hBitmap = bitmap.GetHbitmap();

            BitmapImage retval;

            try

            {
                retval = (BitmapImage)Imaging.CreateBitmapSourceFromHBitmap(

                             hBitmap,

                             IntPtr.Zero,

                             Int32Rect.Empty,

                             BitmapSizeOptions.FromEmptyOptions());
            }
            finally

            {
                DeleteObject(hBitmap);
            }

            return retval;
        }
    }
}