using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PalindromosAspNetCore.Models;

namespace PalindromosAspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PalindromosController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet("{cadena}")]
        public async Task<ActionResult<Palindromos>> GetPalindromos(string cadena)
        {
            var contador = 0;
            var nuevaCadena = "";
            //var longitud = cadena.Length;
            //foreach ((char caracter, int index) in cadena)
            //{
            //    Console.WriteLine(caracter);
            //    contador++;
            //    var inverso = caracter.ToString() + cadena[]
            //}

            recorrerCadena(1, cadena);

            //for (int i = 0; i < cadena.Length; i++)
            //{


            //    Console.WriteLine(cadena[i]);
            //    nuevaCadena = nuevaCadena + cadena[i];
            //    Console.WriteLine(nuevaCadena);
            //}

            //for (int i = cadena.Length-1; i > -1; i--)
            //{
            //    Console.WriteLine(cadena[i]);
            //    contador++;
            //}

            return new Palindromos
            {
                PalindromosContenidos = new List<string>() { "cadena" },
                PalindromosTotales = 1
            };
        }

        private string inverso (string cadena)
        {
            char[] arrayChar = cadena.ToCharArray();
            Array.Reverse(arrayChar);
            return new string(arrayChar);
        }

        private void recorrerCadena(int nCaracteres, string cadena)
        {
            var cadenaTemporal = "";
            var arrayNuevo = new List<string>();
            for (int i = 0; i < cadena.Length; i++)
            {
                Console.WriteLine(i);
                if (i+nCaracteres < cadena.Length)
                {
                    cadenaTemporal = "";
                    for (int j = 0; j < nCaracteres+1; j++)
                    {
                        Console.WriteLine(j);
                        cadenaTemporal += cadena[i+j];
                    }
                    //Console.WriteLine(cadena[i].ToString() + cadena[i+nCaracteres].ToString());
                    Console.WriteLine(cadenaTemporal);
                }
                //for (int j = i; j < i + nCaracteres; j++)
                //{
                //    Console.WriteLine(j);
                //    if ((j + nCaracteres) < cadena.Length)
                //    {
                //        Console.WriteLine(cadena[j]);
                //    }
                //}
            }
        }
    }
}
