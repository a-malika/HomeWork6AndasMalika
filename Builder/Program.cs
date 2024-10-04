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
            ReportDirector reportDirector = new ReportDirector();

            // Создание отчетов с использованием различных строителей
            Console.WriteLine("Создание HTML отчета:");
            IReportBuilder htmlBuilder = new HtmlReportBuilder();
            reportDirector.ConstructReport(htmlBuilder);
            DisplayReport(htmlBuilder.GetReport());

            Console.WriteLine("\nСоздание текстового отчета:");
            IReportBuilder textBuilder = new TextReportBuilder();
            reportDirector.ConstructReport(textBuilder);
            DisplayReport(textBuilder.GetReport());

            Console.WriteLine("\nСоздание XML отчета:");
            IReportBuilder xmlBuilder = new XmlReportBuilder();
            reportDirector.ConstructReport(xmlBuilder);
            DisplayReport(xmlBuilder.GetReport());
        }
        public static void DisplayReport(Report report)
        {
            Console.WriteLine("\nОтчет:");
            Console.WriteLine($"Заголовок: {report.Header}");
            Console.WriteLine($"Содержание: {report.Content}");
            Console.WriteLine($"Подвал: {report.Footer}");
        }
    }
}
