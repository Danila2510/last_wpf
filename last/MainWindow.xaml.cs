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

namespace last
{
    public partial class MainWindow : Window
    {
        private Color color_text;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ApplyChange(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Start_text.Text, out int start) && int.TryParse(End_text.Text, out int end))
            {
                if (start >= 0 && end <= new TextRange(Text_Box.Document.ContentStart, Text_Box.Document.ContentEnd).Text.Length && start <= end)
                {
                    TextPointer startRange = Text_Box.Document.ContentStart.GetPositionAtOffset(start, LogicalDirection.Forward);
                    TextPointer endRange = Text_Box.Document.ContentStart.GetPositionAtOffset(end, LogicalDirection.Backward);
                    TextRange selectedRange = new TextRange(startRange, endRange);
                    if ((sender as Button).Name == "Bold_font")
                        selectedRange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                    else if ((sender as Button).Name == "Underline_font")
                        selectedRange.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
                    else if ((sender as Button).Name == "Italic_font")
                        selectedRange.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
                    selectedRange.ApplyPropertyValue(TextElement.FontSizeProperty, Convert.ToDouble(((ListBoxItem)FontSize_Box.SelectedItem).Content.ToString()));
                    string selectedItem = ((ListBoxItem)FontColor_Box.SelectedItem).Content.ToString();
                    if  (selectedItem == "Синий")
                        color_text = Colors.Blue;
                    else if (selectedItem == "Фиолетовый")
                        color_text = Colors.Purple;
                    else if (selectedItem == "Зеленый")
                        color_text = Colors.Green;
                    else if (selectedItem == "Красный")
                        color_text = Colors.Red;
                    else
                        color_text = Colors.Black;
                    selectedRange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(color_text));
                }
            }
        }  
        private void ClearChanges(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(Text_Box.Document.ContentStart, Text_Box.Document.ContentEnd);
            range.ClearAllProperties();
        }
    }
}

