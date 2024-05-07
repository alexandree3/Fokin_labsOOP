using System;
using System.Globalization;

namespace zadanie_2
{
    internal class DateEuroStyle : DDateTime
    {
        public string Print()
        {
            return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }
    }
}