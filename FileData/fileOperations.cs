using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SWAN.FileData
{
    public static class FileOperations
    {
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T t)
                    {
                        yield return t;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static void SaveStateToCsv(DependencyObject parent)
        {
            var sb = new StringBuilder();
            //first append the name of the specific RMF maybe to check which out of 4
            // sb.AppendLine("TerryRMF");
            sb.AppendLine("Name,IsChecked");

            foreach (CheckBox checkBox in FindVisualChildren<CheckBox>(parent))
            {
                sb.AppendLine($"{checkBox.Name},{checkBox.IsChecked}");
            }

            // this part might have to get moved and return the file if the save file button handles saving files
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "checkBoxState.csv");
            File.WriteAllText(filePath, sb.ToString());
        }

        public static void LoadStateFromCsv(DependencyObject parent)
        {
            // this might change to be handled by the choose file button/initialization
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "checkBoxState.csv");

            if (!File.Exists(filePath))
                return;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1)) // Skip header line
            {
                var parts = line.Split(',');
                var checkBoxName = parts[0];
                var isChecked = bool.Parse(parts[1]);

                var checkBox = FindVisualChildren<CheckBox>(parent)
                                  .FirstOrDefault(c => c.Name == checkBoxName);
                if (checkBox != null)
                {
                    checkBox.IsChecked = isChecked;
                }
            }
        }
    }
}
