using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RandomBitmapAndBitmapSource
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // generate and display a 230x200 random pixel image
            preview.Source = CreateRandomBitmapSource(230, 200);
            // open the WinForm
            var form = new WinForm();
            var wih = new WindowInteropHelper(this) { Owner = form.Handle };
            form.Show();
        }

        private BitmapSource CreateRandomBitmapSource(int width, int height)
        {
            // create an array and fill it with random bytes
            var randomPixels = new byte[4 * width * height];
            new Random().NextBytes(randomPixels);
            // create and return a 32-bit color BitmapSource
            return BitmapSource.Create(width, height, 96d, 96d, PixelFormats.Bgra32, null, randomPixels, width * 4);
        }
    }
}
