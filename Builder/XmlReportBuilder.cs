using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    public class XmlReportBuilder : IReportBuilder
    {
        private Report report = new Report();
        public void SetHeader(string header)
        {
            report.Header = $"<header>{header}</header>";
        }
        public void SetContent(string content)
        {
            report.Content = $"<content>{content}</content>";
        }
        public void SetFooter(string footer)
        {
            report.Footer = $"<footer>{footer}</footer>";
        }
        public Report GetReport()
        {
            return report;
        }
    }
}
