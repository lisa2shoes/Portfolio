using System.Security.Cryptography.Xml;

namespace hw13_1_web_asp
{
    public class Equation
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public Equation(int a, int b, int c)
        {
            if (a == 0)
            {
                throw new ArgumentException("Коэффициент а не может быть равен нулю.");
            }

            A = a;
            B = b;
            C = c;
        }
        public double[] SolveEquation()
        {
            var d = Math.Pow(B, 2) - 4 * A * C;

            if (d < 0)
            {
                return Array.Empty<double>();
            }

            else
            {
                var x1 = (-1 * B + Math.Pow(d, 0.5)) / 2 * A;
                var x2 = (-1 * B - Math.Pow(d, 0.5)) / 2 * A;

                if (x1 != x2)
                {
                    return new[] { x1, x2 };
                }

                else
                {
                    return new[] { x1 };
                }
            }
        }
    }
}
