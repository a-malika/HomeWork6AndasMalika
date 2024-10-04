using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    public class ConfigurationManager
    {
        private static ConfigurationManager instance;
        private static readonly object instancelock = new object();
        private Dictionary<string, string> settings;
        private ConfigurationManager()
        {
            settings = new Dictionary<string, string>();
        }
        public static ConfigurationManager GetInstance()
        {
            if (instance == null)
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new ConfigurationManager();
                    }
                }
            }
            return instance;
        }
        public void LoadSettings(string filePath)
        {
            try
            {
                lock(instancelock)
                {
                    if (!File.Exists(filePath))
                    {
                        throw new FileNotFoundException("Файл настроек не найден.", filePath);
                    }
                    settings.Clear();
                    foreach (string line in File.ReadAllLines(filePath))
                    {
                        string[] parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            settings[parts[0].Trim()] = parts[1].Trim();
                        }
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void SaveSettings(string filePath)
        {
            try
            {
                lock (instancelock)
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (KeyValuePair<string, string> kvp in settings)
                        {
                            writer.WriteLine($"{kvp.Key}={kvp.Value}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public string GetSetting(string key)
        {
            try
            {
                if (settings.TryGetValue(key, out var value))
                {
                    return value;
                }
                throw new KeyNotFoundException($"Настройка '{key}' не найдена.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }
        public void ReadSettings(string threadName)
        {
            lock(instancelock)
            {
                Console.WriteLine($"\n{threadName}: Читаем настройки.");
                foreach (KeyValuePair<string, string> kvp in settings)
                {
                    Console.WriteLine($"{kvp.Key}={kvp.Value}");
                }
            }
        }
        public void SetSetting(string key, string value)
        {
            settings[key] = value;
        }
    }
}
