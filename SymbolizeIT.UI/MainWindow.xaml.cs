using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SymbolizeIT.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ISymbolizer converter;

        public MainWindow()
        {
            InitializeComponent();

            converter = new ToneBasedSymbolizer();
            converter.DefaultPalette = new AsciiPalette(new []{' ', '.', '+', ':', '&'}, true);
            converter.DefaultBlockSize = new System.Drawing.Size(10, 10);
        }

        private void CloseApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a image";
            openFileDialog.Filter = "Image Files|*.jpg";

            if (openFileDialog.ShowDialog() == true)
            {
                OriginalImageImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void ConverToAscii(object sender, RoutedEventArgs e)
        {
            AsciiImageTxb.Text = string.Empty;

            var imageSource = OriginalImageImg.Source as BitmapImage;

            if (imageSource == null)
            {
                throw new Exception("Orifinal image is not BitmapImage");
            }

            var image = new Bitmap(imageSource.UriSource.LocalPath);

            var asciiImage = converter.GetAsciiArt(image);

            for (int i = 0; i < asciiImage.Width; i++)
            {
                for (int j = 0; j < asciiImage.Height; j++)
                {
                    AsciiImageTxb.Text += asciiImage[j, i];
                }
                AsciiImageTxb.Text += Environment.NewLine;                
            }

            AsciiImageTxb.FontSize = 8.0f;
        }
    }
}
