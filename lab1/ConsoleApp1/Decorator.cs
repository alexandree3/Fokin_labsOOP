
using System;

namespace zadanie_2
{
    internal abstract class Decorator : DDateTime
    {
        protected DDateTime _datetime;
        public Decorator(DDateTime datetime)
        {
            _datetime = datetime;
        }
        public abstract string Print();
    }
}