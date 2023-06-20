using hw13_1_web_asp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace hw13_1_web_asp.Controllers
{
    [ApiController]
    [Route("ratio")]
    public class RatioController
    {
        [HttpGet]
        [Route("solve")]
        public double[] Get(int a, int b, int c)
        {
            var equation = new Equation(a, b, c);
            return equation.SolveEquation();
        }

        [HttpPost]
        [Route("solve-from-body")]
        public double[] Post([FromBody] Equation arguments)
        {
            var equation = new Equation(arguments.A, arguments.B, arguments.C);
            return equation.SolveEquation();
        }
    }
}