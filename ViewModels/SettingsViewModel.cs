using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Ui.Appearance; // Import the theme manager
using System.Windows; // Import for MessageBox
using Wpf.Ui.Controls;
using System.Windows.Controls;
using SWAN.Components;
using System.IO;
using CommunityToolkit.Mvvm.Messaging;
using SWAN.Services;

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

        private IMessenger _messenger;

        private SettingsManager _settingsManager = new SettingsManager();

        // Constructor to initialize default values
        public SettingsViewModel(IMessenger messenger)
        {
            _messenger = messenger;
            LoadSettings(); // Load persisted settings
        }

        // Method to load settings from JSON file
        private void LoadSettings()
        {
            var settings = _settingsManager.LoadSettings(); // Load settings from the manager
            if (settings != null)
            {
                AppTheme = settings.Theme; 
                CheckBoxesPerRow = settings.CheckboxWidth; 
                NavigationStyle = settings.NavigationStyle; 
            }
            else
            {
                // Default settings if no file exists or it couldn't be loaded
                AppTheme = "Light";
                CheckBoxesPerRow = 3;
                NavigationStyle = "Left compact";
            }

        }

        partial void OnAppThemeChanged(string oldValue, string newValue)
        {   
            ApplyTheme(newValue);
            //save it in the settings here so it persists
        }

        partial void OnCheckBoxesPerRowChanged(int value)
        {
            SaveSettings();
            //use messenger here to update the width in the rmf dashboard viewmodel
            _messenger.Send(new WidthUpdatedMessage(value));
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
            SaveSettings();
        }

        private AppSettings CreateAppSettings()
        {
            return new AppSettings
            {
                Theme = AppTheme,
                CheckboxWidth = CheckBoxesPerRow,
                NavigationStyle = NavigationStyle,
            };
        }

        private void SaveSettings()
        {
            var settings = CreateAppSettings();
            _settingsManager.SaveSettings(settings);
        }
    }
}
