using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw13_1_asp
{
    public class Program
    {
        public static void Main(string[] args) // � ���� ������ �� �������, �� ��� �����, �������� �� � ���� ������ �� ��� �����������, ��� ������ ������ 
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>  
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        public class Ratio
        {
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }

            public void SolveEquation(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;

                if (a == 0)
                {
                    Console.WriteLine("����������� a �� ����� ��������� ����.");
                    return;
                }

                var d = Math.Pow(b, 2) - 4 * a * c;

                if (d < 0)
                {
                    Console.WriteLine("������ ���.");
                }

                else
                {
                    var x1 = (-1 * b + Math.Pow(d, 0.5)) / 2 * a;
                    var x2 = (-1 * b - Math.Pow(d, 0.5)) / 2 * a;

                    if (x1 != x2)
                    {
                        Console.WriteLine($"����� ���������: {x1}, {x2}");
                    }

                    else
                    {
                        Console.WriteLine($"������ ��������� ����: {x1}");
                    }
                }
            }
        }
    }
}
