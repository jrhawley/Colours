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
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Colours.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ColourPage : Page
    {
        public ColourPage()
        {
            this.InitializeComponent();
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Load colours and buttons
            string tag = (string)e.Parameter;

            // Hex values of colours
            Dictionary<string, List<string>> colours = new Dictionary<string, List<string>>()
            {
                {
                    "red",
                    new List<string>
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
                    }
                },
                {
                    "pink",
                    new List<string>
                    {
                        "#fce4ec",
                        "#f8bbd0",
                        "#f48fb1",
                        "#f06292",
                        "#ec407a",
                        "#e91e63",
                        "#d81b60",
                        "#c2185b",
                        "#ad1457",
                        "#880e4f",
                        "#ff80ab",
                        "#ff4081",
                        "#f50057",
                        "#c51162"
                    }
                },
                {
                    "purple",
                    new List<string>
                    {
                        "#f3e5f5",
                        "#e1bee7",
                        "#ce93d8",
                        "#ba68c8",
                        "#ab47bc",
                        "#9c27b0",
                        "#8e24aa",
                        "#7b1fa2",
                        "#6a1b9a",
                        "#4a148c",
                        "#ea80fc",
                        "#e040fb",
                        "#d500f9",
                        "#aa00ff"
                    }
                },
                {
                    "deep purple",
                    new List<string>
                    {
                        "#ede7f6",
                        "#d1c4e9",
                        "#b39ddb",
                        "#9575cd",
                        "#7e57c2",
                        "#673ab7",
                        "#5e35b1",
                        "#512da8",
                        "#4527a0",
                        "#311b92",
                        "#b388ff",
                        "#7c4dff",
                        "#651fff",
                        "#6200ea"
                    }
                },
                {
                    "indigo",
                    new List<string>
                    {
                        "#e8eaf6",
                        "#c5cae9",
                        "#9fa8da",
                        "#7986cb",
                        "#5c6bc0",
                        "#3f51b5",
                        "#3949ab",
                        "#303f9f",
                        "#283593",
                        "#1a237e",
                        "#8c9eff",
                        "#536dfe",
                        "#3d5afe",
                        "#304ffe"
                    }
                },
                {
                    "blue",
                    new List<string>
                    {
                        "#e3f2fd",
                        "#bbdefb",
                        "#90caf9",
                        "#64b5f6",
                        "#42a5f5",
                        "#2196f3",
                        "#1e88e5",
                        "#1976d2",
                        "#1565c0",
                        "#0d47a1",
                        "#82b1ff",
                        "#448aff",
                        "#2979ff",
                        "#2962ff"
                    }
                },
                {
                    "light blue",
                    new List<string>
                    {
                        "#e1f5fe",
                        "#b3e5fc",
                        "#81d4fa",
                        "#4fc3f7",
                        "#29b6f6",
                        "#03a9f4",
                        "#039be5",
                        "#0288d1",
                        "#0277bd",
                        "#01579b",
                        "#80d8ff",
                        "#40c4ff",
                        "#00b0ff",
                        "#0091ea"
                    }
                },
                {
                    "cyan",
                    new List<string>
                    {
                        "#e0f7fa",
                        "#b2ebf2",
                        "#80deea",
                        "#4dd0e1",
                        "#26c6da",
                        "#00bcd4",
                        "#00acc1",
                        "#0097a7",
                        "#00838f",
                        "#006064",
                        "#84ffff",
                        "#18ffff",
                        "#00e5ff",
                        "#00b8d4"
                    }
                },
                {
                    "teal",
                    new List<string>
                    {
                        "#e0f2f1",
                        "#b2dfdb",
                        "#80cbc4",
                        "#4db6ac",
                        "#26a69a",
                        "#009688",
                        "#00897b",
                        "#00796b",
                        "#00695c",
                        "#004d40",
                        "#a7ffeb",
                        "#64ffda",
                        "#1de9b6",
                        "#00bfa5"
                    }
                },
                {
                    "green",
                    new List<string>
                    {
                        "#e8f5e9",
                        "#c8e6c9",
                        "#a5d6a7",
                        "#81c784",
                        "#66bb6a",
                        "#4caf50",
                        "#43a047",
                        "#388e3c",
                        "#2e7d32",
                        "#1b5e20",
                        "#b9f6ca",
                        "#69f0ae",
                        "#00e676",
                        "#00c853"
                    }
                },
                {
                    "light green",
                    new List<string>
                    {
                        "#f1f8e9",
                        "#dcedc8",
                        "#c5e1a5",
                        "#aed581",
                        "#9ccc65",
                        "#8bc34a",
                        "#7cb342",
                        "#689f38",
                        "#558b2f",
                        "#33691e",
                        "#ccff90",
                        "#b2ff59",
                        "#76ff03",
                        "#64dd17"
                    }
                },
                {
                    "lime",
                    new List<string>
                    {
                        "#f9fbe7",
                        "#f0f4c3",
                        "#e6ee9c",
                        "#dce775",
                        "#d4e157",
                        "#cddc39",
                        "#c0ca33",
                        "#afb42b",
                        "#9e9d24",
                        "#827717",
                        "#f4ff81",
                        "#eeff41",
                        "#c6ff00",
                        "#aeea00"
                    }
                },
                {
                    "yellow",
                    new List<string>
                    {
                        "#fffde7",
                        "#fff9c4",
                        "#fff59d",
                        "#fff176",
                        "#ffee58",
                        "#ffeb3b",
                        "#fdd835",
                        "#fbc02d",
                        "#f9a825",
                        "#f57f17",
                        "#ffff8d",
                        "#ffff00",
                        "#ffea00",
                        "#ffd600"
                    }
                },
                {
                    "amber",
                    new List<string>
                    {
                        "#fff8e1",
                        "#ffecb3",
                        "#ffe082",
                        "#ffd54f",
                        "#ffca28",
                        "#ffc107",
                        "#ffb300",
                        "#ffa000",
                        "#ff8f00",
                        "#ff6f00",
                        "#ffe57f",
                        "#ffd740",
                        "#ffc400",
                        "#ffab00"
                    }
                },
                {
                    "orange",
                    new List<string>
                    {
                        "#fff3e0",
                        "#ffe0b2",
                        "#ffcc80",
                        "#ffb74d",
                        "#ffa726",
                        "#ff9800",
                        "#fb8c00",
                        "#f57c00",
                        "#ef6c00",
                        "#e65100",
                        "#ffd180",
                        "#ffab40",
                        "#ff9100",
                        "#ff6d00"
                    }
                },
                {
                    "deep orange",
                    new List<string>
                    {
                        "#fbe9e7",
                        "#ffccbc",
                        "#ffab91",
                        "#ff8a65",
                        "#ff7043",
                        "#ff5722",
                        "#f4511e",
                        "#e64a19",
                        "#d84315",
                        "#bf360c",
                        "#ff9e80",
                        "#ff6e40",
                        "#ff3d00",
                        "#dd2c00"
                    }
                },
                {
                    "brown",
                    new List<string>
                    {
                        "#efebe9",
                        "#d7ccc8",
                        "#bcaaa4",
                        "#a1887f",
                        "#8d6e63",
                        "#795548",
                        "#6d4c41",
                        "#5d4037",
                        "#4e342e",
                        "#3e2723"
                    }
                },
                {
                    "grey",
                    new List<string>
                    {
                        "#fafafa",
                        "#f5f5f5",
                        "#eeeeee",
                        "#e0e0e0",
                        "#bdbdbd",
                        "#9e9e9e",
                        "#757575",
                        "#616161",
                        "#424242",
                        "#212121"
                    }
                },
                {
                    "blue grey",
                    new List<string>
                    {
                        "#eceff1",
                        "#cfd8dc",
                        "#b0bec5",
                        "#90a4ae",
                        "#78909c",
                        "#607d8b",
                        "#546e7a",
                        "#455a64",
                        "#37474f",
                        "#263238"
                    }
                }
            };
            for (int i = 0; i < colours[tag].Count; i++)
            {
                // Extract RGB values from string and make SolidColorBrush
                byte a = byte.Parse("FF", NumberStyles.HexNumber);
                byte r = byte.Parse(colours[tag][i].Substring(1, 2), NumberStyles.HexNumber);
                byte g = byte.Parse(colours[tag][i].Substring(3, 2), NumberStyles.HexNumber);
                byte b = byte.Parse(colours[tag][i].Substring(5, 2), NumberStyles.HexNumber);
                Color col = Color.FromArgb(a, r, g, b);
                SolidColorBrush brush = new SolidColorBrush(col);

                // Add buttons to StackPanel
                Button colourButton = new Button
                {
                    Content = colours[tag][i],
                    Background = brush,
                    Width = 100
                };
                colourButton.Click += Button_Click;
                ColourPanel.Children.Add(colourButton);
            }
        }
    }
}
