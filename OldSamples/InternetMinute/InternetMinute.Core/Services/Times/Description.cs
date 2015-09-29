using System;
using System.Linq;
using System.Text;

namespace InternetMinute.Core.Services.Times
{
    public class Description
    {
        public Description(string name, string logoUrl, double perMinute)
        {
            LogoUrl = logoUrl;
            PerMinute = perMinute;
            Name = name;
        }

        public string Name { get; private set; }
        public string LogoUrl { get; private set; }
        public double PerMinute { get; private set; }
    }
}
