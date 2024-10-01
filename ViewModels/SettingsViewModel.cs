using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Ui.Appearance; // Import the theme manager
using System.Windows; // Import for MessageBox
using Wpf.Ui.Controls;
using System.Windows.Controls;

namespace SWAN.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string appTheme;

        [ObservableProperty]
        private int checkBoxesPerRow;

        [ObservableProperty]
        private string navigationStyle;

        // Constructor to initialize default values
        public SettingsViewModel()
        {
            AppTheme = "Light"; // Default theme
            CheckBoxesPerRow = 2; // Default checkboxes per row
            NavigationStyle = "Left compact"; // Default navigation style
        }

        partial void OnAppThemeChanged(string oldValue, string newValue)
        {   
            ApplyTheme(newValue);
            //save it in the settings here so it persists
        }

        // Method to apply the theme
        public void ApplyTheme(string theme)
        {
            if (theme == "Light")
            {
                ApplicationThemeManager.Apply(
                    ApplicationTheme.Light,        
                    WindowBackdropType.Mica,        
                    true                           
                );
            }
            else if (theme == "Dark")
            {
                ApplicationThemeManager.Apply(
                    ApplicationTheme.Dark,          
                    WindowBackdropType.Mica,        
                    true                          
                );            }
            else if (theme == "High Contrast")
            {
                ApplicationThemeManager.Apply(
                    ApplicationTheme.HighContrast,  
                    WindowBackdropType.Mica,
                    true
                );
            }
            else
            {
                System.Windows.MessageBox.Show("Theme not recognized");
            }
        }
    }
}
