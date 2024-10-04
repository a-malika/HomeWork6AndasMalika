using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    public class Discount : IClonable<Discount>
    {
        public string Reason { get; set; }
        public int Percentage { get; set; }
        public Discount() { }
        public Discount(string reason, int percentage)
        {
            Reason = reason;
            Percentage = percentage;
        }
        public Discount Clone()
        {
            return new Discount(Reason, Percentage);
        }
    }
}
