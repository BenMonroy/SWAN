using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SWAN.Components
{
    public class RecentFilesManager
    {
        private readonly string _filePath;

        public RecentFilesManager()
        {
            // Check for directory and create it if it doesn't exist
            var appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SWAN");
            if (!Directory.Exists(appDataFolder))
            {
                Directory.CreateDirectory(appDataFolder);
            }
            _filePath = Path.Combine(appDataFolder, "recentFiles.json");

            // Ensure the file exists
            if (!File.Exists(_filePath))
            {
                SaveRecentFiles(new List<RecentFile>());
            }
        }

        public List<RecentFile> LoadRecentFiles()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<RecentFile>();
                }

                var json = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<List<RecentFile>>(json) ?? new List<RecentFile>();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error loading recent files: {ex.Message}");
                return new List<RecentFile>();
            }
        }

        public void SaveRecentFiles(List<RecentFile> recentFiles)
        {
            try
            {
                var json = JsonConvert.SerializeObject(recentFiles, Formatting.Indented);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error saving recent files: {ex.Message}");
            }
        }

        public void AddRecentFile(RecentFile newFile)
        {
            try
            {
                var recentFiles = LoadRecentFiles();

                // Remove any existing entries for the same file path
                recentFiles = recentFiles.Where(file => file.FilePath != newFile.FilePath).ToList();

                // Add the new file to the beginning of the list
                recentFiles.Insert(0, newFile);

                // Save the updated list
                SaveRecentFiles(recentFiles);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error adding recent file: {ex.Message}");
            }
        }

        public void RemoveRecentFile(string filePath)
        {
            try
            {
                var recentFiles = LoadRecentFiles();
                var updatedList = recentFiles.Where(file => file.FilePath != filePath).ToList();
                SaveRecentFiles(updatedList);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error removing recent file: {ex.Message}");
            }
        }
    }

    public class RecentFile
    {
        public required string FilePath { get; set; } //used to open the file
        public required string Name { get; set; } // Display name of the file
        public required string RmfType { get; set; } // RMF type associated with the file
        public required DateTime LastOpened { get; set; } //shows when modified last
    }
}
