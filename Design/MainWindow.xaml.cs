using System;
using System.Collections.Generic;
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

namespace Design
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            Color LeftColor = TextBlockGradient.GradientStops[0].Color;

            byte R = Convert.ToByte(LeftColor.R + 40);
            byte G = Convert.ToByte(LeftColor.G + 40);
            byte B = Convert.ToByte(LeftColor.B + 40);

            double LeftColorOffset = e.GetPosition(DesignTextBlock).X / 300 - 0.6;
            double CenterColorOffset = e.GetPosition(DesignTextBlock).X / 300;
            double RightColorOffset = e.GetPosition(DesignTextBlock).X / 300 + 0.6;

            TextBlockGradient.GradientStops[0].Offset = LeftColorOffset;
            GradientStop CenterGradientStop = new GradientStop(Color.FromRgb(R, G, B), CenterColorOffset);
            GradientStop RightGradientStop = new GradientStop(LeftColor, RightColorOffset);

            TextBlockGradient.GradientStops.Add(CenterGradientStop);
            TextBlockGradient.GradientStops.Add(RightGradientStop);
        }

        private void TextBlock_MouseMove(object sender, MouseEventArgs e)
        {
            double LeftColorOffset = e.GetPosition(DesignTextBlock).X / 300 - 0.6;
            double CenterColorOffset = e.GetPosition(DesignTextBlock).X / 300;
            double RightColorOffset = e.GetPosition(DesignTextBlock).X / 300 + 0.6;

            TextBlockGradient.GradientStops[0].Offset = LeftColorOffset;
            TextBlockGradient.GradientStops[1].Offset = CenterColorOffset;
            TextBlockGradient.GradientStops[2].Offset = RightColorOffset;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlockGradient.GradientStops.Remove(TextBlockGradient.GradientStops[2]);
            TextBlockGradient.GradientStops.Remove(TextBlockGradient.GradientStops[1]);
        }
    }
}
