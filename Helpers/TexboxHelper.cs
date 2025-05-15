using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Expenser.Helpers
{
    public static class TexboxHelper
    {
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.RegisterAttached("Placeholder", typeof(string), typeof(TexboxHelper), new FrameworkPropertyMetadata(null, OnPlaceholderChanged));

        public static string GetPlaceholder(DependencyObject obj) => (string)obj.GetValue(PlaceholderProperty);
        public static void SetPlaceholder(DependencyObject obj, string value) => obj.SetValue(PlaceholderProperty, value);

        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.GotFocus += (s, _) => RemovePlaceholder(textBox);
                textBox.LostFocus += (s, _) => UpdatePlaceholder(textBox);
                textBox.Loaded += (s, _) => UpdatePlaceholder(textBox);
                //textBox.TextChanged += (s, _) => UpdatePlaceholder(textBox);
            }
        }

        private static void RemovePlaceholder(TextBox textBox)
        {
            if (textBox.Text == GetPlaceholder(textBox))
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private static void UpdatePlaceholder(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = GetPlaceholder(textBox);
                textBox.Foreground = Brushes.Gray;
            }
            else
            {
                textBox.Foreground = Brushes.Black;
            }
        }
    }
}
