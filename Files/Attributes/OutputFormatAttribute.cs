using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sion.Useful.Files.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OutputFormatAttribute : Attribute
    {
        public string Format { get; set; }

        public OutputFormatAttribute()
        {
            Format = "";
        }
        public OutputFormatAttribute(string format)
        {
            Format = format;
        }
    }
}
