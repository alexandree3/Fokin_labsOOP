namespace zadanie_1
{
    public class Rational
    {
        private int _numerator;
        private int _denominator;
        public Rational(int Numenator, int Denominator)
        {
            _numerator = Numenator;
            _denominator = Denominator;
            if (_denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            if (_denominator < 0)
            {
                _numerator *= -1;
                _denominator *= -1;
            }
            int gcd = GCD(Math.Abs(_numerator), Math.Abs(_denominator));
            _numerator = _numerator / gcd;
            _denominator = _denominator / gcd;
        }
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public override string ToString()
        {
            if (_denominator == _numerator)
            {
                return "1";
            }
            else if (_denominator == 1)
            {
                return $"{_numerator}";
            }
            else
            {
                return $"{_numerator}/{_denominator}";
            }
        }

        public static Rational operator +(Rational A, Rational B)
        {
            if (A._denominator != B._denominator)
            {
                int x = A._denominator, y = B._denominator;
                B._numerator *= x; B._denominator *= x;
                A._numerator *= y; A._denominator *= y;
            }
            return new Rational(A._numerator + B._numerator, A._denominator);
        }
        public static Rational operator -(Rational A, Rational B)
        {
            if (A._denominator != B._denominator)
            {
                int x = A._denominator, y = B._denominator;
                B._numerator *= x; B._denominator *= x;
                A._numerator *= y; A._denominator *= y;
            }
            return new Rational(A._numerator - B._numerator, A._denominator);
        }
        public static Rational operator *(Rational A, Rational B)
        {
            return new Rational(A._numerator * B._numerator, A._denominator * B._denominator); ;
        }
        public static Rational operator /(Rational A, Rational B)
        {
            return new Rational(A._numerator * B._denominator, A._denominator * B._numerator);
        }
        public static Rational operator -(Rational A)
        {
            return new Rational(-A._numerator, A._denominator);
        }
        public static bool operator ==(Rational A, Rational B)
        {
            return (Convert.ToDouble(A._numerator) / A._denominator) == (Convert.ToDouble(B._numerator) / B._denominator);
        }
        public static bool operator !=(Rational A, Rational B)
        {
            return (Convert.ToDouble(A._numerator) / A._denominator) != (Convert.ToDouble(B._numerator) / B._denominator);
        }
        public static bool operator <(Rational A, Rational B)
        {
            return (Convert.ToDouble(A._numerator) / A._denominator) < (Convert.ToDouble(B._numerator) / B._denominator);
        }
        public static bool operator >(Rational A, Rational B)
        {
            return (Convert.ToDouble(A._numerator) / A._denominator) > (Convert.ToDouble(B._numerator) / B._denominator);
        }
        public static bool operator <=(Rational A, Rational B)
        {
            return (Convert.ToDouble(A._numerator) / A._denominator) <= (Convert.ToDouble(B._numerator) / B._denominator);
        }
        public static bool operator >=(Rational A, Rational B)
        {
            return (Convert.ToDouble(A._numerator) / A._denominator) >= (Convert.ToDouble(B._numerator) / B._denominator);
        }
    }
}