using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Colours.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RedPage : Page
    {
        public RedPage()
        {
            this.InitializeComponent();

            // Hex values of colours
            List<string> reds = new List<string>(14)
            {
                "#ffebee",
                "#ffcdd2",
                "#ef9a9a",
                "#e57373",
                "#ef5350",
                "#f44336",
                "#e53935",
                "#d32f2f",
                "#c62828",
                "#b71c1c",
                "#ff8a80",
                "#ff5252",
                "#ff1744",
                "#d50000"
            };
            // Generate colours to be used as brushes for button backgrounds
            List<SolidColorBrush> brushes = new List<SolidColorBrush>(14);
            for (int i = 0; i < 14; i++)
            {
                // Extract RGB values from string and make SolidColorBrush
                byte a = byte.Parse("FF", NumberStyles.HexNumber);
                byte r = byte.Parse(reds[i].Substring(1, 2), NumberStyles.HexNumber);
                byte g = byte.Parse(reds[i].Substring(3, 2), NumberStyles.HexNumber);
                byte b = byte.Parse(reds[i].Substring(5, 2), NumberStyles.HexNumber);
                Color col = Color.FromArgb(a, r, g, b);
                SolidColorBrush brush = new SolidColorBrush(col);

                // Add buttons to StackPanel
                Button colourButton = new Button
                {
                    Content = reds[i],
                    Background = brush,
                    Width = 100
                };
                colourButton.Click += Button_Click;
                ColourPanel.Children.Add(colourButton);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // cast sender as Button
            Button b = (Button)sender;
            // DataPackage for handling clipboard
            DataPackage dataPackage = new DataPackage();

            // assign button text content to dataPackage
            dataPackage.SetText(b.Content.ToString());
            // assign dataPackage to clipboard
            Clipboard.SetContent(dataPackage);
        }
    }
}
