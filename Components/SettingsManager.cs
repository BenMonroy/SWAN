using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAN.Components
{
    public class SettingsManager
    {
        private readonly string _filePath;

        public SettingsManager()
        {
            // Check for directory and create it if it doesn't exist
            var appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SWAN");
            if (!Directory.Exists(appDataFolder))
            {
                Directory.CreateDirectory(appDataFolder);
            }
            _filePath = Path.Combine(appDataFolder, "settings.json");

            // Ensure the file exists
            if (!File.Exists(_filePath))
            {
                SaveSettings(new AppSettings()); // Save default settings if the file doesn't exist
            }
        }

        public AppSettings LoadSettings()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new AppSettings();
                }

                var json = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<AppSettings>(json) ?? new AppSettings();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error loading settings: {ex.Message}");
                return new AppSettings();
            }
        }

        public void SaveSettings(AppSettings settings)
        {
            try
            {
                var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error saving settings: {ex.Message}");
            }
        }
    }

    public class AppSettings
    {
        public string Theme { get; set; } = "Light"; // Default to light theme
        public int CheckboxWidth { get; set; } = 3;  // Default width of checkboxes
    }

}
