using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "settings.txt";

            Thread thread1 = new Thread(() => RunConfigurationManager("Thread 1", filePath));
            Thread thread2 = new Thread(() => RunConfigurationManager("Thread 2", filePath));
            Thread thread3 = new Thread(() => RunConfigurationManager("Thread 3", filePath));

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine("\nВсе потоки завершены.");
        }
        static void RunConfigurationManager(string threadName, string filePath)
        {
            ConfigurationManager configManager = ConfigurationManager.GetInstance();
            configManager.LoadSettings(filePath);
            Console.WriteLine($"{threadName}: Настройки успешно загружены.");

            configManager.SetSetting("color", threadName == "Thread 1" ? "red" : "blue");
            configManager.SetSetting("fontsize", "16");
            configManager.SetSetting("fontstyle", "Arial");

            Console.WriteLine($"\n{threadName}: Добавлены новые настройки.");
            configManager.ReadSettings(threadName);

            configManager.SaveSettings(filePath);
            Console.WriteLine($"\n{threadName}: Настройки успешно сохранены в файл: {filePath}");
            string value = configManager.GetSetting("color");
            Console.WriteLine($"\n{threadName}: Получено значение настройки 'color': {value}");
        }
    }
}
