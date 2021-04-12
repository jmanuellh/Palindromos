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
        List<string> palindromosContenidos;
        int palindromosTotales;

        public PalindromosController()
        {
            palindromosContenidos = new List<string>();
            palindromosTotales = 0;
        }

        [HttpGet("{cadena}")]
        public async Task<ActionResult<Palindromos>> GetPalindromos(string cadena)
        {
            for (int i = 0; i < cadena.Length; i++)
            {
                recorrerCadena(i, cadena);            
            }

            return new Palindromos
            {
                PalindromosContenidos = palindromosContenidos,
                PalindromosTotales = palindromosTotales
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
            for (int i = 0; i < cadena.Length; i++)
            {
                if (i+nCaracteres < cadena.Length)
                {
                    var cadenaTemporal = "";
                    for (int j = 0; j < nCaracteres+1; j++)
                    {
                        cadenaTemporal += cadena[i+j];
                    }
                    if (compararConInverso(cadenaTemporal)) {
                        palindromosContenidos.Add(cadenaTemporal);
                        palindromosTotales++;
                    }
                }
            }
        }
        private bool compararConInverso(string cadenaTemporal)
        {
            return cadenaTemporal == inverso(cadenaTemporal);
        }
    }
}
