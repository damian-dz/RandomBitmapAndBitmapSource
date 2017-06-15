using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RandomBitmapAndBitmapSource
{
    public partial class WinForm : Form
    {
        public WinForm()
        {
            InitializeComponent();
            // generate and display a 230x200 random pixel image
            preview.Image = CreateRandomBitmap(230, 200);
        }

        private Bitmap CreateRandomBitmap(int width, int height)
        {
            // create an array and fill it with random bytes
            var randomPixels = new byte[4 * width * height];
            new Random().NextBytes(randomPixels);
            // allocate a handle to access the managed data from unmanaged memory
            var gch = GCHandle.Alloc(randomPixels, GCHandleType.Pinned);
            // get the address of the "pinned" data
            IntPtr dataPtr = gch.AddrOfPinnedObject();
            // create a 32-bit color Bitmap
            var randomBmp = new Bitmap(width, height, width * 4, PixelFormat.Format32bppArgb, dataPtr);
            // free the handle and return the generated Bitmap
            gch.Free();
            return randomBmp;
        }
    }
}
