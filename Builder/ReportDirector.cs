using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    public class ReportDirector
    {
        public void ConstructReport(IReportBuilder builder)
        {
            Console.WriteLine("Введите заголовок:");
            builder.SetHeader(Console.ReadLine());
            Console.WriteLine("Введите содержание:");
            builder.SetContent(Console.ReadLine());
            Console.WriteLine("Введите подвал:");
            builder.SetFooter(Console.ReadLine());
        }
    }
}
