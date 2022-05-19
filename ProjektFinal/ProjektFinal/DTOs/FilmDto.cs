using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektFinal.DTOs
{
    public class FilmDto
    {
        
        public string FilmName { get; set; }
        public int Earnings { get; set; }
        public int YearOfProduction { get; set; }
        


    }
}
